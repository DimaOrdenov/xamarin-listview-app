using MobileApp.ExtendedViewControls;
using MobileApp.ExtendedViewControls.Pages;
using MobileApp.Views.Base;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views.Catalog
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatalogPage : SearchPage
    {
        public CatalogPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
