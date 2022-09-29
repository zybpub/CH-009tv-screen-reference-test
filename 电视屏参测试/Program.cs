using System;
using System.Windows.Forms;

namespace Test_Automation
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
             Application.Run(new Form_Main());
            // Application.Run(new Form_DrawCurve());
           // Application.Run(new Form_VG876());
             //Application.Run(new Form_160());
           // Application.Run(new Form_CA410());
           // Application.Run(new Form_Gamma_CA410());
        }
    }
}
