using System;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.Foundation.Collections;

namespace AppServiceLib
{
    public sealed class AppServiceTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            var appServiceTriggerDetails = taskInstance.TriggerDetails as AppServiceTriggerDetails;
            if (appServiceTriggerDetails.Name == "andyhammar-appServiceLib")
            {
                appServiceTriggerDetails.AppServiceConnection.RequestReceived += AppServiceConnection_RequestReceived;
            }
        }

        private async void AppServiceConnection_RequestReceived(
            AppServiceConnection sender, 
            AppServiceRequestReceivedEventArgs args)
        {
            var appServiceDeferral = args.GetDeferral();

            var msg = args.Request.Message;
            var cmd = msg["cmd"] as string;
            if (cmd == null) return;

            if (cmd == "time")
            {
                var result = new ValueSet {{"time", DateTime.Now.ToString("T")}};
                await args.Request.SendResponseAsync(result);
            }

            appServiceDeferral.Complete();
        }
    }
}
