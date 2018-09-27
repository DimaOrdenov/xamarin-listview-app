using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ExtendedViewControls
{
    public class ExtendedSearchBar : SearchBar
    {
        public ExtendedSearchBar() : base()
        {
            Placeholder = "Поиск";
        }
    }
}
