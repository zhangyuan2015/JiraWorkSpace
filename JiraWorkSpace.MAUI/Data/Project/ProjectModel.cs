namespace JiraWorkSpace.MAUI.Data.Project
{
    public class ProjectModel
    {
        public string ProjectName { get; set; }
        public string CodeDirectory { get; set; }
        public string GitUrl { get; set; }
        public List<EnvironmentModel> EnvironmentList { get; set; }
    }

    public class EnvironmentModel
    {
        public string Name { get; set; }
        public string BranchName { get; set; }
        public string Url { get; set; }
    }
}