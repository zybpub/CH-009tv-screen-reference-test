using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Automation
{
    public partial class Form_DrawCurve : Form
    {
        Thread thread;
        RealTimeImageMaker rti;
        Color backColor = Color.Black;//指定绘制曲线图的背景色  
        public Form_DrawCurve()
        {
            InitializeComponent();

        }

        private void Form_DrawCurve_Load(object sender, EventArgs e)
        {
            //rti = new RealTimeImageMaker(500, 300, backColor, Color.Green);
            //thread = new Thread(new ThreadStart(Run));
            //thread.Start();

        }
        private void Run()
        {
           // while (true)
            {
                Image image = rti.GetCurrentCurve();
                Graphics g = CreateGraphics();
                //用指定背景色清除当前窗体上的图象  
                g.Clear(backColor);
                g.DrawImage(image, 0, 0);
                g.Dispose();
                //每秒钟刷新一次  
              //  Thread.Sleep(1000);
            }
        }

        private void FormRealTime_FormClosing(object sender, FormClosingEventArgs e)
        {
            //在窗体即将关闭之前中止线程  
            thread.Abort();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userCurve1.SetLeftCurve("A", GetRandomValueByCount(300, 0, 200), Color.DodgerBlue);
        }
        Random random = new Random();
        private float[] GetRandomValueByCount(int count, float min, float max)
        {
            float[] data = new float[count];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (float)random.NextDouble() * (max - min) + min;
            }
            return data;
        }

        int num = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            num++;
            userCurve1.SetLeftCurve("A", GetRandomValueByCount(num, 0, 400));
        }
    }
}
