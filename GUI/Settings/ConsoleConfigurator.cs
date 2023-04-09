using GeometryShapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryShapes
{
    public class ConsoleConfigurator
    {
        public ConsoleConfigurator(ConsoleSettings settings)
        {
            Console.BackgroundColor = settings.BackgroundColor;
            Console.ForegroundColor = settings.ForegroundColor;
            Console.Title = settings.Title;
            Console.WindowWidth = settings.WindowWidth;
        }
    }
}
