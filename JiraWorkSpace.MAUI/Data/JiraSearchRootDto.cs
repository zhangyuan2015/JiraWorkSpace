namespace JiraWorkSpace.MAUI.Data
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