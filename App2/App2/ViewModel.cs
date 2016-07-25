using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
namespace App2
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Model model;
        private CoreDispatcher dispatcher;
        public ViewModel(List<string> arg, int numChars)
        {
            model = new Model();
            model.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChangedDispatcher);
            _list = arg;
            NumChars = numChars;
            TextToRender = new string(model.CharToRendered, NumChars);
            dispatcher = Windows.UI.Core.CoreWindow.GetForCurrentThread().Dispatcher;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private List<string> _list;
        public List<String> List
        {
            get
            {
                return _list;
            }

            set
            {
                _list = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("List"));
            }
        }

        public int NumChars { get; set; }
        private string _textToRender;

        public string TextToRender
        {
            get
            {
                return _textToRender;
            }

            set
            {
                _textToRender = value;
            }
        }

        public string TextToRender2 { get; set; }

        private void OnPropertyChangedDispatcher(object obj, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "CharToRendered":
                    OnCharToRenderedChanged(obj, e);
                    break;
                default:
                    throw new Exception();
            }
        }

        private async void OnCharToRenderedChanged(object obj, PropertyChangedEventArgs e)
        {
            
            TextToRender = new string(model.CharToRendered, NumChars);
            await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => {
                PropertyChanged?.Invoke(obj, new PropertyChangedEventArgs("TextToRender"));
            });
        }
    }
}
