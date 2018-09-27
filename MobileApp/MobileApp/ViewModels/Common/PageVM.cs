using MobileApp.Interfaces;
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

        public PageVM(INavigationService navigationService) : base(navigationService)
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
                OnPropertyChanged();
            }
        }

        public virtual void Subscribe() { }

        public virtual void OnAppearing() { }

        public virtual void OnDisappearing() { }

        public virtual void OnBackButtonPressed() { }

        public virtual void OnPopped(Page page) { }

        public virtual Task OnNavigated(object parameter)
        {
            return Task.Run(() => { });
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
    }
}
