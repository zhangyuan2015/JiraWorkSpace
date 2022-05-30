using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraWorkSpace.MAUI.Data.Jira
{
    public class JiraIssueDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string expand { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string self { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public JiraIssueFieldDto fields { get; set; }
    }
}
