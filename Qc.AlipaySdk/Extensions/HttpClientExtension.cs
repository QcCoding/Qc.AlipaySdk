using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Qc.AlipaySdk
{
    public static class HttpClientExtension
    {
        public static T HttpPostParams<T>(this HttpClient client, string url, IEnumerable<KeyValuePair<string, string>> paraList = null, string contentType = "application/x-www-form-urlencoded")
        {
            using (var httpContent = new FormUrlEncodedContent(paraList))
            {
                if (contentType != null)
                    httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
                using (HttpResponseMessage response = client.PostAsync(url, httpContent).Result)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    return Utils.JsonHelper.Deserialize<T>(result);
                }
            }
        }
        public static T HttpPost<T>(this HttpClient client, string url, string postData = null, string contentType = "application/x-www-form-urlencoded")
        {
            using (var httpContent = new StringContent(postData ?? string.Empty))
            {
                if (contentType != null)
                    httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
                using (HttpResponseMessage response = client.PostAsync(url, httpContent).Result)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    return Utils.JsonHelper.Deserialize<T>(result);
                }
            }
        }
        public static T HttpPost<T>(this HttpClient client, string url, Dictionary<string, string> dicData, bool isQuery)
        {
            StringBuilder dataBuilder = new StringBuilder();
            foreach (var item in dicData)
            {
                dataBuilder.Append(item.Key).Append("=").Append(isQuery ? System.Web.HttpUtility.UrlEncode(item.Value) : item.Value).Append("&");
            }
            string dataStr = dataBuilder.ToString().TrimEnd('&');
            if (isQuery)
            {
                url = url + (url.Contains("?") ? "&" : "?") + dataStr;
                dataStr = null;
            }
            return client.HttpPost<T>(url, dataStr);
        }

        public static T HttpGet<T>(this HttpClient client, string url)
        {
            using (HttpResponseMessage response = client.GetAsync(url).Result)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return Utils.JsonHelper.Deserialize<T>(result);
            }
        }

        public static T HttpGet<T>(this HttpClient client, string url, Dictionary<string, string> queryData)
        {
            var urlAndQuery = AppendUrlQuery(url, queryData);
            return client.HttpGet<T>(urlAndQuery);
        }

        public static string AppendUrlQuery(string url, Dictionary<string, string> queryData, bool isEncode = false)
        {
            if (queryData == null || queryData.Count == 0)
                return url;
            url = url ?? string.Empty;
            string queryStr = string.Empty;
            if ((url.Contains("&") || url.Contains("?")) && !(url.EndsWith("&") || url.EndsWith("?")))
            {
                queryStr += "&";
            }
            else if (!url.Contains("?"))
            {
                queryStr += "?";
            }
            url += queryStr;
            StringBuilder dataBuilder = new StringBuilder();
            foreach (var item in queryData)
            {
                dataBuilder.Append(item.Key).Append("=").Append(isEncode ? System.Web.HttpUtility.UrlEncode(item.Value) : item.Value).Append("&");
            }
            string dataStr = dataBuilder.ToString().TrimEnd('&');
            url += dataStr;
            return url;
        }
    }
}
