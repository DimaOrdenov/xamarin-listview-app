using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using MobileApp.Models.Enums;
using MobileApp.Repository;
using MobileApp.Repository.Interfaces;
using MobileApp.Services;
using MobileApp.Services.Interfaces;
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

            InitRepositoriesWithAuth();
            InitPages();
        }

        private static void InitServices()
        {
            _builder.RegisterType<ViewNavigationService>().As<INavigationService>().SingleInstance();
            _builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();
            _builder.RegisterType<DialogService>().As<IDialogService>().SingleInstance();
        }

        private static void InitRepositories()
        {
            _builder.RegisterType<AuthenticationRepository>().As<IAuthenticationRepository>().SingleInstance();
            _builder.RegisterType<ProductsRepository>().As<IProductsRepository>().SingleInstance();
        }

        private static void InitRepositoriesWithAuth()
        {
            IAuthenticationService _authenticationService = ServiceLocator.Current.GetInstance<IAuthenticationService>();

            _authenticationService.InjectAuthorization(ServiceLocator.Current.GetInstance<IProductsRepository>());

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
