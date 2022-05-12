using System.Text.Json;

namespace JiraWorkSpace.MAUI.Data
{
    public static class ConfigHelper
    {
        private static ConfigModel Config;

        public static ConfigModel GetConfig()
        {
            if (Config == null)
                Config = JsonSerializer.Deserialize<ConfigModel>(File.ReadAllText($"{System.AppDomain.CurrentDomain.BaseDirectory}\\_c.json"));

            return Config;
        }
    }

    public class ConfigModel
    {
        public string AD { get; set; }
        public string CodeDirectory { get; set; }
        public string JiraDomain { get; set; }
        public string JiraUaseName { get; set; }
        public string JiraApiToken { get; set; }
        public string JiraApiVersion { get; set; }
    }
}