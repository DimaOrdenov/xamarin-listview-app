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
                OnPropertyChanged("Image");
                OnPropertyChanged("Title");
                OnPropertyChanged("Description");
                OnPropertyChanged("Price");
                OnPropertyChanged("RetailPrice");
            }
        }

        public ExtendedImageSource Image
        {
            get
            {
                return _product?.ImageSource;
            }
        }

        public string Title
        {
            get { return _product?.Title; }
        }

        public string Description
        {
            get { return _product?.Description; }
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
