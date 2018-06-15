using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Drawing.Imaging;

namespace PCTool
{
    public partial class Form1 : Form
    {
        String BinPath = "";
        String RELPath = "";

        byte deicve_type;
        byte PCBversion;
        

        //24字节                    /*上海仰邦科技股份有限公司*/
        byte[] company = new byte[] { 0XC9, 0XCF, 0XBA, 0XA3, 0XD1, 0XF6, 0XB0, 0XEE, 0XBF, 0XC6, 0XBC, 0XBC, 0XB9, 0XC9, 0XB7, 0XDD, 0XD3, 0XD0, 0XCF, 0XDE, 0XB9, 0XAB, 0XCB, 0XBE
                                      /*onbonbx.com*/
                                     ,0x6F,0x6E,0x62,0x6F,0x6E,0x62,0x78,0x2E,0x63,0x6F,0x6D};

        public Form1()
        {
            InitializeComponent();
        }

        private void bt_open_Click(object sender, EventArgs e)
        {
            try
            {
                //OpenFileDialog dialog = new OpenFileDialog();
                //openFileDialog.FileName = "1";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    BinPath = openFileDialog.FileName;
                    tB_binpath.ForeColor = Color.Black;
                    tB_binpath.Text = openFileDialog.SafeFileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void bt_startmake_Click(object sender, EventArgs e)
        {
            Byte[] data = new byte[1024*1024];
            Byte[] bufferEnc = new byte[1024*1024];
            Int32 file_len;
            Int32 save_file_len;

            if (BinPath == "")//如果路径是空的
            {
                MessageBox.Show("请选择需要转换的目标文件!         ", "错误");
                return;
            }

            try
            {
                this.saveFileDialog.FileName = cB_type.Text+"-"+ tB_vision.Text+ "-" + cB_PCBvision.Text;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    RELPath = saveFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            try
            {
                FileStream fs_read = new FileStream(BinPath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs_read);
                file_len = (int)fs_read.Length;//获取bin文件长度

                if (file_len < (1024 * 1024))
                {
                    bt_open.Enabled = false;
                    cB_type.Enabled = false;
                    tB_vision.Enabled = false;
                    cB_PCBvision.Enabled = false;

                    br.BaseStream.Seek(0, SeekOrigin.Begin);
                    for (int num = 0; num < file_len; num++)
                    {
                        data[num] = br.ReadByte();
                    }
                    br.Close();
                    fs_read.Close();


                    uint i;
                    uint j = 0;

                    //// 创建加密缓存及加密处理
                    byte[] buffer = new byte[16];


                    AESDLL.AesEncInit();

                    //128个字节的公司信息
                    for (j = 0; j < company.Length; j++)
                    {
                        bufferEnc[j] = company[j];
                    }
                    //32个字节版本信息，1字节型号，8个字节主型号，1个字节PCB版本
                    byte[] vision = System.Text.Encoding.Default.GetBytes(tB_vision.Text);
                    bufferEnc[128] = deicve_type;
                    for (j = 0; j < vision.Length; j++)
                    {
                        bufferEnc[129+j] = vision[j];
                    }
                    bufferEnc[129+ vision.Length] = PCBversion;



                    for (i = 0; i < (file_len / 16 + 1); i++)
                    {
                        for (j = 0; j < 16; j++)
                        {
                            buffer[j] = 0;
                        }
                        for (j = 0; j < 16; j++)
                        {
                            buffer[j] = data[i * 16 + j];
                        }
                        AESDLL.AesDecrypt(ref buffer[0]);
                        for (j = 0; j < 16; j++)
                        {
                            bufferEnc[i * 16 + j+128+32] = buffer[j];
                        }
                    }


                    if (RELPath == "")
                    {
                        RELPath = Path.ChangeExtension(BinPath, "Bin");
                    }
                    FileStream fBin = new FileStream(RELPath, FileMode.Create); //创建文件BIN文件
                    BinaryWriter BinWrite = new BinaryWriter(fBin); //二进制方式打开文件
                                                                    // 数据写入文件

                    //BinWrite.Write(bufferEnc, 0, bufferEnc.Length); //写入数据
                    save_file_len = 128 + 32 + (file_len / 16 + 1) * 16;
                    BinWrite.Write(bufferEnc, 0, save_file_len); //写入数据

                    BinWrite.Flush();//释放缓存
                    BinWrite.Close();//关闭文件


                    bt_open.Enabled = true;
                    cB_type.Enabled = true;
                    tB_vision.Enabled = true;
                    cB_PCBvision.Enabled = true;


                    MessageBox.Show("文件转换完成!        ", "提示");
                }
                else
                {
                    MessageBox.Show("文件大于1M!        ", "错误");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        string xmlPath = System.Environment.CurrentDirectory + "\\config.xml";
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                AESDLL.AesEncInit();
            }
            catch
            {
                MessageBox.Show("缺少AESDLL.dll文件!        ", "提示");
                Application.Exit();
            }
            if (File.Exists(xmlPath))
            {
                XmlDocument doc = new XmlDocument();
                //加载根目录下XML文件
                doc.Load(xmlPath);
                //获取根节点
                XmlElement root = doc.DocumentElement;
                //获取<controller>子节点 
                XmlNodeList controllerNodes = root.GetElementsByTagName("controller");

                //使用foreach循环读出集合
                foreach (XmlNode node in controllerNodes)
                {
                    ////string controller_name = ((XmlElement)node).GetElementsByTagName("controller_name")[0].InnerText;
                    string controller_name = ((XmlElement)node).GetAttribute("name");
                    cB_type.Items.Add(controller_name);
                }
                cB_type.SelectedIndex = 0;
                doc.Save(xmlPath);

                //tSt = str.Substring(str.Length - i);
                string strtime = DateTime.Now.Year.ToString();
                tB_vision.Text = strtime.Substring(strtime.Length - 2);

                if (DateTime.Now.Month < 10)
                    tB_vision.Text += "0" + DateTime.Now.Month.ToString();
                else
                    tB_vision.Text += DateTime.Now.Month.ToString();

                if (DateTime.Now.Hour < 10)
                    tB_vision.Text += "0" + DateTime.Now.Hour.ToString();
                else
                    tB_vision.Text += DateTime.Now.Hour.ToString();
                if (DateTime.Now.Minute < 10)
                    tB_vision.Text += "0" + DateTime.Now.Minute.ToString();
                else
                    tB_vision.Text += DateTime.Now.Minute.ToString();
            }
            else
            {
                MessageBox.Show("没有XML配置文件        ", "错误");
                Application.Exit();
            }
        }

        private void cB_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            cB_PCBvision.Items.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            ////获取根节点
            XmlElement root = doc.DocumentElement;
            ////获取root下<controller>子节点 
            //XmlNodeList controllerlist = root.GetElementsByTagName("controller");
            ///获取root下所有子节点
            XmlNodeList rootlist = root.ChildNodes;
            if (rootlist != null)
            {
                foreach (XmlNode controllerNode in rootlist)
                {
                    if (controllerNode.Name == "controller")
                    {
                        string controller_name = ((XmlElement)controllerNode).GetAttribute("name");
                        if (controller_name == cB_type.Text)
                        {
                            string controller_type_value = ((XmlElement)controllerNode).GetElementsByTagName("type_value")[0].InnerText;
                            controller_type_value = controller_type_value.Remove(0, 2);//去掉前两个字符
                            deicve_type = Convert.ToByte(controller_type_value, 16);
                          
                            XmlNodeList PCBvisionList = controllerNode.ChildNodes;
                            if (PCBvisionList != null)
                            {
                                foreach (XmlNode PCBvisionnode in PCBvisionList)
                                {
                                    if (PCBvisionnode.Name == "PCBvision")
                                    {
                                        string PCBvision_name = ((XmlElement)PCBvisionnode).GetAttribute("name");
                                        cB_PCBvision.Items.Add(PCBvision_name);
                                    }
                                }
                                cB_PCBvision.SelectedIndex = 0;
                            }
                        }
                    }  
                }
            }
        }

        private void cB_PCBvision_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num;
            num = 0;
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            ////获取根节点
            XmlElement root = doc.DocumentElement;
            ////获取root下<controller>子节点 
            //XmlNodeList controllerlist = root.GetElementsByTagName("controller");
            ///获取root下所有子节点
            XmlNodeList rootlist = root.ChildNodes;
            if (rootlist != null)
            {
                foreach (XmlNode controllerNode in rootlist)
                {
                    if (controllerNode.Name == "controller")
                    {
                        string controller_name = ((XmlElement)controllerNode).GetAttribute("name");
                        if (controller_name == cB_type.Text)
                        {
                            XmlNodeList PCBvisionList = controllerNode.ChildNodes;
                            if (PCBvisionList != null)
                            {
                                foreach (XmlNode PCBvisionnode in PCBvisionList)
                                {
                                    if (PCBvisionnode.Name == "PCBvision")
                                    {
                                        num++;
                                        string PCBvision_name = ((XmlElement)PCBvisionnode).GetAttribute("name");
                                        if (PCBvision_name == cB_PCBvision.Text)
                                        {
                                            num--;
                                            string PCBvision_value = ((XmlElement)controllerNode).GetElementsByTagName("PCBvision")[num].InnerText;
                                            PCBvision_value = PCBvision_value.Remove(0, 2);//去掉前两个字符
                                            PCBversion = Convert.ToByte(PCBvision_value, 16);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        string timenum;
        private void timer_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now.Minute.ToString()) != timenum)
            {
                timenum = DateTime.Now.Minute.ToString();

                string strtime = DateTime.Now.Year.ToString();
                tB_vision.Text = strtime.Substring(strtime.Length - 2);

                if (DateTime.Now.Month < 10)
                    tB_vision.Text += "0" + DateTime.Now.Month.ToString();
                else
                    tB_vision.Text += DateTime.Now.Month.ToString();

                if (DateTime.Now.Hour < 10)
                    tB_vision.Text += "0" + DateTime.Now.Hour.ToString();
                else
                    tB_vision.Text += DateTime.Now.Hour.ToString();
                if (DateTime.Now.Minute < 10)
                    tB_vision.Text += "0" + DateTime.Now.Minute.ToString();
                else
                    tB_vision.Text += DateTime.Now.Minute.ToString();
            }
        }
    }
}

