using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace Test_Automation
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        double currentx, currenty, currentz;
        double centerx, centery, centerz; //屏幕中心点坐标
        double firstx, firsty,firstz; //第一个测试点的坐标
        double move_relative_x, move_relative_y, move_relative_z;

        bool test160_finished=false;
        bool gamma_finished = false;
        //todo 160点测试
        void Test_160()
        {

            centerx = Convert.ToDouble(tb_center_x.Text);
            centery = Convert.ToDouble(tb_center_y.Text);
            centerz = Convert.ToDouble(tb_center_z.Text);
            firstx = centerx;
            firsty = centery - config_json.屏幕宽 / 2 + config_json.屏幕宽 / 32;
            firstz = centerz + config_json.屏幕高 / 2 - config_json.屏幕高 / 20;

            //lb_firstx.Text = firstx.ToString("0");
            //lb_firsty.Text = firsty.ToString("0");
            //lb_firstz.Text = firstz.ToString("0");

            int 列间距 = Convert.ToInt32(config_json.屏幕宽 / 16);
            int 行间距 = -Convert.ToInt32(config_json.屏幕高 / 10);
            lb_列间距.Text = 列间距.ToString();
            lb_行间距.Text = 行间距.ToString();

            testing = true;
            //连接PLC
            if (plc_connected == false)
            {
                plc_connect();
            }
            if (plc_connected == false)
            {
                addmemo_txt("测试已停止");
                return;
            }

            //读取当前位置
            timer_get_current_position_Tick(null, null);
            //移动到零点
            addmemo_txt("移动X到中心点");

            //move("x", (Convert.ToDouble(lb_center_x.Text) - Convert.ToDouble(lb_x.Text)));
            move_relative_x = centerx-currentx;
            if (move_relative_x != 0)
            {
                addmemo_txt(Class_PLC.Move_Dis(plc, "x", move_relative_x));
                addmemo_txt(Class_PLC.Move_Exe(plc, "x"));
                Move_Wait_Finish("x");
                autoreset_move.WaitOne();
            }
            else {
                addmemo_txt("x移动到位");
            }

            addmemo_txt("移动Y到中心点");
            move_relative_y =  centery-currenty;
            if (move_relative_y != 0)
            {
                addmemo_txt("Y移动距离：" + move_relative_y);
                Class_PLC.Move_Dis(plc, "y", move_relative_y);
                Class_PLC.Move_Exe(plc, "y");
                Move_Wait_Finish("y");
                autoreset_move.WaitOne();
            }
            else
            {
                addmemo_txt("y移动到位");
            }

            addmemo_txt("移动Z到中心点");

            move_relative_z =  centerz-currentz;
            addmemo_txt("Z移动距离：" + move_relative_z);
            if (move_relative_z != 0)
            {
                Class_PLC.Move_Dis(plc, "z", move_relative_z);
                Class_PLC.Move_Exe(plc, "z");
                Move_Wait_Finish("z");
                autoreset_move.WaitOne();
            }
            else {
                addmemo_txt("z移动到位");
            }



            //移动到第一个测试点
            addmemo_txt("y移动到第一个测试点");
            Class_PLC.Move_Dis(plc,"y", firsty-currenty);
            Class_PLC.Move_Exe(plc, "y");
            Move_Wait_Finish("y");
            autoreset_move.WaitOne();

            addmemo_txt("z移动到第一个测试点");
            Class_PLC.Move_Dis(plc, "z", firstz - currentz);
            Class_PLC.Move_Exe(plc, "z");
            Move_Wait_Finish("z");
            autoreset_move.WaitOne();

            //写入测试过程中相对运动值
           
            addmemo_txt("写入测试过程中相对运动值:y=" + 列间距 + " z=" + 行间距);
            Class_PLC.Move_Dis(plc, "y", 列间距);
            Class_PLC.Move_Dis(plc, "z", 行间距);

            timer_get_current_position.Enabled = true;
            addmemo_txt("开启实时位置显示");

            for (test_num = 0; test_num <= 159; test_num++)
            {
                if (testing == false)
                {
                    return;
                }
                Do_GetData();
                autoreset_read_color_value = new AutoResetEvent(false);
                autoreset_read_color_value.WaitOne();

                result[test_num] = Convert.ToSingle(lb_light_value.Text);
                addmemo_txt("第" + test_num + "点测试完成");
                if (test_num == Convert.ToInt16(tb_测试点数.Text)-1) break;
                //机械移动
                if ((test_num + 1) % 16 == 0)
                {
                    addmemo_txt("换行");

                    //移动z轴向下运动
                    Class_PLC.Move_Exe(plc, "z");
                    Move_Wait_Finish("z");
                    autoreset_move.WaitOne();

                    addmemo_txt("移动Y到第一列");

                    move_relative_y= firsty-currenty;
                    //y回到第一列y_base
                   Class_PLC.Move_Dis(plc, "y", move_relative_y);
                    Class_PLC.Move_Exe(plc,"y");
                    Move_Wait_Finish("y");
                    autoreset_move.WaitOne();
                    Class_PLC.Move_Dis(plc, "y", 列间距); //更新下一次的相对移动距离
                    row_changed = true;
                }
                else //移动到当前行的下一点
                {
                    addmemo_txt("同行下一点移动");
                    Class_PLC.Move_Exe(plc, "y");
                    Move_Wait_Finish("y");
                    autoreset_move.WaitOne();
                }
            }
            test160_finished = true;
            addmemo_txt("亮度均匀性测试完成!");

        }

        private void Move_Wait_Finish(string axis)
        {
            addmemo_txt("启动定时器，等待移动"+axis+"到位");
            chech_axis = axis;
            timer_check_move_finished.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form_Gamma_CA410_Autoreset f = new Form_Gamma_CA410_Autoreset();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process[] pro =
                System.Diagnostics.Process.GetProcessesByName("cs-200");
            if (pro.Length == 0)
            {
                System.Diagnostics.Process.Start("cs-200.exe");
            }

            autoreset_move = new AutoResetEvent(false);

            if (tb_sheet_no.Text != config_json.sheet_no)
            {
                config_json.save("sheet_no", tb_sheet_no.Text);
            }
            if (tb_sheet_no.Text.Trim() == "")
            {
                MessageBox.Show("委托单号不能为空！", "提示");
                return;
            }

            if (!(cb_160.Checked || cb_gamma.Checked)) { MessageBox.Show("请勾选要测试的项目"); return; }
            tabControl1.SelectedIndex = 0;
            if (cb_160.Checked)
                lb_160.Text = "(待测试)";
            if (cb_gamma.Checked)
                lb_gamma.Text = "(待测试)";

            config_json.屏幕宽 = Convert.ToDouble(tb_width.Text);
            config_json.屏幕高 = Convert.ToDouble(tb_height.Text);

            if (cb_160.Checked)
            {
                lb_160.Text = "(测试中)";
                lb_160.ForeColor = System.Drawing.Color.Green;
                Thread test160 = new Thread(new ThreadStart(Test_160));
                test160.IsBackground = true;
                test160.Start();
            }
            if (cb_gamma.Checked) {

            }
                lb_gamma.Text = "(测试中)"; return;
        }

        private HslCommunication.ModBus.ModbusTcpNet plc;
        static bool plc_connected = false;
        System.Timers.Timer timer_get_current_position, timer_check_move_finished;
        AutoResetEvent autoreset_move = new AutoResetEvent(false);
        AutoResetEvent autoreset_read_color_value = new AutoResetEvent(false);
        System.Timers.Timer timer_read_result;
        System.Timers.Timer timer_test_timeout;
        float[] result = new float[160];
        List<Data160> data160 = new List<Data160>();
        double y_base = 0;  //y轴第一列的坐标
        bool cb_160_finished = false;
        bool cb_gamma_finished = false;
        void plc_connect()
        {
            if (plc_connected == false)
            {
                plc = new HslCommunication.ModBus.ModbusTcpNet(config_json.PLC_IP);
                plc.AddressStartWithZero = true;
                plc.DataFormat = HslCommunication.Core.DataFormat.CDAB;
                HslCommunication.OperateResult resut = plc.ConnectServer();
                if (resut.IsSuccess)
                {
                    addmemo_txt("PLC连接成功！");
                    timer_get_current_position.Enabled = true;
                    timer_get_current_position_Tick(null, null);
                    plc_connected = true;
                }
                else
                {
                    addmemo_txt("PLC连接失败！");
                    ts1.Text = "连接PLC失败！";
                    plc_connected = false;
                }
            }
        }
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private void addmemo_txt(string memo)
        {
            tb_memo.AppendText(DateTime.Now.ToString("[HH:mm:ss.fff] ") + memo + "\r\n");
            tb_memo.ScrollToCaret();
            logger.Info(DateTime.Now.ToString("[yyyy-M-d HH:mm:ss.fff] ") + memo + "\r\n");
        }
        private void Form_Main_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            tb_date.Text = DateTime.Now.ToString("yyyy-M-d HH:mm:ss");
            SOFT_VER.Text =
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            config_json.config_json_readall();
            tb_sheet_no.Text = config_json.sheet_no;
            serialPort_VG876.PortName = config_json.VG870_PortName;

            test_timeout_timer = new System.Timers.Timer(10000);
            test_timeout_timer.Elapsed += new System.Timers.ElapsedEventHandler(test_timeout_timer_Tick);
            test_timeout_timer.AutoReset = false;
            test_timeout_timer.Enabled = false;
            ResultReadTimer = new System.Timers.Timer(1000);  //每秒刷新测试时间
            ResultReadTimer.Elapsed += new System.Timers.ElapsedEventHandler(ResultReadTimer_Tick);//到时间的时候执行事件；
            ResultReadTimer.AutoReset = false;//设置是执行一次（false）还是一直执行(true)；
            ResultReadTimer.Enabled = false;

            timer_get_current_position = new System.Timers.Timer(200);
            timer_get_current_position.Elapsed += new System.Timers.ElapsedEventHandler(timer_get_current_position_Tick);
            timer_get_current_position.AutoReset = true;
            timer_get_current_position.Enabled = false;


            timer_check_move_finished = new System.Timers.Timer(200);
            timer_check_move_finished.Elapsed += new System.Timers.ElapsedEventHandler(timer_check_move_finished_Tick);
            timer_check_move_finished.AutoReset = false;
            timer_check_move_finished.Enabled = false;

            timer_read_result = new System.Timers.Timer(200);  //每秒刷新测试时间
            timer_read_result.Elapsed += new System.Timers.ElapsedEventHandler(timer_read_result_Tick);//到时间的时候执行事件；
            timer_read_result.AutoReset = false;//设置是执行一次（false）还是一直执行(true)；
            timer_read_result.Enabled = false;

            serialPort_VG876.PortName = config_json.VG870_PortName;

            string result = Class_Mysql.check_mysql();
            if (result != "OK") MessageBox.Show(result);


            conn =
           new MySql.Data.MySqlClient.MySqlConnection(
               "Database=" + config_json.mysql_database_name + ";" +
               "Data Source=" + config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");
            加载产商和型号();
        }
        string check_move_value = "";
        string chech_axis = "";
        static bool testing = false;

        //todo 检查运动是否到位 timer_check_move_finished_Tick
        private void timer_check_move_finished_Tick(object sender, ElapsedEventArgs e)
        {
            switch (chech_axis)
            {
                case "x":
                    check_move_value = plc.ReadInt32(config_json.X轴相对运动完成a).Content.ToString();
                    if (check_move_value == "1") //移动到位
                    {
                        addmemo_txt("x移动到位");
                        plc.Write(config_json.X轴相对运动完成a, 0);
                        addmemo_txt("autoreset_move.Set();");
                        autoreset_move.Set();
                    }
                    else { timer_check_move_finished.Enabled = true; }
                    break;
                case "y":
                    check_move_value = plc.ReadInt32(config_json.Y轴相对运动完成a).Content.ToString();
                    if (check_move_value == "1") //移动到位
                    {
                        addmemo_txt("y移动到位");
                        plc.Write(config_json.Y轴相对运动完成a, 0);
                        autoreset_move.Set();
                    }
                    else { timer_check_move_finished.Enabled = true; }
                    break;
                case "z":
                    check_move_value = plc.ReadInt32(config_json.Z轴相对运动完成a).Content.ToString();
                    if (check_move_value == "1") //移动到位
                    {
                        addmemo_txt("z移动到位");
                        plc.Write(config_json.Z轴相对运动完成a, 0);
                        autoreset_move.Set();
                    }
                    else { timer_check_move_finished.Enabled = true; }
                    break;
                case "r":
                    if (check_move_value == "1") //移动到位
                    {
                        addmemo_txt("r移动到位");
                        plc.Write(config_json.R轴相对运动完成a, 0);
                        autoreset_move.Set();
                    }
                    else { timer_check_move_finished.Enabled = true; }
                    break;
                default:
                    break;
            }

        }
        int test_num = 1;
        void Do_GetData()
        {
            addmemo_txt("开始检测第"+test_num+"点");
            lb_test_num.Text = test_num.ToString();
            try
            { //清空result.txt文件内容
                System.IO.StreamWriter sw = new System.IO.StreamWriter("result.txt");
                sw.Write("");
                sw.Close();

                System.IO.StreamWriter sw2 = new System.IO.StreamWriter("input.txt");
                sw2.Write("mes");
                sw2.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
                return;
            }
            addmemo_txt("等待返回数据");
            timer_read_result.Enabled = true;
        }

        //todo timer_get_current_position_Tick
        private void timer_get_current_position_Tick(object sender, ElapsedEventArgs e)
        {
            if (plc_connected)
            {
                currentx= plc.ReadInt32(config_json.X轴当前位置a).Content / 1000;
                currenty = plc.ReadInt32(config_json.Y轴当前位置a).Content / 1000;
                currentz = plc.ReadInt32(config_json.Z轴当前位置a).Content / 1000;
                lb_x.Text = currentx.ToString();
                lb_y.Text = currenty.ToString();
                lb_z.Text = currentz.ToString();
                try { textBox1.AppendText("x:" + lb_x.Text + " y:" + lb_y.Text + " z:" + lb_z.Text + "\r\n"); } catch { }
            }
        }

        public static MySql.Data.MySqlClient.MySqlConnection conn;
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

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 亮度计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_CA410 f = new Form_CA410();
            f.ShowDialog();
        }

        private void 机械系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_control f = new Form_control();
            f.ShowDialog();

        }

        private void btn_white_pattern_Click(object sender, EventArgs e)
        {
            if (serialPort_VG876.IsOpen == false) serialPort_VG876.Open();
            try { serialPort_VG876.Write(config_json.pattern_white, 0, config_json.pattern_white.Length); } catch { }
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            Form_160 f = new Form_160();
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form_control f = new Form_control();
            f.ShowDialog();
        }

        System.Timers.Timer ResultReadTimer;
        System.Timers.Timer test_timeout_timer;
        private void btn_cs200read_Click(object sender, EventArgs e)
        {
            cs200.RunCS200();
            try
            { //清空result.txt文件内容
                System.IO.StreamWriter sw = new System.IO.StreamWriter("result.txt");
                sw.Write("");
                sw.Close();

                System.IO.StreamWriter sw2 = new System.IO.StreamWriter("input.txt");
                sw2.Write("zyb");
                sw2.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
                return;
            }
            test_timeout_timer.Enabled = true;
            ResultReadTimer.Enabled = true;
        }

        private void test_timeout_timer_Tick(object sender, ElapsedEventArgs e)
        {
            tb_memo.Text += "超时";
        }

        private void ResultReadTimer_Tick(object sender, ElapsedEventArgs e)
        {
            string result = ReadResult("result.txt"); //OK00,0,2,1, 1,0,    0,0,20,      6.313,     0.3102,     0.3489
            if (result == "")
            {
                ResultReadTimer.Enabled = true;
                return;
            }
            string[] data = result.Replace(" ", "").Split(',');
            if (data.Length > 9) lb_light_value.Text = data[9];
            test_timeout_timer.Enabled = false;
        }
        public string ReadResult(string file)
        {
            string str = "";
            //判断文件是否存在
            if (!System.IO.File.Exists(file))  //文件不存在
            {
                return "";
            }
            else
            {
                try
                {
                    //文件已存在
                    //读取文件
                    System.IO.StreamReader sr = new System.IO.StreamReader(file);
                    str = sr.ReadToEnd();
                    sr.Close();
                    System.Threading.Thread.Sleep(100);
                    //清空result.txt文件内容
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(file);
                    sw.Write("");
                    sw.Close();
                }
                catch { }
            }
            return str.Trim();
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            cs200.ExitCS200();
            timer_get_current_position.Enabled = false;
        }

        private void 信号发生器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_VG876 f = new Form_VG876();
            f.ShowDialog();
        }

        private void btn_get_Click(object sender, EventArgs e)
        {
            cs200.RunCS200();
            try
            { //清空result.txt文件内容
                System.IO.StreamWriter sw = new System.IO.StreamWriter("result.txt");
                sw.Write("");
                sw.Close();

                System.IO.StreamWriter sw2 = new System.IO.StreamWriter("input.txt");
                sw2.Write("mes");
                sw2.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
                return;
            }
            test_timeout_timer.Enabled = true;
            ResultReadTimer.Enabled = true;
        }

        private void serialPort_VG876_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            System.Threading.Thread.Sleep(100);

            int n = serialPort_VG876.BytesToRead;
            byte[] buf = new byte[n];
            serialPort_VG876.Read(buf, 0, n);
            tb_memo.Text += "VG876收到的数据:" + byteToHexStr(buf);
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

        private void btn_plc_disconnect_Click(object sender, EventArgs e)
        {
            plc.ConnectClose();
            plc_connected = false;
        }

        private void cbb生产厂商_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb产品型号.Items.Clear();
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select distinct 产品型号 from  产品参数 where 生产厂商='" + cbb生产厂商.Text + "' order by 产品型号", conn);
            MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbb产品型号.Items.Add(dr[0].ToString());
            }
            conn.Close();
            if (cbb产品型号.Items.Count > 0) cbb产品型号.SelectedIndex = 0;

        }

        private void cbb产品型号_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select distinct 中心坐标 from  产品参数 where 产品型号='" + cbb产品型号.Text + "'", conn);
            MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                try
                {
                    string[] str = dr[0].ToString().Split(',');
                    config_json.X轴原点位置v = str[0];
                    config_json.Y轴原点位置v = str[1];
                    config_json.Z轴原点位置v = str[2];
                }
                catch
                {
                }
            }
            conn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form_Gamma f = new Form_Gamma();
            f.ShowDialog();
        }

     
        string result_file = "result.txt";
        double max = 0, min = 0;
        double test_a = 0, test_b = 0;

        //todo 读取cs-200数据 timer_read_result_Tick
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
                //timer_test_timeout.Enabled = false;
                //清空result.txt文件内容
                System.IO.StreamWriter sw = new System.IO.StreamWriter(result_file);
                sw.Write("");
                sw.Close();

                addmemo_txt("读取到数据:"+str_result);
                string[] data = str_result.Replace(" ", "").Split(',');

                addmemo_txt(test_num.ToString() + "读数:" + data[9] + "," + data[10] + "," + data[11]);

                if (data.Length < 9)
                {
                    MessageBox.Show("读取到的数据有误！");
                    return;
                }
                foreach (Control c in panel_160.Controls)
                {
                    if (c is PictureBox && c.Name == "pb" + (test_num+1).ToString())
                    {
                        PictureBox pb = c as PictureBox;
                        pb.Image = global::Test_Automation.Properties.Resources.green;
                    }

                    if (c is Label && c.Name == "n" + (test_num+1).ToString())
                    {

                        Label lb = c as Label;
                        //lb.Text = data[9].Substring(0,data[9].Length-(data[9].IndexOf(".")+2));
                        if (data[9].Length >= 5)
                            lb.Text = data[9].Substring(0, 5);
                        else lb.Text = data[9];

                       // addmemo_txt(test_num.ToString() + "读数:" + lb.Text + "," + data[10] + "," + data[11]);

                        if (test_a == 0)
                        {
                            test_a = Convert.ToSingle(lb.Text);
                            addmemo_txt("test_a:" + test_a.ToString("0.0"));
                            Do_GetData();
                            return;
                        }
                        else
                        {
                            test_b = Convert.ToSingle(lb.Text);
                            addmemo_txt("test_b:" + test_b.ToString("0.0"));
                            int diff = (int)(Math.Abs(test_a - test_b) / test_b * 1000);
                            addmemo_txt("两次读数差异" + ((float)diff / 10).ToString());
                            if (diff > 10)
                            {
                                addmemo_txt("两次读数已超过1%，再次读数");
                                test_a = test_b;
                                addmemo_txt("test_a" + test_a.ToString());
                                Do_GetData();
                                return;
                            }
                            else
                            {
                                addmemo_txt("两次读数差异未超过1%");
                            }
                        }
                       
                        test_a = 0;
                        lb_light_value.Text = lb.Text;

                        Data160 d = new Data160();
                        d.l = lb.Text; d.u = data[10]; d.v = data[11].Trim();
                        data160.Add(d);
                        result[test_num] = Convert.ToSingle(lb.Text);
                        if (test_num == 0) { max = result[test_num]; lb_max.Text = lb.Text; min = result[test_num]; lb_min.Text = lb.Text; }
                        if (result[test_num] > max) { max = result[test_num]; lb_max.Text = lb.Text; }
                        if (result[test_num] < min) { min = result[test_num]; lb_min.Text = lb.Text; }

                        lb_bp.Text = (min / max * 100).ToString("0.00");
                        addmemo_txt("等待进行下一点测试");
                        autoreset_read_color_value.Set();
                    }
                }

               
            }
            catch
            {
                timer_read_result.Enabled = true;
            }
        }
        bool row_changed = false;

        private void ts_view_Click(object sender, EventArgs e)
        {
            //todo 生成报告
            //string localFilePath, fileNameExt, newFileName, FilePath;
            SaveFileDialog sfd = new SaveFileDialog();
            //设置文件类型
            sfd.Filter = "Word文档(*.docx)|*.docx";
            //sfd.Filter = "文本文件(*.txt)";
            //设置默认文件类型显示顺序
            sfd.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录
            sfd.RestoreDirectory = true;
            sfd.FileName = tb_sheet_no.Text;
            //点了保存按钮进入
            if (sfd.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            if (test160_finished) {
              string save1=  Data160.docx_save(sfd.FileName, data160, lb_max.Text,lb_min.Text,lb_bp.Text);
                if (save1 == "OK") {
                 }else
                {
                    MessageBox.Show("160保存结果出错："+save1);
                  }
            }

        }

        private void gammaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Gamma_CA410_SDK2net f = new Form_Gamma_CA410_SDK2net();
            f.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("cs-200.exe");
        }

        private void btn_move_tocenter_Click(object sender, EventArgs e)
        {
            if (plc_connected == false)
            {
                plc_connect();
            }
            if (plc_connected == false)
            {
                addmemo_txt("测试已停止");
                return;
            }

            
            //移动到零点
            addmemo_txt("移动X到中心点");
            centerx = Convert.ToSingle(tb_center_x.Text);
            centery = Convert.ToSingle(tb_center_y.Text);
            centerz = Convert.ToSingle(tb_center_z.Text);


            //move("x", (Convert.ToDouble(lb_center_x.Text) - Convert.ToDouble(lb_x.Text)));
            move_relative_x = centerx - currentx;
            if (move_relative_x != 0)
            {
                addmemo_txt(Class_PLC.Move_Dis(plc, "x", move_relative_x));
                addmemo_txt(Class_PLC.Move_Exe(plc, "x"));
                Move_Wait_Finish("x");
                autoreset_move.WaitOne();
            }
            else
            {
                addmemo_txt("x移动到位");
            }

            addmemo_txt("移动Y到中心点");
            move_relative_y = centery - currenty;
            if (move_relative_y != 0)
            {
                addmemo_txt("Y移动距离：" + move_relative_y);
                Class_PLC.Move_Dis(plc, "y", move_relative_y);
                Class_PLC.Move_Exe(plc, "y");
                Move_Wait_Finish("y");
                autoreset_move.WaitOne();
            }
            else
            {
                addmemo_txt("y移动到位");
            }

            addmemo_txt("移动Z到中心点");

            move_relative_z = centerz - currentz;
            addmemo_txt("Z移动距离：" + move_relative_z);
            if (move_relative_z != 0)
            {
                Class_PLC.Move_Dis(plc, "z", move_relative_z);
                Class_PLC.Move_Exe(plc, "z");
                Move_Wait_Finish("z");
                autoreset_move.WaitOne();
            }
            else
            {
                addmemo_txt("z移动到位");
            }
        }

        private void btn_save_center_Click(object sender, EventArgs e)
        {
            conn.Open();
            //检查厂商型号是否已存在
            MySql.Data.MySqlClient.MySqlCommand cmd =
                new MySql.Data.MySqlClient.MySqlCommand("select id from  产品参数 where 生产厂商='" + cbb生产厂商.Text + "' and  产品型号='" + cbb产品型号.Text + "'", conn);
            MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) //已存在则更新
            {
                dr.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd2 =
               new MySql.Data.MySqlClient.MySqlCommand("update  产品参数 set 中心坐标='" + tb_center_x.Text + "," + tb_center_y.Text + "," + tb_center_z.Text + "',屏幕大小='" + tb_inch.Text + "',屏幕宽='" + tb_width.Text + "',屏幕高='" + tb_height.Text + "' where 生产厂商='" + cbb生产厂商.Text + "' and 产品型号='" + cbb产品型号.Text + "'", conn);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("已更新");
            }
            else // 不存在则添加
            {
                dr.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd3 =
                  new MySql.Data.MySqlClient.MySqlCommand("insert into  产品参数 (生产厂商,产品型号,屏幕大小,中心坐标,屏幕宽,屏幕高) values('" + cbb生产厂商.Text + "','" + cbb产品型号.Text + "','" + tb_inch.Text + "','" + tb_center_x.Text + "," + tb_center_y.Text + "," + tb_center_z.Text + "','" + tb_width.Text + "','" + tb_height.Text + "')", conn);
                cmd3.ExecuteNonQuery();
                MessageBox.Show("已添加");

            }
            conn.Close();
            config_json.save("X轴原点位置v", tb_center_x.Text);
            config_json.save("Y轴原点位置v", tb_center_y.Text);
            config_json.save("Z轴原点位置v", tb_center_z.Text);
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void tb_x_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            if (tb_inch.Text.Trim() != "")
            {
                double y = Convert.ToDouble(tb_inch.Text) * 25.4;
                double x = Math.Sqrt(y * y / 347 * 256);
                tb_width.Text = x.ToString("0.0");
                tb_height.Text = (x / 16 * 9).ToString("0.0");
            }
        }

        private void btn_count_zero_Click(object sender, EventArgs e)
        {
            tb_center_x.Text = (Convert.ToDouble(tb_height.Text) * 3).ToString();
            tb_center_y.Text = "0";
            //((int)(-Convert.ToDouble(tb_width.Text) / 2 + Convert.ToDouble(tb_width.Text) / 32)).ToString("0.0");
            tb_center_z.Text = (Convert.ToDouble(tb_height.Text) / 2).ToString("0.0");
                //((int)(Convert.ToDouble(tb_height.Text) - Convert.ToDouble(tb_height.Text) / 20)).ToString("0.0");
        }

        private void tb_height_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_plc_connect_Click_1(object sender, EventArgs e)
        {
            if (plc_connected == false)
            {
                plc_connect();
            }
            if (plc_connected == false)
            {
                addmemo_txt("PLC连接失败");
            }
            else {
                timer_get_current_position.Enabled = true;
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            //检查厂商型号是否已存在
            MySql.Data.MySqlClient.MySqlCommand cmd =
                new MySql.Data.MySqlClient.MySqlCommand("select id from  产品参数 where 生产厂商='" + cbb生产厂商.Text + "' and  产品型号='" + cbb产品型号.Text + "'", conn);
            MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) //已存在则更新
            {
                dr.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd2 =
               new MySql.Data.MySqlClient.MySqlCommand("update  产品参数 set 中心坐标='" + tb_center_x.Text + "," + tb_center_y.Text + "," + tb_center_z.Text + "',屏幕大小='" + tb_inch.Text + "',屏幕宽='" + tb_width.Text + "',屏幕高='" + tb_height.Text + "' where 生产厂商='" + cbb生产厂商.Text + "' and 产品型号='" + cbb产品型号.Text + "'", conn);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("已更新");
            }
            else // 不存在则添加
            {
                dr.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd3 =
                  new MySql.Data.MySqlClient.MySqlCommand("insert into  产品参数 (生产厂商,产品型号,屏幕大小,中心坐标,屏幕宽,屏幕高) values('" + cbb生产厂商.Text + "','" + cbb产品型号.Text + "','" + tb_inch.Text + "','" + tb_center_x.Text + "," + tb_center_y.Text + "," + tb_center_z.Text + "','" + tb_width.Text + "','" + tb_height.Text + "')", conn);
                cmd3.ExecuteNonQuery();
                MessageBox.Show("已添加");

            }
            conn.Close();
            config_json.save("X轴原点位置v", tb_center_x.Text);
            config_json.save("Y轴原点位置v", tb_center_y.Text);
            config_json.save("Z轴原点位置v", tb_center_z.Text);
        }

        private void Do_Move()
        {
            for (test_num = 1; test_num <= 160; test_num++)
                //换行
                if ((test_num - 1) % 16 == 0)
                {
                    addmemo_txt("换行");
                    //移动z轴向下运动
                    plc.Write(config_json.Z轴相对运动启动a, 1);

                    //y回到第一列y_base
                    plc.Write(config_json.Y轴相对运动坐标写入a, (y_base - Convert.ToDouble(lb_y.Text)) * 1000);

                    // PLC.Write(config_json.Y轴相对运动坐标写入a, -50000 * 16);
                    plc.Write(config_json.Y轴相对运动启动a, 1);
                    chech_axis = "y";
                    timer_check_move_finished.Enabled = true;
                    row_changed = true;
                }
                else //移动到当前行的下一点
                {
                    addmemo_txt("同行移动1");
                    if (row_changed)
                    {
                        plc.Write(config_json.Y轴相对运动坐标写入a, Convert.ToInt32(config_json.屏幕宽 / 16) * 1000);
                        row_changed = false;
                    }
                    plc.Write(config_json.Y轴相对运动启动a, 1);
                    chech_axis = "y";
                    timer_check_move_finished.Enabled = true;
                }


        }

        private void 写入ca200读数信号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter sw2 = new System.IO.StreamWriter("input.txt");
            sw2.Write("mes");
            sw2.Close();
        }


        //todo move
        bool move(string axis, double value)
        {
            if (plc_connected == false) plc_connect();
            if (plc_connected == false) return false;
            switch (axis)
            {
                case "x":
                    HslCommunication.OperateResult opresult = plc.Write(config_json.X轴相对运动坐标写入a, value * 1000);
                    if (opresult.IsSuccess)
                    {
                        plc.Write(config_json.X轴相对运动启动a, 1);
                        return true;
                    }
                    else
                    {
                        tb_memo.Text += "PLC写入失败\r\n";
                        return false;
                    }
                case "y":
                    HslCommunication.OperateResult opresulty = plc.Write(config_json.Y轴相对运动坐标写入a, (Int32) value * 1000);
                    if (opresulty.IsSuccess)
                    {
                        plc.Write(config_json.Y轴相对运动启动a, 1);
                        return true;
                    }
                    else
                    {
                        tb_memo.Text += "PLC写入失败\r\n";
                        return false;
                    }
                case "z":
                    HslCommunication.OperateResult opresultz = plc.Write(config_json.Z轴相对运动坐标写入a, value * 1000);
                    if (opresultz.IsSuccess)
                    {
                        plc.Write(config_json.Z轴相对运动启动a, 1);
                        return true;
                    }
                    else
                    {
                        tb_memo.Text += "PLC写入失败\r\n";
                        return false;
                    }
                case "r":
                    HslCommunication.OperateResult opresultr = plc.Write(config_json.R轴相对运动坐标写入a, value * 1000);
                    if (opresultr.IsSuccess)
                    {
                        plc.Write(config_json.R轴相对运动启动a, 1);
                        return true;
                    }
                    else
                    {
                        tb_memo.Text += "PLC写入失败\r\n";
                        return false;
                    }
                default:
                    break;
            }
            return false;

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
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
            sfd.FileName = tb_sheet_no.Text;
            //点了保存按钮进入
            if (sfd.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            addmemo_txt(sfd.FileName);
            if (cb_160.Checked && test160_finished)
            {
                string save_result = docx_save.save_160(data160, sfd.FileName, lb_max.Text, lb_min.Text, lb_bp.Text);
                if ("OK" != save_result)
                {
                    MessageBox.Show("文件保存失败：" + save_result);
                    return;
                }
                DialogResult dr =
                       MessageBox.Show("是否需要立即找开Word文档？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
            }
        }

        private void ts_setup_Click(object sender, EventArgs e)
        {
            Form_control f = new Form_control();
            f.ShowDialog();
        }

        private void 启动PLC模拟器ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            testing = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("CS-200色彩析仪模拟器.exe");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Modbus模拟器.exe");
        }

        private void cbb产品型号_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select distinct 中心坐标,屏幕宽,屏幕高,屏幕大小 from  产品参数 where 生产厂商='" + cbb生产厂商.Text + "' and 产品型号='" + cbb产品型号.Text + "'", conn);
            MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string[] cor = dr[0].ToString().Split(',');
                if (cor.Length == 3)
                {
                    tb_center_x.Text = cor[0];
                    tb_center_y.Text = cor[1];
                    tb_center_z.Text = cor[2];
                    tb_width.Text = dr[1].ToString();
                    tb_height.Text = dr[2].ToString();
                    tb_inch.Text = dr[3].ToString(); 
                }

            }
            dr.Close();
            conn.Close();
            if (cbb产品型号.Items.Count > 0 && cbb产品型号.Text == "") cbb产品型号.SelectedIndex = 0;
        }

        private void cbb生产厂商_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cbb产品型号.Items.Clear();
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select distinct 产品型号 from  产品参数 where 生产厂商='" + cbb生产厂商.Text + "'", conn);
            MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbb产品型号.Items.Add(dr[0].ToString());
            }
            dr.Close();
            conn.Close();
            if (cbb产品型号.Items.Count > 0) cbb产品型号.SelectedIndex = 0;
        }

        private void btn_plc_connect_Click(object sender, EventArgs e)
        {
            plc_connect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_Gamma_CA410_SDK2net f = new Form_Gamma_CA410_SDK2net();
            f.ShowDialog();
        }

        //private void button5_Click_1(object sender, EventArgs e)
        //{
        //    conn.Open();
        //    //检查厂商型号是否已存在
        //    MySql.Data.MySqlClient.MySqlCommand cmd =
        //        new MySql.Data.MySqlClient.MySqlCommand("select id from  测试数据 where 测试编号='" + tb_test_proj.Text + "'", conn);
        //    MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.Read()) //已存在则更新
        //    {
        //        dr.Close();
        //        MySql.Data.MySqlClient.MySqlCommand cmd2 =
        //       new MySql.Data.MySqlClient.MySqlCommand("update  测试数据 set 最大亮度='" + tb_light_value.Text + "' where 测试编号='" + tb_test_proj.Text + "'", conn);
        //        cmd2.ExecuteNonQuery();
        //    }
        //    else // 不存在则添加
        //    {
        //        dr.Close();
        //        MySql.Data.MySqlClient.MySqlCommand cmd3 =
        //          new MySql.Data.MySqlClient.MySqlCommand("insert into  测试数据 (测试编号,最大亮度,测试时间) values('" + tb_test_proj.Text + "','" + tb_light_value.Text + "','" + tb_centerX.Text + "',now())", conn);
        //        cmd3.ExecuteNonQuery();

        //    }
        //    conn.Close();
        //}
    }
}
