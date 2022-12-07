namespace JiraWorkSpace.MAUI.Data.Setup
{
    public class SetupModel
    {
        public string AD { get; set; }
        public string BranchRule { get; set; }
        public string DefBranchRule { get; } = "{JIRAKEY}-{AD}-{MMdd}-{BranchName}";
        public string JiraDomain { get; set; }
        public string JiraUaseName { get; set; }
        public string JiraApiToken { get; set; }
        public string JiraApiVersion { get; set; }

        public string JiraUrl(string jiraId)
        {
            return JiraDomain + "/browse/" + jiraId;
        }
    }
}