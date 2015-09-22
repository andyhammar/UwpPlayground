using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpPlayground
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdaptiveLayoutPage : Page
    {
        private readonly List<PropertyInfo> _colors;
        public object ColorVmis { get; set; }

        public AdaptiveLayoutPage()
        {
            this.InitializeComponent();

            _colors = typeof (Colors).GetProperties().ToList();
            ColorVmis = _colors.Select(x => new {x.Name, Brush = new SolidColorBrush((Color)x.GetValue(x))}).ToList();
            
            DataContext = this;
        }


        private void BlueBorder_OnTapped(object sender, TappedRoutedEventArgs e)
        {
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
            
        }
    }
}
