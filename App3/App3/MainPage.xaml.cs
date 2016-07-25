using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ellipse_Loaded(object sender, RoutedEventArgs e)
        {
            var ellipseObj = (Windows.UI.Xaml.Shapes.Ellipse)sender;
            if (ellipseObj.Name == "ellipse")
            {
                ellipseObj.DataContext = new ViewModel(0.004, 0.004, ellipseObj.ActualWidth, ellipseObj.ActualHeight);
            }
            else
            {
                ellipseObj.DataContext = new ViewModel(0.005, 0.007, ellipseObj.ActualWidth, ellipseObj.ActualHeight);
            }
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var grid = (Windows.UI.Xaml.Controls.Grid)sender;
            ellipse.DataContext = new ViewModel(0.004, 0.004, e.NewSize.Width, e.NewSize.Height / 2);
            ellipse2.DataContext = new ViewModel(0.005, 0.007, e.NewSize.Width, e.NewSize.Height / 2);
        }
    }
}
