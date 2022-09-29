namespace Test_Automation
{
    partial class Form_Main2
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
            this.lb_connect_info = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPLC_ip = new System.Windows.Forms.TextBox();
            this.btn_client_disconnect = new System.Windows.Forms.Button();
            this.btn_client_connect = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.tb_start_reg = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_startregvalue = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tb_log = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_mon_M170 = new System.Windows.Forms.Button();
            this.timer1_m_detect = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SOFT_VER = new System.Windows.Forms.ToolStripStatusLabel();
            this.label22 = new System.Windows.Forms.Label();
            this.btn_log_clear = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_move_test = new System.Windows.Forms.Button();
            this.timer_check_xyisfinished = new System.Windows.Forms.Timer(this.components);
            this.timer_z_upfinished = new System.Windows.Forms.Timer(this.components);
            this.timer_check_movefinished = new System.Windows.Forms.Timer(this.components);
            this.label23 = new System.Windows.Forms.Label();
            this.lb_当前状态 = new System.Windows.Forms.Label();
            this.btn_pos_reset = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_connect_info
            // 
            this.lb_connect_info.AutoSize = true;
            this.lb_connect_info.Location = new System.Drawing.Point(719, 111);
            this.lb_connect_info.Name = "lb_connect_info";
            this.lb_connect_info.Size = new System.Drawing.Size(59, 12);
            this.lb_connect_info.TabIndex = 36;
            this.lb_connect_info.Text = "未连接PLC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(440, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "IP：";
            // 
            // tbPLC_ip
            // 
            this.tbPLC_ip.Location = new System.Drawing.Point(478, 102);
            this.tbPLC_ip.Name = "tbPLC_ip";
            this.tbPLC_ip.Size = new System.Drawing.Size(101, 21);
            this.tbPLC_ip.TabIndex = 30;
            this.tbPLC_ip.Text = "192.168.1.5";
            // 
            // btn_client_disconnect
            // 
            this.btn_client_disconnect.Enabled = false;
            this.btn_client_disconnect.Location = new System.Drawing.Point(654, 101);
            this.btn_client_disconnect.Name = "btn_client_disconnect";
            this.btn_client_disconnect.Size = new System.Drawing.Size(59, 26);
            this.btn_client_disconnect.TabIndex = 20;
            this.btn_client_disconnect.Text = "断开";
            this.btn_client_disconnect.UseVisualStyleBackColor = true;
            // 
            // btn_client_connect
            // 
            this.btn_client_connect.Location = new System.Drawing.Point(590, 102);
            this.btn_client_connect.Name = "btn_client_connect";
            this.btn_client_connect.Size = new System.Drawing.Size(58, 25);
            this.btn_client_connect.TabIndex = 21;
            this.btn_client_connect.Text = "连接";
            this.btn_client_connect.UseVisualStyleBackColor = true;
            this.btn_client_connect.Click += new System.EventHandler(this.btn_client_connect_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(758, 142);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(71, 22);
            this.button8.TabIndex = 60;
            this.button8.Text = "读取";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // tb_start_reg
            // 
            this.tb_start_reg.Location = new System.Drawing.Point(516, 141);
            this.tb_start_reg.Name = "tb_start_reg";
            this.tb_start_reg.Size = new System.Drawing.Size(45, 21);
            this.tb_start_reg.TabIndex = 59;
            this.tb_start_reg.Text = "2000";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(436, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 58;
            this.label10.Text = "寄存器地址：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(580, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 57;
            this.label11.Text = "值：";
            // 
            // tb_startregvalue
            // 
            this.tb_startregvalue.Location = new System.Drawing.Point(615, 142);
            this.tb_startregvalue.Name = "tb_startregvalue";
            this.tb_startregvalue.Size = new System.Drawing.Size(62, 21);
            this.tb_startregvalue.TabIndex = 56;
            this.tb_startregvalue.Text = "1";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(692, 142);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(60, 23);
            this.button9.TabIndex = 55;
            this.button9.Text = "写入";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(970, 24);
            this.menuStrip1.TabIndex = 91;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // tb_log
            // 
            this.tb_log.Location = new System.Drawing.Point(31, 89);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.Size = new System.Drawing.Size(386, 221);
            this.tb_log.TabIndex = 92;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(429, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 93;
            this.label1.Text = "X轴运行(M170)";
            // 
            // btn_mon_M170
            // 
            this.btn_mon_M170.Location = new System.Drawing.Point(610, 169);
            this.btn_mon_M170.Name = "btn_mon_M170";
            this.btn_mon_M170.Size = new System.Drawing.Size(94, 23);
            this.btn_mon_M170.TabIndex = 94;
            this.btn_mon_M170.Text = "连续检测";
            this.btn_mon_M170.UseVisualStyleBackColor = true;
            this.btn_mon_M170.Click += new System.EventHandler(this.btn_mon_M170_Click);
            // 
            // timer1_m_detect
            // 
            this.timer1_m_detect.Interval = 500;
            this.timer1_m_detect.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(518, 171);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(73, 21);
            this.textBox1.TabIndex = 95;
            this.textBox1.Text = "171";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.SOFT_VER});
            this.statusStrip1.Location = new System.Drawing.Point(0, 658);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(970, 22);
            this.statusStrip1.TabIndex = 135;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabel1.Text = "软件版本：";
            // 
            // SOFT_VER
            // 
            this.SOFT_VER.Name = "SOFT_VER";
            this.SOFT_VER.Size = new System.Drawing.Size(53, 17);
            this.SOFT_VER.Text = "Vx.x.x.x";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(29, 65);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 12);
            this.label22.TabIndex = 136;
            this.label22.Text = "日志";
            // 
            // btn_log_clear
            // 
            this.btn_log_clear.Location = new System.Drawing.Point(156, 60);
            this.btn_log_clear.Name = "btn_log_clear";
            this.btn_log_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_log_clear.TabIndex = 137;
            this.btn_log_clear.Text = "清空";
            this.btn_log_clear.UseVisualStyleBackColor = true;
            this.btn_log_clear.Click += new System.EventHandler(this.btn_log_clear_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(721, 169);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 138;
            this.button2.Text = "停止检测";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(518, 263);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(181, 90);
            this.button3.TabIndex = 140;
            this.button3.Text = "寄存器调试";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_move_test
            // 
            this.btn_move_test.Location = new System.Drawing.Point(730, 263);
            this.btn_move_test.Name = "btn_move_test";
            this.btn_move_test.Size = new System.Drawing.Size(172, 84);
            this.btn_move_test.TabIndex = 141;
            this.btn_move_test.Text = "移动测试";
            this.btn_move_test.UseVisualStyleBackColor = true;
            this.btn_move_test.Click += new System.EventHandler(this.btn_move_test_Click);
            // 
            // timer_check_xyisfinished
            // 
            this.timer_check_xyisfinished.Interval = 1000;
            this.timer_check_xyisfinished.Tick += new System.EventHandler(this.timer_check_xyisfinished_Tick);
            // 
            // timer_z_upfinished
            // 
            this.timer_z_upfinished.Interval = 1000;
            this.timer_z_upfinished.Tick += new System.EventHandler(this.timer_z_upfinished_Tick);
            // 
            // timer_check_movefinished
            // 
            this.timer_check_movefinished.Interval = 1000;
            this.timer_check_movefinished.Tick += new System.EventHandler(this.timer_check_movefinished_Tick);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(777, 42);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(65, 12);
            this.label23.TabIndex = 144;
            this.label23.Text = "当前状态：\r\n";
            // 
            // lb_当前状态
            // 
            this.lb_当前状态.AutoSize = true;
            this.lb_当前状态.Location = new System.Drawing.Point(849, 42);
            this.lb_当前状态.Name = "lb_当前状态";
            this.lb_当前状态.Size = new System.Drawing.Size(29, 12);
            this.lb_当前状态.TabIndex = 145;
            this.lb_当前状态.Text = "复位";
            // 
            // btn_pos_reset
            // 
            this.btn_pos_reset.Location = new System.Drawing.Point(851, 65);
            this.btn_pos_reset.Name = "btn_pos_reset";
            this.btn_pos_reset.Size = new System.Drawing.Size(75, 23);
            this.btn_pos_reset.TabIndex = 146;
            this.btn_pos_reset.Text = "复位";
            this.btn_pos_reset.UseVisualStyleBackColor = true;
            this.btn_pos_reset.Click += new System.EventHandler(this.btn_pos_reset_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 680);
            this.Controls.Add(this.btn_pos_reset);
            this.Controls.Add(this.lb_当前状态);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.btn_move_test);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_log_clear);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_mon_M170);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_log);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.tb_start_reg);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tb_startregvalue);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.lb_connect_info);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPLC_ip);
            this.Controls.Add(this.btn_client_disconnect);
            this.Controls.Add(this.btn_client_connect);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "电视屏自动测试系统";
            this.Load += new System.EventHandler(this.Form_PLC_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_connect_info;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPLC_ip;
        private System.Windows.Forms.Button btn_client_disconnect;
        private System.Windows.Forms.Button btn_client_connect;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox tb_start_reg;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_startregvalue;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_mon_M170;
        private System.Windows.Forms.Timer timer1_m_detect;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel SOFT_VER;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btn_log_clear;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_move_test;
        private System.Windows.Forms.Timer timer_check_xyisfinished;
        private System.Windows.Forms.Timer timer_z_upfinished;
        private System.Windows.Forms.Timer timer_check_movefinished;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lb_当前状态;
        private System.Windows.Forms.Button btn_pos_reset;
    }
}