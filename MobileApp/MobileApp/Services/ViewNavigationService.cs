using MobileApp.ExtendedViewControls;
using MobileApp.Models.Enums;
using MobileApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.Services
{
    public class ViewNavigationService : INavigationService
    {
        private readonly object _sync = new object();
        private readonly Dictionary<PageEnum, Type> _pagesByKey = new Dictionary<PageEnum, Type>();
        private readonly Stack<ExtendedNavigationPage> _navigationPageStack = new Stack<ExtendedNavigationPage>();
        private ExtendedNavigationPage CurrentNavigationPage => _navigationPageStack.Peek();

        public void Configure(PageEnum pageKey, Type pageType)
        {
            lock (_sync)
            {
                if (_pagesByKey.ContainsKey(pageKey))
                {
                    _pagesByKey[pageKey] = pageType;
                }
                else
                {
                    _pagesByKey.Add(pageKey, pageType);
                }
            }
        }

        public Page SetRootPage(PageEnum rootPageKey)
        {
            var rootPage = GetPage(rootPageKey);

            _navigationPageStack.Clear();

            var mainPage = new ExtendedNavigationPage(rootPage);

            _navigationPageStack.Push(mainPage);

            return mainPage;
        }

        public PageEnum CurrentPageKey
        {
            get
            {
                lock (_sync)
                {
                    if (CurrentNavigationPage?.CurrentPage == null)
                    {
                        return PageEnum.None;
                    }

                    var pageType = CurrentNavigationPage.CurrentPage.GetType();

                    return _pagesByKey.ContainsValue(pageType)
                        ? _pagesByKey.First(p => p.Value == pageType).Key
                        : PageEnum.None;
                }
            }
        }

        public async Task GoBack()
        {
            var navigationStack = CurrentNavigationPage.Navigation;

            if (navigationStack.NavigationStack.Count > 1)
            {
                await CurrentNavigationPage.PopAsync();

                return;
            }

            if (_navigationPageStack.Count > 1)
            {
                _navigationPageStack.Pop();
                await CurrentNavigationPage.Navigation.PopModalAsync();

                return;
            }

            await CurrentNavigationPage.PopAsync();
        }

        public async Task NavigateModalAsync(PageEnum pageKey, bool animated = true)
        {
            await NavigateModalAsync(pageKey, null, animated);
        }

        public async Task NavigateModalAsync(PageEnum pageKey, object parameter, bool animated = true)
        {
            var page = GetPage(pageKey, parameter);

            ExtendedNavigationPage.SetHasNavigationBar(page, false);

            var modalNavigationPage = new ExtendedNavigationPage(page);

            await CurrentNavigationPage.Navigation.PushModalAsync(modalNavigationPage, animated);

            _navigationPageStack.Push(modalNavigationPage);
        }

        public async Task NavigateAsync(PageEnum pageKey, bool animated = true)
        {
            await NavigateAsync(pageKey, null, animated);
        }

        public async Task NavigateAsync(PageEnum pageKey, object parameter, bool animated = true)
        {
            var page = GetPage(pageKey, parameter);

            await CurrentNavigationPage.Navigation.PushAsync(page, animated);
        }

        private Page GetPage(PageEnum pageKey, object parameter = null)
        {

            lock (_sync)
            {
                if (!_pagesByKey.ContainsKey(pageKey))
                {
                    throw new ArgumentException(
                        $"No such page: {pageKey}. Did you forget to call NavigationService.Configure?");
                }

                var type = _pagesByKey[pageKey];

                ConstructorInfo constructor;
                object[] parameters;

                if (parameter == null)
                {
                    constructor = type.GetTypeInfo()
                        .DeclaredConstructors
                        .FirstOrDefault(c => !c.GetParameters().Any());

                    parameters = new object[]
                    {
                    };
                }
                else
                {
                    constructor = type.GetTypeInfo()
                        .DeclaredConstructors
                        .FirstOrDefault(
                            c =>
                            {
                                var p = c.GetParameters();

                                return p.Length == 1
                                       && p[0].ParameterType == parameter.GetType();
                            });

                    parameters = new[]
                    {
                        parameter
                    };
                }

                if (constructor == null)
                {
                    throw new InvalidOperationException(
                        "No suitable constructor found for page " + pageKey);
                }

                var page = constructor?.Invoke(parameters) as Page;

                return page;
            }
        }
    }
}
