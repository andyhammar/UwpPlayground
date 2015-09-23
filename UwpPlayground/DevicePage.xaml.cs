using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpPlayground
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DevicePage : Page
    {
        public DevicePage()
        {
            this.InitializeComponent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var frame = Window.Current.Content as Frame;
            if (frame == null)
            {
                frame = Frame;
                if (frame == null)
                    return;
            }

            var canGoBack = frame.CanGoBack;
            var appViewBackButtonVisibility = canGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                appViewBackButtonVisibility;

        }
    }
}
