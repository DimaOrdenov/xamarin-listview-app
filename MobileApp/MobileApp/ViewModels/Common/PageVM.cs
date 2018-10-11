using MobileApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.ViewModels.Common
{
    public class PageVM : BaseVM
    {
        private bool _isLoading = false;
        private bool _isBusy = false;
        private readonly CancellationTokenSource _networkTokenSource = new CancellationTokenSource();

        protected INavigationService NavigationService;
        protected IDialogService DialogService;

        public PageVM(INavigationService navigationService, IDialogService dialogService)
        {
            // Always start with loading animation
            IsLoading = true;

            NavigationService = navigationService;
            DialogService = dialogService;
        }

        ~PageVM()
        {
            Dispose(false);
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

        public CancellationToken CancellationToken => _networkTokenSource?.Token ?? CancellationToken.None;

        public void CancelNetworkRequests()
        {
            _networkTokenSource.Cancel();
        }

        public virtual void OnAppearing()
        {
            IsLoading = true;
        }

        public virtual void OnDisappearing() { }

        protected virtual void Dispose(bool disposing)
        {
            DialogService.CloseAllDialogs();
            CancelNetworkRequests();
        }

        public virtual void OnBackButtonPressed() { }

        public virtual void OnPopped(Page page) { }

        public virtual Task OnNavigated(object parameter)
        {
            return Task.Run(() => { });
        }
    }
}
