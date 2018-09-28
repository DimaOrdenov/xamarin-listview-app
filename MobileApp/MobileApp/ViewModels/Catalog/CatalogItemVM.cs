using MobileApp.Interfaces;
using MobileApp.Models;
using MobileApp.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileApp.ViewModels.Catalog
{
    public class CatalogItemVM : ViewCellVM
    {
        private Product _product;

        public CatalogItemVM()
        {
        }

        public Product Product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged();
                OnPropertyChanged("Image");
                OnPropertyChanged("Title");
                OnPropertyChanged("Description");
                OnPropertyChanged("MainPrice");
                OnPropertyChanged("SubPrice");
            }
        }

        public ImageSource Image
        {
            get
            {
                if (!string.IsNullOrEmpty(_product?.Image))
                {
                    return ImageSource.FromFile(_product?.Image);
                }

                if (_product?.ImageUri != null)
                {
                    return ImageSource.FromUri(_product?.ImageUri);
                }

                return null;
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

        public string MainPrice
        {
            get { return _product?.MainPrice; }
        }

        public string SubPrice
        {
            get { return _product?.SubPrice; }
        }
    }
}
