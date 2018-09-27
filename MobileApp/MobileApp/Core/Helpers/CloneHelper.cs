using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Core.Helpers
{
    public static class CloneHelper
    {
        public static T Clone<T>(this T obj)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));
        }
    }
}
