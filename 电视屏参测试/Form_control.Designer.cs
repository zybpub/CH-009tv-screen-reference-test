using System;

namespace Test_Automation
{
    partial class Form_control
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_ip = new System.Windows.Forms.TextBox();
            this.btn_plc_connect = new System.Windows.Forms.Button();
            this.停止rv = new System.Windows.Forms.Label();
            this.复位rv = new System.Windows.Forms.Label();
            this.启动rv = new System.Windows.Forms.Label();
            this.急停rv = new System.Windows.Forms.Label();
            this.自动rv = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SOFT_VER = new System.Windows.Forms.ToolStripStatusLabel();
            this.tb_memo = new System.Windows.Forms.TextBox();
            this.btnx_n50 = new System.Windows.Forms.Button();
            this.btnx_n10 = new System.Windows.Forms.Button();
            this.btnx_p10 = new System.Windows.Forms.Button();
            this.btnx_p50 = new System.Windows.Forms.Button();
            this.btny_p50 = new System.Windows.Forms.Button();
            this.btny_p10 = new System.Windows.Forms.Button();
            this.btny_n10 = new System.Windows.Forms.Button();
            this.btny_n50 = new System.Windows.Forms.Button();
            this.btnz_p50 = new System.Windows.Forms.Button();
            this.btnz_p10 = new System.Windows.Forms.Button();
            this.btnz_n10 = new System.Windows.Forms.Button();
            this.btnz_n50 = new System.Windows.Forms.Button();
            this.btnr_p50 = new System.Windows.Forms.Button();
            this.btnr_p10 = new System.Windows.Forms.Button();
            this.btnr_n10 = new System.Windows.Forms.Button();
            this.btnr_n50 = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_get_current_position = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_nowZ = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_nowY = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_nowX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_plc_disconnect = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbb生产厂商 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbb产品型号 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_count_zero = new System.Windows.Forms.Button();
            this.tb_height = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tb_width = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tb_z = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tb_y = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tb_x = new System.Windows.Forms.TextBox();
            this.btn_save_center = new System.Windows.Forms.Button();
            this.tb_inch = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tb_ratio = new System.Windows.Forms.TextBox();
            this.btn_setcenter = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "夹持系统PLC地址";
            // 
            // tb_ip
            // 
            this.tb_ip.Location = new System.Drawing.Point(145, 46);
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.Size = new System.Drawing.Size(155, 21);
            this.tb_ip.TabIndex = 1;
            // 
            // btn_plc_connect
            // 
            this.btn_plc_connect.Location = new System.Drawing.Point(321, 46);
            this.btn_plc_connect.Name = "btn_plc_connect";
            this.btn_plc_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_plc_connect.TabIndex = 312;
            this.btn_plc_connect.Text = "连接";
            this.btn_plc_connect.UseVisualStyleBackColor = true;
            this.btn_plc_connect.Click += new System.EventHandler(this.btn_plc_connect_Click);
            // 
            // 停止rv
            // 
            this.停止rv.AutoSize = true;
            this.停止rv.Location = new System.Drawing.Point(1519, 615);
            this.停止rv.Name = "停止rv";
            this.停止rv.Size = new System.Drawing.Size(35, 12);
            this.停止rv.TabIndex = 343;
            this.停止rv.Text = ".....";
            // 
            // 复位rv
            // 
            this.复位rv.AutoSize = true;
            this.复位rv.Location = new System.Drawing.Point(1519, 592);
            this.复位rv.Name = "复位rv";
            this.复位rv.Size = new System.Drawing.Size(35, 12);
            this.复位rv.TabIndex = 342;
            this.复位rv.Text = ".....";
            // 
            // 启动rv
            // 
            this.启动rv.AutoSize = true;
            this.启动rv.Location = new System.Drawing.Point(1519, 568);
            this.启动rv.Name = "启动rv";
            this.启动rv.Size = new System.Drawing.Size(35, 12);
            this.启动rv.TabIndex = 341;
            this.启动rv.Text = ".....";
            // 
            // 急停rv
            // 
            this.急停rv.AutoSize = true;
            this.急停rv.Location = new System.Drawing.Point(1519, 545);
            this.急停rv.Name = "急停rv";
            this.急停rv.Size = new System.Drawing.Size(35, 12);
            this.急停rv.TabIndex = 340;
            this.急停rv.Text = ".....";
            // 
            // 自动rv
            // 
            this.自动rv.AutoSize = true;
            this.自动rv.Location = new System.Drawing.Point(1519, 522);
            this.自动rv.Name = "自动rv";
            this.自动rv.Size = new System.Drawing.Size(35, 12);
            this.自动rv.TabIndex = 339;
            this.自动rv.Text = ".....";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1013, 562);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 344;
            this.button1.Text = "清空";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.SOFT_VER});
            this.statusStrip1.Location = new System.Drawing.Point(0, 624);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1114, 22);
            this.statusStrip1.TabIndex = 348;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel1.Text = "软件版本：";
            // 
            // SOFT_VER
            // 
            this.SOFT_VER.Name = "SOFT_VER";
            this.SOFT_VER.Size = new System.Drawing.Size(49, 17);
            this.SOFT_VER.Text = "Vx.x.x.x";
            // 
            // tb_memo
            // 
            this.tb_memo.Location = new System.Drawing.Point(806, 44);
            this.tb_memo.Multiline = true;
            this.tb_memo.Name = "tb_memo";
            this.tb_memo.Size = new System.Drawing.Size(282, 512);
            this.tb_memo.TabIndex = 373;
            this.tb_memo.TextChanged += new System.EventHandler(this.tb_memo_TextChanged);
            // 
            // btnx_n50
            // 
            this.btnx_n50.Location = new System.Drawing.Point(59, 482);
            this.btnx_n50.Name = "btnx_n50";
            this.btnx_n50.Size = new System.Drawing.Size(75, 23);
            this.btnx_n50.TabIndex = 374;
            this.btnx_n50.Text = "x-50";
            this.btnx_n50.UseVisualStyleBackColor = true;
            this.btnx_n50.Click += new System.EventHandler(this.btnx_n50_Click);
            // 
            // btnx_n10
            // 
            this.btnx_n10.Location = new System.Drawing.Point(140, 482);
            this.btnx_n10.Name = "btnx_n10";
            this.btnx_n10.Size = new System.Drawing.Size(75, 23);
            this.btnx_n10.TabIndex = 375;
            this.btnx_n10.Text = "x-10";
            this.btnx_n10.UseVisualStyleBackColor = true;
            this.btnx_n10.Click += new System.EventHandler(this.btnx_n10_Click);
            // 
            // btnx_p10
            // 
            this.btnx_p10.Location = new System.Drawing.Point(244, 482);
            this.btnx_p10.Name = "btnx_p10";
            this.btnx_p10.Size = new System.Drawing.Size(75, 23);
            this.btnx_p10.TabIndex = 376;
            this.btnx_p10.Text = "x+10";
            this.btnx_p10.UseVisualStyleBackColor = true;
            this.btnx_p10.Click += new System.EventHandler(this.btnx_p10_Click);
            // 
            // btnx_p50
            // 
            this.btnx_p50.Location = new System.Drawing.Point(333, 482);
            this.btnx_p50.Name = "btnx_p50";
            this.btnx_p50.Size = new System.Drawing.Size(75, 23);
            this.btnx_p50.TabIndex = 377;
            this.btnx_p50.Text = "x+50";
            this.btnx_p50.UseVisualStyleBackColor = true;
            this.btnx_p50.Click += new System.EventHandler(this.btnx_p50_Click);
            // 
            // btny_p50
            // 
            this.btny_p50.Location = new System.Drawing.Point(187, 414);
            this.btny_p50.Name = "btny_p50";
            this.btny_p50.Size = new System.Drawing.Size(75, 23);
            this.btny_p50.TabIndex = 381;
            this.btny_p50.Text = "y+50";
            this.btny_p50.UseVisualStyleBackColor = true;
            this.btny_p50.Click += new System.EventHandler(this.btny_p50_Click);
            // 
            // btny_p10
            // 
            this.btny_p10.Location = new System.Drawing.Point(187, 443);
            this.btny_p10.Name = "btny_p10";
            this.btny_p10.Size = new System.Drawing.Size(75, 23);
            this.btny_p10.TabIndex = 380;
            this.btny_p10.Text = "y+10";
            this.btny_p10.UseVisualStyleBackColor = true;
            this.btny_p10.Click += new System.EventHandler(this.btny_p10_Click);
            // 
            // btny_n10
            // 
            this.btny_n10.Location = new System.Drawing.Point(187, 518);
            this.btny_n10.Name = "btny_n10";
            this.btny_n10.Size = new System.Drawing.Size(75, 23);
            this.btny_n10.TabIndex = 379;
            this.btny_n10.Text = "y-10";
            this.btny_n10.UseVisualStyleBackColor = true;
            this.btny_n10.Click += new System.EventHandler(this.btny_n10_Click);
            // 
            // btny_n50
            // 
            this.btny_n50.Location = new System.Drawing.Point(187, 552);
            this.btny_n50.Name = "btny_n50";
            this.btny_n50.Size = new System.Drawing.Size(75, 23);
            this.btny_n50.TabIndex = 378;
            this.btny_n50.Text = "y-50";
            this.btny_n50.UseVisualStyleBackColor = true;
            this.btny_n50.Click += new System.EventHandler(this.btny_n50_Click);
            // 
            // btnz_p50
            // 
            this.btnz_p50.Location = new System.Drawing.Point(479, 424);
            this.btnz_p50.Name = "btnz_p50";
            this.btnz_p50.Size = new System.Drawing.Size(75, 23);
            this.btnz_p50.TabIndex = 385;
            this.btnz_p50.Text = "z+50";
            this.btnz_p50.UseVisualStyleBackColor = true;
            this.btnz_p50.Click += new System.EventHandler(this.btnz_p50_Click);
            // 
            // btnz_p10
            // 
            this.btnz_p10.Location = new System.Drawing.Point(479, 453);
            this.btnz_p10.Name = "btnz_p10";
            this.btnz_p10.Size = new System.Drawing.Size(75, 23);
            this.btnz_p10.TabIndex = 384;
            this.btnz_p10.Text = "z+10";
            this.btnz_p10.UseVisualStyleBackColor = true;
            this.btnz_p10.Click += new System.EventHandler(this.btnz_p10_Click);
            // 
            // btnz_n10
            // 
            this.btnz_n10.Location = new System.Drawing.Point(479, 528);
            this.btnz_n10.Name = "btnz_n10";
            this.btnz_n10.Size = new System.Drawing.Size(75, 23);
            this.btnz_n10.TabIndex = 383;
            this.btnz_n10.Text = "z-10";
            this.btnz_n10.UseVisualStyleBackColor = true;
            this.btnz_n10.Click += new System.EventHandler(this.btnz_n10_Click);
            // 
            // btnz_n50
            // 
            this.btnz_n50.Location = new System.Drawing.Point(479, 562);
            this.btnz_n50.Name = "btnz_n50";
            this.btnz_n50.Size = new System.Drawing.Size(75, 23);
            this.btnz_n50.TabIndex = 382;
            this.btnz_n50.Text = "z-50";
            this.btnz_n50.UseVisualStyleBackColor = true;
            this.btnz_n50.Click += new System.EventHandler(this.btnz_n50_Click);
            // 
            // btnr_p50
            // 
            this.btnr_p50.Location = new System.Drawing.Point(627, 424);
            this.btnr_p50.Name = "btnr_p50";
            this.btnr_p50.Size = new System.Drawing.Size(75, 23);
            this.btnr_p50.TabIndex = 389;
            this.btnr_p50.Text = "R+50";
            this.btnr_p50.UseVisualStyleBackColor = true;
            this.btnr_p50.Click += new System.EventHandler(this.btnr_p50_Click);
            // 
            // btnr_p10
            // 
            this.btnr_p10.Location = new System.Drawing.Point(628, 453);
            this.btnr_p10.Name = "btnr_p10";
            this.btnr_p10.Size = new System.Drawing.Size(75, 23);
            this.btnr_p10.TabIndex = 388;
            this.btnr_p10.Text = "R+10";
            this.btnr_p10.UseVisualStyleBackColor = true;
            this.btnr_p10.Click += new System.EventHandler(this.btnr_p10_Click);
            // 
            // btnr_n10
            // 
            this.btnr_n10.Location = new System.Drawing.Point(628, 528);
            this.btnr_n10.Name = "btnr_n10";
            this.btnr_n10.Size = new System.Drawing.Size(75, 23);
            this.btnr_n10.TabIndex = 387;
            this.btnr_n10.Text = "R-10";
            this.btnr_n10.UseVisualStyleBackColor = true;
            this.btnr_n10.Click += new System.EventHandler(this.btnr_n10_Click);
            // 
            // btnr_n50
            // 
            this.btnr_n50.Location = new System.Drawing.Point(628, 562);
            this.btnr_n50.Name = "btnr_n50";
            this.btnr_n50.Size = new System.Drawing.Size(75, 23);
            this.btnr_n50.TabIndex = 386;
            this.btnr_n50.Text = "R-50";
            this.btnr_n50.UseVisualStyleBackColor = true;
            this.btnr_n50.Click += new System.EventHandler(this.btnr_n50_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(537, 46);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 418;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click_1);
            // 
            // btn_get_current_position
            // 
            this.btn_get_current_position.Location = new System.Drawing.Point(429, 90);
            this.btn_get_current_position.Name = "btn_get_current_position";
            this.btn_get_current_position.Size = new System.Drawing.Size(97, 23);
            this.btn_get_current_position.TabIndex = 435;
            this.btn_get_current_position.Text = "获取当前坐标";
            this.btn_get_current_position.UseVisualStyleBackColor = true;
            this.btn_get_current_position.Click += new System.EventHandler(this.btn_get_current_position_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(51, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 434;
            this.label10.Text = "当前值：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(310, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 12);
            this.label7.TabIndex = 433;
            this.label7.Text = "Z：";
            // 
            // tb_nowZ
            // 
            this.tb_nowZ.Location = new System.Drawing.Point(337, 90);
            this.tb_nowZ.Name = "tb_nowZ";
            this.tb_nowZ.Size = new System.Drawing.Size(70, 21);
            this.tb_nowZ.TabIndex = 432;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(211, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 12);
            this.label8.TabIndex = 431;
            this.label8.Text = "Y：";
            // 
            // tb_nowY
            // 
            this.tb_nowY.Location = new System.Drawing.Point(237, 90);
            this.tb_nowY.Name = "tb_nowY";
            this.tb_nowY.Size = new System.Drawing.Size(70, 21);
            this.tb_nowY.TabIndex = 430;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(105, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 12);
            this.label9.TabIndex = 429;
            this.label9.Text = "X：";
            // 
            // tb_nowX
            // 
            this.tb_nowX.Location = new System.Drawing.Point(132, 90);
            this.tb_nowX.Name = "tb_nowX";
            this.tb_nowX.Size = new System.Drawing.Size(70, 21);
            this.tb_nowX.TabIndex = 428;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(628, 383);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 436;
            this.label2.Text = "分度盘";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(480, 383);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 437;
            this.label3.Text = "Z轴(高度)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 458);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 438;
            this.label4.Text = "X轴(距离)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(188, 383);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 12);
            this.label5.TabIndex = 439;
            this.label5.Text = "Y轴(屏幕的横向位置)";
            // 
            // btn_plc_disconnect
            // 
            this.btn_plc_disconnect.Location = new System.Drawing.Point(414, 44);
            this.btn_plc_disconnect.Name = "btn_plc_disconnect";
            this.btn_plc_disconnect.Size = new System.Drawing.Size(75, 23);
            this.btn_plc_disconnect.TabIndex = 440;
            this.btn_plc_disconnect.Text = "断开";
            this.btn_plc_disconnect.UseVisualStyleBackColor = true;
            this.btn_plc_disconnect.Click += new System.EventHandler(this.btn_plc_disconnect_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(804, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 441;
            this.label6.Text = "日志：";
            // 
            // cbb生产厂商
            // 
            this.cbb生产厂商.FormattingEnabled = true;
            this.cbb生产厂商.Location = new System.Drawing.Point(107, 183);
            this.cbb生产厂商.Name = "cbb生产厂商";
            this.cbb生产厂商.Size = new System.Drawing.Size(64, 20);
            this.cbb生产厂商.TabIndex = 445;
            this.cbb生产厂商.SelectedIndexChanged += new System.EventHandler(this.cbb生产厂商_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(47, 186);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 444;
            this.label11.Text = "生产厂商：";
            // 
            // cbb产品型号
            // 
            this.cbb产品型号.FormattingEnabled = true;
            this.cbb产品型号.Location = new System.Drawing.Point(215, 184);
            this.cbb产品型号.Name = "cbb产品型号";
            this.cbb产品型号.Size = new System.Drawing.Size(79, 20);
            this.cbb产品型号.TabIndex = 443;
            this.cbb产品型号.SelectedIndexChanged += new System.EventHandler(this.cbb产品型号_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(177, 187);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 442;
            this.label12.Text = "型号：";
            // 
            // btn_count_zero
            // 
            this.btn_count_zero.Location = new System.Drawing.Point(673, 214);
            this.btn_count_zero.Name = "btn_count_zero";
            this.btn_count_zero.Size = new System.Drawing.Size(91, 22);
            this.btn_count_zero.TabIndex = 457;
            this.btn_count_zero.Text = "自动计算零点";
            this.btn_count_zero.UseVisualStyleBackColor = true;
            this.btn_count_zero.Click += new System.EventHandler(this.btn_count_zero_Click);
            // 
            // tb_height
            // 
            this.tb_height.Location = new System.Drawing.Point(528, 215);
            this.tb_height.Name = "tb_height";
            this.tb_height.Size = new System.Drawing.Size(70, 21);
            this.tb_height.TabIndex = 456;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(473, 222);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 455;
            this.label13.Text = "屏幕高：";
            // 
            // tb_width
            // 
            this.tb_width.Location = new System.Drawing.Point(394, 215);
            this.tb_width.Name = "tb_width";
            this.tb_width.Size = new System.Drawing.Size(70, 21);
            this.tb_width.TabIndex = 454;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(339, 222);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 453;
            this.label14.Text = "屏幕宽：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(315, 248);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 452;
            this.label15.Text = "中心点：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(573, 248);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(23, 12);
            this.label20.TabIndex = 451;
            this.label20.Text = "Z：";
            // 
            // tb_z
            // 
            this.tb_z.Location = new System.Drawing.Point(599, 243);
            this.tb_z.Name = "tb_z";
            this.tb_z.Size = new System.Drawing.Size(70, 21);
            this.tb_z.TabIndex = 450;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(473, 248);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(23, 12);
            this.label21.TabIndex = 449;
            this.label21.Text = "Y：";
            // 
            // tb_y
            // 
            this.tb_y.Location = new System.Drawing.Point(499, 243);
            this.tb_y.Name = "tb_y";
            this.tb_y.Size = new System.Drawing.Size(70, 21);
            this.tb_y.TabIndex = 448;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(368, 248);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(23, 12);
            this.label22.TabIndex = 447;
            this.label22.Text = "X：";
            // 
            // tb_x
            // 
            this.tb_x.Location = new System.Drawing.Point(394, 243);
            this.tb_x.Name = "tb_x";
            this.tb_x.Size = new System.Drawing.Size(70, 21);
            this.tb_x.TabIndex = 446;
            // 
            // btn_save_center
            // 
            this.btn_save_center.Location = new System.Drawing.Point(673, 243);
            this.btn_save_center.Name = "btn_save_center";
            this.btn_save_center.Size = new System.Drawing.Size(75, 23);
            this.btn_save_center.TabIndex = 458;
            this.btn_save_center.Text = "保存";
            this.btn_save_center.UseVisualStyleBackColor = true;
            this.btn_save_center.Click += new System.EventHandler(this.btn_save_center_Click);
            // 
            // tb_inch
            // 
            this.tb_inch.Location = new System.Drawing.Point(408, 184);
            this.tb_inch.Name = "tb_inch";
            this.tb_inch.Size = new System.Drawing.Size(41, 21);
            this.tb_inch.TabIndex = 460;
            this.tb_inch.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.tb_inch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_inch_KeyPress);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(339, 189);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(65, 12);
            this.label23.TabIndex = 459;
            this.label23.Text = "屏幕大小：";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(455, 189);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(29, 12);
            this.label24.TabIndex = 461;
            this.label24.Text = "英寸";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(526, 188);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(65, 12);
            this.label25.TabIndex = 462;
            this.label25.Text = "宽高比例：";
            // 
            // tb_ratio
            // 
            this.tb_ratio.Location = new System.Drawing.Point(586, 185);
            this.tb_ratio.Name = "tb_ratio";
            this.tb_ratio.ReadOnly = true;
            this.tb_ratio.Size = new System.Drawing.Size(42, 21);
            this.tb_ratio.TabIndex = 463;
            this.tb_ratio.Text = "16:9";
            // 
            // btn_setcenter
            // 
            this.btn_setcenter.Location = new System.Drawing.Point(546, 90);
            this.btn_setcenter.Name = "btn_setcenter";
            this.btn_setcenter.Size = new System.Drawing.Size(140, 23);
            this.btn_setcenter.TabIndex = 464;
            this.btn_setcenter.Text = "使用当前坐标为中心点";
            this.btn_setcenter.UseVisualStyleBackColor = true;
            this.btn_setcenter.Click += new System.EventHandler(this.btn_setcenter_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(605, 213);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 23);
            this.button2.TabIndex = 465;
            this.button2.Text = "计算宽高";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form_control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 646);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_setcenter);
            this.Controls.Add(this.tb_ratio);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.tb_inch);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.btn_save_center);
            this.Controls.Add(this.btn_count_zero);
            this.Controls.Add(this.tb_height);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tb_width);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.tb_z);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.tb_y);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.tb_x);
            this.Controls.Add(this.cbb生产厂商);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbb产品型号);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_plc_disconnect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_get_current_position);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_nowZ);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_nowY);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tb_nowX);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btnr_p50);
            this.Controls.Add(this.btnr_p10);
            this.Controls.Add(this.btnr_n10);
            this.Controls.Add(this.btnr_n50);
            this.Controls.Add(this.btnz_p50);
            this.Controls.Add(this.btnz_p10);
            this.Controls.Add(this.btnz_n10);
            this.Controls.Add(this.btnz_n50);
            this.Controls.Add(this.btny_p50);
            this.Controls.Add(this.btny_p10);
            this.Controls.Add(this.btny_n10);
            this.Controls.Add(this.btny_n50);
            this.Controls.Add(this.btnx_p50);
            this.Controls.Add(this.btnx_p10);
            this.Controls.Add(this.btnx_n10);
            this.Controls.Add(this.btnx_n50);
            this.Controls.Add(this.tb_memo);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.停止rv);
            this.Controls.Add(this.复位rv);
            this.Controls.Add(this.启动rv);
            this.Controls.Add(this.急停rv);
            this.Controls.Add(this.自动rv);
            this.Controls.Add(this.btn_plc_connect);
            this.Controls.Add(this.tb_ip);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_control";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_control";
            this.Load += new System.EventHandler(this.Form_control_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


     

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_ip;
        private System.Windows.Forms.Button btn_plc_connect;
        private System.Windows.Forms.Label 停止rv;
        private System.Windows.Forms.Label 复位rv;
        private System.Windows.Forms.Label 启动rv;
        private System.Windows.Forms.Label 急停rv;
        private System.Windows.Forms.Label 自动rv;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel SOFT_VER;
        private System.Windows.Forms.TextBox tb_memo;
        private System.Windows.Forms.Button btnx_n50;
        private System.Windows.Forms.Button btnx_n10;
        private System.Windows.Forms.Button btnx_p10;
        private System.Windows.Forms.Button btnx_p50;
        private System.Windows.Forms.Button btny_p50;
        private System.Windows.Forms.Button btny_p10;
        private System.Windows.Forms.Button btny_n10;
        private System.Windows.Forms.Button btny_n50;
        private System.Windows.Forms.Button btnz_p50;
        private System.Windows.Forms.Button btnz_p10;
        private System.Windows.Forms.Button btnz_n10;
        private System.Windows.Forms.Button btnz_n50;
        private System.Windows.Forms.Button btnr_p50;
        private System.Windows.Forms.Button btnr_p10;
        private System.Windows.Forms.Button btnr_n10;
        private System.Windows.Forms.Button btnr_n50;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_get_current_position;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_nowZ;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_nowY;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_nowX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_plc_disconnect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbb生产厂商;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbb产品型号;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_count_zero;
        private System.Windows.Forms.TextBox tb_height;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tb_width;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tb_z;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tb_y;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tb_x;
        private System.Windows.Forms.Button btn_save_center;
        private System.Windows.Forms.TextBox tb_inch;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox tb_ratio;
        private System.Windows.Forms.Button btn_setcenter;
        private System.Windows.Forms.Button button2;
    }
}