using CommonServiceLocator;
using MobileApp.Core.Helpers;
using MobileApp.ExtendedViewControls;
using MobileApp.Models.DTO;
using MobileApp.Services.Interfaces;
using MobileApp.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    await ServiceLocator.Current.GetInstance<IDialogService>().ShowMessage("Опции товара", _product?.Option);
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

                //OnPropertyChanged("ProductImageSource");
                //OnPropertyChanged("ImageBackgroundColor");
                //OnPropertyChanged("Title");
                //OnPropertyChanged("GabaritInfo");
                //OnPropertyChanged("SupplierInfo");
                //OnPropertyChanged("DeliveryDate");
                //OnPropertyChanged("ShortDescription");
                //OnPropertyChanged("Price");
                //OnPropertyChanged("RetailPrice");
                //OnPropertyChanged("ProductImageAvailableSource");
                //OnPropertyChanged("ProductImageAvailableTintColor");
            }
        }

        public ImageSource ProductImageSource
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
                return ProductImageSource != null ? Color.Transparent : (Color)App.Current.Resources["blue_gray"];
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
                            ForegroundColor = (Color)App.Current.Resources["blue_gray"]
                        }
                    }
                };
            }
        }

        //public FormattedString SupplierInfo
        //{
        //    get
        //    {
        //        return new FormattedString
        //        {
        //            Spans =
        //            {
        //                new Span
        //                {
        //                    Text = "Поставщик: ",
        //                    ForegroundColor = IsSupplierInfoShort ? Color.Black : (Color)App.Current.Resources["main_action"]
        //                },
        //                new Span
        //                {
        //                    Text = IsSupplierInfoShort ? _product?.SupplierInfo : ShortSupplierInfo,
        //                    ForegroundColor = (Color)App.Current.Resources["blue_gray"]
        //                }
        //            }
        //        };
        //    }
        //}

        public string SupplierInfo
        {
            get
            {
                return IsSupplierInfoShort ? _product?.SupplierInfo : ShortSupplierInfo;
            }
        }

        private int _supplierInfoLimit { get; } = 40;

        public bool IsSupplierInfoShort
        {
            get
            {
                return _product?.SupplierInfo?.Split('\n')?.Length <= 2 && _product?.SupplierInfo?.Length <= _supplierInfoLimit;
            }
        }

        public string ShortSupplierInfo
        {
            get
            {
                string result = _product?.SupplierInfo;

                string[] splittedInfo = _product?.SupplierInfo?.Split('\n');

                if (splittedInfo?.Length > 2)
                {
                    result = string.Concat(splittedInfo[0], "\n", splittedInfo[1]);
                }
                
                if (result?.Length > _supplierInfoLimit)
                {
                    result = result.Substring(0, _supplierInfoLimit - 1);
                }

                return result;
            }
        }

        public ICommand SupplierInfoTapCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (IsSupplierInfoShort)
                    {
                        return;
                    }

                    await ServiceLocator.Current.GetInstance<IDialogService>().ShowMessage("Поставщик", _product?.SupplierInfo);
                });
            }
        }

        public Color SupplierInfoTitleColor
        {
            get
            {
                return IsSupplierInfoShort ? Color.Black : (Color)App.Current.Resources["main_action"];
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
                            Text = string.Format("{0} д{1}",
                                        (_product?.DeliveryTime ?? 0).ToString(),
                                        StringHelper.FormatEndingByInt(_product?.DeliveryTime ?? 0, "ень", "ня", "ней")),
                            ForegroundColor = (Color)App.Current.Resources["blue_gray"]
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
