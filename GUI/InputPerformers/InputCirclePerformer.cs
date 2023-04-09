using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GeometryShapes.GUI.InputPerformers
{
    public class InputCirclePerformer
    {

        public double PerformCircleInput()
        {
            double circleRadius;

            Console.Write(Messages.INPUT_CIRCUT_RADIUS);

            while (!double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Float, CultureInfo.InvariantCulture, out circleRadius) || circleRadius <= 0 || circleRadius > double.MaxValue)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" Input Error. Try again.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Messages.INPUT_CIRCUT_RADIUS);
            }

            return circleRadius;
        }
    }
}
