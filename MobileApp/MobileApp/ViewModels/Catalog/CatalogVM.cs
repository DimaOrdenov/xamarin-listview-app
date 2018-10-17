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
using Xamarin.Forms.Internals;
using System.Collections.Specialized;

namespace MobileApp.ViewModels.Catalog
{
    public class CatalogVM : PaginationPageVM
    {
        private IProductsRepository _productsRepository { get; }

        private ObservableCollection<CatalogItemVM> _catalogItems { get; set; }
        private ObservableCollection<CatalogItemVM> _catalogItemsLoaded { get; set; }
        private string _searchProductText { get; set; }

        public CatalogVM(INavigationService navigationService, IDialogService dialogService, IProductsRepository productsRepository) :
            base(navigationService, dialogService)
        {
            _productsRepository = productsRepository;
        }

        private void CatalogItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(CatalogItems));
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

            Page = 1;
            Limit = 10;

            LoadData().ContinueWith((task) =>
            {
                CatalogItems.CollectionChanged += CatalogItems_CollectionChanged;
                Page++;

                IsLoading = false;
            });
        }

        public override void OnDisappearing()
        {
            base.OnDisappearing();

            CatalogItems.CollectionChanged -= CatalogItems_CollectionChanged;
        }

        private async Task LoadData()
        {
            await Task.Run(async () =>
            {
                IsLoading = true;

                Dictionary<string, string> requestParameters = new Dictionary<string, string>
                {
                    { "page", Page.ToString() },
                    { "limit", Limit.ToString() }
                };

                _catalogItemsLoaded = new ObservableCollection<CatalogItemVM>(
                        (await _productsRepository.GetProductList(requestParameters)).Value.Select(x => new CatalogItemVM() { Product = x }));

                CatalogItems = _catalogItemsLoaded;

                IsLoading = false;
            }, CancellationToken);
        }

        public ICommand LoadMoreCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsMoreLoading = true;

                    Dictionary<string, string> requestParameters = new Dictionary<string, string>
                    {
                        { "page", Page.ToString() },
                        { "limit", Limit.ToString() }
                    };

                    _catalogItemsLoaded = new ObservableCollection<CatalogItemVM>(
                            (await _productsRepository.GetProductList(requestParameters)).Value.Select(x => new CatalogItemVM() { Product = x }));

                    _catalogItemsLoaded.ForEach(x => CatalogItems.Add(x));

                    Page++;

                    IsLoading = false;

                    IsMoreLoading = false;
                });
            }
        }
    }
}
