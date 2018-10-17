using MobileApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.ViewModels.Common
{
    public class PaginationPageVM : PageVM
    {
        private int _page;

        private int _limit;

        private bool _isMoreLoading;

        public PaginationPageVM(INavigationService navigationService, IDialogService dialogService) : base(navigationService, dialogService) { }

        public int Page
        {
            get { return _page; }
            set
            {
                _page = value;
                OnPropertyChanged();
            }
        }

        public int Limit
        {
            get { return _limit; }
            set
            {
                _limit = value;
                OnPropertyChanged();
            }
        }

        public bool IsMoreLoading
        {
            get { return _isMoreLoading; }
            set
            {
                _isMoreLoading = value;
                OnPropertyChanged();
            }
        }
    }
}
