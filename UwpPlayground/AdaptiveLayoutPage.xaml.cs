using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using UwpPlayground.Annotations;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpPlayground
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdaptiveLayoutPage : Page, INotifyPropertyChanged
    {
        private string _redText;
        public object ColorVmis { get; set; }

        public string RedText
        {
            get { return _redText; }
            set { _redText = value; OnPropertyChanged();}
        }

        public AdaptiveLayoutPage()
        {
            this.InitializeComponent();

            RedText = "first red text";

            
            var colors = typeof (Colors).GetProperties().ToList();
            var systemColors = colors.Select(x => new { x.Name, Brush = new SolidColorBrush((Color)x.GetValue(x)) }).ToList();

            var allColors = new List<object>();
            for (byte i = 0; i <= 254; i = (byte)Math.Min(255, i + 10))
            {
                for (byte j = 0; j <= 254; j = (byte)Math.Min(255, j + 10))
                {
                    for (byte k = 0; k <= 254; k = (byte)Math.Min(255, k + 10))
                    {
                        var color = new {Name=$"{i},{j},{k}", Brush=new SolidColorBrush(Color.FromArgb(255, i, j, k))};
                        allColors.Add(color);
                    }
                }
            }

            ColorVmis = allColors;

            DataContext = this;
        }


        private void BlueBorder_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            RedText = "blueborder was tapped";

            try
            {
                Debug.WriteLine(wideOnlyList.ActualHeight);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
        }

        private void RedBorder_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            RedText = "redborder was tapped";
        }

        private void RelativePanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            
            //RedText = "relpanel was tapped";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            
            UpdateRedText();
        }

        private void Button2_OnClick(object sender, RoutedEventArgs e)
        {
            UpdateRedText();
        }

        private void UpdateRedText([CallerMemberName]string sender = null)
        {
            RedText = sender;
        }

        private void SuspendingBindingsButton_OnClick(object sender, RoutedEventArgs e)
        {
            Bindings.StopTracking();
        }

        private void ResumeBindingsButton_OnClick(object sender, RoutedEventArgs e)
        {
            Bindings.Update();
        }
    }
}
