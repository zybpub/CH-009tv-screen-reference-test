using Aspose.Words;
using CASDK2;
using System;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace Test_Automation
{
    public partial class Form_Gamma_CA410_SDK2net : Form
    {
        public Form_Gamma_CA410_SDK2net()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        static CASDK2Ca200 objCa200;
        static CASDK2Cas objCas;
        static CASDK2Ca objCa;
        static CASDK2Probes objProbes;
        static CASDK2OutputProbes objOutputProbes;
        static CASDK2Probe objProbe;
        static CASDK2Memory objMemory;
        static int err = 0;
        static double SX;
        static double SY;
        static double Lv;
        static bool ca410detected = false;

        AutoResetEvent autoreset;

        System.Timers.Timer timer_check_move_finished, timer_delay;
        System.Timers.Timer timer_get_current_position;
        HslCommunication.ModBus.ModbusTcpNet PLC;

        string chech_axis = "x";
        float delay_seconds = 1.0F;  //两次测试间隔时间

        bool plc_connected = false;
        int test_num = 0;
        float[] result = new float[256];
        bool testing = false;
        double test_a = 0, test_b = 0;

        AutoResetEvent VG870_reset_event_06;  //等待VG870回复06
        string VG870_reply = "";

        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        void Test_Main() {
            while (test_num <= 255 && testing) {
                lb_test_num.Text = test_num.ToString();
                //发送RGB到VG876
                serialPort_VG876.Write(config_json.pattern_window_color_pre, 0, config_json.pattern_window_color_pre.Length);
                serialPort_VG876.Write(test_num.ToString() + "," + test_num.ToString() + "," + test_num.ToString());
                serialPort_VG876.Write(config_json.pattern_window_color_end, 0, config_json.pattern_window_color_end.Length);
                addmemo("发送"+test_num.ToString()+"到VG870,等待响应");
                VG870_reset_event_06.WaitOne();

                //延时
                timer_delay.Enabled = true;
                autoreset.WaitOne();

                //读取亮度
                objCa.Measure();
               // objProbe.get_sx(ref SX);
              //  objProbe.get_sy(ref SY);
                objProbe.get_Lv(ref Lv);

                test_a = Lv;
                lb_lv.Text = Lv.ToString("0.00");
                addmemo("获取亮度1：" + lb_lv.Text);

                timer_delay.Enabled = true;
                autoreset.WaitOne();
                //读取亮度
                objCa.Measure();
                // objProbe.get_sx(ref SX);
                //  objProbe.get_sy(ref SY);
                objProbe.get_Lv(ref Lv);
                test_b = Lv;
                lb_lv.Text = Lv.ToString("0.00");
                addmemo("获取亮度2：" + lb_lv.Text);
                int diff = (int)(Math.Abs(test_a - test_b) / test_b * 1000);
               addmemo("两次读数差异" + ((float)diff / 10).ToString());
                while (diff > 10)
                {
                    addmemo("两次读数已超过1%，再次读数");
                    test_a = test_b;

                    timer_delay.Enabled = true;
                    autoreset.WaitOne();
                    //读取亮度
                    objCa.Measure();
                    // objProbe.get_sx(ref SX);
                    //  objProbe.get_sy(ref SY);
                    objProbe.get_Lv(ref Lv);
                    lb_lv.Text = Lv.ToString("0.00");
                    addmemo("获取新的亮度："+ lb_lv.Text);
                    test_b = Lv;
                    diff = (int)(Math.Abs(test_a - test_b) / test_b * 1000);
                    addmemo("两次读数差异" + ((float)diff / 10).ToString());
                }
                addmemo("两次读数差异小于1%");
                addmemo(test_num.ToString()+"," +Lv.ToString());
                result[test_num] =(float) Lv;
                tb_result.AppendText(lb_test_num.Text + "," + lb_lv.Text + "\r\n");
                tb_result.ScrollToCaret();
                userCurve1.SetLeftCurve("A", result, System.Drawing.Color.Green);
                test_num++;
            }
            if (testing == false) {
                MessageBox.Show("测试已停止");
            }
            if (test_num == 256)
            {
                addmemo("测试完成，发送黑场信号");
                serialPort_VG876.Write(config_json.pattern_black, 0, config_json.pattern_black.Length);
                savetomysql();
                btn_test_start.Enabled = true;
                MessageBox.Show("测试已完成");
            }
        }

        private void addmemo(string memo)
        {
            memo = DateTime.Now.ToString("[yyyy-M-d HH:mm:ss.fff] ") + memo + "\r\n";
            tb_memo.AppendText(memo);
            tb_memo.ScrollToCaret();
            logger.Info(memo);
        }
        float[] test_result = new float[256];
        public static MySql.Data.MySqlClient.MySqlConnection conn;
        string[] text = new string[256];
        private void Form_160_Load(object sender, EventArgs e)
        {
            config_json.config_json_readall();
            foreach (string com in System.IO.Ports.SerialPort.GetPortNames()) //自动获取串行口名称
            {
                cmb_serialPort.Items.Add(com);
            }
            try { cmb_serialPort.Text = config_json.VG870_PortName; } catch { }
            this.serialPort_VG876.BaudRate = 38400;

            con =
          new MySql.Data.MySqlClient.MySqlConnection(
              "Database=" + config_json.mysql_database_name + ";" +
              "Data Source=" + config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");

            tb_centerX.Text = config_json.X轴中心位置v;
            tb_centerY.Text = config_json.Y轴中心位置v;
            tb_centerZ.Text = config_json.Z轴中心位置v;

            timer_delay = new System.Timers.Timer(delay_seconds*1000);
            timer_delay.Elapsed += new System.Timers.ElapsedEventHandler(timer_delay_Tick);
            timer_delay.AutoReset = false;
            timer_delay.Enabled = false;

            PLC = new HslCommunication.ModBus.ModbusTcpNet(config_json.PLC_IP, 502, 1);
            PLC.AddressStartWithZero = true;
            PLC.DataFormat = HslCommunication.Core.DataFormat.CDAB;

            timer_check_move_finished = new System.Timers.Timer(200);
            timer_check_move_finished.Elapsed += new System.Timers.ElapsedEventHandler(timer_check_move_finished_Tick);
            timer_check_move_finished.AutoReset = false;
            timer_check_move_finished.Enabled = false;

            timer_get_current_position = new System.Timers.Timer(1000);
            timer_get_current_position.Elapsed += new System.Timers.ElapsedEventHandler(timer_get_current_position_Tick);
            timer_get_current_position.AutoReset = false;
            timer_get_current_position.Enabled = false;

            serialPort_VG876.PortName = config_json.VG870_PortName;
           
            conn =  new MySql.Data.MySqlClient.MySqlConnection(
             "Database=" + config_json.mysql_database_name + ";" +
             "Data Source=" + config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");
            LoadProducerData();

            userCurve1.SetLeftCurve("A", test_result, System.Drawing.Color.Green);
            for (int i = 0; i < 256; i++)
            {
                text[i] = i.ToString();
            }
            userCurve1.SetCurveText(text);
        }

        private void timer_delay_Tick(object sender, ElapsedEventArgs e)
        {
            autoreset.Set();
        }

        private void LoadProducerData()
        {
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select distinct 产品型号 from  产品参数", conn);
            MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbb_type.Items.Add(dr[0].ToString());
            }
            dr.Close();
            conn.Close();
            if (cbb_type.Items.Count > 0) cbb_type.SelectedIndex = 0;
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

        string check_move_value = "";
        private void timer_check_move_finished_Tick(object sender, ElapsedEventArgs e)
        {
            switch (chech_axis)
            {
                case "x":
                    check_move_value = PLC.ReadInt32(config_json.X轴相对运动完成a).Content.ToString();
                    if (check_move_value == "1") //移动到位
                    {
                        addmemo("x移动到位");
                        if (plc_action == "回到原点")
                        {
                            addmemo("X回到原点");
                            chech_axis = "y";
                            timer_check_move_finished.Enabled = true;
                            PLC.Write(config_json.X轴相对运动完成a, 0);
                            return;
                        }
                        timer_check_move_finished.Enabled = false;
                        PLC.Write(config_json.X轴相对运动完成a, 0);
                    }
                    else { timer_check_move_finished.Enabled = true; }
                    break;
                case "y":
                    check_move_value = PLC.ReadInt32(config_json.Y轴相对运动完成a).Content.ToString();
                    if (check_move_value == "1") //移动到位
                    {
                        addmemo("Y移动到位");
                        if (plc_action == "回到原点")
                        {
                            addmemo("Y回到原点");
                            chech_axis = "z";
                            timer_check_move_finished.Enabled = true;
                            PLC.Write(config_json.Y轴相对运动完成a, 0);
                            return;
                        }
                        timer_check_move_finished.Enabled = false;
                        PLC.Write(config_json.Y轴相对运动完成a, 0);
                    }
                    else { timer_check_move_finished.Enabled = true; }
                    break;
                case "z":
                    check_move_value = PLC.ReadInt32(config_json.Z轴相对运动完成a).Content.ToString();
                    if (check_move_value == "1") //移动到位
                    {
                        addmemo("Z移动到位");
                        if (plc_action == "回到原点")
                        {
                            chech_axis = "z";
                            timer_check_move_finished.Enabled = false;
                            addmemo("Z回到原点");
                            PLC.Write(config_json.Z轴相对运动完成a, 0);
                            return;
                        }

                        timer_check_move_finished.Enabled = false;
                        PLC.Write(config_json.Z轴相对运动完成a, 0);
                    }
                    else { timer_check_move_finished.Enabled = true; }
                    break;
                case "r":
                    check_move_value = PLC.ReadInt32(config_json.R轴相对运动完成a).Content.ToString();
                    if (check_move_value == "1") //移动到位
                    {
                        timer_check_move_finished.Enabled = false;
                        PLC.Write(config_json.R轴相对运动完成a, 0);
                    }
                    else { timer_check_move_finished.Enabled = true; }
                    break;
                default:
                    break;
            }

        }
        private void serialPort_VG870_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            int n = serialPort_VG876.BytesToRead;
            byte[] buf = new byte[n];
            serialPort_VG876.Read(buf, 0, n);
            VG870_reply = zyb_class.byteToHexStr(buf);
            addmemo("收到VG876回复："+ VG870_reply);
            if (VG870_reply.Contains("06")) VG870_reset_event_06.Set();
        }
        private void btn_test_stop_Click(object sender, EventArgs e)
        {
            testing = false;
            btn_test_start.Enabled = true;
        }
        public static MySql.Data.MySqlClient.MySqlConnection con;
        void savetomysql() {
            //保存到数据库
            try
            {
                con.Open();
                //检查厂商型号是否已存在
                MySql.Data.MySqlClient.MySqlCommand cmd =
                    new MySql.Data.MySqlClient.MySqlCommand("select id from  测试数据 where 测试编号='" + tb_test_proj.Text + "'", con);
                MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read()) //已存在则更新
                {
                    dr.Close();
                    MySql.Data.MySqlClient.MySqlCommand cmd2 =
                   new MySql.Data.MySqlClient.MySqlCommand("update  测试数据 set　gamma='" + string.Join(",", result) + "' where 测试编号='" + tb_test_proj.Text + "'", con);
                    //  cmd2.ExecuteNonQuery();
                }
                else // 不存在则添加
                {
                    dr.Close();
                    MySql.Data.MySqlClient.MySqlCommand cmd3 =
                      new MySql.Data.MySqlClient.MySqlCommand("insert into  测试数据 (测试编号,gamma) values('" + tb_test_proj.Text + "','" + string.Join(",", result) + "')", con);
                    cmd3.ExecuteNonQuery();

                }
                con.Close();
            }
            catch (Exception ex)
            {
                if (con.State == System.Data.ConnectionState.Open) con.Close();
                MessageBox.Show("保存到数据库出错：" + ex.Message);
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件(*.txt)|*.txt";
            sfd.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录
            sfd.RestoreDirectory = true;
            sfd.FileName = tb_test_proj.Text;

            //点了保存按钮进入
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = sfd.FileName.ToString(); 
                System.IO.StreamWriter sw2 = new System.IO.StreamWriter(localFilePath, true);
                sw2.Write("\r\n测试编号：" + tb_test_proj.Text + "\r\ngamma测试日志：\r\n" + tb_memo.Text + "\r\n");

                sw2.Write("gamma测试数据汇总：\r\n");
                for (int j = 0; j < 256; j++) { sw2.Write(j.ToString() + "," + result[j].ToString() + "\r\n"); }    
                sw2.Close();

                DialogResult dr = MessageBox.Show("是否需要立即打开文档？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(localFilePath);
                }
            }
        }
        private void btn_plc_connect_Click(object sender, EventArgs e)
        {
            HslCommunication.OperateResult resut = PLC.ConnectServer();
            if (resut.IsSuccess)
            {
                tb_memo.Text = "plc连接成功！";
                plc_connected = true;
                tb_nowX.Text = PLC.ReadInt32(config_json.X轴当前位置a).Content.ToString();
                tb_nowY.Text = PLC.ReadInt32(config_json.Y轴当前位置a).Content.ToString();
                tb_nowZ.Text = PLC.ReadInt32(config_json.Z轴当前位置a).Content.ToString();
                addmemo("X轴当前位置:" + tb_nowX.Text);
                addmemo("Y轴当前位置:" + tb_nowY.Text);
                addmemo("Z轴当前位置:" + tb_nowZ.Text);
                timer_get_current_position.Enabled = true;
            }
            else { MessageBox.Show("PLC连接失败，IP:" + config_json.PLC_IP); }
        }

        private void btn_plc_disconnect_Click(object sender, EventArgs e)
        {
            PLC.ConnectClose();
            plc_connected = false;
        }
        string plc_action = "";
        private void button7_Click(object sender, EventArgs e)
        {
            if (plc_connected == false)
            {
                plc_connect();
            }
            if (plc_connected == false) return;

            PLC.Write(config_json.X轴相对运动坐标写入a, (Convert.ToInt32(tb_centerX.Text) - Convert.ToInt32(tb_nowX.Text)) * 1000);
            PLC.Write(config_json.Y轴相对运动坐标写入a, (Convert.ToInt32(tb_centerY.Text) - Convert.ToInt32(tb_nowY.Text)) * 1000);
            PLC.Write(config_json.Z轴相对运动坐标写入a, (Convert.ToInt32(tb_centerZ.Text) - Convert.ToInt32(tb_nowZ.Text)) * 1000);
            PLC.Write(config_json.X轴相对运动启动a, 1);
            PLC.Write(config_json.Y轴相对运动启动a, 1);
            PLC.Write(config_json.Z轴相对运动启动a, 1);
            plc_action = "回到原点";
            chech_axis = "x";
            timer_check_move_finished.Enabled = true;
            addmemo("检测头回到中心点");
            test_num = 1;
        }

        private void plc_connect()
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

        private void btn_zero_save_Click(object sender, EventArgs e)
        {
            conn.Open();
            //检查厂商型号是否已存在
            MySql.Data.MySqlClient.MySqlCommand cmd =
                new MySql.Data.MySqlClient.MySqlCommand("select id from  产品参数 where  产品型号='" + cbb_type.Text + "'", conn);
            MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) //已存在则更新
            {
                dr.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd2 =
               new MySql.Data.MySqlClient.MySqlCommand("update  产品参数 set 中心坐标='" + tb_centerX.Text + "," + tb_centerY.Text + "," + tb_centerZ.Text + "' where 产品型号='" + cbb_type.Text + "'", conn);
                cmd2.ExecuteNonQuery();
            }
            else // 不存在则添加
            {
                dr.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd3 =
                  new MySql.Data.MySqlClient.MySqlCommand("insert into  产品参数 (产品型号,中心坐标) values('" + cbb_type.Text + "','" + tb_centerX.Text + "," + tb_centerY.Text + "," + tb_centerZ.Text + "')", conn);
                cmd3.ExecuteNonQuery();

            }
            conn.Close();
            config_json.save("X轴中心位置v", tb_centerX.Text);
            config_json.save("Y轴中心位置v", tb_centerY.Text);
            config_json.save("Z轴中心位置v", tb_centerZ.Text);
            MessageBox.Show("保存成功");
        }
        private void cbb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = 
                new MySql.Data.MySqlClient.MySqlCommand("select distinct 中心坐标,列间距,行间距,屏幕宽,屏幕高 from  产品参数 where 产品型号='" + cbb_type.Text + "'", conn);
            MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                try
                {
                    string[] str = dr[0].ToString().Split(',');
                    tb_centerX.Text = str[0];
                    tb_centerY.Text = str[1];
                    tb_centerZ.Text = str[2];
                    tb_width.Text = dr[3].ToString();
                    tb_height.Text = dr[4].ToString();
                }
                catch { }
            }
            conn.Close();
        }

        private void btn_count_zero_Click(object sender, EventArgs e)
        {
            tb_centerX.Text = (Math.Sqrt(Convert.ToInt16(tb_width.Text) * Convert.ToInt16(tb_width.Text) + Convert.ToInt16(tb_height.Text) * Convert.ToInt16(tb_height.Text)) * 3).ToString();
            tb_centerY.Text = ((int)(-Convert.ToDouble(tb_width.Text) / 2 + Convert.ToDouble(tb_width.Text) / 32)).ToString();
            tb_centerZ.Text = ((int)(Convert.ToDouble(tb_height.Text) - Convert.ToDouble(tb_height.Text) / 20)).ToString();
        }

        private void btn_white_pattern_Click(object sender, EventArgs e)
        {
            try {
                if (serialPort_VG876.IsOpen == false) serialPort_VG876.Open();
                serialPort_VG876.Write(config_json.pattern_black, 0, config_json.pattern_black.Length);
            } catch { }
        }

        private void button4_Click(object sender, EventArgs e) //保存VG870端口号
        {
            config_json.VG870_PortName = cmb_serialPort.Text;
            config_json.save("VG870_PortName", cmb_serialPort.Text);
            MessageBox.Show("保存成功");
        }
        private void btn_test_start_Click(object sender, EventArgs e) //开始测试按钮
        {
            btn_test_start.Enabled = false;
            if (Class_Mysql.Exexute_Sql2Str("select id from 测试数据 where 测试编号='" + tb_test_proj.Text + "'") != "")
            {
                string result = zyb_class.InputBox("测试编号已存在", "测试编号", tb_test_proj.Text);
                if (result != "") tb_test_proj.Text = result;
            }

            objCa200 = new CASDK2Ca200();
            err = objCa200.AutoConnect();
            if (err == 299)
            {
                MessageBox.Show("没有检测到CA410或连接端口被占用！");
                btn_test_start.Enabled = true;
                return;
            }
            ca410detected = true;

            err = objCa200.get_SingleCa(ref objCa);
            err = objCa.get_Memory(ref objMemory);
            err = objCa.get_SingleProbe(ref objProbe);

            objCa200.get_Cas(ref objCas);
            objCas.put_ChannelNO(84);  //设置使用的通道
            objCa.SetAutoZeroCal(1);   //设置自动校零
            objCa.put_DisplayMode(0);  //设置显示模式 0: Lvxy 1: Tduv 5: u'v’Lv 7: XYZ
            objCa.GetDeviceStatus();  //获取设备状态
            int zerostatus = 0;
            objProbe.get_ZeroCalStatus(ref zerostatus);
            //获取校零状态-1: Zero calibration status invalid
            //0: Zero calibration not executed
            //1: Zero calibration recommended
            //2: Zero calibration completed
            addmemo("检查是否需要校零");
            if (zerostatus == 1 || zerostatus == 0)
                objCa.CalZero();
            addmemo("检查校零完成");

            userCurve1.SetLeftCurve("A", result,System.Drawing.Color.Green);
            test_num = 0;
       
            if (!serialPort_VG876.IsOpen)
            {
                serialPort_VG876.PortName = config_json.VG870_PortName;
                try
                {
                    serialPort_VG876.Open();
                    addmemo("打开仪表串口成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("VG870信号发生器串口打开失败:" + ex.Message);
                    addmemo("VG870信号发生器串口打开失败");
                    btn_test_start.Enabled = true;
                    return;
                }
            }

            //发送黑场信号
            serialPort_VG876.Write(config_json.pattern_black, 0, config_json.pattern_black.Length);

            //显示窗体
            serialPort_VG876.Write(config_json.pattern_window, 0, config_json.pattern_window.Length);

            plc_action = "测试";
            addmemo("启动Gamma测试");
            testing = true;
            autoreset = new AutoResetEvent(false);
            VG870_reset_event_06 = new AutoResetEvent(false);
            System.Threading.Thread th = new Thread(Test_Main);
            th.IsBackground = true;
            th.Start();
        }
        private void brn_save_doc_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Word文档(*.docx)|*.docx";
            sfd.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录
            sfd.RestoreDirectory = true;
            sfd.FileName = tb_test_proj.Text;
            //点了保存按钮进入
            if (sfd.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            int colomn_width = 50;
            Aspose.Words.Document doc = new Document();
            DocumentBuilder builder = new DocumentBuilder(doc);

            builder.PageSetup.PaperSize = PaperSize.A4;
            builder.PageSetup.Orientation = Aspose.Words.Orientation.Landscape;  //Landscape;水平
            builder.PageSetup.LeftMargin = 72.0;
            builder.PageSetup.RightMargin = 72.0;
            builder.PageSetup.TopMargin = 30.0;
            builder.PageSetup.BottomMargin = 30.0;

            builder.StartTable();
            // builder.RowFormat.LeftIndent = 15;
            //标题

            builder.InsertCell();
            // builder.CellFormat.
            builder.CellFormat.Borders.LineStyle = LineStyle.Single;
            builder.CellFormat.Borders.Color = System.Drawing.Color.Black;
            builder.CellFormat.Width = colomn_width;
            builder.CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;//垂直居中对齐
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;//水平居中对齐
            builder.Write("灰阶");
            builder.InsertCell();
            builder.Write("亮度");

            builder.InsertCell();
            builder.Write("灰阶");
            builder.InsertCell();
            builder.Write("亮度");
            builder.InsertCell();
            builder.Write("灰阶");
            builder.InsertCell();
            builder.Write("亮度");
            builder.InsertCell();
            builder.Write("灰阶");
            builder.InsertCell();
            builder.Write("亮度");
            builder.InsertCell();
            builder.Write("灰阶");
            builder.InsertCell();
            builder.Write("亮度");
            builder.InsertCell();
            builder.Write("灰阶");
            builder.InsertCell();
            builder.Write("亮度");
            builder.InsertCell();
            builder.Write("灰阶");
            builder.InsertCell();
            builder.Write("亮度");
            builder.InsertCell();
            builder.Write("灰阶");
            builder.InsertCell();
            builder.Write("亮度");


            builder.EndRow();

            //总行数
            for (int j = 0; j <= 31; j++)
            {
               for (int i = 0; i <= 7; i++)
                {
                    builder.InsertCell();
                    builder.Write((i*32+j).ToString());
                    builder.InsertCell();
                    builder.Write(result[i*32+j].ToString("0.0"));
                }
                builder.EndRow();
            }

            builder.EndTable();
            try
            {
                doc.Save(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, sfd.FileName.ToString()));
                MessageBox.Show("保存成功！");
                DialogResult dr = MessageBox.Show("是否需要立即找开Word文档？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, sfd.FileName.ToString()));
                }
            }
            catch (Exception ex) {
                MessageBox.Show("保存失败："+ex.Message);
            }

            //转换为pdf文档
            // doc.Save(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.pdf"), Aspose.Words.SaveFormat.Pdf);
        }


        private void btn_get_current_position_Click(object sender, EventArgs e)
        {
            if (plc_connected)
            {
                tb_nowX.Text = PLC.ReadInt32(config_json.X轴当前位置a).Content.ToString();
                tb_nowY.Text = PLC.ReadInt32(config_json.Y轴当前位置a).Content.ToString();
                tb_nowZ.Text = PLC.ReadInt32(config_json.Z轴当前位置a).Content.ToString();
                addmemo("X轴当前位置:" + tb_nowX.Text);
                addmemo("Y轴当前位置:" + tb_nowY.Text);
                addmemo("Z轴当前位置:" + tb_nowZ.Text);
                timer_get_current_position.Enabled = true;
            }
        }
    }
}

