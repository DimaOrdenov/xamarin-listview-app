using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileApp.ViewControlEffects
{
    public class TintImageEffect : RoutingEffect
    {
        public const string GroupName = "BabyCrazy";
        public const string Name = "TintImageEffect";

        //public static readonly BindableProperty TintColorProperty = BindableProperty.Create(nameof(TintColor), typeof(Color), typeof(TintImageEffect), Color.Black);

        //public Color TintColor
        //{
        //    get { return (Color)GetValue(TintColorProperty); }
        //    set { SetValue(TintColorProperty, value); }
        //}

        public Color TintColor { get; set; }

        public TintImageEffect() : base(string.Format("{0}.{1}", GroupName, Name))
        {
        }
    }
}
