namespace Test_Automation
{
    partial class Form_CA410
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CA410));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.txtreceived = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.cmbStopBits = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnsend = new System.Windows.Forms.Button();
            this.txtsend = new System.Windows.Forms.TextBox();
            this.btn_port_open = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDataBits = new System.Windows.Forms.TextBox();
            this.cmbBaudRate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.com_CA410 = new System.IO.Ports.SerialPort(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(782, 449);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 26);
            this.button1.TabIndex = 45;
            this.button1.Text = "全自动发送";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(811, 410);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 24);
            this.button2.TabIndex = 44;
            this.button2.Text = "清除";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "COM,1",
            "MDS,0",
            "MCH,1",
            "ZRC",
            "MES,1"});
            this.comboBox1.Location = new System.Drawing.Point(649, 417);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(118, 20);
            this.comboBox1.TabIndex = 43;
            this.comboBox1.Text = "COM,1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(346, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(5, 24);
            this.label8.TabIndex = 42;
            this.label8.Text = "\r\n\r\n";
            // 
            // cmbPortName
            // 
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Location = new System.Drawing.Point(403, 113);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(52, 20);
            this.cmbPortName.TabIndex = 40;
            // 
            // txtreceived
            // 
            this.txtreceived.Location = new System.Drawing.Point(358, 302);
            this.txtreceived.Multiline = true;
            this.txtreceived.Name = "txtreceived";
            this.txtreceived.Size = new System.Drawing.Size(511, 101);
            this.txtreceived.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(360, 287);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 38;
            this.label7.Text = "接收到的数据";
            // 
            // cmbParity
            // 
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.cmbParity.Location = new System.Drawing.Point(416, 214);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(88, 20);
            this.cmbParity.TabIndex = 37;
            this.cmbParity.Text = "None";
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.Location = new System.Drawing.Point(481, 178);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(24, 21);
            this.cmbStopBits.TabIndex = 36;
            this.cmbStopBits.Text = "2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(428, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 35;
            this.label6.Text = "停止位：";
            // 
            // btnsend
            // 
            this.btnsend.Location = new System.Drawing.Point(649, 443);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(118, 32);
            this.btnsend.TabIndex = 34;
            this.btnsend.Text = "发送数据";
            this.btnsend.UseVisualStyleBackColor = true;
            this.btnsend.Click += new System.EventHandler(this.btnsend_Click);
            // 
            // txtsend
            // 
            this.txtsend.Location = new System.Drawing.Point(362, 413);
            this.txtsend.Multiline = true;
            this.txtsend.Name = "txtsend";
            this.txtsend.Size = new System.Drawing.Size(262, 62);
            this.txtsend.TabIndex = 33;
            this.txtsend.Text = "COM,1";
            // 
            // btn_port_open
            // 
            this.btn_port_open.Location = new System.Drawing.Point(557, 79);
            this.btn_port_open.Name = "btn_port_open";
            this.btn_port_open.Size = new System.Drawing.Size(69, 54);
            this.btn_port_open.TabIndex = 32;
            this.btn_port_open.Text = "打开端口";
            this.btn_port_open.UseVisualStyleBackColor = true;
            this.btn_port_open.Click += new System.EventHandler(this.btn_port_open_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(356, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 31;
            this.label5.Text = "串口设置";
            // 
            // tbDataBits
            // 
            this.tbDataBits.Location = new System.Drawing.Point(404, 178);
            this.tbDataBits.Name = "tbDataBits";
            this.tbDataBits.Size = new System.Drawing.Size(18, 21);
            this.tbDataBits.TabIndex = 30;
            this.tbDataBits.Text = "7";
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.Location = new System.Drawing.Point(403, 144);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(52, 21);
            this.cmbBaudRate.TabIndex = 29;
            this.cmbBaudRate.Text = "38400";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(357, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "奇偶校验：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(357, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "数据位：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "波特率：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(358, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "端口号：";
            // 
            // com_CA410
            // 
            this.com_CA410.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(663, 66);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(72, 208);
            this.textBox1.TabIndex = 46;
            this.textBox1.Text = "COM,1\r\nMDS,0\r\nMCH,1\r\nZRC";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(304, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(244, 27);
            this.label9.TabIndex = 47;
            this.label9.Text = "CA410串口通讯测试";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(287, 204);
            this.label10.TabIndex = 48;
            this.label10.Text = "指示灯状态（位于探头背面）：\r\n\r\n无电源：熄灭\r\n\r\n正在测量/正在零位校准：熄灭\r\n\r\n存储器异常：闪烁（0.2秒亮/0.2秒熄）\r\n\r\n未实施零位校准：闪烁" +
    "（1秒亮/1秒熄）\r\n\r\n可测量：亮灯\r\n\r\n零位校准\r\n环境温度发生变化时（超过6度），请进行零位校准。\r\n零位校准中，探头内部的遮蔽器会自动关闭遮光，\r\n但" +
    "为了谨慎起见，请勿将探头前端对准超过测量\r\n范围上限的高亮度光源。";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(557, 175);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(69, 54);
            this.button3.TabIndex = 49;
            this.button3.Text = "关闭端口";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(358, 251);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(167, 12);
            this.label11.TabIndex = 50;
            this.label11.Text = "参考设置：38400，7，2，EVEN";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(38, 287);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(303, 212);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // Form_CA410
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 560);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbPortName);
            this.Controls.Add(this.txtreceived);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbParity);
            this.Controls.Add(this.cmbStopBits);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnsend);
            this.Controls.Add(this.txtsend);
            this.Controls.Add(this.btn_port_open);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbDataBits);
            this.Controls.Add(this.cmbBaudRate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_CA410";
            this.Text = "CA410串口通讯测试";
            this.Load += new System.EventHandler(this.Form_CA410_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbPortName;
        private System.Windows.Forms.TextBox txtreceived;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbParity;
        private System.Windows.Forms.TextBox cmbStopBits;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnsend;
        private System.Windows.Forms.TextBox txtsend;
        private System.Windows.Forms.Button btn_port_open;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDataBits;
        private System.Windows.Forms.TextBox cmbBaudRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort com_CA410;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}