using MobileApp.Models.Common;
using MobileApp.Models.ServerResponse;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileApp.Models.DTO
{
    public class ProductDTO : BaseDTO
    {
        public ImageSource ImageSource { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Money Price { get; set; }

        public Money RetailPrice { get; set; }

        public static ProductDTO CreateFromServerResponse(Product serverProduct)
        {
            if (serverProduct == null)
            {
                return null;
            }

            ProductDTO productDTO = new ProductDTO();

            if (serverProduct.Images?.Count > 0)
            {
                productDTO.ImageSource = serverProduct.Images[0].ImageSource;
            }

            productDTO.Title = serverProduct.Title;

            productDTO.Description = serverProduct.Short_description;

            productDTO.Price = new Money(serverProduct.Price ?? 0);

            productDTO.RetailPrice = new Money(serverProduct.Retail_price ?? 0);

            return productDTO;
        }
    }
}
