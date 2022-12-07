using System.Net;
using System.Text;

namespace JiraWorkSpace.MAUI.Data.Jira
{
    public class JiraApi
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string BaseURL { get; private set; }

        public JiraApi(string baseUrl, string username, string password)
        {
            BaseURL = baseUrl;
            Username = username;
            Password = password;
        }
        /// <summary>
        /// 处理post请求，执行新建、编辑、删除等操作
        /// </summary>
        /// <param name="sData">json输入字符</param>
        /// <param name="uri">api的具体地址，一般是baseurl + 业务处理资源关键字</param>
        /// <returns>Jira返回的WebResponse输出</returns>
        public string DoPost(string sData, string uri)
        {
            Uri address = new Uri(uri);
            HttpWebRequest request;
            //HttpWebResponse response1 = null;
            StreamReader sr;
            string returnXML = string.Empty;
            if (address == null) { throw new ArgumentNullException("address"); }
            try
            {
                request = WebRequest.Create(address) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/json";
                string base64Credentials = GetEncodedCredentials();
                request.Headers.Add("Authorization", "Basic " + base64Credentials);
                //request.Credentials = new NetworkCredential(sUsername, sPassword);
                if (sData != null)
                {
                    byte[] byteData = UTF8Encoding.UTF8.GetBytes(sData);
                    request.ContentLength = byteData.Length;
                    using (Stream postStream = request.GetRequestStream())
                    {
                        postStream.Write(byteData, 0, byteData.Length);
                    }
                    using (HttpWebResponse response1 = request.GetResponse() as HttpWebResponse)
                    {
                        StreamReader reader = new StreamReader(response1.GetResponseStream());
                        string str = reader.ReadToEnd();
                        return str;
                    }
                }
                return "error";
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    using (HttpWebResponse errorResponse = (HttpWebResponse)wex.Response)
                    {
                        try
                        {
                            string sError = string.Format("The server returned '{0}' with the status code {1} ({2:d}).",
                            errorResponse.StatusDescription, errorResponse.StatusCode,
                            errorResponse.StatusCode);
                            sr = new StreamReader(errorResponse.GetResponseStream(), Encoding.UTF8);
                            returnXML = sr.ReadToEnd();
                            return returnXML;
                        }
                        finally
                        {
                            if (errorResponse != null) errorResponse.Close();
                        }
                    }
                }
                else
                {
                    //throw new Exception(wex.Message);
                    return wex.Message;
                }
            }
        }

        /// <summary>
        /// 处理get请求，执行查询操作
        /// </summary>
        /// <param name="resource">输入的业务处理资源关键字，必填项</param>
        /// <param name="argument">参数，用于获取具体查询操作，非必填项</param>
        /// <param name="data">暂时没用处，非必填项</param>
        /// <param name="method">默认为GET，非必填项</param>
        /// <returns></returns>
        public string DoQuery(
        string resource,
        string argument = null,
        string data = null,
        string method = "GET")
        {
            string url = string.Format("{0}{1}", BaseURL, resource.ToString());
            if (argument != null)
            {
                url = string.Format("{0}{1}", url, argument);
            }
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = method;
            if (data != null)
            {
                using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(data);
                }
            }
            string base64Credentials = GetEncodedCredentials();
            request.Headers.Add("Authorization", "Basic " + base64Credentials);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string result = string.Empty;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }
            return result;

        }
        private string GetEncodedCredentials()
        {
            string mergedCredentials = string.Format("{0}:{1}", Username, Password);
            byte[] byteCredentials = UTF8Encoding.UTF8.GetBytes(mergedCredentials);
            return Convert.ToBase64String(byteCredentials);
        }
    }
}