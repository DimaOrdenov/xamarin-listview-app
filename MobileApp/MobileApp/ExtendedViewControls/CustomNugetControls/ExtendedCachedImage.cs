using FFImageLoading.Forms;
using FFImageLoading.Transformations;
using FFImageLoading.Work;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileApp.ExtendedViewControls.CustomNugetControls
{
    public class ExtendedCachedImage : CachedImage
    {
        public static BindableProperty TintColorProperty =
            BindableProperty.Create(
                nameof(TintColor),
                typeof(Color),
                typeof(ExtendedCachedImage),
                Color.Transparent,
                propertyChanged: HandleTintColorPropertyChanged);

        public Color TintColor
        {
            get { return (Color)GetValue(TintColorProperty); }
            set { SetValue(TintColorProperty, value); }
        }

        private static void HandleTintColorPropertyChanged(BindableObject bindable, object oldColor, object newColor)
        {
            var oldcolor = (Color)oldColor;
            var newcolor = (Color)newColor;

            if (!oldcolor.Equals(newcolor) && bindable is ExtendedCachedImage view)
            {
                var transformations = new List<ITransformation>()
                {
                    new TintTransformation((int)(newcolor.R * 255), (int)(newcolor.G * 255), (int)(newcolor.B * 255), (int)(newcolor.A * 255))
                    {
                        EnableSolidColor = true
                    }
                };

                view.Transformations = transformations;
            }
        }
    }
}
