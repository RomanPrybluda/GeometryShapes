using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace GeometryTest
{
    public static class ValidatorMenu
    {
        
        public static int GetValidInputMainMenu()
        {
            int inputMm;
            bool inputIsValid;

            do
            {
                Console.Write(Massage.INPUT_MENU_ITEM);
                string itemMainMenu = Console.ReadLine();

                inputIsValid = int.TryParse(itemMainMenu, NumberStyles.Integer, CultureInfo.InvariantCulture, out inputMm) && inputMm >= 1 && inputMm <= 7;

                if (!inputIsValid)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Massage.INVALID_INPUT_MAIN_MENU_ITEM);
                    Console.ForegroundColor = ConsoleColor.White;
                }

            } while (!inputIsValid);

            return inputMm;
        }

        public static int GetValidInputSubMenu()
        {
            int inputSm;
            bool inputIsValid;

            do
            {
                Console.Write(Massage.INPUT_MENU_ITEM);

                string itemSubMenu = Console.ReadLine();

                inputIsValid = int.TryParse(itemSubMenu, NumberStyles.Integer, CultureInfo.InvariantCulture, out inputSm) && inputSm >= 1 && inputSm <= 5;

                if (!inputIsValid)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Massage.INVALID_INPUT_SUB_MENU_ITEM);
                    Console.ForegroundColor = ConsoleColor.White;
                }

            } while (!inputIsValid);

            return inputSm;
        }

    }

}
