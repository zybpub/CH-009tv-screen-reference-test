using System;
using System.Timers;
using System.Windows.Forms;

namespace Test_Automation
{
    public partial class Form_control : Form
    {
        private HslCommunication.ModBus.ModbusTcpNet PLC;
        MySql.Data.MySqlClient.MySqlConnection conn;
        System.Timers.Timer timer_get_current_position;
        public Form_control()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form_control_Load(object sender, EventArgs e)
        {
            SOFT_VER.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            config_json.config_json_readall();

            tb_ip.Text = config_json.PLC_IP;

            timer_get_current_position = new System.Timers.Timer(1000);
            timer_get_current_position.Elapsed += new System.Timers.ElapsedEventHandler(timer_get_current_position_Tick);
            timer_get_current_position.AutoReset = false;
            timer_get_current_position.Enabled = false;

            conn =
           new MySql.Data.MySqlClient.MySqlConnection(
               "Database=" + config_json.mysql_database_name + ";" +
               "Data Source=" + config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");

            加载产商和型号();

            //btn_plc_connect_Click(null, null);
        }

        private void timer_get_current_position_Tick(object sender, ElapsedEventArgs e)
        {
            if (plc_connected)
            {
                tb_nowX.Text = (PLC.ReadInt32(config_json.X轴当前位置a).Content / 1000).ToString();
                tb_nowY.Text = (PLC.ReadInt32(config_json.Y轴当前位置a).Content / 1000).ToString();
                tb_nowZ.Text = (PLC.ReadInt32(config_json.Z轴当前位置a).Content / 1000).ToString();
                timer_get_current_position.Enabled = true;
            }
        }

        private void 加载产商和型号()
        {
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select distinct 生产厂商 from  产品参数", conn);
            MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbb生产厂商.Items.Add(dr[0].ToString());
            }
            dr.Close();
            conn.Close();
            if (cbb生产厂商.Items.Count > 0) cbb生产厂商.SelectedIndex = 0;
            cbb生产厂商_SelectedIndexChanged(null,null);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(config_json.config_file_path))
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo("d:\\软件配置");
                if (di.Exists == false) di.Create();

                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(config_json.config_file_path, true))
                {
                    writer.WriteLine("{}");
                    writer.Close();
                }
            }
            string json = System.IO.File.ReadAllText(config_json.config_file_path);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            jsonObj["夹持系统PLC地址"] = tb_ip.Text;

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(config_json.config_file_path, output);

            //update config content to variant
            config_json.config_json_readall();

            MessageBox.Show("保存成功！");
        }

        private void btn_plc_connect_Click(object sender, EventArgs e)
        {
            PLC = new HslCommunication.ModBus.ModbusTcpNet(tb_ip.Text, 502, 1);   // 站号1
            PLC.AddressStartWithZero = true;
            PLC.DataFormat = HslCommunication.Core.DataFormat.CDAB;

            HslCommunication.OperateResult resut = PLC.ConnectServer();

            if (resut.IsSuccess)
            {
                tb_memo.Text += "已成功连接PLC:"+ tb_ip .Text+ "\r\n";
                btn_plc_connect.Enabled = false;
                plc_connected = true;
            }
            else
            {
                tb_memo.Text += "连接PLC失败:" + tb_ip.Text +"\r\n";
                btn_plc_connect.Enabled = true;
            }
        }

            
      
        private void button1_Click(object sender, EventArgs e)
        {
            tb_memo.Text = "";
        }

        private void btn_readall_Click(object sender, EventArgs e)
        {

        }

       
        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_Y轴复位位置_Click(object sender, EventArgs e)
        {

        }

        private void btn_Z轴复位位置_Click(object sender, EventArgs e)
        {

        }

        private void btn_R轴复位位置_Click(object sender, EventArgs e)
        {

        }

        private void btn_reset_Click(object sender, EventArgs e)
        {

        }

        private void btnx_n10_Click(object sender, EventArgs e)
        {
            if (plc_connected == false) btn_plc_connect_Click(null, null);
            HslCommunication.OperateResult opresult = PLC.Write( config_json.X轴相对运动坐标写入a, -10000);
            HslCommunication.OperateResult opresult2 = PLC.Write(config_json.X轴相对运动启动a, 1);
            if (opresult.IsSuccess) tb_memo.Text += "成功\r\n";
            else tb_memo.Text += "失败\r\n";
        }

        private void btnx_n50_Click(object sender, EventArgs e)
        {
            if (plc_connected == false) btn_plc_connect_Click(null, null);
            HslCommunication.OperateResult opresult = PLC.Write(config_json.X轴相对运动坐标写入a, -50000);
            HslCommunication.OperateResult opresult2 = PLC.Write(config_json.X轴相对运动启动a, 1);
            if (opresult.IsSuccess) tb_memo.Text += "成功\r\n";
            else tb_memo.Text += "失败\r\n";
        }

        private void btnx_p10_Click(object sender, EventArgs e)
        {
            if (plc_connected == false) btn_plc_connect_Click(null, null);
            HslCommunication.OperateResult opresult = PLC.Write(config_json.X轴相对运动坐标写入a, 10000);
            HslCommunication.OperateResult opresult2 = PLC.Write(config_json.X轴相对运动启动a, 1);
            if (opresult.IsSuccess) tb_memo.Text += "成功\r\n";
            else tb_memo.Text += "失败\r\n";
        }

        private void btnx_p50_Click(object sender, EventArgs e)
        {
            if (plc_connected == false) btn_plc_connect_Click(null, null);
            HslCommunication.OperateResult opresult = PLC.Write(config_json.X轴相对运动坐标写入a, 50000);
            HslCommunication.OperateResult opresult2 = PLC.Write(config_json.X轴相对运动启动a, 1);
            if (opresult.IsSuccess) tb_memo.Text += "成功\r\n";
            else tb_memo.Text += "失败\r\n";
        }

        private void btny_p10_Click(object sender, EventArgs e)
        {
            if (plc_connected == false) btn_plc_connect_Click(null, null);
            HslCommunication.OperateResult opresult = PLC.Write(config_json.Y轴相对运动坐标写入a, 10000);
            HslCommunication.OperateResult opresult2 = PLC.Write(config_json.Y轴相对运动启动a, 1);
            if (opresult.IsSuccess) tb_memo.Text += "成功\r\n";
            else tb_memo.Text += "失败\r\n";
        }

        private void btny_p50_Click(object sender, EventArgs e)
        {
            if (plc_connected == false) btn_plc_connect_Click(null, null);
            HslCommunication.OperateResult opresult = PLC.Write(config_json.Y轴相对运动坐标写入a, 50000);
            HslCommunication.OperateResult opresult2 = PLC.Write(config_json.Y轴相对运动启动a, 1);
            if (opresult.IsSuccess) tb_memo.Text += "成功\r\n";
            else tb_memo.Text += "失败\r\n";
        }

        private void btny_n10_Click(object sender, EventArgs e)
        {
            if (plc_connected == false) btn_plc_connect_Click(null, null);
            HslCommunication.OperateResult opresult = PLC.Write(config_json.Y轴相对运动坐标写入a, -10000);
            HslCommunication.OperateResult opresult2 = PLC.Write(config_json.Y轴相对运动启动a, 1);
            if (opresult.IsSuccess) tb_memo.Text += "成功\r\n";
            else tb_memo.Text += "失败\r\n";
        }

        private void btny_n50_Click(object sender, EventArgs e)
        {
            if (plc_connected == false) btn_plc_connect_Click(null, null);
            HslCommunication.OperateResult opresult = PLC.Write(config_json.Y轴相对运动坐标写入a, -50000);
            HslCommunication.OperateResult opresult2 = PLC.Write(config_json.Y轴相对运动启动a, 1);
            if (opresult.IsSuccess) tb_memo.Text += "成功\r\n";
            else tb_memo.Text += "失败\r\n";
        }

        private void btnz_p10_Click(object sender, EventArgs e)
        {
            if (plc_connected == false) btn_plc_connect_Click(null, null);
            HslCommunication.OperateResult opresult = PLC.Write(config_json.Z轴相对运动坐标写入a, 10000);
            HslCommunication.OperateResult opresult2 = PLC.Write(config_json.Z轴相对运动启动a, 1);
            if (opresult.IsSuccess) tb_memo.Text += "成功\r\n";
            else tb_memo.Text += "失败\r\n";
        }

        private void btnz_p50_Click(object sender, EventArgs e)
        {
            if (plc_connected == false) btn_plc_connect_Click(null, null);
            HslCommunication.OperateResult opresult = PLC.Write(config_json.Z轴相对运动坐标写入a, 50000);
            HslCommunication.OperateResult opresult2 = PLC.Write(config_json.Z轴相对运动启动a, 1);
            if (opresult.IsSuccess) tb_memo.Text += "成功\r\n";
            else tb_memo.Text += "失败\r\n";
        }

        private void btnz_n10_Click(object sender, EventArgs e)
        {
            if (plc_connected == false) btn_plc_connect_Click(null, null);
            HslCommunication.OperateResult opresult = PLC.Write(config_json.Z轴相对运动坐标写入a, -10000);
            HslCommunication.OperateResult opresult2 = PLC.Write(config_json.Z轴相对运动启动a, 1);
            if (opresult.IsSuccess) tb_memo.Text += "成功\r\n";
            else tb_memo.Text += "失败\r\n";
        }

        private void btnz_n50_Click(object sender, EventArgs e)
        {
            if (plc_connected == false) btn_plc_connect_Click(null, null);
            HslCommunication.OperateResult opresult = PLC.Write(config_json.Z轴相对运动坐标写入a, -50000);
            HslCommunication.OperateResult opresult2 = PLC.Write(config_json.Z轴相对运动启动a, 1);
            if (opresult.IsSuccess) tb_memo.Text += "成功\r\n";
            else tb_memo.Text += "失败\r\n";
        }

        private void btnr_p10_Click(object sender, EventArgs e)
        {
            if (plc_connected == false) btn_plc_connect_Click(null, null);
            HslCommunication.OperateResult opresult = PLC.Write(config_json.R轴相对运动坐标写入a, 10000);
            HslCommunication.OperateResult opresult2 = PLC.Write(config_json.R轴相对运动启动a, 1);
            if (opresult.IsSuccess) tb_memo.Text += "成功\r\n";
            else tb_memo.Text += "失败\r\n";
        }

        private void btnr_p50_Click(object sender, EventArgs e)
        {
            if (plc_connected == false) btn_plc_connect_Click(null, null);
            HslCommunication.OperateResult opresult = PLC.Write(config_json.R轴相对运动坐标写入a, 50000);
            HslCommunication.OperateResult opresult2 = PLC.Write(config_json.R轴相对运动启动a, 1);
            if (opresult.IsSuccess) tb_memo.Text += "成功\r\n";
            else tb_memo.Text += "失败\r\n";

        }

        private void btnr_n10_Click(object sender, EventArgs e)
        {
            if (plc_connected == false) btn_plc_connect_Click(null, null);
            HslCommunication.OperateResult opresult = PLC.Write(config_json.R轴相对运动坐标写入a, -10000);
            HslCommunication.OperateResult opresult2 = PLC.Write(config_json.R轴相对运动启动a, 1);
            if (opresult.IsSuccess) tb_memo.Text += "成功\r\n";
            else tb_memo.Text += "失败\r\n";
        }

        private void btnr_n50_Click(object sender, EventArgs e)
        {
            if (plc_connected == false) btn_plc_connect_Click(null, null);
            HslCommunication.OperateResult opresult = PLC.Write(config_json.R轴相对运动坐标写入a, -50000);
            HslCommunication.OperateResult opresult2 = PLC.Write(config_json.R轴相对运动启动a, 1);
            if (opresult.IsSuccess) tb_memo.Text += "成功\r\n";
            else tb_memo.Text += "失败\r\n";
        }


        private void btn_save_Click_1(object sender, EventArgs e)
        {
            config_json.save("PLC_IP",tb_ip.Text);
        }
        bool plc_connected = false;
        private void btn_get_current_position_Click(object sender, EventArgs e)
        {
            if (plc_connected)
            {
                tb_nowX.Text = PLC.ReadInt32(config_json.X轴当前位置a).Content.ToString();
                tb_nowY.Text = PLC.ReadInt32(config_json.Y轴当前位置a).Content.ToString();
                tb_nowZ.Text = PLC.ReadInt32(config_json.Z轴当前位置a).Content.ToString();
                tb_memo.Text += "X轴当前位置:" + tb_nowX.Text + "\r\n";
                tb_memo.Text += "Y轴当前位置:" + tb_nowY.Text + "\r\n";
                tb_memo.Text += "Z轴当前位置:" + tb_nowZ.Text + "\r\n";
                timer_get_current_position.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (plc_connected == false) plc_connect();
            if (plc_connected == false) return;
            PLC.Write(config_json.X轴复位位置a, Convert.ToInt32(tb_x.Text));
            PLC.Write(config_json.Y轴复位位置a, Convert.ToInt32(tb_y.Text));
            PLC.Write(config_json.Z轴复位位置a, Convert.ToInt32(tb_z.Text));
            PLC.Write(config_json.复位写入, 1);
        }
        void plc_connect()
        {
            PLC = new HslCommunication.ModBus.ModbusTcpNet(config_json.PLC_IP);   // 站号1
            PLC.AddressStartWithZero = true;
            PLC.DataFormat = HslCommunication.Core.DataFormat.CDAB;

            HslCommunication.OperateResult resut = PLC.ConnectServer();
            if (resut.IsSuccess)
            {
                tb_memo.Text += "PLC连接成功！";
                plc_connected = true;
            }
            else
            {
                tb_memo.Text += "PLC连接失败！";
            }
        }

        private void btn_plc_disconnect_Click(object sender, EventArgs e)
        {
            PLC.ConnectClose();
            btn_plc_connect.Enabled = true;
            plc_connected = false;
        }

        private void tb_memo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_save_center_Click(object sender, EventArgs e)
        {
            conn.Open();
            //检查厂商型号是否已存在
            MySql.Data.MySqlClient.MySqlCommand cmd =
                new MySql.Data.MySqlClient.MySqlCommand("select id from  产品参数 where 生产厂商='"+cbb生产厂商.Text+"' and  产品型号='" + cbb产品型号.Text + "'", conn);
            MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) //已存在则更新
            {
                dr.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd2 =
               new MySql.Data.MySqlClient.MySqlCommand("update  产品参数 set 中心坐标='" + tb_x.Text + "," + tb_y.Text + "," + tb_z.Text + "',屏幕大小='"+tb_inch.Text+"',屏幕宽='"+tb_width.Text+"',屏幕高='"+tb_height.Text+ "' where 生产厂商='" + cbb生产厂商.Text + "' and 产品型号='" + cbb产品型号.Text + "'", conn);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("已更新");
            }
            else // 不存在则添加
            {
                dr.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd3 =
                  new MySql.Data.MySqlClient.MySqlCommand("insert into  产品参数 (生产厂商,产品型号,屏幕大小,中心坐标,屏幕宽,屏幕高) values('" + cbb生产厂商.Text + "','" + cbb产品型号.Text + "','" + tb_inch.Text + "','" + tb_x.Text + "," + tb_y.Text + "," + tb_z.Text + "','"+tb_width.Text + "','" + tb_height.Text + "')", conn);
                cmd3.ExecuteNonQuery();
                MessageBox.Show("已添加");

            }
            conn.Close();
            config_json.save("X轴原点位置v", tb_x.Text);
            config_json.save("Y轴原点位置v", tb_y.Text);
            config_json.save("Z轴原点位置v", tb_z.Text);
          
        }

        private void cbb生产厂商_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb产品型号.Items.Clear();
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select distinct 产品型号 from  产品参数 where 生产厂商='"+cbb生产厂商.Text+"'", conn);
            MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbb产品型号.Items.Add(dr[0].ToString());
            }
            dr.Close();
            conn.Close();
            if (cbb产品型号.Items.Count > 0 ) cbb产品型号.SelectedIndex = 0;
        }

        private void cbb产品型号_SelectedIndexChanged(object sender, EventArgs e)
        {

            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select distinct 中心坐标,屏幕宽,屏幕高,屏幕大小 from  产品参数 where 生产厂商='" + cbb生产厂商.Text + "' and 产品型号='"+cbb产品型号.Text+"'", conn);
            MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string[] cor=dr[0].ToString().Split(',');
                if (cor.Length==3)
                {
                    tb_x.Text = cor[0];
                    tb_y.Text = cor[1];
                    tb_z.Text = cor[2];
                    tb_width.Text = dr[1].ToString();
                    tb_height.Text = dr[2].ToString();
                    tb_inch.Text = dr[3].ToString();
                }

            }
            dr.Close();
            conn.Close();
            if (cbb产品型号.Items.Count > 0 && cbb产品型号.Text=="") cbb产品型号.SelectedIndex = 0;
        }

        //输入英寸自动计算屏幕宽/高
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void tb_inch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;


            //小数点的处理。

            if (e.KeyChar == 46)                           //小数点
            {
                if (tb_inch.Text.Length == 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(tb_inch.Text, out oldf);
                    b2 = float.TryParse(tb_inch.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void btn_count_zero_Click(object sender, EventArgs e)
        {
            tb_x.Text = ( Convert.ToDouble(tb_height.Text) * 3).ToString();
            tb_y.Text = ((int)(-Convert.ToDouble(tb_width.Text) / 2 + Convert.ToDouble(tb_width.Text) / 32)).ToString("0.0");
            tb_z.Text = ((int)(Convert.ToDouble(tb_height.Text) - Convert.ToDouble(tb_height.Text) / 20)).ToString("0.0");
        }

        private void btn_setcenter_Click(object sender, EventArgs e)
        {
            tb_x.Text = tb_nowX.Text;
            tb_y.Text = tb_nowY.Text;
            tb_z.Text = tb_nowZ.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tb_inch.Text.Trim() != "")
            {
                double y = Convert.ToDouble(tb_inch.Text) * 25.4;
                double x = Math.Sqrt(y * y / 347 * 256);
                tb_width.Text = x.ToString("0.0");
                tb_height.Text = (x / 16 * 9).ToString("0.0");
            }
        }
    }
}
