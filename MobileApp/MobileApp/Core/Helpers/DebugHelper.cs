using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Core.Helpers
{
    public static class DebugHelper
    {
        public static void Log(object obj)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine(obj?.ToString());
#endif
        }

        public static void Log(string str)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine(str);
#endif
        }

        public static void Log(string str, params object[] args)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine(str, args);
#endif
        }
    }
}
