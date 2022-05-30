using System.ComponentModel;
using System.Text.Json.Serialization;

namespace JiraWorkSpace.MAUI.Data.Jira
{
    public class JiraIssueFieldDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string summary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime created { get; set; }

        /// <summary>
        /// 
        /// </summary>
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