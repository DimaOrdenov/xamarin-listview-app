using MobileApp.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    public class Product : BaseModel
    {
        public string Image { get; set; }

        public Uri ImageUri { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string MainPrice { get; set; }

        public string SubPrice { get; set; }
    }
}
