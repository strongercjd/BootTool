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

namespace PCTool
{
    public partial class Form1 : Form
    {
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
    }
}
