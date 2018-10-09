using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Core.Helpers
{
    public static class StringHelper
    {
        public static string FormatEndingByInt(int number, string end1, string end234, string defaultEnd)
        {
            int mod = number <= 20 ? number : number % 10;

            switch (mod)
            {
                case 1:
                    return end1;
                case 2:
                case 3:
                case 4:
                    return end234;
                default:
                    return defaultEnd;
            }
        }
    }
}
