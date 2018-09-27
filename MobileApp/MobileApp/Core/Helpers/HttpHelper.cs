using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileApp.Core.Helpers
{
    public static class HttpHelper
    {
        public static string ToQueryString(this IDictionary<string, string> dictionary)
        {
            return '?' + string.Join("&", dictionary?.Select(p => p.Key + '=' + Uri.EscapeUriString(p.Value))?.ToArray());
        }
    }
}
