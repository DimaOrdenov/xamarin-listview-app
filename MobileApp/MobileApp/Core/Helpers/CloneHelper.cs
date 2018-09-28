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
            try
            {
                var serialzed = JsonConvert.SerializeObject(obj);
                var deserialized = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));

                return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));
            }
            catch (Exception e)
            {
                DebugHelper.Log(e);

                return default(T);
            }
        }
    }
}
