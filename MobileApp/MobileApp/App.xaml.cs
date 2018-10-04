using Autofac;
using CommonServiceLocator;
using MobileApp.Models.Enums;
using MobileApp.Services.Interfaces;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ContentPage();
        }

        protected override void OnStart()
        {
            IoCInitializer.Initialize();

            ServiceLocator.Current.GetInstance<IAuthenticationService>().Authenticate("", "");

            IoCInitializer.SetMainPage(PageEnum.CatalogPage);
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
