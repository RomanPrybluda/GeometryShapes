using System;


namespace GeometryTest
{
    public class ValidatorCircle
    {

        public void ToValidateCircle(DataManager dm)
        {

            bool isValid = false;
            double circleRadius;

            Console.Write(Massage.INPUT_CIRCUT_RADIUS);

            while (!double.TryParse(Console.ReadLine(), out circleRadius) || circleRadius <= 0 || circleRadius > double.MaxValue)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" Input Error. Try again.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Massage.INPUT_CIRCUT_RADIUS);
            }

            while (!isValid)
            {
                                
                try
                {

                    if (circleRadius <= 0)
                    {
                        throw new ArgumentException("\n The radius must be greater than zero.");
                    }

                    isValid = true;
                }

                catch (ArgumentException ex)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(Menu.TOP_ADD_CIRCLE);

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\n Please enter valid radius:");

                    Console.Write(Massage.INPUT_CIRCUT_RADIUS);
                    circleRadius = Convert.ToDouble(Console.ReadLine());
                    
                }
            }

            dm.AddNewCircle(circleRadius);

        }


    }

}
