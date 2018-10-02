using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using MobileApp.Droid.CustomRenderers;
using MobileApp.ExtendedViewControls.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SearchPage), typeof(SearchPageRenderer))]
namespace MobileApp.Droid.CustomRenderers
{
    public class SearchPageRenderer : PageRenderer
    {
        private SearchView _searchView;

        public SearchPageRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null || e.OldElement != null)
            {
                return;
            }

            AddSearchToToolBar();
        }

        protected override void Dispose(bool disposing)
        {
            if (_searchView != null)
            {
                _searchView.QueryTextChange += searchView_QueryTextChange;
                _searchView.QueryTextSubmit += searchView_QueryTextSubmit;
            }

            MainActivity.Toolbar?.Menu?.RemoveItem(Resource.Menu.mainmenu);
            base.Dispose(disposing);
        }

        private void AddSearchToToolBar()
        {
            MainActivity.Toolbar = MainActivity.Current.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            if (MainActivity.Toolbar == null || Element == null)
            {
                return;
            }

            MainActivity.Toolbar.Title = Element?.Title;

            MainActivity.Toolbar.InflateMenu(Resource.Menu.mainmenu);

            var temp = MainActivity.Toolbar.Menu?.FindItem(Resource.Id.action_search);

            _searchView = MainActivity.Toolbar.Menu?.FindItem(Resource.Id.action_search)?.ActionView?.JavaCast<SearchView>();

            //_searchView.QueryTextChange += searchView_QueryTextChange;
            //_searchView.QueryTextSubmit += searchView_QueryTextSubmit;
            //_searchView.SetQueryHint((Element as SearchPage)?.SearchPlaceHolderText);
            //_searchView.SetImeOptions(ImeAction.Search);
            //_searchView.SetInputType(InputTypes.TextVariationNormal);
            //_searchView.SetMaxWidth(int.MaxValue);
        }

        private void searchView_QueryTextSubmit(object sender, SearchView.QueryTextSubmitEventArgs e)
        {
            var searchPage = Element as SearchPage;
            searchPage.SearchText = e.Query;
            searchPage.SearchCommand?.Execute(e.Query);
            e.Handled = true;
        }

        private void searchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            var searchPage = Element as SearchPage;
            searchPage.SearchText = e?.NewText;
        }
    }
}