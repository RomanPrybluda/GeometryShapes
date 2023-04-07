using System;


namespace GeometryTest
{
    public class ValidatorRectangle
    {

        public void ToValidateRectangle(DataManager dm)
        {
            bool isValid = false;
            double rectangleSide1, rectangleSide2;

            Console.Write(Massage.INPUT_RECTANGLE_FIRST_SIDE);

            while (!double.TryParse(Console.ReadLine(), out rectangleSide1) || rectangleSide1 <= 0 || rectangleSide1 > double.MaxValue)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" Input Error. Try again.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Massage.INPUT_RECTANGLE_FIRST_SIDE);
            }

            Console.Write(Massage.INPUT_RECTANGLE_SECOND_SIDE);

            while (!double.TryParse(Console.ReadLine(), out rectangleSide2) || rectangleSide2 <= 0 || rectangleSide2 > double.MaxValue)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" Input Error. Try again.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Massage.INPUT_RECTANGLE_SECOND_SIDE);
            }

            while (!isValid)
            {
                                
                try
                {

                    if (rectangleSide1 <= 0 || rectangleSide2 <= 0)
                    {
                        throw new ArgumentException("\n All sides must be greater than zero.");
                    }

                    isValid = true;
                }

                catch (ArgumentException ex)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(Menu.TOP_ADD_RECTANGLE);

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\n Please enter valid rectangle sides:");

                    Console.Write(Massage.INPUT_RECTANGLE_FIRST_SIDE);
                    rectangleSide1 = Convert.ToDouble(Console.ReadLine());

                    Console.Write(Massage.INPUT_RECTANGLE_SECOND_SIDE);
                    rectangleSide2 = Convert.ToDouble(Console.ReadLine());
                    
                }
            }

            dm.AddNewRectangle(rectangleSide1, rectangleSide2);

        }


    }

}
