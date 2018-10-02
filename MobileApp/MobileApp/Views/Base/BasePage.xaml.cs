using MobileApp.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views.Base
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BasePage : ContentPage
	{
		public BasePage()
		{
			InitializeComponent ();

            //NavigationPage.SetHasNavigationBar(this, false);
            //NavigationPage.SetBackButtonTitle(this, "");

            SetBinding(IsBusyProperty, new Binding("IsBusy"));
        }

        protected override bool OnBackButtonPressed()
        {
            var bindingContext = BindingContext as PageVM;

            bindingContext?.OnBackButtonPressed();

            return base.OnBackButtonPressed();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var bindingContext = BindingContext as PageVM;

            bindingContext?.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            var bindingContext = BindingContext as PageVM;

            bindingContext?.OnDisappearing();
        }
    }
}