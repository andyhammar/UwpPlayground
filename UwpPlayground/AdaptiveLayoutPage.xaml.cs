using System;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpPlayground
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdaptiveLayoutPage : Page
    {
        public AdaptiveLayoutPage()
        {
            this.InitializeComponent();
        }

        private void wideOnlyButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void BlueBorder_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                Debug.WriteLine(wideOnlyButton.Content);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
        }
    }
}
