using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models.ServerResponse
{
    public class Product
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public string Short_title { get; set; }

        public string Description { get; set; }

        public string Short_description { get; set; }

        public int? Retail_price { get; set; }

        public int? Price { get; set; }

        public int? Discount_price { get; set; }

        public bool? Is_new { get; set; }

        public List<Image> Images { get; set; }
    }
}
