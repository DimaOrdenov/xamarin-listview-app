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
    }
}
