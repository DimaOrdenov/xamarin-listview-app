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
using MobileApp.Core.Helpers;
using MobileApp.Droid.CustomRenderers;
using MobileApp.ExtendedViewControls.Pages;
using Plugin.CurrentActivity;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using SearchView = Android.Support.V7.Widget.SearchView;

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

            var mainToolbar = (CrossCurrentActivity.Current?.Activity as MainActivity)?.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            mainToolbar.Menu?.RemoveItem(Resource.Menu.mainmenu);

            base.Dispose(disposing);
        }

        private void AddSearchToToolBar()
        {
            var search = Element as SearchPage;
            var searchTextTemp = string.Empty;

            if (search.SearchText != null)
            {
                searchTextTemp = search.SearchText;
            }

            var mainToolbar = (CrossCurrentActivity.Current?.Activity as MainActivity)?.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            if (mainToolbar == null || Element == null)
            {
                return;
            }

            mainToolbar.Title = Element.Title;
            mainToolbar.InflateMenu(Resource.Menu.mainmenu);
            mainToolbar.NavigationClick += (sender, args) =>
            {
                DebugHelper.Log("NavigationClick");
                DebugHelper.Log(sender);
                DebugHelper.Log(args);
            };

            var actionSearch = Resource.Id.action_search;

            _searchView = mainToolbar.Menu?.FindItem(Resource.Id.action_search)?.ActionView?.JavaCast<SearchView>();

            if (_searchView == null)
            {
                return;
            }

            //default open but has a debug make searchview hasnot cursor
            // _searchView.OnActionViewExpanded();
            //_searchView.SetBackgroundColor(Android.Graphics.Color.Green);
            //_searchView.SetIconifiedByDefault(false);

            //_searchView.SetBackgroundColor(Android.Graphics.Color.White);

            _searchView.QueryTextChange += searchView_QueryTextChange;
            _searchView.QueryTextSubmit += searchView_QueryTextSubmit;

            _searchView.QueryHint = (Element as SearchPage)?.SearchPlaceHolderText;
            _searchView.ImeOptions = (int)ImeAction.Search;
            // donn't use this code it make the cursor miss
            //_searchView.InputType = (int)InputTypes.TextVariationNormal;
            _searchView.MaxWidth = int.MaxValue;
        }

        private void searchView_QueryTextSubmit(object sender, SearchView.QueryTextSubmitEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            var searchPage = Element as SearchPage;

            if (searchPage == null)
            {
                return;
            }

            searchPage.SearchText = e.Query;
            searchPage.SearchCommand?.Execute(e.Query);
            e.Handled = true;
        }

        private void searchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            var searchPage = Element as SearchPage;

            if (searchPage == null)
            {
                return;
            }

            searchPage.SearchText = e?.NewText;
        }

        private class OnCloseListener : Java.Lang.Object, SearchView.IOnCloseListener
        {
            public bool OnClose()
            {
                DebugHelper.Log("SearchViewClosed");

                return true;
            }
        }
    }
}