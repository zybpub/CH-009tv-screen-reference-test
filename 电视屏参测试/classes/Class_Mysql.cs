//V1.0

using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Test_Automation
{
    class Class_Mysql
    {
        public static MySql.Data.MySqlClient.MySqlConnection conn;
        public Class_Mysql()
        {
            conn =
             new MySql.Data.MySqlClient.MySqlConnection(
                 "Database=" + config_json.mysql_database_name + ";" +
                 "Data Source=" + config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");

        }

        public static MySql.Data.MySqlClient.MySqlConnection get_conn()
        {
            return new MySql.Data.MySqlClient.MySqlConnection(
                   "Database=" + config_json.mysql_database_name + ";" +
                   "Data Source=" + config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");
        }

        public static string Exexute_Sql(string sql)
        {
            conn = get_conn();
            string result = "OK";
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            conn.Close();
            return result;
        }

        public static string Exexute_Sql2Str(string sql)
        {
            conn = get_conn();
            string result = "";
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                result = dr[0].ToString();
            }
            dr.Close();
            conn.Close();
            return result;
        }
        public static string check_mysql()
        {
            conn = get_conn();
            string result = "OK";
            try
            {
                conn.Open();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Access denied") > -1)
                {
                    //password incorrect,set to destin password  
                    //set password =password('')
                    result = Class_Mysql.create_password();
                    //change pass failed
                    if (result != "OK")
                    {
                        // return "密码有误或原密码不为空（创建密码失败，原密码必须为空）";
                    }
                }
            }

            try
            {
                if (create_database() != "OK")
                {
                    return "创建数据库失败";
                }
            }
            catch (Exception exx)
            {
                 return exx.Message;
            }

            try
            {
                string table_result = create_tables();
                if (table_result == "OK") { } else { result += table_result; }
            }
            catch (Exception exx)
            {
                result = exx.Message;
            }
            return result;
        }

        public static bool check_table_column_isexist(string tablename, string columnname)
        {
            conn = get_conn();
            bool b = false;
            conn.Open();
            string query = @"SELECT count(*) FROM information_schema.COLUMNS WHERE table_name = '" + config_json.mysql_testdata_table
                + "' AND column_name = '" + columnname + "'";
            //string query = @"SELECT count(*) FROM information_schema.COLUMNS WHERE table_name = 'jyny_testdataV3' AND column_name = 'operator'";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr[0].ToString() == "1") b = true;
            }

            conn.Close();
            return b;

        }
        /// <summary>
        /// 为表添加列
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="columnname">列名</param>
        /// <param name="typeandlength">列类型及长度VARCHAR(50)</param>
        /// <returns></returns>
        public static string add_column(string tablename, string columnname, string typeandlength)
        {
            conn = get_conn();
            string result = "OK";
            string query = "ALTER TABLE `" + tablename + "` ADD `" + columnname + "` " + typeandlength + "  NULL";
            conn.Open();
            //create command and assign the query and connection from the constructor
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);

            //Execute command
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            conn.Close();
            return result;
        }

        /// <summary>
        /// 为表添加列
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="columnname">列名</param>
        /// <returns></returns>
        public static string add_column(string tablename, string columnname)
        {
            return add_column(tablename, columnname, "VARCHAR(50)");
        }

      
        public static bool check_table_is_exist(string database_name, string table_name)
        {
            conn = get_conn();
            bool b = false;
            conn.Open();
            string query = "select `TABLE_NAME` from `INFORMATION_SCHEMA`.`TABLES` where `TABLE_SCHEMA`= '" + database_name + "' and `TABLE_NAME`= '" + table_name + "'";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                b = true;
            }
            else
            {
                b = false;
            }
            conn.Close();
            return b;
        }
        public static string create_user_admin()
        {
            conn = get_conn();
            string result = "OK";
            string query = @"CREATE TABLE  IF NOT EXISTS `user_admin` (
                             `id` int(5) NOT NULL AUTO_INCREMENT,
                            `code` varchar(50) NOT NULL,
                             `name` varchar(50) NOT NULL,
                             `pass` varchar(50) NOT NULL,
                             `memo` varchar(50) DEFAULT NULL,
                             PRIMARY KEY (`id`),
                             UNIQUE KEY `code` (`code`)
                            ) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='超级管理员';

                            INSERT INTO `user_admin` (`code`,`name`, `pass`, `memo`) VALUES
                            ('admin','张三', 'admin', '超级管理员');";
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            conn.Close();
            return result;
        }

        public static string create_user_operator()
        {
            conn = get_conn();
            string result = "OK";
            string query = @"CREATE TABLE  IF NOT EXISTS `user_operater` (
                             `id` int(5) NOT NULL AUTO_INCREMENT,
                            `code` varchar(50) NOT NULL,
                             `name` varchar(50) NOT NULL,
                             `pass` varchar(50) NOT NULL,
                             `memo` varchar(50) DEFAULT NULL,
                             PRIMARY KEY (`id`),
                             UNIQUE KEY `code` (`code`)
                            ) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='操作工';

                            INSERT INTO `user_operater` (`code`, `name`, `pass`, `memo`) VALUES
                            ('op','张三', 'op', '操作工');";
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            conn.Close();
            return result;
        }

        public static string create_user_technician()
        {
            conn = get_conn();
            string result = "OK";
            string query = @"
                            CREATE TABLE  IF NOT EXISTS `user_technician` (
                             `id` int(5) NOT NULL AUTO_INCREMENT,
                             `code` varchar(50) NOT NULL,
                             `name` varchar(50) NOT NULL,
                             `pass` varchar(50) NOT NULL,
                             `memo` varchar(50) DEFAULT NULL,
                             PRIMARY KEY (`id`),
                             UNIQUE KEY `code` (`code`)
                            ) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='工艺（修改设置）';

                            INSERT INTO `user_technician` (`code`,`name`, `pass`, `memo`) VALUES
                            ('gy','张三', 'gy', '工艺');";
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            conn.Close();
            return result;
        }
        public static string create_user_user_login_log()
        {
            conn = get_conn();
            string result = "OK";
            string query = @" CREATE TABLE   IF NOT EXISTS  `user_login_log` ( 
                                `id` INT NOT NULL AUTO_INCREMENT , 
                                `login_user_type` VARCHAR(50) NOT NULL , 
                                `login_name` VARCHAR(50) NOT NULL , 
                                `login_datetime` DATETIME NOT NULL , 
                                 `logout_datetime` datetime DEFAULT NULL,
                                 `online_hours` decimal(5,2) DEFAULT NULL,

                                PRIMARY KEY (`id`)) ENGINE = MyISAM; ";
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            conn.Close();
            return result;
        }
        public static string add_logout_log(string id, string hours)
        {
            return Exexute_Sql2Str("update user_login_log set logout_datetime=now(),online_hours=" + hours + " where id=" + id);
        }
        public static string add_login_login(string user_type, string name)
        {
            return Exexute_Sql2Str("insert into user_login_log(login_user_type, login_name, login_datetime) values('" + user_type + "', '" + name + "', now()); select last_insert_id();");
        }
        public static string login_operater(string code, string pass)
        {
            conn = get_conn();
            string b = "";
            try
            {
                conn.Open();
                try
                {
                    string query = "select * from user_operater where code=@code and pass=@pass";//向数据库服务器发送指令
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        b = "OK";
                    }
                    else
                    {
                        b = "用户名或密码有误";
                    }
                }
                catch (Exception ex)
                {
                    b = "数据读取失败:" + ex.Message;
                }
                conn.Close();
            }
            catch
            {
                b = "数据库连接失败";
            }
            return b;
        }
        public static string login_technician(string code, string pass)
        {
            conn = get_conn();
            string b = "";
            try
            {
                conn.Open();
                try
                {
                    string query = "select * from user_technician where code=@code and pass=@pass";//向数据库服务器发送指令
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        b = "OK";
                    }
                    else
                    {
                        b = "用户名或密码有误";
                    }
                }
                catch (Exception ex)
                {
                    b = "数据读取失败:" + ex.Message;
                }
                conn.Close();
            }
            catch
            {
                b = "数据库连接失败";
            }
            return b;
        }
        public static string login_admin(string code, string pass)
        {
            conn = get_conn();
            string b = "";
            try
            {
                conn.Open();
                try
                {
                    string query = "select * from user_admin where code=@code and pass=@pass";//向数据库服务器发送指令
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        b = "OK";
                    }
                    else
                    {
                        b = "用户名或密码有误";
                    }
                }
                catch (Exception ex)
                {
                    b = "数据读取失败:" + ex.Message;
                }
                conn.Close();
            }
            catch
            {
                b = "数据库连接失败";
            }
            return b;
        }

        public static string create_password()
        {
            MySql.Data.MySqlClient.MySqlConnection con =
               new MySql.Data.MySqlClient.MySqlConnection(
                   //"Database=" + config_json.mysql_database_name + ";"+
                   "Data Source=" + config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=;charset=utf8;");
            try
            {
                con.Open();
                //set password =password('')
                string query = "set password =password('" + config_json.Mysql_Pass + "');";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                return "初始密码不为空，无法更改密码！";
            }
            return "OK";
        }
        public static string create_database()
        {
            MySql.Data.MySqlClient.MySqlConnection con =
               new MySql.Data.MySqlClient.MySqlConnection("Database=mysql;Data Source=" +
               config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");
            try
            {
                con.Open();

                string query = "CREATE DATABASE IF NOT EXISTS " + config_json.mysql_database_name + " DEFAULT CHARACTER SET utf8 DEFAULT COLLATE utf8_general_ci";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return "OK";
            }
            catch (Exception ex)
            { return ex.Message; }
        }

        public static string create_tongji_table()
        {
            MySql.Data.MySqlClient.MySqlConnection con =
               new MySql.Data.MySqlClient.MySqlConnection("Database=" + config_json.mysql_database_name + ";Data Source=" +
               config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");
            con.Open();

            string query = "CREATE TABLE IF NOT EXISTS `" + config_json.mysql_yielddata_table + @"` (  
                            `id` int(11) NOT NULL AUTO_INCREMENT,  
                            `测试日期` varchar(100) DEFAULT NULL,  
                            `一次直通数量` int(11) DEFAULT '0',  
                            `一次直通率` varchar(100) DEFAULT '0',  
                            `通过数量` int(11) DEFAULT '0', 
                            `通过率` varchar(100) DEFAULT '0',  
                            `误测数量` int(11) DEFAULT '0',  
                            `误测率` varchar(100) DEFAULT '0',  
                            `不合格数量` int(11) DEFAULT '0',  
                            `不合格率` varchar(100) DEFAULT '0',  
                            `备注` varchar(500) DEFAULT '0', 
                            PRIMARY KEY (`id`)) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='测试统计'";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return "OK";
        }

        public static int[] get_produce_data()
        {
            int[] result = new int[4];
            MySql.Data.MySqlClient.MySqlConnection con =
              new MySql.Data.MySqlClient.MySqlConnection("Database=" + config_json.mysql_database_name + ";Data Source=" +
              config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");
            try
            {
                con.Open();
                try
                {
                    string query = "select * from " + config_json.mysql_yielddata_table + " where testdate='" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//向数据库服务器发送指令
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, con);
                    MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        result[0] = Convert.ToInt16(dr["first_pass_num"]);
                        result[1] = Convert.ToInt16(dr["pass_num"]);
                        result[2] = Convert.ToInt16(dr["faulttest_num"]);
                        result[3] = Convert.ToInt16(dr["ng_num"]);
                    }
                    else
                    {
                        con.Close();
                        con.Open();
                        string insertstr = "insert into " + config_json.mysql_yielddata_table + " (`testdate`) values('" + DateTime.Now.ToString("yyyy-MM-dd") + "')";//插入今天日期并加载默认值0
                        MySql.Data.MySqlClient.MySqlCommand insertcmd = new MySql.Data.MySqlClient.MySqlCommand(insertstr, con);
                        insertcmd.ExecuteNonQuery();
                        result[0] = result[1] = result[2] = result[3] = 0;
                    }
                    dr.Close();
                    con.Close();
                    return result;
                }
                catch
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public static int[] get_produce_data_cn()
        {
            int[] result = new int[4];
            MySql.Data.MySqlClient.MySqlConnection con =
              new MySql.Data.MySqlClient.MySqlConnection("Database=" + config_json.mysql_database_name + ";Data Source=" +
              config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");
            try
            {
                con.Open();
                try
                {
                    string query = "select * from " + config_json.mysql_yielddata_table + " where 测试日期='" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//向数据库服务器发送指令
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, con);
                    MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        result[0] = Convert.ToInt16(dr["一次直通数量"]);
                        result[1] = Convert.ToInt16(dr["通过数量"]);
                        result[2] = Convert.ToInt16(dr["误测数量"]);
                        result[3] = Convert.ToInt16(dr["不合格数量"]);
                    }
                    else
                    {
                        con.Close();
                        con.Open();
                        string insertstr = "insert into " + config_json.mysql_yielddata_table + " (`测试日期`) values('" + DateTime.Now.ToString("yyyy-MM-dd") + "')";//插入今天日期并加载默认值0
                        MySql.Data.MySqlClient.MySqlCommand insertcmd = new MySql.Data.MySqlClient.MySqlCommand(insertstr, con);
                        insertcmd.ExecuteNonQuery();
                        result[0] = result[1] = result[2] = result[3] = 0;
                    }
                    dr.Close();
                    con.Close();
                    return result;
                }
                catch
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        public static string create_systeminfo_table()
        {
            string result = "";
            conn.Open();
            string query = @"CREATE TABLE  if not exists  `system_info` (
                             `id` int(11) NOT NULL AUTO_INCREMENT,
                             `soft_ver` varchar(200) DEFAULT NULL,
                             `database_ver` varchar(200) DEFAULT NULL,
                             `update_time` datetime DEFAULT NULL,
                             `memo` varchar(2000) DEFAULT NULL,
                             PRIMARY KEY (`id`)
                            ) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='系统信息';
                                insert into `system_info` (database_ver,update_time) values('4.0',now());";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            conn.Close();
            return result;
        }
        public static string create_tables()
        {
            string result = "";
            conn.Open();
            string query = @"CREATE TABLE if not exists `测试数据` (
                             `id` int(11) NOT NULL AUTO_INCREMENT,
                             `测试编号` varchar(100) DEFAULT NULL,
                             `测试时间` date DEFAULT NULL,
                             `产品名称` varchar(100) DEFAULT NULL,
                             `产品型号` varchar(100) DEFAULT NULL,
                             `最大亮度` varchar(100) DEFAULT NULL,
                             `均匀性` varchar(1000) DEFAULT NULL,
                             `均匀性最大值` double(8,3) DEFAULT NULL,
                             `均匀性最小值` double(8,3) DEFAULT NULL,
                             `均匀性BP` varchar(100) DEFAULT NULL,
                             `相邻点色彩一致性` decimal(8,3) DEFAULT '0.000',
                             `gamma` varchar(10000) DEFAULT NULL,
                             PRIMARY KEY (`id`)
                            ) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='测试数据';

                            CREATE TABLE  if not exists `产品参数` (
                             `id` int(11) NOT NULL AUTO_INCREMENT,
                             `生产厂商` varchar(100) DEFAULT NULL,
                             `产品名称` varchar(100) DEFAULT NULL,
                             `产品型号` varchar(100) NOT NULL,
                             `中心坐标` varchar(100) DEFAULT NULL,
                             `屏幕宽` int(5) NOT NULL DEFAULT '0' COMMENT '屏幕宽(单位mm)',
                             `屏幕高` int(5) NOT NULL DEFAULT '0' COMMENT '屏幕高(单位mm)',
                             `零点坐标` varchar(100) DEFAULT '0,0,0',
                             `列间距` int(11) DEFAULT '0' COMMENT '列(水平)间距',
                             `行间距` int(11) DEFAULT '0' COMMENT '行(垂直)间距',
                             PRIMARY KEY (`id`)
                            ) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
                            ";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            conn.Close();
            return result;
        }

      
        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                // this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

    }
}















