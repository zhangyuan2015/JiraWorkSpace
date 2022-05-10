using System.ComponentModel;

namespace JiraWorkSpace.MAUI.Data
{
    public class JiraIssuePriorityDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string self { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string iconUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("优先级")]
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
    }
}