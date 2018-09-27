using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace MobileApp.Droid.CustomRenderers
{
    public class CustomSearchBar : SearchBarRenderer
    {
        public CustomSearchBar(Context context) : base(context)
        {
        }
    }
}