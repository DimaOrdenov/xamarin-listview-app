using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ExtendedViewControls
{
    public class LoadMoreListView : ExtendedListView
    {
        public LoadMoreListView()
        {
            ItemAppearing += (sender, args) =>
            {
                IList items = ItemsSource as IList;

                if (items?.Count == 0 && args.Item != items[items.Count - 1] &&
                    LoadMoreCommand == null && !LoadMoreCommand.CanExecute(null))
                {
                    return;
                }

                LoadMoreCommand.Execute(null);
            };

            Footer = new StackLayout
            {
                Spacing = 0,
                Padding = 12,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Transparent,
                Children =
                {
                    new ActivityIndicator
                    {
                        IsRunning = true,
                        HeightRequest = 15,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Color = AppColor.MainAction
                    }
                }
            };
        }

        public static readonly BindableProperty LoadMoreCommandProperty = BindableProperty.Create(
            nameof(LoadMoreCommand),
            typeof(ICommand),
            typeof(LoadMoreListView),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: HandleLoadMoreCommandPropertyChanged
            );

        public ICommand LoadMoreCommand
        {
            get { return (ICommand)GetValue(LoadMoreCommandProperty); }
            set { SetValue(LoadMoreCommandProperty, value); }
        }

        private static void HandleLoadMoreCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is LoadMoreListView view)
            {
                view.LoadMoreCommand = (ICommand)newValue;
            }
        }
    }
}
