using System.Diagnostics;

namespace JiraWorkSpace.CMD
{
    public class Program
    {
        static void Main(string[] args)
        {
            var cmdStr = Console.ReadLine() ?? "";
            new Program().RunCmd(cmdStr);
            Console.WriteLine("End");
        }

        //异步回显（1-2-3-4）
        // 1.定义委托
        public delegate void DelReadStdOutput(string result);
        public delegate void DelReadErrOutput(string result);
        // 2.定义委托事件
        public event DelReadStdOutput ReadStdOutput;
        public event DelReadErrOutput ReadErrOutput;

        public string RunCmd(string cmd)
        {

            //3.将相应函数注册到委托事件中
            ReadStdOutput += new DelReadStdOutput(ReadStdOutputAction);
            ReadErrOutput += new DelReadErrOutput(ReadErrOutputAction);

            try
            {
                //string strInput = Console.ReadLine();
                Process p = new Process();
                //设置要启动的应用程序
                p.StartInfo.FileName = "cmd.exe";
                //是否使用操作系统shell启动
                p.StartInfo.UseShellExecute = false;
                // 接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardInput = true;
                //输出信息
                p.StartInfo.RedirectStandardOutput = true;
                // 输出错误
                p.StartInfo.RedirectStandardError = true;
                //不显示程序窗口
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;

                p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
                p.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);
                //启用Exited事件
                p.EnableRaisingEvents = true;
                p.Exited += new EventHandler(Process_Exited);

                //启动程序
                p.Start();
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
                p.StandardInput.AutoFlush = true;
                //输入命令
                p.StandardInput.WriteLine(cmd);
                //p.StandardInput.WriteLine("exit");

                //获取输出信息
                // string strOuput = p.StandardOutput.ReadToEnd();
                //等待程序执行完退出进程
                p.WaitForExit();
                p.Close();
                // return strOuput;
                return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void ReadStdOutputAction(string result)
        {
            //this.textBoxShowStdRet.AppendText(result + "\r\n");
        }

        private void ReadErrOutputAction(string result)
        {
            //this.textBoxShowErrRet.AppendText(result + "\r\n");
        }

        private void p_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                // 4. 异步调用，需要invoke
                //this.Invoke(ReadStdOutput, new object[] { e.Data });
                Console.WriteLine(e.Data);
            }
        }

        private void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                //this.Invoke(ReadErrOutput, new object[] { e.Data });
                Console.WriteLine(e.Data);
            }
        }

        private void Process_Exited(object sender, EventArgs e)
        { Console.WriteLine("命令执行完毕"); }
    }
}