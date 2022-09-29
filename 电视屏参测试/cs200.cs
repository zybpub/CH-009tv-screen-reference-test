namespace Test_Automation
{
    class cs200
    {
        public static void RunCS200()
        {
            try
            {
                //检测进程是否已经存在
                System.Diagnostics.Process[] pro =
                    System.Diagnostics.Process.GetProcessesByName("cs-200");
                if (pro.Length > 0)
                {
                    //已经在运行则直接退出
                    return;
                }
                //实例一个Process类，启动一个独立进程
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                //Process类有一个StartInfo属性
                //设定程序名
                process.StartInfo.FileName = "cs-200.exe";
                //设定程式执行参数   
                // p.StartInfo.Arguments = args;
                //关闭Shell的使用  
                process.StartInfo.UseShellExecute = true;
                //重定向标准输入     
                process.StartInfo.RedirectStandardInput = false;
                process.StartInfo.RedirectStandardOutput = false;
                //重定向错误输出  
                process.StartInfo.RedirectStandardError = false;
                //设置不显示窗口
                process.StartInfo.CreateNoWindow = false;
              
                //启动
                process.Start();
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
                //也可以用这种方式输入要执行的命令
                //不过要记得加上Exit要不然下一行程式执行的时候会当机
                //p.StandardInput.WriteLine(command);
                //p.StandardInput.WriteLine("exit");       
                //从输出流取得命令执行结果
                //string outstr = "";
                //string temp = p.StandardOutput.ReadLine();

                //while (temp != "")
                //{
                //    outstr += temp + "\r\n";
                //    temp = p.StandardOutput.ReadLine();
                //}

                //return outstr;
            }
            catch { }
        }
        public static void ExitCS200()
        {
            System.Diagnostics.Process[] pro =
                System.Diagnostics.Process.GetProcessesByName("cs-200");
            if (pro.Length > 0)
            {
                pro[0].Kill();
                return;
            }
        }
    }
}