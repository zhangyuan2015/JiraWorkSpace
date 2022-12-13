using JiraWorkSpace.MAUI.Data.Cookie;
using System.Net;
using System.Text;
using System.Text.Json;

namespace JiraWorkSpace.MAUI.Data
{
    public static class HttpHelper
    {
        public static CookieContainer GetCookieCollection(Uri baseAddress, string cookieStr)
        {
            CookieContainer cookieContainer = new CookieContainer();
            if (!string.IsNullOrEmpty(cookieStr))
            {
                CookieCollection cookies = new CookieCollection();
                foreach (var cookieItem in cookieStr.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var cookieItemArr = cookieItem.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    if (cookieItemArr.Length == 1)
                        cookies.Add(new System.Net.Cookie(cookieItemArr[0].Trim(), "", "/", baseAddress.Host));
                    else if (cookieItemArr.Length == 2)
                        cookies.Add(new System.Net.Cookie(cookieItemArr[0].Trim(), cookieItemArr[1].Trim(), "/", baseAddress.Host));
                }
                cookieContainer.Add(cookies);
            }

            return cookieContainer;
        }

        public static CookieContainer GetCookieCollection(List<CookieModel> cookieModels)
        {
            CookieContainer cookieContainer = new CookieContainer();
            if (cookieModels != null && cookieModels.Any())
            {
                CookieCollection cookies = new CookieCollection();
                foreach (var cookieItem in cookieModels)
                {
                    cookies.Add(new System.Net.Cookie(cookieItem.name.Trim(), cookieItem.value.Trim(), cookieItem.path, cookieItem.domain));
                }
                cookieContainer.Add(cookies);
            }

            return cookieContainer;
        }

        public static T1 Post<T1, T2>(Uri baseAddress, string path, string cookieStr, Dictionary<string, string> headers, T2 param)
        {
            CookieContainer cookieContainer = GetCookieCollection(baseAddress, cookieStr);
            return Post<T1>(baseAddress, path, cookieContainer, headers, JsonSerializer.Serialize(param), Encoding.UTF8, "application/json");
        }

        public static T1 Post<T1>(Uri baseAddress, string path, string cookieStr, Dictionary<string, string> headers, string param, Encoding encoding, string mediaType)
        {
            CookieContainer cookieContainer = GetCookieCollection(baseAddress, cookieStr);
            return Post<T1>(baseAddress, path, cookieContainer, headers, param, encoding, mediaType);
        }

        public static T1 Post<T1>(Uri baseAddress, string path, List<CookieModel> cookieModels, Dictionary<string, string> headers, string param, Encoding encoding, string mediaType)
        {
            CookieContainer cookieContainer = GetCookieCollection(cookieModels);
            return Post<T1>(baseAddress, path, cookieContainer, headers, param, encoding, mediaType);
        }

        public static T1 Post<T1>(Uri baseAddress, string path, CookieContainer cookieContainer, Dictionary<string, string> headers, string param, Encoding encoding, string mediaType)
        {
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                if (headers != null && headers.Any())
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                var paramStr = param;
                var content = new StringContent(paramStr, encoding, mediaType);
                var result = client.PostAsync(path, content);
                result.Result.EnsureSuccessStatusCode();
                var resStr = result.Result.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<T1>(resStr);
            }
        }

        public static T Get<T>(Uri baseAddress, string path, string cookieStr, Dictionary<string, string> headers, Dictionary<string, string> queryParams)
        {
            return Get<T>(baseAddress, path, GetCookieCollection(baseAddress, cookieStr), headers, queryParams);
        }

        public static T Get<T>(Uri baseAddress, string path, List<CookieModel> cookieModels, Dictionary<string, string> headers, Dictionary<string, string> queryParams)
        {
            return Get<T>(baseAddress, path, GetCookieCollection(cookieModels), headers, queryParams);
        }

        private static T Get<T>(Uri baseAddress, string path, CookieContainer cookieContainer, Dictionary<string, string> headers, Dictionary<string, string> queryParams)
        {
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                if (headers != null && headers.Any())
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                if (queryParams != null && queryParams.Any())
                {
                    var queryArr = queryParams.Select(a => a.Key + "=" + a.Value);
                    path += ("?" + string.Join("&", queryArr));
                }

                var result = client.GetAsync(path);
                result.Result.EnsureSuccessStatusCode();
                var resStr = result.Result.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<T>(resStr, new JsonSerializerOptions());
            }
        }
    }
}