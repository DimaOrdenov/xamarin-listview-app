using Autofac;
using MobileApp.Interfaces;
using MobileApp.Models.Enums;
using MobileApp.Repository;
using MobileApp.Repository.Interfaces;
using MobileApp.Services;
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

            IoCInitializer.SetMainPage(PageEnum.CatalogPage);
            // Handle when your app starts
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
