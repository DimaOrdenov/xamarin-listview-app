using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileApp.Models.ServerResponse
{
    public class Image
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        [JsonIgnore]
        public ImageSource ImageSource
        {
            get
            {
                if (string.IsNullOrEmpty(Url) || string.IsNullOrEmpty(Title))
                {
                    return ImageSource.FromFile("placeholder.png");
                }

                return ImageSource.FromUri(new Uri(String.Concat(Url, Title)));
            }
        }
    }
}
