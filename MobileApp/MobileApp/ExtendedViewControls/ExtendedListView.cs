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
            HasUnevenRows = true;

            SeparatorVisibility = SeparatorVisibility.None;

            ItemSelected += (sender, e) =>
            {
                (sender as ExtendedListView).SelectedItem = null;
            };
        }
    }
}
