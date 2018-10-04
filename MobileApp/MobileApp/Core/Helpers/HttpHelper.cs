using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileApp.Core.Helpers
{
    public static class HttpHelper
    {
        public static string RequestString(string controller, string url, string id, IDictionary<string, string> parameters)
        {
            string result = "";

            List<string> requestStringPaths = new List<string> { controller, url, id };

            requestStringPaths.ForEach(x =>
            {
                if (x.StartsWith("/"))
                {
                    string path = requestStringPaths.FirstOrDefault(y => y == x);

                    if (path != null)
                    {
                        path = path.Substring(1);
                    }
                }
            });

            if (!string.IsNullOrEmpty(controller))
            {
                result += controller;
            }

            if (!string.IsNullOrEmpty(url))
            {
                result += (result.EndsWith("/") ? "" : "/") + url;
            }

            if (!string.IsNullOrEmpty(url))
            {
                result += (result.EndsWith("/") ? "" : "/") + url;
            }

            return "";
        }

        public static string ToQueryString(this IDictionary<string, string> dictionary)
        {
            return '?' + string.Join("&", dictionary?.Select(p => p.Key + '=' + Uri.EscapeUriString(p.Value))?.ToArray());
        }

        public static T DeserializeJsonString<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception e)
            {
                DebugHelper.Log(e);

                return default(T);
            }
        }
    }
}
