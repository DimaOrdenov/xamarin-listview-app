using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MobileApp.Droid.CustomRenderers;
using MobileApp.Droid.Handlers;
using MobileApp.ExtendedViewControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportImageSourceHandler(typeof(ExtendedImageSource), typeof(SecuredImageLoaderSourceHandler))]
namespace MobileApp.Droid.Handlers
{
    public class SecuredImageLoaderSourceHandler : IImageSourceHandler
    {
        public async Task<Bitmap> LoadImageAsync(ImageSource imagesource,
                                                 Context context,
                                                 CancellationToken cancelationToken = default(CancellationToken))
        {
            var imageLoader = imagesource as ExtendedImageSource;

            if (imageLoader != null && imageLoader.UriImageSource.Uri != null)
            {
                var webClient = new WebClient();
                var data = await webClient.DownloadDataTaskAsync(imageLoader.UriImageSource.Uri).ConfigureAwait(false);

                using (var stream = new MemoryStream(data))
                {
                    return await BitmapFactory.DecodeStreamAsync(stream).ConfigureAwait(false);
                }
            }

            return null;
        }
    }
}