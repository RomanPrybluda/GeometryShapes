using Newtonsoft.Json.Linq;
using System;


namespace GeometryTest
{
    public class ValidatorTriangle
    {

        public void ToValidateTriangle(DataManager dm)
        {
            bool isValid = false;
            double triangleSide1, triangleSide2, triangleSide3;

            Console.Write(Massage.INPUT_TRIANGLE_FIRST_SIDE);
            while (!double.TryParse(Console.ReadLine(), out triangleSide1)|| triangleSide1 <= 0 || triangleSide1 > double.MaxValue)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(Massage.INPUT_NUMBER);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Massage.INPUT_TRIANGLE_FIRST_SIDE);
            }

            Console.Write(Massage.INPUT_TRIANGLE_SECOND_SIDE);
            while (!double.TryParse(Console.ReadLine(), out triangleSide2) || triangleSide2 <= 0 || triangleSide2 > double.MaxValue)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(Massage.INPUT_NUMBER);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Massage.INPUT_TRIANGLE_SECOND_SIDE);
            }

            Console.Write(Massage.INPUT_TRIANGLE_THIRD_SIDE);
            while (!double.TryParse(Console.ReadLine(), out triangleSide3) || triangleSide3 <= 0 || triangleSide2 > double.MaxValue)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(Massage.INPUT_NUMBER);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Massage.INPUT_TRIANGLE_THIRD_SIDE);
            }
            

            while (!isValid)
            {
                                
                try
                {

                    if (triangleSide1 <= 0 || triangleSide2 <= 0 || triangleSide3 <= 0)
                    {
                        throw new ArgumentException("\n All sides must be greater than zero.");
                    }

                    if (Math.Abs(triangleSide1 - triangleSide2) >= triangleSide3 || Math.Abs(triangleSide1 - triangleSide3) >= triangleSide2 || Math.Abs(triangleSide2 - triangleSide3) >= triangleSide1)
                    {
                        throw new ArgumentException("\n The sides do not form a triangle.");
                    }

                    isValid = true;
                }

                catch (ArgumentException ex)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine(Menu.TOP_ADD_TRIANGLE);

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\n Please enter valid triangle sides:");
                    Console.Write(Massage.INPUT_TRIANGLE_FIRST_SIDE);
                    triangleSide1 = Convert.ToDouble(Console.ReadLine());

                    Console.Write(Massage.INPUT_TRIANGLE_SECOND_SIDE);
                    triangleSide2 = Convert.ToDouble(Console.ReadLine());

                    Console.Write(Massage.INPUT_TRIANGLE_THIRD_SIDE);
                    triangleSide3 = Convert.ToDouble(Console.ReadLine());
                }
            }

            dm.AddNewTriangle(triangleSide1, triangleSide2, triangleSide3);

        }
    }
}