using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Windows.System.Threading;
using System.Threading.Tasks;

namespace App2
{
    public class Model : INotifyPropertyChanged
    {
        private char _charToRendered;
        private TimeSpan _period = TimeSpan.FromMilliseconds(3000);
        private ThreadPoolTimer _periodicTimer;
        private Object _lockObject;
        public event PropertyChangedEventHandler PropertyChanged;

        public char CharToRendered
        {
            get
            {
                return _charToRendered;
            }

            set
            {
                _charToRendered = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CharToRendered"));
            }
        }

        public Model()
        {
            _lockObject = new Object();
            _charToRendered = 'a';
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CharToRendered"));
            _periodicTimer = ThreadPoolTimer.CreatePeriodicTimer((source) =>
            {
                lock (_lockObject)
                {
                    _charToRendered = (char)(_charToRendered + 1);
                    if (_charToRendered > 'z')
                    {
                        _charToRendered = 'a';
                    }
                }

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CharToRendered"));
            }, _period);
        }
    }
}
