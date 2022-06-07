using System.Diagnostics;

namespace JiraWorkSpace.MAUI.Data
{
    public class TortoiseGitUtility
    {
        public TortoiseGitUtility(string workingDir)
        {
            WorkingDir = workingDir;
        }

        /// <summary>
        /// 获取环境git.ext的环境变量路径
        /// </summary>
        private string GetEnvironmentVariable
        {
            get
            {
                string strPath = Environment.GetEnvironmentVariable("Path");
                if (string.IsNullOrEmpty(strPath))
                {
                    return null;
                }

                string[] strResults = strPath.Split(';');
                for (int i = 0; i < strResults.Length; i++)
                {
                    if (!strResults[i].Contains(@"TortoiseGit\bin"))
                        continue;

                    strPath = strResults[i];
                }

                return strPath;
            }
        }

        /// <summary>        
        /// git工作路径
        /// </summary>
        public string WorkingDir { get; set; }

        /// <summary>
        /// 执行指令
        /// https://tortoisegit.org/docs/tortoisegit/tgit-automation.html
        /// </summary>
        public string ExcuteCommand(string strCommnad)
        {
            string strGitPath = Path.Combine(GetEnvironmentVariable, "TortoiseGitProc.exe");
            if (string.IsNullOrEmpty(strGitPath))
            {
                return "TortoiseGit环境错误，请确保正确安装 TortoiseGit";
            }

            Process p = new Process();
            p.StartInfo.FileName = strGitPath;
            p.StartInfo.Arguments = strCommnad;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.WorkingDirectory = WorkingDir;

            p.Start();
            //p.WaitForExit();
            //string returnMsg = p.StandardOutput.ReadToEnd();
            //return returnMsg;
            return "";
        }
    }
}