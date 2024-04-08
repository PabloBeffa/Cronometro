using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronometro
{
    public interface ICronometro
    {
        bool IsRunning { get; }
        bool IsPaused { get; }
        TimeSpan TimeSpan { get; }

        event EventHandler TimeActualice;

        void Start();
        void Pause();
        void Stop();


    }
}
