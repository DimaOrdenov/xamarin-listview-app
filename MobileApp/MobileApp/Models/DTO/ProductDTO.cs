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
        public ImageSource ImageSource { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public Money Price { get; set; }

        public Money RetailPrice { get; set; }

        public bool? IsAvailable { get; set; }

        public string GabaritInfo { get; set; }

        public string SupplierInfo { get; set; }

        public int? DeliveryTime { get; set; }

        public string Option { get; set; }

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
                    //productDTO.ImageSource = Xamarin.Forms.ImageSource.FromFile("placeholder.png") as ExtendedImageSource;

                    productDTO.ImageSource = Xamarin.Forms.ImageSource.FromFile("placeholder.png");
                }
                else
                {
                    //productDTO.ImageSource = ExtendedImageSource.FromSecureUri(new Uri(string.Concat(serverImage.Url, serverImage.Title)));

                    productDTO.ImageSource = ImageSource.FromUri(new Uri(string.Concat(serverImage.Url, serverImage.Title)));
                }
            }
            else
            {
                //productDTO.ImageSource = Xamarin.Forms.ImageSource.FromFile("placeholder.png") as ExtendedImageSource;

                productDTO.ImageSource = Xamarin.Forms.ImageSource.FromFile("placeholder.png");
            }

            productDTO.Title = serverProduct.Title;
            productDTO.ShortDescription = serverProduct.Short_description;
            productDTO.Price = new Money(serverProduct.Price ?? 0);
            productDTO.RetailPrice = new Money(serverProduct.Retail_price ?? 0);
            productDTO.IsAvailable = serverProduct.Is_available;
            productDTO.GabaritInfo = serverProduct.GabaritInfo;
            productDTO.SupplierInfo = serverProduct.SupplierInfo;
            productDTO.DeliveryTime = serverProduct.Delivery_time;
            productDTO.Option = serverProduct.Option;

            return productDTO;
        }
    }
}
