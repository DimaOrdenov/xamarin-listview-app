using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using MobileApp.Interfaces;
using MobileApp.Models.Enums;
using MobileApp.Repository;
using MobileApp.Repository.Interfaces;
using MobileApp.Services;
using MobileApp.ViewModels.Catalog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp
{
    public sealed class IoCInitializer
    {
        private static ContainerBuilder _builder;
        private static INavigationService _navigationService;

        public static void Initialize()
        {
            _builder = new ContainerBuilder();

            InitServices();
            InitRepositories();
            InitViewModels();

            IContainer container = _builder.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));

            _navigationService = ServiceLocator.Current.GetInstance<INavigationService>();

            InitPages();
        }

        private static void InitServices()
        {
            _builder.RegisterType<ViewNavigationService>().As<INavigationService>();
        }

        private static void InitRepositories()
        {
            _builder.RegisterType<ProductsRepository>().As<IProductsRepository>();
        }

        private static void InitViewModels()
        {
            _builder.RegisterType<CatalogVM>().AsSelf();
            _builder.RegisterType<CatalogItemVM>().AsSelf();
        }

        private static void InitPages()
        {
            _navigationService.Configure(PageEnum.CatalogPage, typeof(Views.Catalog.CatalogPage));
        }
        
        public static void SetMainPage(PageEnum pageKey)
        {
            App.Current.MainPage = _navigationService.SetRootPage(pageKey);
        }
    }
}
