using System;


namespace GeometryTest
{
    public class ValidatorSquare
    {

        public void ToValidateSquare(DataManager dm)
        {
            bool isValid = false;

            double squareSide;

            Console.Write(Massage.INPUT_SQUARE_SIDE);

            while (!double.TryParse(Console.ReadLine(), out squareSide) || squareSide <= 0 || squareSide > double.MaxValue)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" Input Error. Try again.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Massage.INPUT_SQUARE_SIDE);
            }

            while (!isValid)
            {
                                
                try
                {

                    if (squareSide <= 0)
                    {
                        throw new ArgumentException("\n The side must be greater than zero.");
                    }

                    isValid = true;
                }

                catch (ArgumentException ex)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(Menu.TOP_ADD_SQUARE);

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\n Please enter valid sid:");

                    Console.Write(Massage.INPUT_SQUARE_SIDE);
                    squareSide = Convert.ToDouble(Console.ReadLine());
                    
                }
            }

            dm.AddNewSquare(squareSide);

        }


    }

}
