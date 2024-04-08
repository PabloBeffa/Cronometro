using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronometro
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ICronometro _cronometro;
        private string _timeHours;
        private string _timeMinutes;
        private string _timeSeconds;

        public string TimeHours
        {
            get { return _timeHours; }
            set { _timeHours = value; OnPropertyChanged("TimeHours"); }
        }
        public string TimeMinutes
        {
            get { return _timeMinutes; }
            set { _timeMinutes = value; OnPropertyChanged("TimeMinutes"); }
        }
        public string TimeSeconds
        {
            get { return _timeSeconds; }
            set { _timeSeconds = value; OnPropertyChanged("TimeSeconds"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public RelayCommand StartCommand { get; }
        public RelayCommand PauseCommand { get; }
        public RelayCommand StopCommand { get; }

        public MainViewModel(ICronometro cronometro)
        {
            _cronometro = cronometro;
            if (_cronometro != null)
            {
                _cronometro.TimeActualice += ActualiceTime;
            }
            StartCommand = new RelayCommand(() =>
            {
                if (!_cronometro.IsRunning)
                {
                    _cronometro.Start();
                }
            },
       () => !_cronometro.IsRunning);


            PauseCommand = new RelayCommand(
       () =>
       {
           if (_cronometro.IsRunning)
           {
               _cronometro.Pause();
           }
       },
       () => _cronometro.IsRunning);

            StopCommand = new RelayCommand(
                () =>
                {

                    _cronometro.Stop();

                },
                () => _cronometro.IsRunning || _cronometro.IsPaused);

        }

        private void ActualiceTime(object sender, EventArgs e)
        {
            TimeHours = _cronometro.TimeSpan.Hours.ToString("00");
            TimeMinutes = _cronometro.TimeSpan.Minutes.ToString("00");
            TimeSeconds = _cronometro.TimeSpan.Seconds.ToString("00");
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
