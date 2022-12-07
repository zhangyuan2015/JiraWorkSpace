using System.ComponentModel;

namespace JiraWorkSpace.MAUI.Data.Jira
{
    public class JiraIssueTypeDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string self { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string iconUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool subtask { get; set; }
    }
}