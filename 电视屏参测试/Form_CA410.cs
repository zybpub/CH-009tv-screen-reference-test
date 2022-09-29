using System;
using System.Linq;
using System.Windows.Forms;

namespace Test_Automation
{
    public partial class Form_CA410 : Form
    {
        public Form_CA410()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void Form_CA410_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (string com in System.IO.Ports.SerialPort.GetPortNames()) //自动获取串行口名称

                    cmbPortName.Items.Add(com);
                cmbPortName.SelectedIndex = 0;
            }
            catch { }

            cmbPortName.Text = config_json.CA410_SerialPort_PortName;

        }

        private void btn_port_open_Click(object sender, EventArgs e)
        {
            // port with some basic settings
            // SerialPort port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
            try
            {
                if (com_CA410.IsOpen)    //当前为打开，则进行关闭处理
                {
                    com_CA410.Close();
                    // gbPortSettings.Enabled = true;
                    btn_port_open.Text = "打开端口";
                    btnsend.Enabled = false;
                }
                else     //当前为关闭，则进行打开处理
                {
                    // Set the port's settings
                    com_CA410.PortName = cmbPortName.Text;
                    com_CA410.BaudRate = int.Parse(cmbBaudRate.Text);
                    com_CA410.DataBits = int.Parse(tbDataBits.Text);
                    com_CA410.StopBits = System.IO.Ports.StopBits.Two;
                    //(System.IO.Ports.StopBits)Enum.Parse(typeof(System.IO.Ports.StopBits), cmbStopBits.Text);
                    // com_CA410.Parity = System.IO.Ports.Parity.Even;
                    com_CA410.Parity = (System.IO.Ports.Parity)Enum.Parse(typeof(System.IO.Ports.Parity), cmbParity.Text);
                    btn_port_open.Text = "关闭端口";
                    com_CA410.Open();
                    com_CA410.DiscardInBuffer();
                    com_CA410.DiscardOutBuffer();
                    btnsend.Enabled = true;
                }
            }
            catch (Exception er)
            { MessageBox.Show("端口打开失败！" + er.Message, "提示"); }

        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //使用委托进行跨线程读取数据
            Invoke
             (new EventHandler
               (delegate
               {
                   txtreceived.Text += com_CA410.ReadExisting();
               }
               )
              );
        }



        private void txtsend_Click(object sender, EventArgs e)
        {
            if (com_CA410.IsOpen != true)
                btn_port_open_Click(null, null);
            for (int i = 0; i < txtsend.Lines.Count(); i++)
                com_CA410.WriteLine(txtsend.Lines[i]);
        }

        private void config_json_read()
        {

        }

        private void config_json_save()
        {
            //保存配置文件
            try
            {
                string json = System.IO.File.ReadAllText("config.json");
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                jsonObj["PortName"] = cmbPortName.Text;
                jsonObj["BaudRate"] = cmbBaudRate.Text;
                jsonObj["DataBits"] = tbDataBits.Text;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText("config.json", output);
            }
            catch (Exception ex)
            {
                MessageBox.Show("配置文件有误：" + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_CA410.IsOpen != true)
                btn_port_open_Click(null, null);
            com_CA410.WriteLine(comboBox1.Text);
            txtsend.Text = comboBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (com_CA410.IsOpen != true)
                btn_port_open_Click(null, null);

            com_CA410.WriteLine(comboBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtreceived.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            /*
             发送*idn?\r\n 获取设备标识
            GPT-9804 ,EM110867    ,v2.08,
            MEAS1?
            MEAS2?

             */
            if (com_CA410.IsOpen != true)
                btn_port_open_Click(null, null);

            com_CA410.WriteLine("*idn?");
            com_CA410.WriteLine("Function:TEST ON");
            System.Threading.Thread.Sleep(5000);
            com_CA410.WriteLine("MEAS1?");
            com_CA410.WriteLine("MEAS2?");
        }
        string checkCA410_result = "";

        private void serialPort1_DataReceived_1(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
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
                    txtreceived.Text += checkCA410_result;
                    //OK00,P1,0,-0.063188,0.4563044,6.6227164,-0.23,-99999999
                    //56个字符，结尾有一个0x0D换行符
                    string[] CA410RecData = checkCA410_result.Split(',');
                    if (CA410RecData.Length == 8)
                    {
                        //Realx = Convert.ToSingle(CA410RecData[3]);
                        //Realy = Convert.ToSingle(CA410RecData[4]);
                        //addmemo("realx:" + Realx + ",realy:" + Realy);
                        //realxy_update = true;
                    }

                }));
            }
            catch { }
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            if (com_CA410.IsOpen != true)
                btn_port_open_Click(null, null);
            for (int i = 0; i < txtsend.Lines.Count(); i++)
                com_CA410.WriteLine(txtsend.Lines[i]);
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (com_CA410.IsOpen != true)
                btn_port_open_Click(null, null);
            com_CA410.WriteLine(comboBox1.Text);
            txtsend.Text = comboBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (com_CA410!=null)
                if (com_CA410.IsOpen)    //当前为打开，则进行关闭处理
                    {
                        com_CA410.Close();
                    }
        }
    }
}
