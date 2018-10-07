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

        public string Url { get; set; }

        public string Description { get; set; }

        public string H1 { get; set; }

        public long? Created { get; set; }

        public long? Updated { get; set; }

        public int? Supplier_id { get; set; }

        public int? Retail_price { get; set; }

        public int? Price { get; set; }

        public int? Discount_price { get; set; }

        public bool? Is_new { get; set; }

        public string Option { get; set; }

        public string Sku { get; set; }

        public bool? Is_available { get; set; }

        public int? Delivery_time { get; set; }

        public bool? Is_active { get; set; }

        public int? Count_added_to_o_cart { get; set; }

        public int? Count_view { get; set; }

        public string Short_description { get; set; }

        public int? Gabarit_id { get; set; }

        public List<Image> Images { get; set; }

        public string SupplierInfo { get; set; }

        public string GabaritInfo { get; set; }
    }
}
