// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

using System;
using Windows.Foundation;
using Windows.UI.Notifications;
using Windows.UI.StartScreen;
using Windows.UI.Xaml;
using NotificationsExtensions.Tiles;

namespace UwpPlayground
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TilePage
    {
        public TilePage()
        {
            this.InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var secondaryTile = new SecondaryTile(
                "tilePage",
                "shortname",
                "displayname",
                new Uri("ms-appx:///Assets/StoreLogo.png", UriKind.Absolute),
                TileSize.Default);
            var success = await secondaryTile.RequestCreateAsync();
            if (success)
            {
                var tileBindingContentAdaptive = new TileBindingContentAdaptive
                {
                    Children =
                    {
                        new TileText
                        {
                            Text = "uwp tiles",
                            Style = TileTextStyle.Header
                        },
                        new TileText
                        {
                            Text = "secondary",
                            Style = TileTextStyle.Body
                        }
                    }
                };
                var tileBinding = new TileBinding
                {
                    Branding = TileBranding.Name,
                    Content = tileBindingContentAdaptive,
                    DisplayName = "my tile"
                };

                var tileContent = new TileContent
                {
                    Visual = new TileVisual
                    {
                        TileMedium = tileBinding,
                        TileWide = tileBinding,
                        TileLarge = tileBinding
                    }
                };

                var xmlDoc = tileContent.GetXml();


                TileNotification tileNotification = new TileNotification(xmlDoc);
                var tileUpdaterForSecondaryTile = TileUpdateManager.CreateTileUpdaterForSecondaryTile("tilePage");
                tileUpdaterForSecondaryTile.Update(tileNotification);   
            }

        }
    }
}
