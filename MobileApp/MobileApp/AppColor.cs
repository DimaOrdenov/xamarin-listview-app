using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileApp
{
    public class AppColor
    {
        public AppColor() { }

        public static Color BlueGray => (Color)Application.Current.Resources["blue_gray"];
        public static Color MainColor => (Color)Application.Current.Resources["main_color"];
        public static Color MainColorDark => (Color)Application.Current.Resources["main_color_dark"];
        public static Color MainAction => (Color)Application.Current.Resources["main_action"];
    }
}
