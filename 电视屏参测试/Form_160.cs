using Aspose.Words;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace Test_Automation
{
    public partial class Form_160 : Form
    {
        public Form_160()
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

        bool plc_connected = false;
        int test_num = 1;
        float[] result = new float[160];
        bool testing = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Class_Mysql.Exexute_Sql2Str("select id from 测试数据 where 测试编号='" + tb_test_proj.Text + "'") != "")
            {
                string result = zyb_class.InputBox("测试编号已存在", "测试编号" ,tb_test_proj.Text);
                if (result!="") tb_test_proj.Text = result;
            }
            action = "测试";
            addmemo_txt("启动测试160点均匀性测试");
            cs200.RunCS200();
            if (!plc_connected) btn_plc_connect_Click(null, null);

            if (plc_connected)
            {
                PLC.Write(config_json.Y轴相对运动坐标写入a, Convert.ToInt32(tb列间距.Text)*1000);
                PLC.Write(config_json.Z轴相对运动坐标写入a, -Convert.ToInt32(tb行间距.Text)*1000);
            }else
            {
                return;
            }
           
            lb_test_num.Text = test_num.ToString();

            testing = true;
            Do_GetData();

            //timer_test_timeout.Enabled = true;
            // timer_read_result.Enabled = true;
        }
        string result_file = "result.txt";
        double max=0, min=0;
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
                foreach (Control c in panel1.Controls)
                {
                    if (c is PictureBox && c.Name == "pb" + test_num.ToString())
                    {
                        PictureBox pb = c as PictureBox;
                        pb.Image = global::Test_Automation.Properties.Resources.green;
                    }

                    if (c is Label && c.Name == "n" + test_num.ToString())
                    {

                        Label lb = c as Label;
                        //lb.Text = data[9].Substring(0,data[9].Length-(data[9].IndexOf(".")+2));
                        if (data[9].Length >= 5)
                            lb.Text = data[9].Substring(0, 5);
                        else lb.Text = data[9];

                        addmemo_txt(test_num.ToString() + "读数:" + lb.Text + "," + data[10] + "," + data[11]);

                        if (test_a == 0)
                        {
                            test_a = Convert.ToSingle(lb.Text);
                            Do_GetData();
                            return;
                        }
                        else {
                            test_b = Convert.ToSingle(lb.Text);
                            int diff = (int)(Math.Abs(test_a - test_b) / test_b * 1000);
                            addmemo_txt("两次读数差异"+((float)diff/10).ToString());
                            if (diff > 10) {
                                addmemo_txt("两次读数已超过1%，再次读数");
                                test_a = test_b;
                                Do_GetData();
                                return;
                            }
                            else
                            {
                                addmemo_txt("两次读数差异未超过1%");
                            }
                        }
                       
                        test_a = 0;
                         result[test_num - 1] = Convert.ToSingle(lb.Text);
                        Data160 d = new Data160();
                        d.l = lb.Text; d.u = data[10]; d.v = data[11].Trim();
                        data160.Add(d);

                        if (test_num == 1) { max = result[test_num - 1]; lb_max.Text = lb.Text; min = result[test_num - 1]; lb_min.Text = lb.Text; }
                        if (result[test_num - 1] > max) { max = result[test_num - 1];lb_max.Text = lb.Text; }
                        if (result[test_num - 1] < min) { min = result[test_num - 1]; lb_min.Text = lb.Text; }

                        lb_bp.Text =( min / max * 100).ToString("0.00");
                    }
                }

                if (testing) Do_Move();
            }
            catch
            {
                timer_read_result.Enabled = true;
            }
        }
        bool row_changed = false;
        private void Do_Move()
        {
            test_num++;
            tb_memo.Text += test_num.ToString();
            if (test_num == 161)  //test_num从1开始
            {
                MessageBox.Show("160个数据测试完成");
                return;
            }
            //换行
            if ((test_num-1) % 16 == 0)
            {
                tb_memo.Text += "换行\r\n";
                PLC.Write(config_json.Z轴相对运动启动a, 1);

                PLC.Write(config_json.Y轴相对运动坐标写入a,( Convert.ToInt32(tb_zeroY.Text) - PLC.ReadInt32(config_json.Y轴当前位置a).Content/1000)*1000);

               // PLC.Write(config_json.Y轴相对运动坐标写入a, -50000 * 16);
                PLC.Write(config_json.Y轴相对运动启动a, 1);
                chech_axis = "y";
                timer_check_move_finished.Enabled = true;
                row_changed = true;
            }
            else //移动到当前行的下一点
            {
                tb_memo.Text += "同行移动\r\n";
                if (row_changed)
                {
                    PLC.Write(config_json.Y轴相对运动坐标写入a, Convert.ToInt32(tb列间距.Text) * 1000);
                    row_changed = false;
                }
                PLC.Write(config_json.Y轴相对运动启动a, 1);
                chech_axis = "y";
                timer_check_move_finished.Enabled = true;
            }
 
        
        }

        void Do_GetData()
        {
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
            timer_test_timeout.Enabled = true;
            timer_read_result.Enabled = true;
           
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
        List<Data160> data160 = new List<Data160>();
        public static MySql.Data.MySqlClient.MySqlConnection conn;
        private void Form_160_Load(object sender, EventArgs e)
        {
            config_json.config_json_readall();
            
            con =
          new MySql.Data.MySqlClient.MySqlConnection(
              "Database=" + config_json.mysql_database_name + ";" +
              "Data Source=" + config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");

         
            tb_zeroX.Text = config_json.X轴原点位置v;
            tb_zeroY.Text = config_json.Y轴原点位置v;
            tb_zeroZ.Text = config_json.Z轴原点位置v;

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


            tb行间距.Text = config_json.行间距;
            tb列间距.Text = config_json.列间距;

            serialPort_VG876.PortName = config_json.VG870_PortName;
            autoreset = new AutoResetEvent(false);
            conn =
         new MySql.Data.MySqlClient.MySqlConnection(
             "Database=" + config_json.mysql_database_name + ";" +
             "Data Source=" + config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");
            加载产商和型号();
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
                tb_nowY.Text = (PLC.ReadInt32(config_json.Y轴当前位置a).Content/1000).ToString();
                tb_nowZ.Text = (PLC.ReadInt32(config_json.Z轴当前位置a).Content/1000).ToString();
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
                        if (action == "回到原点") {
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

        private void btn_move_x_Click(object sender, EventArgs e)
        {
            if (!plc_connected) btn_plc_connect_Click(null, null);
            {
                HslCommunication.OperateResult opresult = PLC.Write(config_json.X轴相对运动坐标写入a, Convert.ToInt32(tb_x.Text));
                HslCommunication.OperateResult opresult2 = PLC.Write(config_json.X轴相对运动启动a, 1);
                tb_memo.Text += config_json.X轴相对运动坐标写入a + "写入：" + tb_x.Text + "\r\n";
            }
            // PLC.move_x(plc, tb_x.Text);


        }

        private void btn_move_y_Click(object sender, EventArgs e)
        {
            // if (plc_connected)    PLC.move_y(plc, tb_y.Text);
            if (!plc_connected) btn_plc_connect_Click(null, null);
            {
                HslCommunication.OperateResult opresult = PLC.Write(config_json.Y轴相对运动坐标写入a, Convert.ToInt32(tb_y.Text));
                HslCommunication.OperateResult opresult2 = PLC.Write(config_json.Y轴相对运动启动a, 1);
                tb_memo.Text += config_json.Y轴相对运动坐标写入a + "写入：" + tb_y.Text + "\r\n";
           }
        }

        private void btn_move_z_Click(object sender, EventArgs e)
        {
            // if (plc_connected) Test_Automation.PLC.move_z(PLC, tb_z.Text);
            if (!plc_connected) btn_plc_connect_Click(null, null);
            {
                HslCommunication.OperateResult opresult = PLC.Write(config_json.Z轴相对运动坐标写入a, Convert.ToInt32(tb_z.Text));
                HslCommunication.OperateResult opresult2 = PLC.Write(config_json.Z轴相对运动启动a, 1);
                tb_memo.Text += config_json.Z轴相对运动坐标写入a + "写入：" + tb_z.Text + "\r\n";
            }
        }

        private void btn_move_r_Click(object sender, EventArgs e)
        {
            //if (plc_connected) Test_Automation.PLC.move_r(PLC, tb_r.Text);
            if (!plc_connected) btn_plc_connect_Click(null, null);
            {
                HslCommunication.OperateResult opresult = PLC.Write(config_json.R轴相对运动坐标写入a, Convert.ToInt32(tb_r.Text));
                HslCommunication.OperateResult opresult2 = PLC.Write(config_json.R轴相对运动启动a, 1);
                tb_memo.Text += config_json.R轴相对运动坐标写入a + "写入：" + tb_r.Text + "\r\n";
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
           
            MessageBox.Show("保存成功");
        }

        private void serialPort_VG876_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort_VG876.IsOpen == false) serialPort_VG876.Open();
                serialPort_VG876.Write(config_json.pattern_white, 0, config_json.pattern_white.Length);
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort_VG876.IsOpen == false) serialPort_VG876.Open();
                serialPort_VG876.Write(config_json.pattern_red, 0, config_json.pattern_red.Length);
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort_VG876.IsOpen == false) serialPort_VG876.Open();
                serialPort_VG876.Write(config_json.pattern_green, 0, config_json.pattern_green.Length);
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           try
            {
                if (serialPort_VG876.IsOpen == false) serialPort_VG876.Open();
                serialPort_VG876.Write(config_json.pattern_blue, 0, config_json.pattern_blue.Length);
            }
            catch { }
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
        private void button3_Click_1(object sender, EventArgs e)
        {
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
                   new MySql.Data.MySqlClient.MySqlCommand("update  测试数据 set　均匀性='" + string.Join(",", result) + "', 均匀性最大值='" + lb_max.Text + ", 均匀性最小值='"
                   + lb_min.Text + "',均匀性BP='" + lb_bp.Text + "' where 测试编号='" + tb_test_proj.Text + "'", con);
                    //  cmd2.ExecuteNonQuery();
                }
                else // 不存在则添加
                {
                    dr.Close();
                    MySql.Data.MySqlClient.MySqlCommand cmd3 =
                      new MySql.Data.MySqlClient.MySqlCommand("insert into  测试数据 (测试编号,均匀性,均匀性最大值,均匀性最小值,均匀性BP) values('" + tb_test_proj.Text + "','" + string.Join(",", result) + "','" + lb_max.Text + "','" + lb_min.Text + "','" + lb_bp.Text + "')", con);
                    cmd3.ExecuteNonQuery();

                }
                con.Close();
            }
            catch (Exception ex)
            {
                if (con.State == System.Data.ConnectionState.Open) con.Close();
                MessageBox.Show("保存到数据库出错："+ex.Message);
            }

            //string localFilePath, fileNameExt, newFileName, FilePath;
            SaveFileDialog sfd = new SaveFileDialog();
            //设置文件类型
            sfd.Filter ="文本文件(*.txt)|*.txt";
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

                //获取文件路径，不带文件名
                //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));

                //给文件名前加上时间
                //newFileName = DateTime.Now.ToString("yyyyMMdd") + fileNameExt;

                //在文件名里加字符
                //saveFileDialog1.FileName.Insert(1,"dameng");

                //System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();//输出文件

                ////fs输出带文字或图片的文件，就看需求了

                // string filename = System.IO.Directory.GetCurrentDirectory() + "/" + tb_test_proj.Text + ".txt";
                System.IO.StreamWriter sw2 = new System.IO.StreamWriter(localFilePath, true);
                sw2.Write("\r\n测试编号：" + tb_test_proj.Text + "\r\n160点测试结果：\r\n" + tb_memo.Text + "\r\n");


                //result = array_sort(result);
                //sw2.Write("9个最大值：");
                //for (int i = 159; i >= 150; i--)
                //{
                //    sw2.Write(result[i].ToString() + ",");
                //}

                //sw2.Write("9个最小值：");
                //for (int i = 0; i < 10; i++)
                //{
                //    sw2.Write(result[i].ToString() + ",");
                //}


                //每一行输出一个测试数据
                //{
                //    int i = 0;
                //    foreach (var d in data160)
                //    {
                //        i++;
                //        sw2.Write(i.ToString() + "," + d.l + "," + d.u + "," + d.v + "\r\n");
                //    }
                //}

                //按表格格式输出测试数据
                {
                    for (int j = 0; j < 10; j++)
                    {
                        sw2.Write("序号,\t");
                        for (int i = 0; i < 16; i++)
                        {
                            sw2.Write((i + j * 16).ToString() + ",\t");
                        }
                        sw2.Write("\r\n");
                        sw2.Write("l,\t");
                        for (int i = 0; i < 16; i++)
                        {
                            sw2.Write(data160[i + j * 16].l+",\t");
                        }
                        sw2.Write("\r\n");
                        sw2.Write("x,\t");
                        for (int i = 0; i < 16; i++)
                        {
                            sw2.Write(data160[i + j * 16].u + ",\t");
                        }
                        sw2.Write("\r\n");
                        sw2.Write("y,\t");
                        for (int i = 0; i < 16; i++)
                        {
                            sw2.Write(data160[i + j * 16].v + ",\t");
                        }
                        sw2.Write("\r\n");
                        sw2.Write("\r\n");
                    }

                }
                sw2.Write("最大值：");
                sw2.Write(lb_max.Text + ",");
                sw2.Write("最小值：");
                sw2.Write(lb_min.Text + "\r\n");
                sw2.Write("Bp=" + lb_bp.Text + "%\r\n");
                sw2.Close();
            }
        }
        float[] array_sort(float[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                //在 i-(nums.Length-1) 范围内，将该范围内最小的数字提到i
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] < nums[j])
                    {
                        //交换
                        float temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }
            }
            return nums;
        }
        float[] test = { 3, 5, 9, 1, 2, 3 };
        private void button6_Click(object sender, EventArgs e)
        {
            test = array_sort(result);
            for (int i = 0; i < test.Length; i++)
            {
                tb_memo.Text += test[i].ToString() + "\r\n";
            }
        }

        private void label138_Click(object sender, EventArgs e)
        {

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

            PLC.Write(config_json.X轴相对运动坐标写入a, ( Convert.ToInt32(tb_zeroX.Text) - Convert.ToInt32(tb_nowX.Text))*1000);
            PLC.Write(config_json.Y轴相对运动坐标写入a,  ( Convert.ToInt32(tb_zeroY.Text) - Convert.ToInt32(tb_nowY.Text))*1000);
            PLC.Write(config_json.Z轴相对运动坐标写入a, (Convert.ToInt32(tb_zeroZ.Text)-Convert.ToInt32(tb_nowZ.Text))*1000  );
            PLC.Write(config_json.X轴相对运动启动a, 1);
            PLC.Write(config_json.Y轴相对运动启动a, 1);
            PLC.Write(config_json.Z轴相对运动启动a, 1);
            action = "回到原点";
            chech_axis = "x";
            timer_check_move_finished.Enabled = true;
            addmemo_txt("检测头回到零点");
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
               new MySql.Data.MySqlClient.MySqlCommand("update  产品参数 set 零点坐标='" + tb_zeroX.Text + "," + tb_zeroY.Text + "," + tb_zeroZ.Text + "',列间距="+tb列间距.Text+",行间距="+tb行间距.Text+" where 产品型号='" + cbb_type.Text + "'", conn);
                cmd2.ExecuteNonQuery();
            }
            else // 不存在则添加
            {
                dr.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd3 =
                  new MySql.Data.MySqlClient.MySqlCommand("insert into  产品参数 (产品型号,零点坐标,列间距,行间距) values('" + cbb_type.Text + "','" + tb_zeroX.Text + "," + tb_zeroY.Text + "," + tb_zeroZ.Text + "',"+tb列间距.Text+","+tb行间距.Text+")", conn);
                cmd3.ExecuteNonQuery();

            }
            conn.Close();
            config_json.save("X轴原点位置v", tb_zeroX.Text);
            config_json.save("Y轴原点位置v", tb_zeroY.Text);
            config_json.save("Z轴原点位置v", tb_zeroZ.Text);
            config_json.save("行间距", tb行间距.Text);
            config_json.save("列间距", tb列间距.Text);
            config_json.行间距 = tb行间距.Text;
            config_json.列间距 = tb列间距.Text;
            MessageBox.Show("保存成功");
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Random rd = new Random();
            data160.Clear();
            for (int i = 0; i < 160; i++)
            {
                Data160 d = new Data160();
                d.l = rd.Next(300, 380).ToString();
                d.u = rd.Next(0,3).ToString();
                d.v = rd.Next(0, 3).ToString();
                data160.Add(d);
            }
        }

        private void cbb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select distinct 零点坐标,列间距,行间距,屏幕宽,屏幕高 from  产品参数 where 产品型号='" + cbb_type.Text + "'", conn);
            MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                try
                {
                    string[] str = dr[0].ToString().Split(',');
                    tb_zeroX.Text = str[0];
                    tb_zeroY.Text = str[1];
                    tb_zeroZ.Text = str[2];
                    tb列间距.Text = dr[1].ToString();
                    tb行间距.Text = dr[2].ToString();
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
           tb_zeroX.Text=  ( Math.Sqrt(Convert.ToInt16(tb_width.Text) * Convert.ToInt16(tb_width.Text) + Convert.ToInt16(tb_height.Text) * Convert.ToInt16(tb_height.Text)) *3).ToString();


            tb_zeroY.Text = ((int)(-Convert.ToDouble(tb_width.Text) / 2 + Convert.ToDouble(tb_width.Text) / 32)).ToString();
            tb_zeroZ.Text = ((int)(Convert.ToDouble(tb_height.Text) - Convert.ToDouble(tb_height.Text) /20)).ToString();
        }

        private void btn_gamma_Click(object sender, EventArgs e)
        {

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
            builder.PageSetup.LeftMargin = 50;
            builder.PageSetup.TopMargin = 60;
            builder.PageSetup.BottomMargin = 30;
            builder.StartTable();
            // builder.RowFormat.LeftIndent = 15;
            //标题

            builder.InsertCell();//序号列
            builder.Write("坐标");
            builder.InsertCell();
           // builder.CellFormat.
            builder.CellFormat.Borders.LineStyle = LineStyle.Single;
            builder.CellFormat.Borders.Color = System.Drawing.Color.Black;
            builder.CellFormat.Width = colomn_width;
            builder.CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;//垂直居中对齐
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;//水平居中对齐
            builder.Write("类别");
            //标题
            for (int i = 1; i < 17; i++)
            {
                builder.InsertCell();
                builder.CellFormat.Borders.LineStyle = LineStyle.Single;
                builder.CellFormat.Borders.Color = System.Drawing.Color.Black;
                builder.CellFormat.Width = colomn_width;
                builder.CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;//垂直居中对齐
                builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;//水平居中对齐
                builder.Write(i.ToString());
            }
            builder.EndRow();

            for (int j = 0; j < 10; j++)
            {
                builder.InsertCell();
                builder.Write((j+1).ToString());  //序号
                builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.First;
               builder.InsertCell();
            builder.Write("l");

            for (int i = 0; i < 16; i++)
            {
                builder.InsertCell();
                builder.CellFormat.Borders.LineStyle = LineStyle.Single;
                builder.CellFormat.Borders.Color = System.Drawing.Color.Black;
                builder.CellFormat.Width = colomn_width;
                builder.CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;//垂直居中对齐
                builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;//水平居中对齐
               builder.Write(data160[i+j*16].l);
            }
            builder.EndRow();

                builder.InsertCell();

                builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.Previous;

                builder.InsertCell();

                builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                builder.Write("u");
            for (int i = 0; i < 16; i++)
            {
                builder.InsertCell();

                    builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                    builder.CellFormat.Borders.LineStyle = LineStyle.Single;
                builder.CellFormat.Borders.Color = System.Drawing.Color.Black;
                builder.CellFormat.Width = colomn_width;
                builder.CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;//垂直居中对齐
                builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;//水平居中对齐
               builder.Write(data160[i+j * 16].u);
            }
            builder.EndRow();
                builder.InsertCell();

                builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.Previous;
                builder.InsertCell();

                builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                builder.Write("v");
            for (int i = 0; i < 16; i++)
            {
                builder.InsertCell();

                    builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                    builder.CellFormat.Borders.LineStyle = LineStyle.Single;
                builder.CellFormat.Borders.Color = System.Drawing.Color.Black;
                builder.CellFormat.Width = colomn_width;
                builder.CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;//垂直居中对齐
                builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;//水平居中对齐
                builder.Write(data160[i+j * 16].v.Trim());
            }
            builder.EndRow();
            }

            builder.EndTable();

            builder.Write("最大值："+lb_max.Text+"\t");
            builder.Write("最小值：" + lb_min.Text + "\t");
            builder.Write("BP值：" + lb_bp.Text + "\r\n");

            //在对应书签位置插入word文档
            //Document srcDoc = new Document("TestInsertChartColumn.docx");

            //builder.MoveToBookmark("合同正文");

            //builder.InsertDocument(srcDoc, ImportFormatMode.KeepDifferentStyles);

            // doc.Save(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "测试结果"+DateTime.Now.ToString("yyyyMMdd-HHmmss")+".doc"));
            string file = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, sfd.FileName.ToString());
            try
            {
                doc.Save(file);
                //转换为pdf文档
                // doc.Save(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "合同正文.pdf"), Aspose.Words.SaveFormat.Pdf);

                DialogResult dr =
                        MessageBox.Show("是否需要立即找开Word文档？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(file);
                }
            }
            catch (Exception ex) {
                MessageBox.Show("文件保存出错："+ex.Message);
            }

           
        }


        private void btn_get_current_position_Click(object sender, EventArgs e)
        {
            if (plc_connected)
            {
                tb_nowX.Text = (PLC.ReadInt32(config_json.X轴当前位置a).Content/1000).ToString();
                tb_nowY.Text = (PLC.ReadInt32(config_json.Y轴当前位置a).Content/1000).ToString();
                tb_nowZ.Text = (PLC.ReadInt32(config_json.Z轴当前位置a).Content/1000).ToString();
                addmemo_txt( "X轴当前位置:" + tb_nowX.Text );
                addmemo_txt("Y轴当前位置:" + tb_nowY.Text);
                addmemo_txt("Z轴当前位置:" + tb_nowZ.Text);
                timer_get_current_position.Enabled = true;
            }
        }

     
    }
}
