using CommonServiceLocator;
using MobileApp.ViewModels.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            Core.Helpers.DebugHelper.Log("Initialized VM locator");
        }

        public CatalogVM CatalogViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CatalogVM>();
            }
        }

        public CatalogItemVM CatalogItemViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CatalogItemVM>();
            }
        }
    }
}
