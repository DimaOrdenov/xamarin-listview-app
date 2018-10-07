using MobileApp.ExtendedViewControls;
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
        public ExtendedImageSource ImageSource { get; set; }

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
                ServerResponse.Image serverImage = serverProduct.Images[0];

                if (string.IsNullOrEmpty(serverImage.Url) || string.IsNullOrEmpty(serverImage.Title))
                {
                    productDTO.ImageSource = Xamarin.Forms.ImageSource.FromFile("placeholder.png") as ExtendedImageSource;
                }
                else
                {
                    productDTO.ImageSource = ExtendedImageSource.FromSecureUri(new Uri(string.Concat(serverImage.Url, serverImage.Title)));
                }
            }
            else
            {
                productDTO.ImageSource = Xamarin.Forms.ImageSource.FromFile("placeholder.png") as ExtendedImageSource;
            }

            productDTO.Title = serverProduct.Title;

            productDTO.Description = serverProduct.Short_description;

            productDTO.Price = new Money(serverProduct.Price ?? 0);

            productDTO.RetailPrice = new Money(serverProduct.Retail_price ?? 0);

            return productDTO;
        }
    }
}
