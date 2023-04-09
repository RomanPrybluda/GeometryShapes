using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTest
{
    public class InputTrianglePerformer
    {

        public (double, double, double) PerformTriangleInput()
        {

            double triangleSide1, triangleSide2, triangleSide3;

            Console.Write(Messages.INPUT_TRIANGLE_FIRST_SIDE);
            while (!double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Float, CultureInfo.InvariantCulture, out triangleSide1) || triangleSide1 <= 0 || triangleSide1 > double.MaxValue)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" Input Error. Try again.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Messages.INPUT_TRIANGLE_FIRST_SIDE);
            }

            Console.Write(Messages.INPUT_TRIANGLE_SECOND_SIDE);
            while (!double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Float, CultureInfo.InvariantCulture, out triangleSide2) || triangleSide2 <= 0 || triangleSide2 > double.MaxValue)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" Input Error. Try again.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Messages.INPUT_TRIANGLE_SECOND_SIDE);
            }

            double minThirdSide = Math.Abs(triangleSide1 - triangleSide2);
            double maxThirdSide = triangleSide1 + triangleSide2;
            Console.WriteLine($"\n Thirt triangle side must be more than {minThirdSide:F2} mm and less than {maxThirdSide:F2} mm.");

            Console.Write(Messages.INPUT_TRIANGLE_THIRD_SIDE);
            while (!double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Float, CultureInfo.InvariantCulture, out triangleSide3) || triangleSide3 <= 0 || triangleSide3 > double.MaxValue
                || triangleSide3 < minThirdSide || triangleSide3 > maxThirdSide)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" Input Error. Try again.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Messages.INPUT_TRIANGLE_THIRD_SIDE);
            }

            return (triangleSide1, triangleSide2, triangleSide3);

        }

    }
}
