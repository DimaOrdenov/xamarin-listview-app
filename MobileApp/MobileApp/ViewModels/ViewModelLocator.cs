using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            Bootstrapper.Initialize();
        }

        public MainPageViewModel Main
        {
            get { return ServiceLocator.Current.GetInstance<MainPageViewModel>(); }
        }
    }
}
