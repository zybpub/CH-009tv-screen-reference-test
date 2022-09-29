namespace Test_Automation
{
    partial class Form_Gamma_CA410_SDK2net
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_white_pattern = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.cmb_serialPort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_count_zero = new System.Windows.Forms.Button();
            this.tb_height = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tb_width = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbb_type = new System.Windows.Forms.ComboBox();
            this.btn_zero_save = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tb_centerZ = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tb_centerY = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tb_centerX = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label3000 = new System.Windows.Forms.Label();
            this.lb_lv = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_test_num = new System.Windows.Forms.Label();
            this.label17000 = new System.Windows.Forms.Label();
            this.btn_test_stop = new System.Windows.Forms.Button();
            this.serialPort_VG876 = new System.IO.Ports.SerialPort(this.components);
            this.tb_memo = new System.Windows.Forms.TextBox();
            this.tb_test_proj = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_plc_connect = new System.Windows.Forms.Button();
            this.btn_plc_disconnect = new System.Windows.Forms.Button();
            this.btn_get_current_position = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_nowZ = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_nowY = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_nowX = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.brn_save_doc = new System.Windows.Forms.Button();
            this.com_CA410 = new System.IO.Ports.SerialPort(this.components);
            this.tb_result = new System.Windows.Forms.TextBox();
            this.Gamma测试 = new System.Windows.Forms.Label();
            this.btn_test_start = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.userCurve1 = new HslCommunication.Controls.UserCurve();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.userCurve1);
            this.groupBox2.Controls.Add(this.btn_white_pattern);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.cmb_serialPort);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btn_count_zero);
            this.groupBox2.Controls.Add(this.tb_height);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.tb_width);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cbb_type);
            this.groupBox2.Controls.Add(this.btn_zero_save);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.tb_centerZ);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.tb_centerY);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.tb_centerX);
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.label3000);
            this.groupBox2.Location = new System.Drawing.Point(12, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1109, 644);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btn_white_pattern
            // 
            this.btn_white_pattern.Location = new System.Drawing.Point(943, 45);
            this.btn_white_pattern.Name = "btn_white_pattern";
            this.btn_white_pattern.Size = new System.Drawing.Size(111, 23);
            this.btn_white_pattern.TabIndex = 82;
            this.btn_white_pattern.Text = "发送黑场信号";
            this.btn_white_pattern.UseVisualStyleBackColor = true;
            this.btn_white_pattern.Click += new System.EventHandler(this.btn_white_pattern_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1003, 14);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(53, 23);
            this.button4.TabIndex = 81;
            this.button4.Text = "保存";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cmb_serialPort
            // 
            this.cmb_serialPort.FormattingEnabled = true;
            this.cmb_serialPort.Location = new System.Drawing.Point(931, 14);
            this.cmb_serialPort.Name = "cmb_serialPort";
            this.cmb_serialPort.Size = new System.Drawing.Size(66, 20);
            this.cmb_serialPort.TabIndex = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(821, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 79;
            this.label2.Text = "信号发生器串口号：";
            // 
            // btn_count_zero
            // 
            this.btn_count_zero.Location = new System.Drawing.Point(405, 13);
            this.btn_count_zero.Name = "btn_count_zero";
            this.btn_count_zero.Size = new System.Drawing.Size(103, 22);
            this.btn_count_zero.TabIndex = 78;
            this.btn_count_zero.Text = "自动计算中心点";
            this.btn_count_zero.UseVisualStyleBackColor = true;
            this.btn_count_zero.Click += new System.EventHandler(this.btn_count_zero_Click);
            // 
            // tb_height
            // 
            this.tb_height.Location = new System.Drawing.Point(318, 13);
            this.tb_height.Name = "tb_height";
            this.tb_height.Size = new System.Drawing.Size(70, 21);
            this.tb_height.TabIndex = 77;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(263, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 76;
            this.label13.Text = "屏幕高：";
            // 
            // tb_width
            // 
            this.tb_width.Location = new System.Drawing.Point(184, 13);
            this.tb_width.Name = "tb_width";
            this.tb_width.Size = new System.Drawing.Size(70, 21);
            this.tb_width.TabIndex = 75;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(129, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 74;
            this.label12.Text = "屏幕宽：";
            // 
            // cbb_type
            // 
            this.cbb_type.FormattingEnabled = true;
            this.cbb_type.Location = new System.Drawing.Point(15, 39);
            this.cbb_type.Name = "cbb_type";
            this.cbb_type.Size = new System.Drawing.Size(93, 20);
            this.cbb_type.TabIndex = 71;
            this.cbb_type.SelectedIndexChanged += new System.EventHandler(this.cbb_type_SelectedIndexChanged);
            // 
            // btn_zero_save
            // 
            this.btn_zero_save.Location = new System.Drawing.Point(474, 41);
            this.btn_zero_save.Name = "btn_zero_save";
            this.btn_zero_save.Size = new System.Drawing.Size(72, 23);
            this.btn_zero_save.TabIndex = 63;
            this.btn_zero_save.Text = "保存参数";
            this.btn_zero_save.UseVisualStyleBackColor = true;
            this.btn_zero_save.Click += new System.EventHandler(this.btn_zero_save_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(114, 46);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 12);
            this.label19.TabIndex = 62;
            this.label19.Text = "中心点：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(362, 46);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(23, 12);
            this.label16.TabIndex = 61;
            this.label16.Text = "Z：";
            // 
            // tb_centerZ
            // 
            this.tb_centerZ.Location = new System.Drawing.Point(388, 41);
            this.tb_centerZ.Name = "tb_centerZ";
            this.tb_centerZ.Size = new System.Drawing.Size(70, 21);
            this.tb_centerZ.TabIndex = 60;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(262, 46);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(23, 12);
            this.label17.TabIndex = 59;
            this.label17.Text = "Y：";
            // 
            // tb_centerY
            // 
            this.tb_centerY.Location = new System.Drawing.Point(288, 41);
            this.tb_centerY.Name = "tb_centerY";
            this.tb_centerY.Size = new System.Drawing.Size(70, 21);
            this.tb_centerY.TabIndex = 58;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(157, 46);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(23, 12);
            this.label18.TabIndex = 57;
            this.label18.Text = "X：";
            // 
            // tb_centerX
            // 
            this.tb_centerX.Location = new System.Drawing.Point(183, 41);
            this.tb_centerX.Name = "tb_centerX";
            this.tb_centerX.Size = new System.Drawing.Size(70, 21);
            this.tb_centerX.TabIndex = 56;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(552, 41);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(122, 23);
            this.button7.TabIndex = 55;
            this.button7.Text = "检测头移动到中心点";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label3000
            // 
            this.label3000.AutoSize = true;
            this.label3000.Location = new System.Drawing.Point(13, 24);
            this.label3000.Name = "label3000";
            this.label3000.Size = new System.Drawing.Size(53, 12);
            this.label3000.TabIndex = 5;
            this.label3000.Text = "机器型号";
            // 
            // lb_lv
            // 
            this.lb_lv.AutoSize = true;
            this.lb_lv.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_lv.ForeColor = System.Drawing.Color.Green;
            this.lb_lv.Location = new System.Drawing.Point(1016, 59);
            this.lb_lv.Name = "lb_lv";
            this.lb_lv.Size = new System.Drawing.Size(28, 29);
            this.lb_lv.TabIndex = 65;
            this.lb_lv.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(953, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 64;
            this.label3.Text = "当前值：";
            // 
            // lb_test_num
            // 
            this.lb_test_num.AutoSize = true;
            this.lb_test_num.Location = new System.Drawing.Point(1019, 45);
            this.lb_test_num.Name = "lb_test_num";
            this.lb_test_num.Size = new System.Drawing.Size(11, 12);
            this.lb_test_num.TabIndex = 40;
            this.lb_test_num.Text = "0";
            // 
            // label17000
            // 
            this.label17000.AutoSize = true;
            this.label17000.Location = new System.Drawing.Point(917, 45);
            this.label17000.Name = "label17000";
            this.label17000.Size = new System.Drawing.Size(89, 12);
            this.label17000.TabIndex = 39;
            this.label17000.Text = "当前测试点数：";
            // 
            // btn_test_stop
            // 
            this.btn_test_stop.Location = new System.Drawing.Point(1317, 11);
            this.btn_test_stop.Name = "btn_test_stop";
            this.btn_test_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_test_stop.TabIndex = 54;
            this.btn_test_stop.Text = "停止测试";
            this.btn_test_stop.UseVisualStyleBackColor = true;
            this.btn_test_stop.Click += new System.EventHandler(this.btn_test_stop_Click);
            // 
            // serialPort_VG876
            // 
            this.serialPort_VG876.BaudRate = 38400;
            this.serialPort_VG876.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_VG870_DataReceived);
            // 
            // tb_memo
            // 
            this.tb_memo.Location = new System.Drawing.Point(1248, 71);
            this.tb_memo.Multiline = true;
            this.tb_memo.Name = "tb_memo";
            this.tb_memo.Size = new System.Drawing.Size(160, 582);
            this.tb_memo.TabIndex = 3;
            // 
            // tb_test_proj
            // 
            this.tb_test_proj.Location = new System.Drawing.Point(1059, 13);
            this.tb_test_proj.Name = "tb_test_proj";
            this.tb_test_proj.Size = new System.Drawing.Size(163, 21);
            this.tb_test_proj.TabIndex = 4;
            this.tb_test_proj.Text = "aaa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1000, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "测试编号";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1263, 670);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 36);
            this.button3.TabIndex = 6;
            this.button3.Text = "保存测试日志";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // btn_plc_connect
            // 
            this.btn_plc_connect.Location = new System.Drawing.Point(498, 59);
            this.btn_plc_connect.Name = "btn_plc_connect";
            this.btn_plc_connect.Size = new System.Drawing.Size(91, 23);
            this.btn_plc_connect.TabIndex = 60;
            this.btn_plc_connect.Text = "PLC连接";
            this.btn_plc_connect.UseVisualStyleBackColor = true;
            this.btn_plc_connect.Click += new System.EventHandler(this.btn_plc_connect_Click);
            // 
            // btn_plc_disconnect
            // 
            this.btn_plc_disconnect.Location = new System.Drawing.Point(595, 59);
            this.btn_plc_disconnect.Name = "btn_plc_disconnect";
            this.btn_plc_disconnect.Size = new System.Drawing.Size(91, 23);
            this.btn_plc_disconnect.TabIndex = 59;
            this.btn_plc_disconnect.Text = "PLC断开连接";
            this.btn_plc_disconnect.UseVisualStyleBackColor = true;
            this.btn_plc_disconnect.Click += new System.EventHandler(this.btn_plc_disconnect_Click);
            // 
            // btn_get_current_position
            // 
            this.btn_get_current_position.Location = new System.Drawing.Point(380, 57);
            this.btn_get_current_position.Name = "btn_get_current_position";
            this.btn_get_current_position.Size = new System.Drawing.Size(97, 23);
            this.btn_get_current_position.TabIndex = 68;
            this.btn_get_current_position.Text = "获取当前坐标";
            this.btn_get_current_position.UseVisualStyleBackColor = true;
            this.btn_get_current_position.Click += new System.EventHandler(this.btn_get_current_position_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 67;
            this.label10.Text = "当前值(mm)：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(272, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 12);
            this.label7.TabIndex = 66;
            this.label7.Text = "Z：";
            // 
            // tb_nowZ
            // 
            this.tb_nowZ.Location = new System.Drawing.Point(299, 59);
            this.tb_nowZ.Name = "tb_nowZ";
            this.tb_nowZ.Size = new System.Drawing.Size(70, 21);
            this.tb_nowZ.TabIndex = 65;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(173, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 12);
            this.label8.TabIndex = 64;
            this.label8.Text = "Y：";
            // 
            // tb_nowY
            // 
            this.tb_nowY.Location = new System.Drawing.Point(199, 59);
            this.tb_nowY.Name = "tb_nowY";
            this.tb_nowY.Size = new System.Drawing.Size(70, 21);
            this.tb_nowY.TabIndex = 63;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(67, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 12);
            this.label9.TabIndex = 62;
            this.label9.Text = "X：";
            // 
            // tb_nowX
            // 
            this.tb_nowX.Location = new System.Drawing.Point(94, 59);
            this.tb_nowX.Name = "tb_nowX";
            this.tb_nowX.Size = new System.Drawing.Size(70, 21);
            this.tb_nowX.TabIndex = 61;
            // 
            // brn_save_doc
            // 
            this.brn_save_doc.Location = new System.Drawing.Point(1263, 712);
            this.brn_save_doc.Name = "brn_save_doc";
            this.brn_save_doc.Size = new System.Drawing.Size(125, 36);
            this.brn_save_doc.TabIndex = 69;
            this.brn_save_doc.Text = "导出Word表格";
            this.brn_save_doc.UseVisualStyleBackColor = true;
            this.brn_save_doc.Click += new System.EventHandler(this.brn_save_doc_Click);
            // 
            // tb_result
            // 
            this.tb_result.Location = new System.Drawing.Point(1127, 72);
            this.tb_result.Multiline = true;
            this.tb_result.Name = "tb_result";
            this.tb_result.Size = new System.Drawing.Size(95, 582);
            this.tb_result.TabIndex = 75;
            // 
            // Gamma测试
            // 
            this.Gamma测试.AutoSize = true;
            this.Gamma测试.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Gamma测试.Location = new System.Drawing.Point(492, 11);
            this.Gamma测试.Name = "Gamma测试";
            this.Gamma测试.Size = new System.Drawing.Size(175, 35);
            this.Gamma测试.TabIndex = 82;
            this.Gamma测试.Text = "Gamma测试";
            // 
            // btn_test_start
            // 
            this.btn_test_start.Location = new System.Drawing.Point(1226, 11);
            this.btn_test_start.Name = "btn_test_start";
            this.btn_test_start.Size = new System.Drawing.Size(85, 25);
            this.btn_test_start.TabIndex = 84;
            this.btn_test_start.Text = "开始测试";
            this.btn_test_start.UseVisualStyleBackColor = true;
            this.btn_test_start.Click += new System.EventHandler(this.btn_test_start_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1127, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 85;
            this.label4.Text = "测试结果";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1246, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 86;
            this.label5.Text = "测试日志";
            // 
            // userCurve1
            // 
            this.userCurve1.BackColor = System.Drawing.Color.Transparent;
            this.userCurve1.IsAbscissaStrech = true;
            this.userCurve1.Location = new System.Drawing.Point(42, 110);
            this.userCurve1.Name = "userCurve1";
            this.userCurve1.Size = new System.Drawing.Size(1027, 496);
            this.userCurve1.StrechDataCountMax = 255;
            this.userCurve1.TabIndex = 83;
            this.userCurve1.TextAddFormat = "";
            this.userCurve1.ValueMaxLeft = 400F;
            this.userCurve1.ValueMaxRight = 400F;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 756);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1420, 22);
            this.statusStrip1.TabIndex = 87;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(95, 17);
            this.toolStripStatusLabel1.Text = "Designed by ZYB";
            // 
            // Form_Gamma_CA410_SDK2net
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1420, 778);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_test_start);
            this.Controls.Add(this.Gamma测试);
            this.Controls.Add(this.tb_result);
            this.Controls.Add(this.brn_save_doc);
            this.Controls.Add(this.btn_get_current_position);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_nowZ);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_nowY);
            this.Controls.Add(this.lb_lv);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_nowX);
            this.Controls.Add(this.btn_plc_connect);
            this.Controls.Add(this.btn_plc_disconnect);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_test_proj);
            this.Controls.Add(this.tb_memo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_test_stop);
            this.Controls.Add(this.label17000);
            this.Controls.Add(this.lb_test_num);
            this.MaximizeBox = false;
            this.Name = "Form_Gamma_CA410_SDK2net";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gamma测试";
            this.Load += new System.EventHandler(this.Form_160_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3000;
        private System.Windows.Forms.Label lb_test_num;
        private System.Windows.Forms.Label label17000;
        private System.IO.Ports.SerialPort serialPort_VG876;
        private System.Windows.Forms.Button btn_test_stop;
        private System.Windows.Forms.TextBox tb_memo;
        private System.Windows.Forms.TextBox tb_test_proj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_zero_save;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tb_centerZ;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tb_centerY;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tb_centerX;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btn_plc_connect;
        private System.Windows.Forms.Button btn_plc_disconnect;
        private System.Windows.Forms.Button btn_get_current_position;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_nowZ;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_nowY;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_nowX;
        private System.Windows.Forms.Label lb_lv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button brn_save_doc;
        private System.Windows.Forms.ComboBox cbb_type;
        private System.Windows.Forms.Button btn_count_zero;
        private System.Windows.Forms.TextBox tb_height;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tb_width;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmb_serialPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.IO.Ports.SerialPort com_CA410;
        private System.Windows.Forms.TextBox tb_result;
        private System.Windows.Forms.Label Gamma测试;
        private System.Windows.Forms.Button btn_test_start;
        private System.Windows.Forms.Button btn_white_pattern;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private HslCommunication.Controls.UserCurve userCurve1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}