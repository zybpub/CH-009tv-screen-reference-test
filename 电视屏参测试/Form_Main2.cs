using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Test_Automation
{
    public partial class Form_Main2 : Form
    {
        
        public Form_Main2()
        {
            InitializeComponent();
        }
        string X = "";
        string Y = "";
        string Z = "";
        string AZ = "";
        string R = "";
        string database_type = "sqlite";  //or mysql 设置使用的数据库类型
        private void Form_PLC_Load(object sender, EventArgs e)
        {
            config_json.config_json_readall();
            SOFT_VER.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            win_init();

            //if (database_type == "sqlite")
            //{
            //    sqlite_action_name_read();
            //    sqlite_action_details_read();
            //}
            //else if (database_type == "mysql") {
            //    mysql_action_nanme_read();
            //    mysql_action_details_read();
            //}

          //  btn_client_connect_Click(null, null);
        }

        string sqlite_database_FileName = "testDB.db";
        SQLiteDataAdapter sqlite_da;
       
        //private void sqlite_action_details_read()
        //{
        //    string sql = "SELECT * FROM 动作明细表 where 动作名称='"+comboBox1.Text+"'";
        //    //string conStr = "D:/sqlliteDb/document.db";
        //    string connStr = @"Data Source=" + sqlite_database_FileName + @";Initial Catalog=sqlite;Integrated Security=True;Max Pool Size=10";
        //    SQLiteConnection conn = new SQLiteConnection(connStr);
        //    //conn.Open();
        //    sqlite_da = new SQLiteDataAdapter(sql, conn);
        //    dataset = new System.Data.DataSet();
        //    sqlite_da.Fill(dataset, "wb");
        //    DataTable dt = dataset.Tables[0];
        //    dataGridView1.DataSource = dt;
        //}
        //void mysql_action_nanme_read()
        //{
        //    comboBox1.Items.Clear();
        //    mysql_Conn = new MySql.Data.MySqlClient.MySqlConnection("Database="
        //       + config_json.mysql_database_name + ";Data Source=" + config_json.Mysql_IP
        //       + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8");
        //    string sql = "select  动作名称 from 动作名称表 order by id";

        //    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql,mysql_Conn);

        //    try
        //    {
        //        mysql_Conn.Open();

        //        MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();

        //        while (dr.Read())          //循环读取结果集
        //        {
        //            //读取数据库中的信息并显示在界面中
        //            comboBox1.Items.Add(dr[0].ToString());
        //        }
        //        if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
        //        dr.Close();
        //        mysql_Conn.Close();
        //    }
        //    catch {
        //        MessageBox.Show("mysql数据库连接失败");
        //    }
        //}

        MySql.Data.MySqlClient.MySqlDataAdapter mysql_da;
        System.Data.DataSet dataset;
        private MySql.Data.MySqlClient.MySqlConnection mysql_Conn;
        void mysql_action_details_read() {
            mysql_Conn = new MySql.Data.MySqlClient.MySqlConnection("Database="
               + config_json.mysql_database_name + ";Data Source=" + config_json.Mysql_IP
               + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8");

           //  mysql_da =new MySql.Data.MySqlClient.MySqlDataAdapter("select  * from 动作明细表 where 动作名称='"+comboBox1.Text+"' order by 序号", mysql_Conn);

            try { 
            mysql_Conn.Open();

            dataset = new System.Data.DataSet();
            mysql_da.Fill(dataset, "wb");
            // 建立DataTable对象(相当于建立前台的虚拟数据库中的数据表)
            System.Data.DataTable dtable;
            //将数据表tabuser的数据复制到DataTable对象（取数据）
            dtable = dataset.Tables["wb"];

           // System.Data.DataRowCollection coldrow;
           // coldrow = dtable.Rows;

           // dataGridView1.DataSource = dtable;

            mysql_Conn.Close();
            }
            catch
            {
              
            }
        }
        //private void btn_add_detail_Click(object sender, EventArgs e)
        //{
        //    if (database_type == "mysql")
        //    {
        //        mysql_Conn = new MySql.Data.MySqlClient.MySqlConnection("Database="
        //    + config_json.mysql_database_name + ";Data Source=" + config_json.Mysql_IP
        //    + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8");

        //        mysql_Conn.Open();
        //        string sql = "insert into  动作明细表 (动作名称,序号,X,Y,Z,R,AX,AZ,AR) values('" + comboBox1.Text
        //            + "','" + tb_序号.Text
        //            + "','" + tb_x.Text
        //            + "','" + tb_y.Text
        //            + "','" + tb_z.Text
        //            + "','" + tb_r.Text
        //            + "','" + tb_ax.Text
        //            + "','" + tb_az.Text
        //            + "','" + tb_ar.Text + "')";

        //        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, mysql_Conn);


        //        cmd.ExecuteNonQuery();
        //        mysql_Conn.Close();
        //        mysql_action_nanme_read();
        //    }
        //    else if (database_type == "sqlite") {
        //        string connectionString = "data source = " + sqlite_database_FileName;
        //        System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(connectionString);
        //        conn.Open();

        //        string sql = "insert into  动作明细表 (动作名称,序号,X,Y,Z,R,AX,AZ,AR) values('" + comboBox1.Text
        //             + "','" + tb_序号.Text
        //             + "','" + tb_x.Text
        //             + "','" + tb_y.Text
        //             + "','" + tb_z.Text
        //             + "','" + tb_r.Text
        //             + "','" + tb_ax.Text
        //             + "','" + tb_az.Text
        //             + "','" + tb_ar.Text + "')";

        //        System.Data.SQLite.SQLiteCommand cmd = conn.CreateCommand();
        //        cmd.CommandText = sql;
        //        cmd.ExecuteNonQuery();
        //        conn.Close();
        //        sqlite_action_details_read();
        //        MessageBox.Show("添加成功");
        //    }
          
        //}

        //private void btn_add_name_Click(object sender, EventArgs e)
        //{
        //    if (database_type == "mysql")
        //    {
        //        MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection("Database="
        //   + config_json.mysql_database_name + ";Data Source=" + config_json.Mysql_IP
        //   + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8");

        //        conn.Open();
        //        string sql = "insert into  动作名称表 (动作名称) values('" + tb_action_name.Text.Trim() + "')";

        //        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
        //        cmd.ExecuteNonQuery();
        //        conn.Close();
        //        mysql_action_nanme_read();
        //    }
        //    else if (database_type == "sqlite")
        //    {
        //        string connectionString = "data source = " + sqlite_database_FileName;
        //        System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(connectionString);
        //        conn.Open();

        //        string sql = "insert into  动作名称表 (动作名称) values('" + tb_action_name.Text.Trim() + "')";

        //        System.Data.SQLite.SQLiteCommand cmd = conn.CreateCommand();
        //        cmd.CommandText = sql;
        //        cmd.ExecuteNonQuery();
        //        conn.Close();
        //        sqlite_action_name_read();
        //        MessageBox.Show("添加成功");
        //    }

        //}
        void win_init()
        {
            tbPLC_ip.Text = config_json.PLC_IP;
        }

        private HslCommunication.ModBus.ModbusTcpNet PLC;

        private bool connected=false;

        private void btn_client_connect_Click(object sender, EventArgs e)
        {
            PLC = new HslCommunication.ModBus.ModbusTcpNet(config_json.PLC_IP, 502,1);   // 站号1

            HslCommunication.OperateResult resut= PLC.ConnectServer();
            if (resut.IsSuccess)
            {
                tb_log.Text += "已成功连接PLC\r\n";
                btn_client_connect.Enabled = false;
                btn_client_disconnect.Enabled = true;
                connected = true;
            }
            else {
                tb_log.Text += "连接PLC失败\r\n";
            }
        }


        private void button9_Click(object sender, EventArgs e)
        {

            if (connected == false) btn_client_connect_Click(null, null);

            HslCommunication.OperateResult result = PLC.Write(tb_start_reg.Text, Convert.ToInt32(tb_startregvalue.Text));
            if (result.IsSuccess)
            {
                tb_log.Text += tb_start_reg.Text+"写入成功：" + tb_startregvalue.Text+"\r\n";
            }
            else
            {
                tb_log.Text += tb_start_reg.Text + "写入失败：" + tb_startregvalue.Text+"\r\n";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (connected == false) btn_client_connect_Click(null, null);
            HslCommunication.OperateResult<Int32> result = PLC.ReadInt32(tb_start_reg.Text);

            if (result.IsSuccess)
            {
                tb_log.Text += tb_start_reg.Text + "读取成功：" + result.Content.ToString() + "\r\n";
            }
            else
            {
                tb_log.Text += tb_start_reg.Text + "读取失败\r\n";
            }
        }

    
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_mon_M170_Click(object sender, EventArgs e)
        {
            timer1_m_detect.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tb_log.Text += PLC.ReadInt16("171").Content.ToString();
        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (database_type == "mysql")
        //        mysql_action_details_read();
        //    else if (database_type == "sqlite") sqlite_action_details_read();
        //}
        bool test_stopped = false;


        string action = ""; //或退件

       int  plc_write_failtimes=0;
       
        

        string check_PLC_addr = "";
       

        private void btn_onestep_Click(object sender, EventArgs e)
        {
        }

        bool plc_write(string addr, string  value) {
            HslCommunication.OperateResult result = PLC.Write(addr,Convert.ToInt32( value));
            if (result.IsSuccess)
            {
                addmemo(addr + "写入:" + value + "成功");
                return true;
            }
            else
            {
                addmemo(addr + "写入:" + value + "失败");
                return  false;
            }
                
        }

        private void addmemo(string str)
        {
            tb_log.Text += str + "\r\n";
        }


        private void btn_log_clear_Click(object sender, EventArgs e)
        {
            tb_log.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1_m_detect.Enabled = false;
        }

        private void btn_autorun_Click(object sender, EventArgs e)
        {
           // dataGridView1.Update();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
        ////变更后立即更新
        //private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dataset.HasChanges())
        //    {
        //        if (database_type == "mysql")
        //        {
        //            MySql.Data.MySqlClient.MySqlCommandBuilder commondbuilder = new MySql.Data.MySqlClient.MySqlCommandBuilder(mysql_da);
        //            mysql_da.Update(dataset.Tables["wb"]);
        //            dataset.Tables["wb"].AcceptChanges();
        //        } else if (database_type == "sqlite")
        //        {
        //            System.Data.SQLite.SQLiteCommandBuilder commondbuilder = new System.Data.SQLite.SQLiteCommandBuilder(sqlite_da);
        //            sqlite_da.Update(dataset.Tables["wb"]);
        //            dataset.Tables["wb"].AcceptChanges();
        //        }

        //    }
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            Form_control fc = new Form_control();
            fc.Show();
        }

        private void btn_move_test_Click(object sender, EventArgs e)
        {
            Form_move fmt = new Form_move();
            fmt.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void timer_check_xyisfinished_Tick(object sender, EventArgs e)
        {
           
        }

        private void timer_z_upfinished_Tick(object sender, EventArgs e)
        {
            
        }

        private void timer_check_movefinished_Tick(object sender, EventArgs e)
        {
           
        }

        private void btn_退件_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_pos_reset_Click(object sender, EventArgs e)
        {
            HslCommunication.OperateResult opresult = PLC.Write(config_json.复位写入, Convert.ToInt32(305));
            if (opresult.IsSuccess) tb_log.Text += "成功\r\n";
            else tb_log.Text += "失败\r\n";
        }
    }
}
