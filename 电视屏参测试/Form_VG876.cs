using System;
using System.Linq;
using System.Windows.Forms;

namespace Test_Automation
{
    public partial class Form_VG876 : Form
    {
        public Form_VG876()
        {
            InitializeComponent();
        }

        private void Form_VG876_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            config_json.config_json_readall();
            foreach (string com in System.IO.Ports.SerialPort.GetPortNames()) //自动获取串行口名称
            {
                cmb_serialPort.Items.Add(com);
            }
            try { cmb_serialPort.Text = config_json.VG870_PortName; } catch { }
            this.serialPort_VG876.BaudRate = 38400;
            btn_open_Click(null, null);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            if (serialPort_VG876.IsOpen) {
                serialPort_VG876.Close();
                tb_memo.Text = "端口关闭成功！";
                btn_open.Enabled = true;
            }
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            if (serialPort_VG876.IsOpen == false) {
                tb_memo.Text += "端口已打开成功！";
                serialPort_VG876.Open();
                btn_open.Enabled = false;
            }
            else
            { tb_memo.Text += "端口已打开或被占用！"; }
        }

        private void btn_white_Click(object sender, EventArgs e)
        {
            if (serialPort_VG876.IsOpen == false) serialPort_VG876.Open();
            try { serialPort_VG876.Write(config_json.pattern_white, 0, config_json.pattern_white.Length); } catch { }
        }

        private void btn_red_Click(object sender, EventArgs e)
        {
            if (serialPort_VG876.IsOpen == false) serialPort_VG876.Open();
            try
            {
                serialPort_VG876.Write(config_json.pattern_red, 0, config_json.pattern_white.Length);
            }
            catch { }
        }

        private void btn_green_Click(object sender, EventArgs e)
        {
            if (serialPort_VG876.IsOpen == false) serialPort_VG876.Open();
            try
            {
                serialPort_VG876.Write(config_json.pattern_green, 0, config_json.pattern_white.Length);
            }
            catch { }
        }

        private void btn_blue_Click(object sender, EventArgs e)
        {
            if (serialPort_VG876.IsOpen == false) serialPort_VG876.Open();
            try
            {
                serialPort_VG876.Write(config_json.pattern_blue, 0, config_json.pattern_white.Length);
            }
            catch { }
        }

        private void brn_black_Click(object sender, EventArgs e)
        {
            if (serialPort_VG876.IsOpen == false) serialPort_VG876.Open();
            try
            {
                serialPort_VG876.Write(config_json.pattern_black, 0, config_json.pattern_white.Length);
            }
            catch { }
        }

        private void btn_50gray_Click(object sender, EventArgs e)
        {
            if (serialPort_VG876.IsOpen == false) serialPort_VG876.Open();
            try
            {
                serialPort_VG876.Write(config_json.pattern_50gray, 0, config_json.pattern_white.Length);
            }
            catch { }
        }

