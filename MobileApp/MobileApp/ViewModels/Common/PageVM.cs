using MobileApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.ViewModels.Common
{
    public class PageVM : BaseVM
    {
        private bool _isLoading = false;
        private bool _isBusy = false;

        protected INavigationService NavigationService;

        public PageVM(INavigationService navigationService)
        {
            // Always start with loading animation
            IsLoading = true;
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                IsBusy = value;

                OnPropertyChanged();
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public virtual void OnAppearing()
        {
            IsLoading = true;
        }

        public virtual void OnDisappearing() { }

        public virtual void OnBackButtonPressed() { }

        public virtual void OnPopped(Page page) { }

        public virtual Task OnNavigated(object parameter)
        {
            return Task.Run(() => { });
        }
    }
}
