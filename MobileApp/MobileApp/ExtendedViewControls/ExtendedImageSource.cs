using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileApp.ExtendedViewControls
{
    public class ExtendedImageSource : ImageSource
    {
        public readonly UriImageSource UriImageSource = new UriImageSource();

        public static ExtendedImageSource FromSecureUri(Uri uri)
        {
            var source = new ExtendedImageSource();

            source.UriImageSource.Uri = uri;

            return source;
        }
    }
}
