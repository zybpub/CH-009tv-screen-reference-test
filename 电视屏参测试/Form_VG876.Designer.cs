namespace Test_Automation
{
    partial class Form_VG876
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_serialPort = new System.Windows.Forms.ComboBox();
            this.btn_open = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.tb_memo = new System.Windows.Forms.TextBox();
            this.serialPort_VG876 = new System.IO.Ports.SerialPort(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.btn_white = new System.Windows.Forms.Button();
            this.btn_red = new System.Windows.Forms.Button();
            this.btn_green = new System.Windows.Forms.Button();
            this.btn_blue = new System.Windows.Forms.Button();
            this.brn_black = new System.Windows.Forms.Button();
            this.btn_50gray = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_r = new System.Windows.Forms.TextBox();
            this.tb_g = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_b = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_mode_window = new System.Windows.Forms.Button();
            this.btn_set_rgb = new System.Windows.Forms.Button();
            this.btn_rgv_add1 = new System.Windows.Forms.Button();
            this.btn_rgb_add10 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btn_win_color = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.btn_graphic_plane_plalette644 = new System.Windows.Forms.Button();
            this.btn_back_ground_color336 = new System.Windows.Forms.Button();
            this.btn327 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.btn_vg876_portsave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口号";
            // 
            // cmb_serialPort
            // 
            this.cmb_serialPort.FormattingEnabled = true;
            this.cmb_serialPort.Location = new System.Drawing.Point(134, 84);
            this.cmb_serialPort.Name = "cmb_serialPort";
            this.cmb_serialPort.Size = new System.Drawing.Size(121, 20);
            this.cmb_serialPort.TabIndex = 1;
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(276, 81);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(75, 23);
            this.btn_open.TabIndex = 2;
            this.btn_open.Text = "打开端口";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(381, 82);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 3;
            this.btn_close.Text = "关闭端口";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // tb_memo
            // 
            this.tb_memo.Location = new System.Drawing.Point(74, 141);
            this.tb_memo.Multiline = true;
            this.tb_memo.Name = "tb_memo";
            this.tb_memo.Size = new System.Drawing.Size(181, 290);
            this.tb_memo.TabIndex = 4;
            // 
            // serialPort_VG876
            // 
            this.serialPort_VG876.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_VG876_DataReceived);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "38400,8,N,1";
            // 
            // btn_white
            // 
            this.btn_white.Location = new System.Drawing.Point(261, 157);
            this.btn_white.Name = "btn_white";
            this.btn_white.Size = new System.Drawing.Size(75, 23);
            this.btn_white.TabIndex = 6;
            this.btn_white.Text = "白场";
            this.btn_white.UseVisualStyleBackColor = true;
            this.btn_white.Click += new System.EventHandler(this.btn_white_Click);
            // 
            // btn_red
            // 
            this.btn_red.Location = new System.Drawing.Point(261, 201);
            this.btn_red.Name = "btn_red";
            this.btn_red.Size = new System.Drawing.Size(75, 23);
            this.btn_red.TabIndex = 7;
            this.btn_red.Text = "红场";
            this.btn_red.UseVisualStyleBackColor = true;
            this.btn_red.Click += new System.EventHandler(this.btn_red_Click);
            // 
            // btn_green
            // 
            this.btn_green.Location = new System.Drawing.Point(261, 239);
            this.btn_green.Name = "btn_green";
            this.btn_green.Size = new System.Drawing.Size(75, 23);
            this.btn_green.TabIndex = 8;
            this.btn_green.Text = "绿场";
            this.btn_green.UseVisualStyleBackColor = true;
            this.btn_green.Click += new System.EventHandler(this.btn_green_Click);
            // 
            // btn_blue
            // 
            this.btn_blue.Location = new System.Drawing.Point(261, 280);
            this.btn_blue.Name = "btn_blue";
            this.btn_blue.Size = new System.Drawing.Size(75, 23);
            this.btn_blue.TabIndex = 9;
            this.btn_blue.Text = "蓝场";
            this.btn_blue.UseVisualStyleBackColor = true;
            this.btn_blue.Click += new System.EventHandler(this.btn_blue_Click);
            // 
            // brn_black
            // 
            this.brn_black.Location = new System.Drawing.Point(261, 320);
            this.brn_black.Name = "brn_black";
            this.brn_black.Size = new System.Drawing.Size(75, 23);
            this.brn_black.TabIndex = 10;
            this.brn_black.Text = "黑场";
            this.brn_black.UseVisualStyleBackColor = true;
            this.brn_black.Click += new System.EventHandler(this.brn_black_Click);
            // 
            // btn_50gray
            // 
            this.btn_50gray.Location = new System.Drawing.Point(261, 359);
            this.btn_50gray.Name = "btn_50gray";
            this.btn_50gray.Size = new System.Drawing.Size(75, 23);
            this.btn_50gray.TabIndex = 11;
            this.btn_50gray.Text = "50%灰场";
            this.btn_50gray.UseVisualStyleBackColor = true;
            this.btn_50gray.Click += new System.EventHandler(this.btn_50gray_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(160, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(349, 29);
            this.label3.TabIndex = 12;
            this.label3.Text = "VG876图像信号发生器控制";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(755, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "R";
            // 
            // tb_r
            // 
            this.tb_r.Location = new System.Drawing.Point(779, 186);
            this.tb_r.Name = "tb_r";
            this.tb_r.Size = new System.Drawing.Size(51, 21);
            this.tb_r.TabIndex = 15;
            this.tb_r.Text = "0";
            // 
            // tb_g
            // 
            this.tb_g.Location = new System.Drawing.Point(779, 213);
            this.tb_g.Name = "tb_g";
            this.tb_g.Size = new System.Drawing.Size(51, 21);
            this.tb_g.TabIndex = 17;
            this.tb_g.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(755, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "G";
            // 
            // tb_b
            // 
            this.tb_b.Location = new System.Drawing.Point(779, 240);
            this.tb_b.Name = "tb_b";
            this.tb_b.Size = new System.Drawing.Size(51, 21);
            this.tb_b.TabIndex = 19;
            this.tb_b.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(755, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "B";
            // 
            // btn_mode_window
            // 
            this.btn_mode_window.Location = new System.Drawing.Point(779, 117);
            this.btn_mode_window.Name = "btn_mode_window";
            this.btn_mode_window.Size = new System.Drawing.Size(105, 23);
            this.btn_mode_window.TabIndex = 20;
            this.btn_mode_window.Text = "设置为window";
            this.btn_mode_window.UseVisualStyleBackColor = true;
            this.btn_mode_window.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_set_rgb
            // 
            this.btn_set_rgb.Location = new System.Drawing.Point(932, 424);
            this.btn_set_rgb.Name = "btn_set_rgb";
            this.btn_set_rgb.Size = new System.Drawing.Size(113, 43);
            this.btn_set_rgb.TabIndex = 21;
            this.btn_set_rgb.Text = "设置planeRGB";
            this.btn_set_rgb.UseVisualStyleBackColor = true;
            this.btn_set_rgb.Click += new System.EventHandler(this.btn_set_rgb_Click);
            // 
            // btn_rgv_add1
            // 
            this.btn_rgv_add1.Location = new System.Drawing.Point(869, 185);
            this.btn_rgv_add1.Name = "btn_rgv_add1";
            this.btn_rgv_add1.Size = new System.Drawing.Size(34, 74);
            this.btn_rgv_add1.TabIndex = 22;
            this.btn_rgv_add1.Text = "+1";
            this.btn_rgv_add1.UseVisualStyleBackColor = true;
            this.btn_rgv_add1.Click += new System.EventHandler(this.btn_rgv_add1_Click);
            // 
            // btn_rgb_add10
            // 
            this.btn_rgb_add10.Location = new System.Drawing.Point(869, 267);
            this.btn_rgb_add10.Name = "btn_rgb_add10";
            this.btn_rgb_add10.Size = new System.Drawing.Size(34, 74);
            this.btn_rgb_add10.TabIndex = 23;
            this.btn_rgb_add10.Text = "+10";
            this.btn_rgb_add10.UseVisualStyleBackColor = true;
            this.btn_rgb_add10.Click += new System.EventHandler(this.btn_rgb_add10_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(918, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 74);
            this.button1.TabIndex = 24;
            this.button1.Text = "+10并发送到仪表";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(779, 387);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "设置RGB155";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(918, 186);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(69, 74);
            this.button3.TabIndex = 26;
            this.button3.Text = "+1并发送到仪表";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(779, 157);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(51, 23);
            this.button4.TabIndex = 27;
            this.button4.Text = "0";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(836, 156);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(51, 23);
            this.button5.TabIndex = 28;
            this.button5.Text = "128";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(893, 156);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(51, 23);
            this.button6.TabIndex = 29;
            this.button6.Text = "255";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btn_win_color
            // 
            this.btn_win_color.Location = new System.Drawing.Point(741, 277);
            this.btn_win_color.Name = "btn_win_color";
            this.btn_win_color.Size = new System.Drawing.Size(113, 35);
            this.btn_win_color.TabIndex = 30;
            this.btn_win_color.Text = "333设置window color RGB";
            this.btn_win_color.UseVisualStyleBackColor = true;
            this.btn_win_color.Click += new System.EventHandler(this.button7_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(693, 427);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 31;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(693, 398);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 32;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // btn_graphic_plane_plalette644
            // 
            this.btn_graphic_plane_plalette644.Location = new System.Drawing.Point(928, 372);
            this.btn_graphic_plane_plalette644.Name = "btn_graphic_plane_plalette644";
            this.btn_graphic_plane_plalette644.Size = new System.Drawing.Size(116, 48);
            this.btn_graphic_plane_plalette644.TabIndex = 33;
            this.btn_graphic_plane_plalette644.Text = "graphic_plane_plalette644";
            this.btn_graphic_plane_plalette644.UseVisualStyleBackColor = true;
            this.btn_graphic_plane_plalette644.Click += new System.EventHandler(this.btn_graphic_plane_plalette644_Click);
            // 
            // btn_back_ground_color336
            // 
            this.btn_back_ground_color336.Location = new System.Drawing.Point(985, 68);
            this.btn_back_ground_color336.Name = "btn_back_ground_color336";
            this.btn_back_ground_color336.Size = new System.Drawing.Size(95, 56);
            this.btn_back_ground_color336.TabIndex = 34;
            this.btn_back_ground_color336.Text = "back_ground_color336";
            this.btn_back_ground_color336.UseVisualStyleBackColor = true;
            this.btn_back_ground_color336.Click += new System.EventHandler(this.btn_back_ground_color336_Click);
            // 
            // btn327
            // 
            this.btn327.Location = new System.Drawing.Point(778, 29);
            this.btn327.Name = "btn327";
            this.btn327.Size = new System.Drawing.Size(75, 23);
            this.btn327.TabIndex = 35;
            this.btn327.Text = "327";
            this.btn327.UseVisualStyleBackColor = true;
            this.btn327.Click += new System.EventHandler(this.btn327_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(372, 125);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(137, 31);
            this.button9.TabIndex = 36;
            this.button9.Text = "329plane-256color";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(375, 170);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(133, 31);
            this.button10.TabIndex = 37;
            this.button10.Text = "331 AllPlaneClear";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(375, 213);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(133, 45);
            this.button11.TabIndex = 38;
            this.button11.Text = "336 back ground color setting";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(375, 269);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(128, 44);
            this.button12.TabIndex = 39;
            this.button12.Text = "334window plane clear";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // btn_vg876_portsave
            // 
            this.btn_vg876_portsave.Location = new System.Drawing.Point(475, 82);
            this.btn_vg876_portsave.Name = "btn_vg876_portsave";
            this.btn_vg876_portsave.Size = new System.Drawing.Size(75, 23);
            this.btn_vg876_portsave.TabIndex = 40;
            this.btn_vg876_portsave.Text = "保存端口号";
            this.btn_vg876_portsave.UseVisualStyleBackColor = true;
            this.btn_vg876_portsave.Click += new System.EventHandler(this.btn_vg876_portsave_Click);
            // 
            // Form_VG876
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 479);
            this.Controls.Add(this.btn_vg876_portsave);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.btn327);
            this.Controls.Add(this.btn_back_ground_color336);
            this.Controls.Add(this.btn_graphic_plane_plalette644);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.btn_win_color);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_rgb_add10);
            this.Controls.Add(this.btn_rgv_add1);
            this.Controls.Add(this.btn_set_rgb);
            this.Controls.Add(this.btn_mode_window);
            this.Controls.Add(this.tb_b);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_g);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_r);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_50gray);
            this.Controls.Add(this.brn_black);
            this.Controls.Add(this.btn_blue);
            this.Controls.Add(this.btn_green);
            this.Controls.Add(this.btn_red);
            this.Controls.Add(this.btn_white);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_memo);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.cmb_serialPort);
            this.Controls.Add(this.label1);
            this.Name = "Form_VG876";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_VG876";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_VG876_FormClosing);
            this.Load += new System.EventHandler(this.Form_VG876_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_serialPort;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.TextBox tb_memo;
        private System.IO.Ports.SerialPort serialPort_VG876;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_white;
        private System.Windows.Forms.Button btn_red;
        private System.Windows.Forms.Button btn_green;
        private System.Windows.Forms.Button btn_blue;
        private System.Windows.Forms.Button brn_black;
        private System.Windows.Forms.Button btn_50gray;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_r;
        private System.Windows.Forms.TextBox tb_g;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_b;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_mode_window;
        private System.Windows.Forms.Button btn_set_rgb;
        private System.Windows.Forms.Button btn_rgv_add1;
        private System.Windows.Forms.Button btn_rgb_add10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btn_win_color;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button btn_graphic_plane_plalette644;
        private System.Windows.Forms.Button btn_back_ground_color336;
        private System.Windows.Forms.Button btn327;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button btn_vg876_portsave;
    }
}