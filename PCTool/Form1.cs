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

namespace PCTool
{
    public partial class Form1 : Form
    {
        String BinPath = "";
        String RELPath = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num;
            string str = string.Empty;
            AESDLL.AesEncInit();
            byte[] bufferIn = new byte[16] {0X00, 0X11, 0X22, 0X33, 0X44, 0X55, 0X66, 0X77, 0X88, 0X99, 0XAA, 0XBB, 0XCC, 0XDD, 0XEE, 0XFF };
            textBox1.Text = "明文是：";
            textBox1.Text += "\r\n";
            for (num = 0; num < bufferIn.Length; num++)
            {
                str = Convert.ToString(bufferIn[num], 16);
                textBox1.Text += "0X" + str + " ";
            }

            AESDLL.AesEncrypt(ref bufferIn[0]);

            textBox1.Text += "\r\n";
            textBox1.Text += "\r\n";
            textBox1.Text += "加密后密文是：";
            textBox1.Text += "\r\n";
            for (num = 0;num< bufferIn.Length; num++)
            {
                str = Convert.ToString(bufferIn[num], 16);
                textBox1.Text += "0X"+str + " ";
            }

            AESDLL.AesDecrypt(ref bufferIn[0]);

            textBox1.Text += "\r\n";
            textBox1.Text += "\r\n";
            textBox1.Text += "解密后明文是：";
            textBox1.Text += "\r\n";
            for (num = 0; num < bufferIn.Length; num++)
            {
                str = Convert.ToString(bufferIn[num], 16);
                textBox1.Text += "0X" + str + " ";
            }

        }

        private void bt_open_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    BinPath = dialog.FileName;
                    tB_binpath.Text = dialog.SafeFileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bt_out_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    RELPath = saveFileDialog.FileName;
                    tB_outpath.Text = RELPath;
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
            try
            {
                if (BinPath == "")//如果路径是空的
                {
                    MessageBox.Show("请选择需要转换的目标文件!         ", "错误");
                    return;
                }


                FileStream fs_read = new FileStream(BinPath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs_read);
                file_len = (int)fs_read.Length;//获取bin文件长度

                if (file_len < (1024*1024))
                {
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
                            bufferEnc[i * 16 + j] = buffer[j];
                        }
                    }


                    if (RELPath == "")
                    {
                        RELPath = Path.ChangeExtension(BinPath, "Bin");
                        tB_outpath.Text = RELPath;
                    }
                    FileStream fBin = new FileStream(RELPath, FileMode.Create); //创建文件BIN文件
                    BinaryWriter BinWrite = new BinaryWriter(fBin); //二进制方式打开文件
                                                                    // 数据写入文件

                    BinWrite.Write(bufferEnc, 0, bufferEnc.Length); //写入数据
                    //BinWrite.Write(bufferEnc, 0, file_len); //写入数据

                    BinWrite.Flush();//释放缓存
                    BinWrite.Close();//关闭文件

                    MessageBox.Show("文件转换完成!        ", "提示");
                }
                else {
                    MessageBox.Show("文件大于1M!        ", "错误");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
