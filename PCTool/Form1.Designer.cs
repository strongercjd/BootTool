namespace PCTool
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_startmake = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tB_vision = new System.Windows.Forms.TextBox();
            this.cB_PCBvision = new System.Windows.Forms.ComboBox();
            this.cB_type = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_out = new System.Windows.Forms.Button();
            this.bt_open = new System.Windows.Forms.Button();
            this.tB_outpath = new System.Windows.Forms.TextBox();
            this.tB_binpath = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(26, 448);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(281, 151);
            this.textBox1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_startmake);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tB_vision);
            this.groupBox1.Controls.Add(this.cB_PCBvision);
            this.groupBox1.Controls.Add(this.cB_type);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bt_out);
            this.groupBox1.Controls.Add(this.bt_open);
            this.groupBox1.Controls.Add(this.tB_outpath);
            this.groupBox1.Controls.Add(this.tB_binpath);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 224);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "生成REL";
            // 
            // bt_startmake
            // 
            this.bt_startmake.Location = new System.Drawing.Point(16, 177);
            this.bt_startmake.Name = "bt_startmake";
            this.bt_startmake.Size = new System.Drawing.Size(257, 34);
            this.bt_startmake.TabIndex = 12;
            this.bt_startmake.Text = "开始生成";
            this.bt_startmake.UseVisualStyleBackColor = true;
            this.bt_startmake.Click += new System.EventHandler(this.bt_startmake_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(196, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "硬件版本";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(95, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "主版本";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "型号";
            // 
            // tB_vision
            // 
            this.tB_vision.Location = new System.Drawing.Point(95, 142);
            this.tB_vision.Name = "tB_vision";
            this.tB_vision.ReadOnly = true;
            this.tB_vision.Size = new System.Drawing.Size(71, 21);
            this.tB_vision.TabIndex = 8;
            // 
            // cB_PCBvision
            // 
            this.cB_PCBvision.FormattingEnabled = true;
            this.cB_PCBvision.Location = new System.Drawing.Point(196, 142);
            this.cB_PCBvision.Name = "cB_PCBvision";
            this.cB_PCBvision.Size = new System.Drawing.Size(58, 20);
            this.cB_PCBvision.TabIndex = 7;
            // 
            // cB_type
            // 
            this.cB_type.FormattingEnabled = true;
            this.cB_type.Location = new System.Drawing.Point(14, 142);
            this.cB_type.Name = "cB_type";
            this.cB_type.Size = new System.Drawing.Size(64, 20);
            this.cB_type.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "REL文件";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "bin文件";
            // 
            // bt_out
            // 
            this.bt_out.Location = new System.Drawing.Point(220, 87);
            this.bt_out.Name = "bt_out";
            this.bt_out.Size = new System.Drawing.Size(53, 23);
            this.bt_out.TabIndex = 3;
            this.bt_out.Text = "输出";
            this.bt_out.UseVisualStyleBackColor = true;
            this.bt_out.Click += new System.EventHandler(this.bt_out_Click);
            // 
            // bt_open
            // 
            this.bt_open.Location = new System.Drawing.Point(220, 37);
            this.bt_open.Name = "bt_open";
            this.bt_open.Size = new System.Drawing.Size(53, 23);
            this.bt_open.TabIndex = 2;
            this.bt_open.Text = "打开";
            this.bt_open.UseVisualStyleBackColor = true;
            this.bt_open.Click += new System.EventHandler(this.bt_open_Click);
            // 
            // tB_outpath
            // 
            this.tB_outpath.Location = new System.Drawing.Point(14, 89);
            this.tB_outpath.Name = "tB_outpath";
            this.tB_outpath.ReadOnly = true;
            this.tB_outpath.Size = new System.Drawing.Size(197, 21);
            this.tB_outpath.TabIndex = 1;
            // 
            // tB_binpath
            // 
            this.tB_binpath.Location = new System.Drawing.Point(14, 39);
            this.tB_binpath.Name = "tB_binpath";
            this.tB_binpath.ReadOnly = true;
            this.tB_binpath.Size = new System.Drawing.Size(197, 21);
            this.tB_binpath.TabIndex = 0;
            this.tB_binpath.Text = "打开bin文件";
            this.tB_binpath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "仰邦bin文件(*.bin)|*.bin";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "升级固件(*.REL)|*.REL";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 611);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "生产工具";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_startmake;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tB_vision;
        private System.Windows.Forms.ComboBox cB_PCBvision;
        private System.Windows.Forms.ComboBox cB_type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_out;
        private System.Windows.Forms.Button bt_open;
        private System.Windows.Forms.TextBox tB_outpath;
        private System.Windows.Forms.TextBox tB_binpath;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

