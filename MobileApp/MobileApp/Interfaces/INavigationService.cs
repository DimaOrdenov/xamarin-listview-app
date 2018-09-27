using MobileApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Interfaces
{
    public interface INavigationService
    {
        PageEnum CurrentPageKey { get; }

        void Configure(PageEnum pageKey, Type pageType);
        Task GoBack();
        Task NavigateModalAsync(PageEnum pageKey, bool animated = true);
        Task NavigateModalAsync(PageEnum pageKey, object parameter, bool animated = true);
        Task NavigateAsync(PageEnum pageKey, bool animated = true);
        Task NavigateAsync(PageEnum pageKey, object parameter, bool animated = true);
    }
}
