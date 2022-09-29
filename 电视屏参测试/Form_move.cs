using System;
using System.Windows.Forms;

namespace Test_Automation
{
    public partial class Form_move : Form
    {
        private HslCommunication.ModBus.ModbusTcpNet PLC;
        public Form_move()
        {
            InitializeComponent();
        }
        private void btn_connect_Click(object sender, EventArgs e)
        {
            PLC = new HslCommunication.ModBus.ModbusTcpNet(config_json.PLC_IP, 502, 1);   // 站号1

            HslCommunication.OperateResult resut = PLC.ConnectServer();
            if (resut.IsSuccess)
            {
                tb_log.Text += "已成功连接PLC\r\n";
            }
            else
            {
                tb_log.Text += "连接PLC失败\r\n";
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            X轴当前位置.Text = PLC.ReadInt32(config_json.X轴当前位置a).Content.ToString();
            Y轴当前位置.Text = PLC.ReadInt32(config_json.Y轴当前位置a).Content.ToString();
            Z轴当前位置.Text = PLC.ReadInt32(config_json.Z轴当前位置a).Content.ToString();
            R轴当前位置.Text = PLC.ReadInt32(config_json.R轴当前位置a).Content.ToString();
        }

        private void Form_move_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PLC.Write(config_json.X轴相对运动坐标写入a, -1000);
            X轴当前位置.Text = (Convert.ToInt32(X轴当前位置.Text) -1000).ToString();
            PLC.Write(config_json.X轴相对运动启动a, Convert.ToInt32(1));
        }

        //X轴+毫米运动
        private void button3_Click(object sender, EventArgs e)
        {
            PLC.Write(config_json.X轴相对运动坐标写入a,  1000);
            X轴当前位置.Text = (Convert.ToInt32(X轴当前位置.Text) + 1000).ToString();
            PLC.Write(config_json.X轴相对运动启动a, Convert.ToInt32(1));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PLC.Write(config_json.X轴相对运动坐标写入a, 10000);
            X轴当前位置.Text = (Convert.ToInt32(X轴当前位置.Text) + 10000).ToString();
            PLC.Write(config_json.X轴相对运动启动a, Convert.ToInt32(1));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PLC.Write(config_json.X轴相对运动坐标写入a,-10000);
            X轴当前位置.Text = (Convert.ToInt32(X轴当前位置.Text) - 10000).ToString();
            PLC.Write(config_json.X轴相对运动启动a, Convert.ToInt32(1));
        }

       
    }
}
