using CommonServiceLocator;
using MobileApp.ExtendedViewControls;
using MobileApp.Models.DTO;
using MobileApp.Services.Interfaces;
using MobileApp.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels.Catalog
{
    public class CatalogItemVM : ViewCellVM
    {
        private ProductDTO _product;

        public CatalogItemVM()
        {
        }

        public ICommand OpenProductOptionsCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await ServiceLocator.Current.GetInstance<IDialogService>().ShowMessage("", _product?.Option);
                });
            }
        }

        public ProductDTO Product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged();

                OnPropertyChanged("ProductImageSource");
                OnPropertyChanged("ImageBackgroundColor");
                OnPropertyChanged("Title");
                OnPropertyChanged("GabaritInfo");
                OnPropertyChanged("SupplierInfo");
                OnPropertyChanged("DeliveryDate");
                OnPropertyChanged("ShortDescription");
                OnPropertyChanged("Price");
                OnPropertyChanged("RetailPrice");
                OnPropertyChanged("ProductImageAvailableSource");
                OnPropertyChanged("ProductImageAvailableTintColor");
            }
        }

        public ExtendedImageSource ProductImageSource
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
                return ProductImageSource != null ? Color.Transparent : (Color)App.Current.Resources["light_gray"];
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

        public FormattedString SupplierInfo
        {
            get
            {
                return new FormattedString
                {
                    Spans =
                    {
                        new Span
                        {
                            Text = "Поставщик: "
                        },
                        new Span
                        {
                            Text = _product?.SupplierInfo,
                            ForegroundColor = (Color)App.Current.Resources["light_gray"]
                        }
                    }
                };
            }
        }

        public FormattedString DeliveryDate
        {
            get
            {
                return new FormattedString
                {
                    Spans =
                    {
                        new Span
                        {
                            Text = "Срок доставки: "
                        },
                        new Span
                        {
                            Text = (_product?.DeliveryTime ?? 0).ToString(),
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

        public ImageSource ProductImageAvailableSource
        {
            get
            {
                if (_product?.IsAvailable == true)
                {
                    return ImageSource.FromFile("ic_check_circle_black_24dp.png");
                }
                else
                {
                    return ImageSource.FromFile("ic_highlight_off_black_24dp.png");
                }
            }
        }

        public Color ProductImageAvailableTintColor
        {
            get
            {
                if (_product?.IsAvailable == true)
                {
                    return Color.Green;
                }
                else
                {
                    return Color.Red;
                }
            }
        }
    }
}
