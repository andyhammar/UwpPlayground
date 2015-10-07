// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

using Windows.Devices.Power;
using Windows.UI.Xaml.Navigation;

namespace UwpPlayground
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BatteryPage
    {
        public BatteryPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var battery = Windows.Devices.Power.Battery.AggregateBattery;
            var report = battery.GetReport();
            _batteryTextBlock.Text = $"{report.Status},{report.ChargeRateInMilliwatts},{report.DesignCapacityInMilliwattHours},{report.FullChargeCapacityInMilliwattHours},{report.RemainingCapacityInMilliwattHours}";
        }
    }
}
