namespace JiraWorkSpace.MAUI.Data.Jira
{
    public class JiraSearchRootDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string expand { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int startAt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int maxResults { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<JiraIssueDto> issues { get; set; }
    }
}