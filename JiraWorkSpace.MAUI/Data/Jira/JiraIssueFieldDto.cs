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
        public JiraIssueDto parent { get; set; }

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
        public JiraIssueTypeDto issuetype { get; set; }

        /// <summary>
        /// 版本JiraId
        /// </summary>
        public string customfield_11710 { get; set; }

        /// <summary>
        /// 英文描述
        /// 分支名称
        /// </summary>
        public string customfield_11100 { get; set; }
    }
}