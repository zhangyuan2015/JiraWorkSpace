using System.ComponentModel;

namespace JiraWorkSpace.MAUI.Data
{
    public class JiraIssueFieldDto
    {
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("概要")]
        public string summary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("描述")]
        public string description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime created { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("更新时间")]
        public DateTime updated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public JiraIssueAssigneeDto assignee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public JiraIssueStatusDto status { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public JiraIssuePriorityDto priority { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public JiraIssueTypeDto issuetype { get; set; }
    }
}