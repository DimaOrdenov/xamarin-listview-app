using MobileApp.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileApp.ExtendedViewControls
{
    public class ExtendedNavigationPage : NavigationPage
    {
        public ExtendedNavigationPage()
        {
            Init();
        }

        public ExtendedNavigationPage(Page rootPage) : base(rootPage)
        {
            Init();
        }

        private void Init()
        {
            Popped += (object sender, NavigationEventArgs e) =>
            {
                if (e.Page != null)
                {
                    var viewModel = e.Page.BindingContext as PageVM;

                    if (viewModel != null)
                    {
                        viewModel.OnPopped(e.Page);
                    }

                    e.Page.BindingContext = null;

                    if (e.Page.ToolbarItems != null)
                    {
                        e.Page.ToolbarItems.Clear();
                    }
                }
            };
        }
    }
}
