using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace App5
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel() { }

        private string _innerText;
        public string InnerText {
            get
            {
                return _innerText;
            }

            set
            {
                _innerText = value;
                OnPropertyChange("InnerText");
            }
        }

        private string _selectedText;

        public event PropertyChangedEventHandler PropertyChanged;

        public string SelectedText
        {
            get
            {
                return _selectedText;
            }

            set
            {
                _selectedText = value;
                OnPropertyChange("SelectedText");
            }
        }

        private void OnPropertyChange(string param)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(param));
        }
    }
}
