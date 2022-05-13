using System.Text.Json;

namespace JiraWorkSpace.MAUI.Data
{
    public static class ProjectService
    {
        private static readonly string filePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\_{nameof(ProjectModel)}.json";

        private static List<ProjectModel> Projects;

        public static List<ProjectModel> GetList()
        {
            if (Projects == null)
                Projects = JsonSerializer.Deserialize<List<ProjectModel>>(File.ReadAllText(filePath));

            return Projects;
        }

        public static void Save(List<ProjectModel> projects)
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(projects));
            Projects = projects;
        }
    }

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