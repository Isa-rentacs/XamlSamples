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

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var stringList = new List<String>();
            for (int i = 0; i < 200; ++i)
            {
                stringList.Add("abdacadabla " + i.ToString());
            }
            //this.DataContext = new ViewModel(stringList, 0);
            customControl2.DataContext = new ViewModel(null, customControl2.NumChars);     
            customControl2b.DataContext = new ViewModel(null, customControl2b.NumChars);
            customControl2c.DataContext = new ViewModel(null, 10);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          
        }
    }
}
