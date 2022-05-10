using System.ComponentModel;

namespace JiraWorkSpace.MAUI.Data
{
    public class JiraIssueAssigneeDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string self { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("经办人")]
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string emailAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public JiraAvatarUrlsDto avatarUrls { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("经办人")]
        public string displayName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string active { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string timeZone { get; set; }
    }
}