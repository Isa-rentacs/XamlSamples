using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace App3
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private CoreDispatcher dispatcher;

        private Model model;
        public ViewModel() { }
        public ViewModel(double deltaX, double deltaY, double width, double height)
        {
            model = new Model(width, height);
            model.DeltaX = deltaX;
            model.DeltaY = deltaY;
            X = width;
            Y = height;
            model.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChangedDispatcher);
            dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
        }

        #region Properies
        private double _x;
        private double _y;
        public double X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
                dispatcher?.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("X"));
                    }
                });
            }
        }
        public double Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
                dispatcher?.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Y"));
                    }
                });
            }
        }
        #endregion

        public void OnPropertyChangedDispatcher(Object obj, PropertyChangedEventArgs args)
        {
            switch (args.PropertyName)
            {
                case "X":
                    X = model.X;
                    break;
                case "Y":
                    Y = model.Y;
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}
