using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JiraWorkSpace.MAUI.Data.Project
{
    public class ProjectModel
    {
        public ProjectModel()
        {
            EnvironmentList = new List<EnvironmentModel>();
        }

        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 项目名
        /// </summary>
        [Required]
        [DisplayName("项目名")]
        public string ProjectName { get; set; }

        /// <summary>
        /// 代码目录
        /// </summary>
        [Required]
        [DisplayName("代码目录")]
        public string CodeDirectory { get; set; }

        /// <summary>
        /// 代码目录
        /// </summary>
        [Required]
        [DisplayName("当前")]
        public string CurrentBranch { get; set; }

        /// <summary>
        /// Git地址
        /// </summary>
        [DisplayName("Git地址")]
        public string GitUrl { get; set; }

        /// <summary>
        /// 环境
        /// </summary>
        [DisplayName("环境")]
        public List<EnvironmentModel> EnvironmentList { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class EnvironmentModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("环境名称")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("分支名")]
        public string BranchName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("站点 Url")]
        public string Url { get; set; }
    }
}