        private void Form_VG876_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort_VG876.IsOpen == false) serialPort_VG876.Open();
            try
            {
                if (serialPort_VG876.IsOpen) serialPort_VG876.Close();
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (serialPort_VG876.IsOpen == false) serialPort_VG876.Open();
            try
            {
                serialPort_VG876.Write(config_json.pattern_window, 0, config_json.pattern_window.Length);
            }
            catch { }
        }

        private void btn_set_rgb_Click(object sender, EventArgs e)
        {
            if (serialPort_VG876.IsOpen == false) serialPort_VG876.Open();
            try
            {
                serialPort_VG876.Write(config_json.pattern_plane_pre, 0, config_json.pattern_plane_pre.Length);
                char[] ch = (tb_r.Text + "," + tb_g.Text + "," + tb_b.Text).ToCharArray();
                byte[] value = System.Text.Encoding.ASCII.GetBytes(ch);
                //byte[] value =System.Text.Encoding.UTF8.GetBytes(tb_r.Text + "," + tb_g.Text + "," + tb_b.Text);
                serialPort_VG876.Write(value, 0, value.Length);
                //serialPort_VG876.Write(tb_r.Text + "," + tb_g.Text + "," + tb_b.Text);
                serialPort_VG876.Write(config_json.pattern_window_color_end, 0, config_json.pattern_window_color_end.Length);
            }
            catch { }
        }

        private void btn_rgv_add1_Click(object sender, EventArgs e)
        {
            tb_r.Text= (Convert.ToInt16(tb_r.Text) + 1).ToString();
            tb_g.Text = (Convert.ToInt16(tb_g.Text) + 1).ToString();
            tb_b.Text = (Convert.ToInt16(tb_b.Text) + 1).ToString();
        }

        private void btn_rgb_add10_Click(object sender, EventArgs e)
        {
            tb_r.Text = (Convert.ToInt16(tb_r.Text) + 10).ToString();
            tb_g.Text = (Convert.ToInt16(tb_g.Text) + 10).ToString();
            tb_b.Text = (Convert.ToInt16(tb_b.Text) + 10).ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tb_r.Text = (Convert.ToInt16(tb_r.Text) + 10).ToString();
            tb_g.Text = (Convert.ToInt16(tb_g.Text) + 10).ToString();
            tb_b.Text = (Convert.ToInt16(tb_b.Text) + 10).ToString();
            button7_Click(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (serialPort_VG876.IsOpen == false) serialPort_VG876.Open();
            try
            {
                serialPort_VG876.Write(config_json.pattern_window_color_155, 0, config_json.pattern_window_color_155.Length);
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tb_r.Text = (Convert.ToInt16(tb_r.Text) + 1).ToString();
            tb_g.Text = (Convert.ToInt16(tb_g.Text) + 1).ToString();
            tb_b.Text = (Convert.ToInt16(tb_b.Text) + 1).ToString();
            button7_Click(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tb_r.Text = "0";
            tb_g.Text = "0";
            tb_b.Text = "0";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tb_r.Text = "128";
            tb_g.Text = "128";
            tb_b.Text = "128";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tb_r.Text = "255";
            tb_g.Text = "255";
            tb_b.Text = "255";
        }

        private void serialPort_VG876_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            System.Threading.Thread.Sleep(100);

            int n = serialPort_VG876.BytesToRead;
            byte[] buf = new byte[n];
            serialPort_VG876.Read(buf, 0, n);
            tb_memo.Text+= byteToHexStr(buf);
        }
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2") + " ";
                }
            }
            return returnStr;
        }
        //7
        private void button7_Click(object sender, EventArgs e)
        {

                serialPort_VG876.Write(config_json.pattern_window_color_pre, 0, config_json.pattern_window_color_pre.Length);
                serialPort_VG876.Write(tb_r.Text + "," + tb_g.Text + "," + tb_b.Text);
                serialPort_VG876.Write(config_json.pattern_window_color_end, 0, config_json.pattern_window_color_end.Length);

        }

        private void btn_back_ground_color336_Click(object sender, EventArgs e)
        {
            serialPort_VG876.Write(config_json.back_ground_color336_pre, 0, config_json.back_ground_color336_pre.Length);
            char[] ch = (tb_r.Text + "," + tb_g.Text + "," + tb_b.Text).ToCharArray();
            byte[] value = System.Text.Encoding.ASCII.GetBytes(ch);
            serialPort_VG876.Write(value, 0, value.Length);
            serialPort_VG876.Write(config_json.back_ground_color336_end, 0, config_json.back_ground_color336_end.Length);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (serialPort_VG876.IsOpen == false) serialPort_VG876.Open();
            try
            {
                serialPort_VG876.Write(config_json.pattern_color_pre, 0, config_json.pattern_color_pre.Length);
                char[] ch = (tb_r.Text + "," + tb_g.Text + "," + tb_b.Text).ToCharArray();
                byte[] value = System.Text.Encoding.ASCII.GetBytes(ch);
                //byte[] value =System.Text.Encoding.UTF8.GetBytes(tb_r.Text + "," + tb_g.Text + "," + tb_b.Text);
                serialPort_VG876.Write(value, 0, value.Length);
                //serialPort_VG876.Write(tb_r.Text + "," + tb_g.Text + "," + tb_b.Text);
                serialPort_VG876.Write(config_json.pattern_color_end, 0, config_json.pattern_color_end.Length);
            }
            catch { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            serialPort_VG876.Write(config_json.pattern_color_1, 0, config_json.pattern_color_1.Length);
            
        }

        private void btn_graphic_plane_plalette644_Click(object sender, EventArgs e)
        {
            serialPort_VG876.Write(config_json.graphic_plane_plalette644, 0, config_json.graphic_plane_plalette644.Length);
            
        }

        private void btn327_Click(object sender, EventArgs e)
        {
            serialPort_VG876.Write(config_json.back327_pre, 0, config_json.back327_pre.Length);
            char[] ch = (tb_r.Text + "," + tb_g.Text + "," + tb_b.Text).ToCharArray();
            byte[] value = System.Text.Encoding.ASCII.GetBytes(ch);
            serialPort_VG876.Write(value, 0, value.Length);
            serialPort_VG876.Write(config_json.back327_end, 0, config_json.back327_end.Length);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            byte[] b = new byte[] {0x02,0xfd,0x28,0x4e,0x30,0x03 };
            serialPort_VG876.Write(b, 0, b.Length);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            byte[] b = new byte[] { 0x02, 0xfd, 0x28, 0x60, 0x03 };
            serialPort_VG876.Write(b, 0, b.Length);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            byte[] b = new byte[] { 0x02, 0xfd, 0x28, 0x60, 0x03 };
            serialPort_VG876.Write(b, 0, b.Length);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            byte[] b = new byte[] { 0x02, 0xfd, 0x28, 0x63, 0x03 };
            serialPort_VG876.Write(b, 0, b.Length);
        }

        private void btn_vg876_portsave_Click(object sender, EventArgs e)
        {
            config_json.save("VG870_PortName", cmb_serialPort.Text);
        }
    }
}
