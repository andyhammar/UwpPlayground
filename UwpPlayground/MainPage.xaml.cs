using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UwpPlayground
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            Debug.WriteLine("MainPage ctor");
            NavigationCacheMode = NavigationCacheMode.Required;

            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(320, 500));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var canGoBack = Frame.CanGoBack;
            var appViewBackButtonVisibility = canGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                appViewBackButtonVisibility;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var pageName = button?.Content as string;
            var ns = this.GetType().Namespace;
            Frame.Navigate(Type.GetType(ns + "." + pageName), null);
        }
    }
}
