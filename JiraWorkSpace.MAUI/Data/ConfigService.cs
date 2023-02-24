using System.Reflection;
using System.Text.Json;

namespace JiraWorkSpace.MAUI.Data
{
    public class ConfigService<T> where T : class, new()
    {
        readonly string ConfigKey;

        public ConfigService(string configKey)
        {
            ConfigKey = configKey;
        }

        public string GetConfigFilePath()
        {
            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string projectPath = $"{basePath}\\JiraWorkSpace";
            if (!Directory.Exists(projectPath))
                Directory.CreateDirectory(projectPath);

            string configName = $"_{ConfigKey}.json";
            string configPath = $"{projectPath}\\{configName}";
            return configPath;
        }

        public T GetEntity(bool isDecrypt = false)
        {
            string configFilePath = GetConfigFilePath();
            if (File.Exists(configFilePath))
            {
                if (isDecrypt)
                {
                    var AES_KEY = GetPropertyValue(new T(), "AES_KEY");
                    return JsonSerializer.Deserialize<T>(AesEncryptHelper.Decrypt(File.ReadAllText(configFilePath), AES_KEY));
                }
                else
                {
                    return JsonSerializer.Deserialize<T>(File.ReadAllText(configFilePath));
                }
            }
            return default;
        }

        public List<T> GetEntityList(bool isDecrypt = false)
        {
            string configFilePath = GetConfigFilePath();
            if (File.Exists(configFilePath))
            {
                if (isDecrypt)
                {
                    var AES_KEY = GetPropertyValue(new T(), "AES_KEY");
                    return JsonSerializer.Deserialize<List<T>>(AesEncryptHelper.Decrypt(File.ReadAllText(configFilePath), AES_KEY));
                }
                else
                {
                    return JsonSerializer.Deserialize<List<T>>(File.ReadAllText(configFilePath));
                }
            }
            return default;
        }

        public void Save(List<T> configData, bool isEncrypt = false)
        {
            string configFilePath = GetConfigFilePath();
            if (isEncrypt)
            {
                var AES_KEY = GetPropertyValue(new T(), "AES_KEY");
                File.WriteAllText(configFilePath, AesEncryptHelper.Encrypt(JsonSerializer.Serialize(configData), AES_KEY));
            }
            else
            {
                File.WriteAllText(configFilePath, JsonSerializer.Serialize(configData));
            }
        }

        public void Save(T configData, bool isEncrypt = false)
        {
            string configFilePath = GetConfigFilePath();
            if (isEncrypt)
            {
                var AES_KEY = GetPropertyValue(new T(), "AES_KEY");
                File.WriteAllText(configFilePath, AesEncryptHelper.Encrypt(JsonSerializer.Serialize(configData), AES_KEY));
            }
            else
            {
                File.WriteAllText(configFilePath, JsonSerializer.Serialize(configData));
            }
        }

        private string GetPropertyValue(T entity, string propertyName)
        {
            Type entityType = typeof(T);
            FieldInfo fieldInfo = entityType.GetField(propertyName);
            return fieldInfo.GetValue(entity).ToString();
        }
    }
}