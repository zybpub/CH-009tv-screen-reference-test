using Aspose.Words;
using System;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace Test_Automation
{
    public partial class Form_Gamma_CA410 : Form
    {
        public Form_Gamma_CA410()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        AutoResetEvent autoreset;

        System.Timers.Timer timer_read_result;
        System.Timers.Timer timer_test_timeout;
        HslCommunication.ModBus.ModbusTcpNet PLC;

        string chech_axis = "x";
        System.Timers.Timer timer_check_move_finished;

        System.Timers.Timer timer_delay;
        float delay_seconds = 1.0F;

        bool plc_connected = false;
        int test_num = 0;
        float[] result = new float[256];
        bool testing = false;

        private void serialPort_CA410_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                int n = com_CA410.BytesToRead;
                byte[] buf = new byte[n];
                com_CA410.Read(buf, 0, n);

                //触发外部处理接收消息事件
                checkCA410_result = System.Text.Encoding.Default.GetString(buf);

                Invoke(new EventHandler(delegate
                {
                    addmemo_txt(checkCA410_result);
                    //OK00,P1,0,0.3776743,0.2927169,1.7717249,-0.03,-99999999

                    //OK00,P1,0,-0.063188,0.4563044,6.6227164,-0.23,-99999999
                    //56个字符，结尾有一个0x0D换行符
                    string[] CA410RecData = checkCA410_result.Split(',');
                    if (CA410RecData.Length == 8)
                    {
                        lb_lv.Text = CA410RecData[5];
                        if (test_a == 0)
                        {
                            test_a = Convert.ToDouble(lb_lv.Text);
                            com_CA410.WriteLine("MES,1");
                        }
                        else
                        {
                            if (Math.Abs(Convert.ToDouble(lb_lv.Text) - test_a) / test_a > 0.01)
                            {
                                addmemo_txt("两次测试的值超差，重新读取");
                                test_a = Convert.ToDouble(lb_lv.Text);
                                com_CA410.WriteLine("MES,1");
                            }
                            else
                            {
                                addmemo_txt("两次测试的未超差，采用数据");
                                addmemo_txt(test_num.ToString() + "," + lb_lv.Text);
                                tb_result.Text += test_num.ToString() + "," + lb_lv.Text + "\r\n";
                                result[test_num] = (float)Convert.ToDouble(lb_lv.Text);
                                userCurve1.SetLeftCurve("A", result);
                                test_num++;

                                if (test_num > 255)
                                {
                                    addmemo_txt("测试结束");
                                }
                                lb_test_num.Text = test_num.ToString();
                                test_a = 0;
                                addmemo_txt("测试下一个点");
                                serialPort_VG876.Write(config_json.pattern_window_color_pre, 0, config_json.pattern_window_color_pre.Length);
                                serialPort_VG876.Write(test_num.ToString() + "," + test_num.ToString() + "," + test_num.ToString());
                                serialPort_VG876.Write(config_json.pattern_window_color_end, 0, config_json.pattern_window_color_end.Length);

                                timer_delay.Enabled = true;
                            }
                        }
                    }
                    else {
                        com_CA410.WriteLine("MES,1");
                    }
                }));
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userCurve1.SetLeftCurve("A", result,System.Drawing.Color.Green);
            test_num = 0;
            //打开串口
            serialPort_VG876.PortName = config_json.VG870_PortName;
            if (serialPort_VG876.IsOpen)
            {

            }
            else
            {
                try
                {
                    serialPort_VG876.Open();
                    addmemo_txt("打开仪表串口成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("VG870信号发生器串口打开失败:" + ex.Message);
                    addmemo_txt("VG870信号发生器串口打开失败");
                    return;
                }

            }

           



            //发送黑场信号
            serialPort_VG876.Write(config_json.pattern_black, 0, config_json.pattern_black.Length);

            //显示窗体
            serialPort_VG876.Write(config_json.pattern_window, 0, config_json.pattern_window.Length);

            serialPort_VG876.Write(config_json.pattern_window_color_pre, 0, config_json.pattern_window_color_pre.Length);
            serialPort_VG876.Write(test_num.ToString()+","+test_num.ToString()+","+test_num.ToString());
            serialPort_VG876.Write(config_json.pattern_window_color_end, 0, config_json.pattern_window_color_end.Length);

            action = "测试";
            addmemo_txt("启动Gamma测试");
           // cs200.RunCS200();
            //connet PLC
           // if (!plc_connected) btn_plc_connect_Click(null, null);
            lb_test_num.Text = test_num.ToString();
            testing = true;
            timer_delay.Enabled = true;
            //timer_test_timeout.Enabled = true;
            // timer_read_result.Enabled = true;
        }
        string result_file = "result.txt";
        double max = 0, min = 0;
        double test_a = 0, test_b = 0;
        private void timer_read_result_Tick(object sender, ElapsedEventArgs e)
        {
            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(result_file);
                string str_result = sr.ReadToEnd();
                sr.Close();
                //OK00,0,2,1, 1,0,    0,0,20,      6.313,     0.3102,     0.3489
                if (str_result == "")
                {
                    timer_read_result.Enabled = true;
                    return;
                }
                timer_test_timeout.Enabled = false;
                //清空result.txt文件内容
                System.IO.StreamWriter sw = new System.IO.StreamWriter(result_file);
                sw.Write("");
                sw.Close();

                string[] data = str_result.Replace(" ", "").Split(',');
                if (data.Length < 9)
                {
                    MessageBox.Show("读取到的数据有误！");
                    return;
                }

                if (data[9].Length >= 5)
                    lb_lv.Text = data[9].Substring(0, 5);
                else lb_lv.Text = data[9];

                addmemo_txt(test_num.ToString() + "读数:" + lb_lv.Text + "," + data[10] + "," + data[11]);

                if (test_a == 0)
                {
                    test_a = Convert.ToSingle(lb_lv.Text);
                   timer_delay.Enabled=true;
                    return;
                }
                else
                {
                    test_b = Convert.ToSingle(lb_lv.Text);
                    int diff = (int)(Math.Abs(test_a - test_b) / test_b * 1000);
                    addmemo_txt("两次读数差异" + ((float)diff / 10).ToString());
                    if (diff > 10)
                    {
                        addmemo_txt("两次读数已超过1%，再次读数");
                        test_a = test_b;
                        timer_delay.Enabled = true;
                        return;
                    }
                    else
                    {
                        addmemo_txt("两次读数差异未超过1%");
                    }
                }

                test_a = 0;
                result[test_num - 1] = Convert.ToSingle(lb_lv.Text);
                userCurve1.SetLeftCurve("A", test_result);
                if (testing) {
                   // 测试下一个点
                    timer_delay.Enabled = true;
                }
            }
            catch
            {
                timer_read_result.Enabled = true;
            }
        }
        bool row_changed = false;

        float teat_a = 0, teat_b = 0;
        void Do_GetData()
        {
            com_CA410.WriteLine("MES,1");
        }

        private void test_timeout_timer_Tick(object sender, ElapsedEventArgs e)
        {
            MessageBox.Show("获取数据超时");
        }

        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private void addmemo_txt(string memo)
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

            try
            {
                foreach (string com in System.IO.Ports.SerialPort.GetPortNames()) //自动获取串行口名称

                    cmbPortName.Items.Add(com);
                cmbPortName.SelectedIndex = 0;
            }
            catch { }

            cmbPortName.Text = config_json.CA410_SerialPort_PortName;

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

            timer_test_timeout = new System.Timers.Timer(10000);
            timer_test_timeout.Elapsed += new System.Timers.ElapsedEventHandler(test_timeout_timer_Tick);
            timer_test_timeout.AutoReset = false;
            timer_test_timeout.Enabled = false;

            timer_read_result = new System.Timers.Timer(200);  //每秒刷新测试时间
            timer_read_result.Elapsed += new System.Timers.ElapsedEventHandler(timer_read_result_Tick);//到时间的时候执行事件；
            timer_read_result.AutoReset = false;//设置是执行一次（false）还是一直执行(true)；
            timer_read_result.Enabled = false;

            PLC = new HslCommunication.ModBus.ModbusTcpNet(config_json.PLC_IP, 502, 1);   // 站号1
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
            autoreset = new AutoResetEvent(false);
            conn =
         new MySql.Data.MySqlClient.MySqlConnection(
             "Database=" + config_json.mysql_database_name + ";" +
             "Data Source=" + config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");
            加载产商和型号();

            userCurve1.SetLeftCurve("A", test_result, System.Drawing.Color.Green);
            for (int i = 0; i < 256; i++)
            {
                text[i] = i.ToString();
            }
            userCurve1.SetCurveText(text);

        }

        private void timer_delay_Tick(object sender, ElapsedEventArgs e)
        {
            if (test_num > 255) {
                MessageBox.Show("测试已结束！");
                //savetomysql();
                return;
            }
            Do_GetData();
        }

        private void 加载产商和型号()
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
                        addmemo_txt("x移动到位");
                        if (action == "回到原点")
                        {
                            addmemo_txt("X回到原点");
                            chech_axis = "y";
                            timer_check_move_finished.Enabled = true;
                            PLC.Write(config_json.X轴相对运动完成a, 0);
                            return;
                        }
                        timer_check_move_finished.Enabled = false;
                        PLC.Write(config_json.X轴相对运动完成a, 0);
                        if (testing) Do_GetData();
                    }
                    else { timer_check_move_finished.Enabled = true; }
                    break;
                case "y":
                    check_move_value = PLC.ReadInt32(config_json.Y轴相对运动完成a).Content.ToString();
                    if (check_move_value == "1") //移动到位
                    {
                        addmemo_txt("Y移动到位");
                        if (action == "回到原点")
                        {
                            addmemo_txt("Y回到原点");
                            chech_axis = "z";
                            timer_check_move_finished.Enabled = true;
                            PLC.Write(config_json.Y轴相对运动完成a, 0);
                            return;
                        }
                        timer_check_move_finished.Enabled = false;
                        PLC.Write(config_json.Y轴相对运动完成a, 0);
                        if (testing) Do_GetData();
                    }
                    else { timer_check_move_finished.Enabled = true; }
                    break;
                case "z":
                    check_move_value = PLC.ReadInt32(config_json.Z轴相对运动完成a).Content.ToString();
                    if (check_move_value == "1") //移动到位
                    {
                        addmemo_txt("Z移动到位");
                        if (action == "回到原点")
                        {
                            chech_axis = "z";
                            timer_check_move_finished.Enabled = false;
                            addmemo_txt("Z回到原点");
                            PLC.Write(config_json.Z轴相对运动完成a, 0);
                            return;
                        }

                        timer_check_move_finished.Enabled = false;
                        PLC.Write(config_json.Z轴相对运动完成a, 0);
                        if (testing) Do_GetData();
                    }
                    else { timer_check_move_finished.Enabled = true; }
                    break;
                case "r":
                    check_move_value = PLC.ReadInt32(config_json.R轴相对运动完成a).Content.ToString();
                    if (check_move_value == "1") //移动到位
                    {
                        timer_check_move_finished.Enabled = false;
                        PLC.Write(config_json.R轴相对运动完成a, 0);
                        if (testing) Do_GetData();
                    }
                    else { timer_check_move_finished.Enabled = true; }
                    break;
                default:
                    break;
            }

        }




        private void serialPort_VG876_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

        }
    

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter sw2 = new System.IO.StreamWriter("input.txt");
            sw2.Write("ext");
            sw2.Close();
        }

        private void btn_test_stop_Click(object sender, EventArgs e)
        {
            timer_test_timeout.Enabled = false;
            timer_read_result.Enabled = false;
            testing = false;
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


            //string localFilePath, fileNameExt, newFileName, FilePath;
            SaveFileDialog sfd = new SaveFileDialog();
            //设置文件类型
            sfd.Filter = "文本文件(*.txt)|*.txt";
            //sfd.Filter = "文本文件(*.txt)";
            //设置默认文件类型显示顺序
            sfd.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录
            sfd.RestoreDirectory = true;
            sfd.FileName = tb_test_proj.Text;

            //点了保存按钮进入
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = sfd.FileName.ToString(); //获得文件路径
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径

                // string filename = System.IO.Directory.GetCurrentDirectory() + "/" + tb_test_proj.Text + ".txt";
                System.IO.StreamWriter sw2 = new System.IO.StreamWriter(localFilePath, true);
                sw2.Write("\r\n测试编号：" + tb_test_proj.Text + "\r\ngamma测试结果：\r\n" + tb_memo.Text + "\r\n");

                //按表格格式输出测试数据
                {
                    for (int j = 0; j < 10; j++)
                    {

                    }

                }

                //   sw2.Write(lb_min.Text + "\r\n");
                //  sw2.Write("Bp=" + lb_bp.Text + "%\r\n");
                sw2.Close();
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
                addmemo_txt("X轴当前位置:" + tb_nowX.Text);
                addmemo_txt("Y轴当前位置:" + tb_nowY.Text);
                addmemo_txt("Z轴当前位置:" + tb_nowZ.Text);
                timer_get_current_position.Enabled = true;
            }
            else { MessageBox.Show("PLC连接失败，IP:" + config_json.PLC_IP); }
        }

        private void btn_plc_disconnect_Click(object sender, EventArgs e)
        {
            PLC.ConnectClose();
            plc_connected = false;
        }
        string action = "";
        private void button7_Click(object sender, EventArgs e)
        {

            if (plc_connected == false)
            {
                plc_connect();

            }
            //  System.Threading.Thread.Sleep(1000);
            if (plc_connected == false) return;

            PLC.Write(config_json.X轴相对运动坐标写入a, (Convert.ToInt32(tb_centerX.Text) - Convert.ToInt32(tb_nowX.Text)) * 1000);
            PLC.Write(config_json.Y轴相对运动坐标写入a, (Convert.ToInt32(tb_centerY.Text) - Convert.ToInt32(tb_nowY.Text)) * 1000);
            PLC.Write(config_json.Z轴相对运动坐标写入a, (Convert.ToInt32(tb_centerZ.Text) - Convert.ToInt32(tb_nowZ.Text)) * 1000);
            PLC.Write(config_json.X轴相对运动启动a, 1);
            PLC.Write(config_json.Y轴相对运动启动a, 1);
            PLC.Write(config_json.Z轴相对运动启动a, 1);
            action = "回到原点";
            chech_axis = "x";
            timer_check_move_finished.Enabled = true;
            addmemo_txt("检测头回到中心点");
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

        private void button6_Click_1(object sender, EventArgs e)
        {
            Random rd = new Random();

            test_result[0] = 0.5F;
            for (int i = 1; i < 256; i++)
            {
                test_result[i] = (float)(test_result[i - 1] + 1.2);
            }
            tb_memo.Text += "模拟数据:\r\n";
            for (int i = 0; i < 256; i++)
            {
                tb_memo.Text += test_result[i].ToString() + "\r\n";
            }

        }

        private void cbb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select distinct 中心坐标,列间距,行间距,屏幕宽,屏幕高 from  产品参数 where 产品型号='" + cbb_type.Text + "'", conn);
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
                catch
                {
                }


            }

            conn.Close();
        }

        private void btn_count_zero_Click(object sender, EventArgs e)
        {
            tb_centerX.Text = (Math.Sqrt(Convert.ToInt16(tb_width.Text) * Convert.ToInt16(tb_width.Text) + Convert.ToInt16(tb_height.Text) * Convert.ToInt16(tb_height.Text)) * 3).ToString();


            tb_centerY.Text = ((int)(-Convert.ToDouble(tb_width.Text) / 2 + Convert.ToDouble(tb_width.Text) / 32)).ToString();
            tb_centerZ.Text = ((int)(Convert.ToDouble(tb_height.Text) - Convert.ToDouble(tb_height.Text) / 20)).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            config_json.VG870_PortName = cmb_serialPort.Text;
            config_json.save("VG870_PortName", cmb_serialPort.Text);
            MessageBox.Show("保存成功");
        }
        string checkCA410_result;
    
        private void button2_Click(object sender, EventArgs e)
        {
            // Set the port's settings
            com_CA410.PortName = cmbPortName.Text;
            com_CA410.BaudRate = 38400;
            com_CA410.DataBits = 7;
            com_CA410.StopBits = System.IO.Ports.StopBits.Two;
            //(System.IO.Ports.StopBits)Enum.Parse(typeof(System.IO.Ports.StopBits), cmbStopBits.Text);
            // com_CA410.Parity = System.IO.Ports.Parity.Even;
            com_CA410.Parity = System.IO.Ports.Parity.None;
            com_CA410.Open();
            com_CA410.DiscardInBuffer();
            com_CA410.DiscardOutBuffer();
         
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            com_CA410.WriteLine("ZRC");
        }

        System.Timers.Timer timer_get_current_position;

        private void brn_save_doc_Click(object sender, EventArgs e)
        {
            //string localFilePath, fileNameExt, newFileName, FilePath;
            SaveFileDialog sfd = new SaveFileDialog();
            //设置文件类型
            sfd.Filter = "Word文档(*.docx)|*.docx";
            //sfd.Filter = "文本文件(*.txt)";
            //设置默认文件类型显示顺序
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
                System.Diagnostics.Process.Start(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, sfd.FileName.ToString()));
            }
            catch (Exception ex) {
                MessageBox.Show("保存失败："+ex.Message);
            }

            //转换为pdf文档
            // doc.Save(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "合同正文.pdf"), Aspose.Words.SaveFormat.Pdf);
        }


        private void btn_get_current_position_Click(object sender, EventArgs e)
        {
            if (plc_connected)
            {
                tb_nowX.Text = PLC.ReadInt32(config_json.X轴当前位置a).Content.ToString();
                tb_nowY.Text = PLC.ReadInt32(config_json.Y轴当前位置a).Content.ToString();
                tb_nowZ.Text = PLC.ReadInt32(config_json.Z轴当前位置a).Content.ToString();
                addmemo_txt("X轴当前位置:" + tb_nowX.Text);
                addmemo_txt("Y轴当前位置:" + tb_nowY.Text);
                addmemo_txt("Z轴当前位置:" + tb_nowZ.Text);
                timer_get_current_position.Enabled = true;
            }
        }
    }
}
