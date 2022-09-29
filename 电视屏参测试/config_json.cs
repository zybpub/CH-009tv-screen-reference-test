namespace Test_Automation
{
    class config_json
    {
        public static string sheet_no = ""; //
        public static double 屏幕宽 = 0;
        public static double 屏幕高 = 0;


        //调试标志


        //VG876
        public static string VG870_PortName = "COM3"; //
        public static byte[] pattern_white = { 0x02, 0xfd, 0x24, 0x20, 0x31, 0x31, 0x32, 0x31, 0x2c, 0x32, 0x03 };//patter 1121
        public static byte[] pattern_red = { 0x02, 0xfd, 0x24, 0x20, 0x31, 0x31, 0x32, 0x32, 0x2c, 0x32, 0x03 };//patter 1122
        public static byte[] pattern_green = { 0x02, 0xfd, 0x24, 0x20, 0x31, 0x31, 0x32, 0x33, 0x2c, 0x32, 0x03 };//patter 1123
        public static byte[] pattern_blue = { 0x02, 0xfd, 0x24, 0x20, 0x31, 0x31, 0x32, 0x34, 0x2c, 0x32, 0x03 };//patter 1124
        public static byte[] pattern_black = { 0x02, 0xfd, 0x24, 0x20, 0x31, 0x31, 0x32, 0x35, 0x2c, 0x32, 0x03 };//patter 1125
        public static byte[] pattern_50gray = { 0x02, 0xfd, 0x24, 0x20, 0x31, 0x31, 0x32, 0x36, 0x2c, 0x32, 0x03 };//patter 1126
        public static byte[] pattern_window = { 0x02,0xfd,0x24,0x30, 0x30, 0x2c, 0x30, 0x2c, 0x31, 0x2c, 0x32, 0x2c, 0x31, 0x30, 0x2c, 0x31, 0x39, 3 };//
        public static byte[] pattern_window_color_pre = { 0x02, 0xfd, 0x28, 0x62 };//
        public static byte[] pattern_window_color_end = { 0x2c, 0x38, 0x03 };//
        public static byte[] pattern_plane_pre = { 0x02, 0xfd, 0x28, 0x2c };//
        public static byte[] pattern_plane_end = { 0x2c, 0x38, 0x03 };//


        public static byte[] pattern_window_color_155 = { 0x02, 0xfd, 0x28, 0x62, 0x31, 0x35, 0x35, 0x2c, 0x31, 0x35, 0x35, 0x2c, 0x31, 0x31, 0x35, 0x35, 0x2c, 0x38, 0x03 };

        public static byte[] pattern_color_1 = { 0x02, 0xea, 0x31, 0x03 };//
        public static byte[] pattern_color_pre = { 0x02, 0x10 };//
        public static byte[] pattern_color_end = { 0x03 };//

        public static byte[] graphic_plane_plalette644 = { 0x02,0xfd,0x28,0x4e,0x0,0x03 };//
        public static byte[] back_ground_color336_pre = { 0x02, 0xfd, 0x28, 0x71 };//
        public static byte[] back_ground_color336_end = { 0x38,0x03 };//

        public static byte[] back327_pre = { 0x02, 0xfd, 0x28, 0x4c,0x32,0x35,0x35,0x2c };//


        public static byte[] back327_end = { 0x2c,0x38, 0x03 };//


        //当前位置读取：
        public static string R轴当前位置a = "5500"; //读取的值单位为毫度（1000毫度=1度）；
        public static string X轴当前位置a = "5540"; //读取的值单位为微米（1000微米=1毫米）；
        public static string Y轴当前位置a = "5580";// 读取的值单位为微米（1000微米=1毫米）；
        public static string Z轴当前位置a = "5620"; //读取的值单位为微米（1000微米=1毫米）；
        //中心位置：
        public static string R轴中心位置v = "0"; //读取的值单位为毫度（1000毫度=1度）；
        public static string X轴中心位置v = "200000"; //读取的值单位为微米（1000微米=1毫米）；
        public static string Y轴中心位置v = "200000";// 读取的值单位为微米（1000微米=1毫米）；　
        public static string Z轴中心位置v = "200000"; //读取的值单位为微米（1000微米=1毫米）；
        //原点位置：
        public static string R轴原点位置v = "0"; //读取的值单位为毫度（1000毫度=1度）；
        public static string X轴原点位置v = "1600000"; //读取的值单位为微米（1000微米=1毫米）；
        public static string Y轴原点位置v = "-400000";// 读取的值单位为微米（1000微米=1毫米）；
        public static string Z轴原点位置v = "230000"; //读取的值单位为微米（1000微米=1毫米）；
        //相对运动位置：
        public static string R轴相对运动坐标写入a = "2048"; //写入的值单位为毫度（1000毫度=1度）；
        public static string X轴相对运动坐标写入a = "2052"; //写入的值单位为微米（1000微米=1毫米）；
        public static string Y轴相对运动坐标写入a = "2056"; //写入的值单位为微米（1000微米=1毫米）；
        public static string Z轴相对运动坐标写入a = "2060"; //写入的值单位为微米（1000微米=1毫米）；
        //相对运动启动：
        public static string R轴相对运动启动a = "2340";  //R轴相对运动坐标写入后，在此写入”1“确认后设备启动运行；
        public static string X轴相对运动启动a = "2342";      // R轴相对运动坐标写入后，在此写入”1“确认后设备启动运行；
        public static string Y轴相对运动启动a = "2344";      // R轴相对运动坐标写入后，在此写入”1“确认后设备启动运行；
        public static string Z轴相对运动启动a = "2346";      // R轴相对运动坐标写入后，在此写入”1“确认后设备启动运行；
        //相对运动完成：
        public static string R轴相对运动完成a = "2350";    //读取到Ture或1代表运动完成,读取后需要写入0;
        public static string X轴相对运动完成a = "2352";    // 读取到Ture或1代表运动完成；
        public static string Y轴相对运动完成a = "2354";    // 读取到Ture或1代表运动完成；
        public static string Z轴相对运动完成a = "2356";    // 读取到Ture或1代表运动完成；
        //复位：
        public static string 复位写入 = "2348";// 若需要复位在此写入”1“，X轴、R轴、Y轴、Z轴会依次复位到PLC默认零点位。
        public static string R轴复位完成 = "165"; //读取到Ture或1代表复位完成；
        public static string X轴复位完成 = "159"; //读取到Ture或1代表复位完成；
        public static string Y轴复位完成 = "161"; //读取到Ture或1代表复位完成；
        public static string Z轴复位完成 = "163";// 读取到Ture或1代表复位完成；
        //复位位置设置：
        public static string X轴复位位置a= "2324";
        public static string Y轴复位位置a = "2328";
        public static string Z轴复位位置a = "2332";
        public static string R轴复位位置a = "XXXX"; //缺

        public static string X轴复位位置v = "100000";
        public static string Y轴复位位置v = "100000";
        public static string Z轴复位位置v = "100000";

        //160点测量
        public static string 行间距 = "150000";
        public static string 列间距 = "150000";



        public static string CA410_SerialPort_PortName = "COM4";

        public static bool mysql_used = true;    //是否启用数据库
        public static string Mysql_IP = "127.0.0.1";       //Mysql IP 地址
        public static string Mysql_Port = "3306";      //Mysql 端口号
        public static string Mysql_User = "root";      //Mysql 用户名 需要有写入权限
        public static string Mysql_Pass = "jczx";      //Mysql 密码
        public static string mysql_database_name = "jczx_screen_test";  //数据库名
        public static string mysql_tongji_table = "tongji_screen_test";
        public static string mysql_testdata_table = "测试数据";
        public static string mysql_yielddata_table = "测试数量统计";

        public static string config_file_path = "control_config.json";

        public static string Workstationid = "HC1-BPHTS";
        public static string pass = "QWQ/r3FGnyU=";    //999

        public static bool PLC_Used = true;    //是否启用PLC
        public static string PLC_IP = "192.168.1.7";              //PLC IP地址
        public static string PLC_Port = "502";             //PLC 端口 默认：502
        public static string PLC_Station = "1";             //PLC 站号  默认：1
        public static string PLC_StartTest_Register = "5000";   //PLC控制是否测试可以开始 0不测试 1 测试
        public static string PLC_LetTVPass_Register = "5001";
        public static string PLC_Type_Register = "5002";
        public static string PLC_SN_Register = "5022";    //PLC读取sn地址
        public static string PLC_Adapter_Register = "4099";
        public static string PLC_Light_Register = "4119";     //PLC红绿黄灯控制寄存器地址
        public static string PLC_Light_GREEN = "1";
        public static string PLC_Light_RED = "2";
        public static string PLC_Light_YELLOW = "3";
        public static string ShakeHand_OK_Code = "2";  //启动测试信号值

        public config_json()
        {
        }

        public static bool save(string key, string value)
        {
            try
            {
                string json = System.IO.File.ReadAllText(config_json.config_file_path);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                jsonObj[key] = value;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText(config_json.config_file_path, output);
                return true;
            }
            catch
            {
                return false;
            }
        }

      
        public static bool config_json_readall()
        {
            if (System.IO.File.Exists(config_json.config_file_path) == false)
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(config_json.config_file_path, true))
                {
                    writer.WriteLine("{}");
                    writer.Close();
                }
            }

            System.IO.StreamReader file = System.IO.File.OpenText(config_json.config_file_path);
            Newtonsoft.Json.JsonTextReader reader = new Newtonsoft.Json.JsonTextReader(file);
             Newtonsoft.Json.Linq.JObject jsonObject = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.Linq.JToken.ReadFrom(reader);


            
                 if (jsonObject["sheet_no"] != null) sheet_no = (string)jsonObject["sheet_no"];
            if (jsonObject["VG870_PortName"] != null) VG870_PortName = (string)jsonObject["VG870_PortName"];
            if (jsonObject["R轴当前位置a"] != null) R轴当前位置a = (string)jsonObject["R轴当前位置a"];
            
            if (jsonObject["X轴当前位置a"] != null) X轴当前位置a = (string)jsonObject["X轴当前位置a"];
            if (jsonObject["Y轴当前位置a"] != null) Y轴当前位置a = (string)jsonObject["Y轴当前位置a"];
            if (jsonObject["Z轴当前位置a"] != null) Z轴当前位置a = (string)jsonObject["Z轴当前位置a"];

            if (jsonObject["X轴原点位置v"] != null) X轴原点位置v = (string)jsonObject["X轴原点位置v"];
            if (jsonObject["Y轴原点位置v"] != null) Y轴原点位置v = (string)jsonObject["Y轴原点位置v"];
            if (jsonObject["Z轴原点位置v"] != null) Z轴原点位置v = (string)jsonObject["Z轴原点位置v"];

            

            if (jsonObject["X轴中心位置v"] != null) X轴中心位置v = (string)jsonObject["X轴中心位置v"];
            if (jsonObject["X轴中心位置v"] != null) Y轴中心位置v = (string)jsonObject["Y轴中心位置v"];
            if (jsonObject["Z轴中心位置v"] != null) Z轴中心位置v = (string)jsonObject["Z轴中心位置v"];

            if (jsonObject["R轴相对运动坐标写入"] != null) R轴相对运动坐标写入a = (string)jsonObject["R轴相对运动坐标写入"];
            if (jsonObject["X轴相对运动坐标写入"] != null) X轴相对运动坐标写入a = (string)jsonObject["X轴相对运动坐标写入"];
            if (jsonObject["Y轴相对运动坐标写入"] != null) Y轴相对运动坐标写入a = (string)jsonObject["Y轴相对运动坐标写入"];
            if (jsonObject["Z轴相对运动坐标写入"] != null) Z轴相对运动坐标写入a = (string)jsonObject["Z轴相对运动坐标写入"];

            if (jsonObject["R轴相对运动启动"] != null) R轴相对运动启动a = (string)jsonObject["R轴相对运动启动"];
            if (jsonObject["X轴相对运动启动"] != null) X轴相对运动启动a = (string)jsonObject["X轴相对运动启动"];
            if (jsonObject["Y轴相对运动启动"] != null) Y轴相对运动启动a = (string)jsonObject["Y轴相对运动启动"];
            if (jsonObject["Z轴相对运动启动"] != null) Z轴相对运动启动a = (string)jsonObject["Z轴相对运动启动"];


            if (jsonObject["R轴相对运动完成"] != null) R轴相对运动完成a = (string)jsonObject["R轴相对运动完成"];
            if (jsonObject["X轴相对运动完成"] != null) X轴相对运动完成a = (string)jsonObject["X轴相对运动完成"];
            if (jsonObject["Y轴相对运动完成"] != null) Y轴相对运动完成a = (string)jsonObject["Y轴相对运动完成"];
            if (jsonObject["Z轴相对运动完成"] != null) Z轴相对运动完成a = (string)jsonObject["Z轴相对运动完成"];


            if (jsonObject["复位写入"] != null) 复位写入 = (string)jsonObject["复位写入"];
            if (jsonObject["R轴复位完成"] != null) R轴复位完成 = (string)jsonObject["R轴复位完成"];
            if (jsonObject["X轴复位完成"] != null) X轴复位完成 = (string)jsonObject["X轴复位完成"];
            if (jsonObject["Y轴复位完成"] != null) Y轴复位完成 = (string)jsonObject["Y轴复位完成"];
            if (jsonObject["Z轴复位完成"] != null) Z轴复位完成 = (string)jsonObject["Z轴复位完成"];


            if (jsonObject["X轴复位位置"] != null) X轴复位位置a = (string)jsonObject["X轴复位位置"];
            if (jsonObject["Y轴复位位置"] != null) Y轴复位位置a = (string)jsonObject["Y轴复位位置"];
            if (jsonObject["Z轴复位位置"] != null) Z轴复位位置a = (string)jsonObject["Z轴复位位置"];

            if (jsonObject["X轴复位位置v"] != null) X轴复位位置v = (string)jsonObject["X轴复位位置v"];
            if (jsonObject["Y轴复位位置v"] != null) Y轴复位位置v = (string)jsonObject["Y轴复位位置v"];
            if (jsonObject["Z轴复位位置v"] != null) Z轴复位位置v = (string)jsonObject["Z轴复位位置v"];

            if (jsonObject["行间距"] != null) 行间距 = (string)jsonObject["行间距"];
            if (jsonObject["列间距"] != null) 列间距 = (string)jsonObject["列间距"];

            if (jsonObject["CA410_SerialPort_PortName"] != null) CA410_SerialPort_PortName = (string)jsonObject["CA410_SerialPort_PortName"];
            

            if (jsonObject["PLC_IP"] != null) PLC_IP = (string)jsonObject["PLC_IP"];

            
            if (jsonObject["PLC_Port"] != null) PLC_Port = (string)jsonObject["PLC_Port"];
            if (jsonObject["PLC_Station"] != null) PLC_Station = (string)jsonObject["PLC_Station"];


            if (jsonObject["PLC_Light_Register"] != null) PLC_Light_Register = (string)jsonObject["PLC_Light_Register"];
            if (jsonObject["PLC_Light_GREEN"] != null) PLC_Light_GREEN = (string)jsonObject["PLC_Light_GREEN"];
            if (jsonObject["PLC_Light_RED"] != null) PLC_Light_RED = (string)jsonObject["PLC_Light_RED"];
            if (jsonObject["PLC_Light_YELLOW"] != null) PLC_Light_YELLOW = (string)jsonObject["PLC_Light_YELLOW"];
            if (jsonObject["PLC_Type_Regist"] != null) PLC_Type_Register = (string)jsonObject["PLC_Type_Regist"]; 
            if (jsonObject["PLC_SN_Register"] != null) PLC_SN_Register = (string)jsonObject["PLC_SN_Register"];
            if (jsonObject["PLC_StartTest_Register"] != null) PLC_StartTest_Register = (string)jsonObject["PLC_StartTest_Register"];


            file.Close();

            return true;
        }


        /// <summary>
        /// 创建配置文件,使用默认值
        /// </summary>
        /// <returns></returns>
        public static bool config_json_create()
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            using (Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
            {
                string newline = "";// System.Environment.NewLine;
                writer.Formatting = Newtonsoft.Json.Formatting.Indented;

                writer.WriteStartObject();

                //是否运行程序后自动开始测试
                writer.WritePropertyName("AUTO_RUN");
                //writer.WriteValue("false"); 
                writer.WriteValue("false");
                writer.WriteComment(newline + "是否运行程序后自动开始测试");


                writer.WritePropertyName("PLC_IP");
                writer.WriteValue("192.168.1.5");
                writer.WriteComment(newline + "PLC控制器设置");
                writer.WritePropertyName("PLC_Port");
                writer.WriteValue("502");
                writer.WritePropertyName("PLC_Station");
                writer.WriteValue("1");
                writer.WritePropertyName("PLC_Control_Register");
                writer.WriteValue("4096");
                writer.WritePropertyName("PLC_Light_Register");
                writer.WriteValue("4097");

                
                writer.WriteEndObject();

                writer.Flush();
            }
            sw.Close();

            //写入文件
            string file_content = sw.GetStringBuilder().ToString();
            string filePath = "config.json";//这里是你的已知文件
            System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create,
                                           System.IO.FileAccess.ReadWrite);
            System.IO.StreamWriter stwr = new System.IO.StreamWriter(fs);
            fs.SetLength(0);//首先把文件清空了。
            stwr.Write(file_content);//写入内容。
            stwr.Close();
            return true;
        }


    }
}


