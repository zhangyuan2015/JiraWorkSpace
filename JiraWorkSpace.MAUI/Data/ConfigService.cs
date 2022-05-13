using System.Text.Json;

namespace JiraWorkSpace.MAUI.Data
{
    public static class ConfigService
    {
        private static readonly string filePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\_{nameof(ConfigModel)}.json";

        private static ConfigModel Config;

        public static ConfigModel GetConfig()
        {
            if (Config == null)
                Config = JsonSerializer.Deserialize<ConfigModel>(File.ReadAllText(filePath));
            return Config;
        }

        public static void Save(ConfigModel config)
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(Config));
            Config = config;
        }
    }

    public class ConfigModel
    {
        public string AD { get; set; }
        public string CodeDirectory { get; set; }
        public string BranchRule { get; set; }
        public string JiraDomain { get; set; }
        public string JiraUaseName { get; set; }
        public string JiraApiToken { get; set; }
        public string JiraApiVersion { get; set; }
    }
}