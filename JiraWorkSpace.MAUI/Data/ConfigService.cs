using System.Text.Json;

namespace JiraWorkSpace.MAUI.Data
{
    public class ConfigService<T>
    {
        readonly string ConfigKey;

        public ConfigService(string configKey)
        {
            ConfigKey = configKey;
        }

        public string GetConfigFilePath()
        {
            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string projectPath = $"{basePath}\\JiraWorkSpace";
            if (!Directory.Exists(projectPath))
                Directory.CreateDirectory(projectPath);

            string configName = $"_{ConfigKey}.json";
            string configPath = $"{projectPath}\\{configName}";
            return configPath;
        }

        public T GetEntity()
        {
            string configFilePath = GetConfigFilePath();
            if (File.Exists(configFilePath))
            {
                return JsonSerializer.Deserialize<T>(File.ReadAllText(configFilePath));
            }
            return default;
        }

        public List<T> GetEntityList()
        {
            string configFilePath = GetConfigFilePath();
            if (File.Exists(configFilePath))
            {
                return JsonSerializer.Deserialize<List<T>>(File.ReadAllText(configFilePath));
            }
            return default;
        }

        public void Save(List<T> configData)
        {
            string configFilePath = GetConfigFilePath();
            File.WriteAllText(configFilePath, JsonSerializer.Serialize(configData));
        }

        public void Save(T configData)
        {
            string configFilePath = GetConfigFilePath();
            File.WriteAllText(configFilePath, JsonSerializer.Serialize(configData));
        }
    }
}