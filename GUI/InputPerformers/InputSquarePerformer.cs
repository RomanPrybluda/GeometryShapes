using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTest
{
    public class InputSquarePerformer
    {

        public double PerformSquareInput()
        {
            double squareSide;

            Console.Write(Messages.INPUT_SQUARE_SIDE);

            while (!double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Float, CultureInfo.InvariantCulture, out squareSide) || squareSide <= 0 || squareSide > double.MaxValue)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" Input Error. Try again.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Messages.INPUT_SQUARE_SIDE);
            }

            return squareSide;
        }
    }
}
