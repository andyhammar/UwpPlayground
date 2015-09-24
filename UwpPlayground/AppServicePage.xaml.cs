// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.AppService;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using UwpPlayground.Annotations;

namespace UwpPlayground
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppServicePage : INotifyPropertyChanged
    {
        private string _appServiceResult;

        public AppServicePage()
        {
            this.InitializeComponent();
            DataContext = this;
        }

        public string AppServiceResult
        {
            get { return _appServiceResult; }
            set
            {
                _appServiceResult = value;
                OnPropertyChanged();

            }
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var connection = new AppServiceConnection
            {
                AppServiceName = "andyhammar-appServiceLib",
                PackageFamilyName = "3cdc12ed-94be-4768-ad67-6029b9dd2c5a_2eqywga5gg4gm"
            };
            var appServiceConnectionStatus = await connection.OpenAsync();
            if (appServiceConnectionStatus != AppServiceConnectionStatus.Success)
            {
                AppServiceResult = appServiceConnectionStatus.ToString();
                return;
            }

            var msg = new ValueSet {["cmd"] = "time" };
            var appServiceResponse = await connection.SendMessageAsync(msg);
            if (appServiceResponse.Status != AppServiceResponseStatus.Success)
            {
                AppServiceResult = appServiceResponse.ToString();
                return;
            }
            var time = appServiceResponse.Message["time"] as string;
            AppServiceResult = time;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
