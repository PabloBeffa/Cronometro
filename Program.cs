using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cronometro
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            var app = new Application();
            app.Run(new MainWindow());
        }
    }

}
