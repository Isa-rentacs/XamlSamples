using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace App2
{
    public class CustomControl2 : Windows.UI.Xaml.Controls.Control
    {
        public CustomControl2()
        {
        }
        
        public static readonly DependencyProperty TextToRenderProperty = DependencyProperty.Register("TextToRender", typeof(string), typeof(CustomControl2), PropertyMetadata.Create("not init", new PropertyChangedCallback(OnTextToRenderChanged)));

        private static void OnTextToRenderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            string str;
            CustomControl2 control = d as CustomControl2;
            if (control != null)
            {
                string text = control.TextToRender;
                if ((str = e.NewValue as string) != null)
                {
                    control.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                     {
                         var textBox = (control.GetTemplateChild("TextBlock2")) as Windows.UI.Xaml.Controls.TextBlock;
                         if(textBox != null)
                         { 
                             textBox.Text = str;
                         }
                     });
                }
            }
        }

        public string TextToRender
        {
            get { return (string)GetValue(TextToRenderProperty); }
            set { SetValue(TextToRenderProperty, value);}
        }
        
        public int NumChars { get; set; }

        
    }
}
