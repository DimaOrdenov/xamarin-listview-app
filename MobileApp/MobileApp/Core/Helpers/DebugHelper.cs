using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Core.Helpers
{
    public static class DebugHelper
    {
        public static void Log(object obj)
        {
            System.Diagnostics.Debug.WriteLine(obj?.ToString());
        }

        public static void Log(string str)
        {
            System.Diagnostics.Debug.WriteLine(str);
        }

        public static void Log(string str, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(str, args);
        }
    }
}
