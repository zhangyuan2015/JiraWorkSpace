﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace JiraWorkSpace.MAUI.Data.Project
{
    public class ProjectModel
    {
        public ProjectModel()
        {
            CommonBranchList = new List<CommonBranchModel>();
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
        /// 当前分支
        /// </summary>
        [DisplayName("当前分支")]
        public string CurrentBranch { get; set; }

        /// <summary>
        /// Git地址
        /// </summary>
        [DisplayName("Git地址")]
        public string GitUrl { get; set; }

        /// <summary>
        /// feature/PRLMS-5059-
        /// </summary>
        [DisplayName("JiraIdPrefix")]
        public string JiraIdPrefix { get; set; }

        /// <summary>
        /// 常用分支
        /// </summary>
        [DisplayName("常用分支")]
        public List<CommonBranchModel> CommonBranchList { get; set; }

        public string RowClass => "projectRow";
    }

    /// <summary>
    /// 
    /// </summary>
    public class CommonBranchModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("别名")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("分支名")]
        public string BranchName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("JiraId")]
        public string JiraId { get { return string.IsNullOrWhiteSpace(JiraIdPrefix) ? "" : (BranchName.Contains(JiraIdPrefix) ? Regex.Match(BranchName, JiraIdPrefix + "-[0-9]{1,}").Value : ""); } }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("版本")]
        public string Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("备注")]
        public string Remark { get; set; }

        public string RowClass => "branchRow";
    }
}