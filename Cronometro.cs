using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Cronometro
{
    public class Cronometro : ICronometro
    {
        private readonly System.Timers.Timer _timer;
        private bool _isRunning;
        private bool _isPaused;
        private DateTime _start;
        private TimeSpan _timeSpan;


        public TimeSpan TimeSpan => _timeSpan;
        public bool IsRunning => _isRunning;
        public bool IsPaused => _isPaused;

        public event EventHandler TimeActualice;
        public Cronometro()
        {
            _timer = new System.Timers.Timer(5);
            _timer.Elapsed += TimerElapsed;
        }
        public void Start()
        {
            if (!_isRunning)
            {
                _start = DateTime.Now - _timeSpan;
                _timer.Start();
                _isRunning = true;
                _isPaused = false;
            }
        }
        public void Stop()
        {
            _timer.Stop();
            _timeSpan = TimeSpan.Zero;
            _isRunning = false;
            _isPaused = false;
            TimeActualice?.Invoke(this, EventArgs.Empty);
        }
        public void Pause()
        {
            if (_isRunning)
            {
                _timer.Stop();
                _isRunning = false;
                _isPaused = true;
            }
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (sender != null)
            {
                _timeSpan = DateTime.Now - _start;
                TimeActualice?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
