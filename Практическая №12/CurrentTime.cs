using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Практическая__12
{
    public class CurrentTime : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime _now;
        private DispatcherTimer _timer;

        public CurrentTime()
        {
            _now = DateTime.Now;

            _timer = new DispatcherTimer(TimeSpan.FromMilliseconds(1000), DispatcherPriority.Normal, (s, e) => Now = DateTime.Now, Application.Current.Dispatcher);
        }

        public DateTime Now
        {
            get { return _now; }
            private set
            {
                if (_now == value)
                    return;
                _now = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Now)));
            }
        }

        public TimeSpan UpdateInterval
        {
            get { return _timer.Interval; }
            set { _timer.Interval = value; }
        }
    }
}
