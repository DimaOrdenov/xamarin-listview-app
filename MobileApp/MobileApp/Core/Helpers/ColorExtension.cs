using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Core.Helpers
{
    public static class ColorExtension
    {
        public static string HexValue(this Xamarin.Forms.Color xfColor)
        {
            var red = (int)(xfColor.R * 255);
            var green = (int)(xfColor.G * 255);
            var blue = (int)(xfColor.B * 255);
            var alpha = (int)(xfColor.A * 255);

            return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", alpha, red, green, blue);
        }
    }
}
