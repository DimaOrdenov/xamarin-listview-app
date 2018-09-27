using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileApp.ExtendedViewControls
{
    public class ExtendedContentPage : ContentPage
    {
        public ExtendedContentPage() : base()
        {
            NavigationPage.SetBackButtonTitle(this, "");
        }

        //protected void SetActivityIndicator(AbsoluteLayout absoluteLayout)
        //{
        //    if (absoluteLayout == null)
        //    {
        //        return;
        //    }

        //    ActivityIndicator activityIndicator = new ActivityIndicator
        //    {
        //        Color = Color.Blue,
        //        IsRunning = false
        //    };

        //    activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, new Binding("IsLoading"));

        //    Frame frame = new Frame
        //    {
        //        Content = activityIndicator,
        //        HasShadow = false,
        //        BackgroundColor = Color.Transparent
        //    };

        //    frame.SetBinding(IsVisibleProperty, new Binding("IsLoading"));

        //    AbsoluteLayout.SetLayoutFlags(frame, AbsoluteLayoutFlags.PositionProportional);
        //    AbsoluteLayout.SetLayoutBounds(frame, Rectangle.FromLTRB(0.5, 0.5, -1, -1));

        //    if (Device.RuntimePlatform == Device.iOS)
        //    {
        //        frame.CornerRadius = 5;
        //        frame.BackgroundColor = Color.LightGray;
        //    }

        //    absoluteLayout.Children.Add(frame);
        //}
    }
}
