using MobileApp.ExtendedViewControls;
using MobileApp.Models.DTO;
using MobileApp.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileApp.ViewModels.Catalog
{
    public class CatalogItemVM : ViewCellVM
    {
        private ProductDTO _product;

        public CatalogItemVM()
        {
        }

        public ProductDTO Product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged();

                OnPropertyChanged("ImageSource");
                OnPropertyChanged("ImageBackgroundColor");
                OnPropertyChanged("Title");
                OnPropertyChanged("GabaritInfo");
                OnPropertyChanged("ShortDescription");
                OnPropertyChanged("Price");
                OnPropertyChanged("RetailPrice");
            }
        }

        public ExtendedImageSource ImageSource
        {
            get
            {
                return _product?.ImageSource;
            }
        }

        public Color ImageBackgroundColor
        {
            get
            {
                return ImageSource != null ? Color.Transparent : (Color)App.Current.Resources["light_gray"];
            }
        }

        public string Title
        {
            get { return _product?.Title; }
        }

        public FormattedString GabaritInfo
        {
            get
            {
                return new FormattedString
                {
                    Spans =
                    {
                        new Span
                        {
                            Text = "Габариты: "
                        },
                        new Span
                        {
                            Text = _product?.GabaritInfo,
                            ForegroundColor = (Color)App.Current.Resources["light_gray"]
                        }
                    }
                };
            }
        }

        public string ShortDescription
        {
            get { return _product?.ShortDescription; }
        }

        public string Price
        {
            get { return _product?.Price?.FormattedString; }
        }

        public string RetailPrice
        {
            get { return _product?.RetailPrice?.FormattedString; }
        }
    }
}
