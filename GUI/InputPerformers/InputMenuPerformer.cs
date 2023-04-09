using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace GeometryShapes
{
    public static class InputMenuPerformer
    {

        public static int PerformMainMenuInput()
        {
            return PerformMenuInput(Messages.INPUT_MENU_ITEM,
                                    Messages.INVALID_INPUT_MAIN_MENU_ITEM,
                                    (input) => input >= 1 && input <= 7);
        }

        public static int PerformSubMenuInput()
        {
            return PerformMenuInput(Messages.INPUT_MENU_ITEM,
                                    Messages.INVALID_INPUT_SUB_MENU_ITEM,
                                    (input) => input >= 1 && input <= 5);
        }

        private static int PerformMenuInput(string header, string errorMessage, Func<int, bool> predicate)
        {
            int input;

            while (true)
            {
                Console.Write(header);

                string itemMenu = Console.ReadLine();

                if (int.TryParse(itemMenu, NumberStyles.Integer, CultureInfo.InvariantCulture, out input) && predicate(input))
                    break;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(errorMessage);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            return input;
        }

    }

}
