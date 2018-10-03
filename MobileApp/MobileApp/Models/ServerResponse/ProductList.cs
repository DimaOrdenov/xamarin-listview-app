using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models.ServerResponse
{
    public class ProductList : PaginationResponse
    {
        public List<Product> Products { get; set; }
    }
}
