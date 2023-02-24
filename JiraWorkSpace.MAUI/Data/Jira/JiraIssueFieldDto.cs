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
        public JiraIssueSubTaskDto parent { get; set; }

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
    }
}