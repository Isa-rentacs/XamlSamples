using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.System.Threading;

namespace App3
{
    public class Model : INotifyPropertyChanged
    {
        private TimeSpan _period = TimeSpan.FromMilliseconds(10);
        private ThreadPoolTimer _periodicTimer;
        private Object _lockObject;
        private double _widthRad = 0;
        private double _heightRad = 0;
        private double _baseX;
        private double _baseY;
        public double DeltaY { get; set; }

        public double DeltaX { get; set; }
        public Model(double width, double height)
        {
            _baseX = width;
            _baseY = height;
            
            _lockObject = new object();
            _periodicTimer = ThreadPoolTimer.CreatePeriodicTimer(x => 
            {
                lock (_lockObject)
                {
                    _widthRad += DeltaX;
                    _heightRad += DeltaY;
                    X = _baseX * Math.Abs(Math.Cos(_widthRad)); 
                    Y = _baseY * Math.Abs(Math.Cos(_heightRad));
                }
            }, _period);
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("X"));
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Y"));
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
