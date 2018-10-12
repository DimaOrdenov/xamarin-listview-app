using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileApp.ExtendedViewControls
{
    public class ExtendedListView : ListView
    {
        public ExtendedListView() : base(ListViewCachingStrategy.RecycleElement)
        {
            ItemSelected += (sender, e) =>
            {
                (sender as ExtendedListView).SelectedItem = null;
            };
        }
    }
}
