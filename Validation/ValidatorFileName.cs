using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTest
{


    public static class ValidatorFileName
    {

        public static string GetValidFileName()
        {
            string fileName;
            bool isValidFileName = true;

            do
            {
                Console.Write(Massage.INPUT_FILE_NAME);
                fileName = Console.ReadLine();


                if (string.IsNullOrEmpty(fileName))
                {
                    isValidFileName = false;
                }

                char[] invalidChars = Path.GetInvalidFileNameChars();

                foreach (char invalidChar in invalidChars)
                {
                    if (fileName.Contains(invalidChar))
                    {
                        isValidFileName = false;
                    }
                }

                if (!isValidFileName)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Massage.INVALID_INPUT_FILE_NAME);
                    Console.ForegroundColor = ConsoleColor.White;
                }

            } while (!isValidFileName);

            return fileName;
        }

    }      

}