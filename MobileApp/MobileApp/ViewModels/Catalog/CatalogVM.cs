using MobileApp.Models;
using MobileApp.ViewModels.Common;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MobileApp.Core.Helpers;
using MobileApp.Repository;
using MobileApp.Repository.Interfaces;
using MobileApp.Services.Interfaces;

namespace MobileApp.ViewModels.Catalog
{
    public class CatalogVM : PageVM
    {
        private IProductsRepository _productsRepository { get; }

        private ObservableCollection<CatalogItemVM> _catalogItems { get; set; }
        private ObservableCollection<CatalogItemVM> _catalogItemsLoaded { get; set; }
        private string _searchProductText { get; set; }

        public CatalogVM(INavigationService navigationService, IProductsRepository productsRepository) : base(navigationService)
        {
            _productsRepository = productsRepository;
        }

        public ObservableCollection<CatalogItemVM> CatalogItems
        {
            get { return _catalogItems; }
            set
            {
                _catalogItems = value;

                OnPropertyChanged();
            }
        }

        public string SearchProductText
        {
            get { return _searchProductText; }
            set
            {
                _searchProductText = value;
                OnPropertyChanged();

                SearchProductCommand?.Execute(value);
            }
        }

        public ICommand SearchProductCommand
        {
            get
            {
                return new Command<string>(async (obj) =>
                {
                    IsLoading = true;

                    DebugHelper.Log(obj);

                    //if (string.IsNullOrEmpty(obj))
                    //{
                    //    CatalogItems = _catalogItemsLoaded.Clone();
                    //}
                    //else
                    //{
                    //    CatalogItems = new ObservableCollection<CatalogItemVM>(_catalogItemsLoaded?.Where(product =>
                    //        product.Product?.Title?.ToLower()?.Contains(obj) == true ||
                    //        product.Product?.Description?.ToLower()?.Contains(obj) == true)
                    //        ?? new List<CatalogItemVM>());
                    //}

                    //CatalogItems = new ObservableCollection<CatalogItemVM>(_catalogItemsLoaded?.Where(product =>
                    //        product.Product?.Title?.ToLower()?.Contains(obj) == true ||
                    //        product.Product?.Description?.ToLower()?.Contains(obj) == true)
                    //        ?? new List<CatalogItemVM>());

                    Dictionary<string, string> filters = new Dictionary<string, string> { { "q", obj } };

                    CatalogItems = new ObservableCollection<CatalogItemVM>(
                        (await _productsRepository.SearchProductList(filters: filters))?
                            .Value?
                            .Select(x =>
                            {
                                var vm = App.VMLocator.CatalogItemViewModel;
                                vm.Product = x;

                                return vm;
                            })
                        ?? new List<CatalogItemVM>());

                    
                    IsLoading = false;
                });
            }
        }

        public override void OnAppearing()
        {
            base.OnAppearing();

            LoadData().ContinueWith((task) =>
            {
                IsLoading = false;
            });
        }

        private async Task LoadData()
        {
            IsLoading = true;

            // await loading ...
            await Task.Run(async () =>
            {
                _catalogItemsLoaded = new ObservableCollection<CatalogItemVM>(
                        (await _productsRepository.GetProductList()).Value.Select(x => new CatalogItemVM() { Product = x }));

                CatalogItems = _catalogItemsLoaded;

                IsLoading = false;
            });

            // Simulate loading
            //await Task.Delay(3000).ContinueWith(async (t) =>
            //{
            //    Product mockProduct1 = new Product
            //    {
            //        ImageUri = new Uri("https://www.howarth-timber.co.uk/assets/img/placeholders/product--preview.png"),
            //        Title = "Название продукта",
            //        Description = "Описание продукта. Описание продукта. Описание продукта. Описание продукта. Описание продукта. ",
            //        MainPrice = "10000 р.",
            //        SubPrice = "8000 р."
            //    };

            //    Product mockProduct2 = new Product
            //    {
            //        ImageUri = new Uri("https://cdn.pcpartpicker.com/static/forever/images/product/50a1c28ab7d844fe91f03602bba66217.256p.jpg"),
            //        Title = "Название продукта",
            //        Description = "Описание продукта. Описание продукта. Описание продукта. Описание продукта. Описание продукта. ",
            //        MainPrice = "10000 р.",
            //        SubPrice = "8000 р."
            //    };

            //    _catalogItemsLoaded = new ObservableCollection<CatalogItemVM>
            //    {
            //        new CatalogItemVM { Product = mockProduct1 },
            //    };

            //    CatalogItems = _catalogItemsLoaded;

            //    IsLoading = false;
            //});
        }
    }
}
