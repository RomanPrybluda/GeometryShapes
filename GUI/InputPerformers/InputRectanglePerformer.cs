using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTest
{
    public class InputRectanglePerformer
    {

        public (double, double) PerformRectangleInput()
        {
            double rectangleSide1, rectangleSide2;

            Console.Write(Messages.INPUT_RECTANGLE_FIRST_SIDE);

            while (!double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Float, CultureInfo.InvariantCulture, out rectangleSide1) || rectangleSide1 <= 0 || rectangleSide1 > double.MaxValue)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" Input Error. Try again.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Messages.INPUT_RECTANGLE_FIRST_SIDE);
            }

            Console.Write(Messages.INPUT_RECTANGLE_SECOND_SIDE);

            while (!double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Float, CultureInfo.InvariantCulture, out rectangleSide2) || rectangleSide2 <= 0 || rectangleSide2 > double.MaxValue)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" Input Error. Try again.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Messages.INPUT_RECTANGLE_SECOND_SIDE);
            }

            return (rectangleSide1, rectangleSide2);
        }

    }
}