class config_json
{
    //VG876
    public static string VG870_PortName = "COM3"; //
    public static byte[] pattern_white = { 0x02, 0xfd, 0x24, 0x20, 0x31, 0x31, 0x32, 0x31, 0x2c, 0x32, 0x03 };//patter 1121
    public static byte[] pattern_red = { 0x02, 0xfd, 0x24, 0x20, 0x31, 0x31, 0x32, 0x32, 0x2c, 0x32, 0x03 };//patter 1122
    public static byte[] pattern_green = { 0x02, 0xfd, 0x24, 0x20, 0x31, 0x31, 0x32, 0x33, 0x2c, 0x32, 0x03 };//patter 1123
    public static byte[] pattern_blue = { 0x02, 0xfd, 0x24, 0x20, 0x31, 0x31, 0x32, 0x34, 0x2c, 0x32, 0x03 };//patter 1124
    public static byte[] pattern_black = { 0x02, 0xfd, 0x24, 0x20, 0x31, 0x31, 0x32, 0x35, 0x2c, 0x32, 0x03 };//patter 1125
    public static byte[] pattern_50gray = { 0x02, 0xfd, 0x24, 0x20, 0x31, 0x31, 0x32, 0x36, 0x2c, 0x32, 0x03 };//patter 1126
    public static byte[] pattern_window = { 0x02, 0xfd, 0x24, 0x30, 0x30, 0x2c, 0x30, 0x2c, 0x31, 0x2c, 0x32, 0x2c, 0x31, 0x30, 0x2c, 0x31, 0x39, 3 };//
    public static byte[] pattern_window_color_pre = { 0x02, 0xfd, 0x28, 0x62 };//
    public static byte[] pattern_window_color_end = { 0x2c, 0x38, 0x03 };//
    public static byte[] pattern_plane_pre = { 0x02, 0xfd, 0x28, 0x2c };//
    public static byte[] pattern_plane_end = { 0x2c, 0x38, 0x03 };//
}