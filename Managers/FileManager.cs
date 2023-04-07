using GeometryTest.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;


namespace GeometryTest
{
    public class FileManager
    {

        private const string FOLDER_NAME = "GeometryShapes";

        private const string FILE_EXTENSION = ".json";

        public string FileFolderPath { get; set; }
        public object jsonRead { get; private set; }

        public FileManager()
        {
            string _fileFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), FOLDER_NAME);

            FileFolderPath = _fileFolderPath;

            FolderCreater();

        }
              

        public string BuildFilePath(string fileName)
        {
            return Path.Combine(FileFolderPath, fileName + FILE_EXTENSION);
        }


        private void FolderCreater()
        {
            if (!Directory.Exists(FileFolderPath))
            {
                Directory.CreateDirectory(FileFolderPath);
            }
        }
                        

        public void SaveJsonToFile(DataManager dm)
        {
            
            bool isOverwrite = false;
            string filePath, fileName;


            do
            {
                fileName = ValidatorFileName.GetValidFileName();
                filePath = BuildFilePath(fileName);

                if (File.Exists(filePath))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"\n File {fileName} already exists. Overwrite this file (y/n) :");
                    Console.ForegroundColor = ConsoleColor.White;

                    string askToOverwriteFile = Console.ReadLine();

                    if (askToOverwriteFile.ToLower() == "y")
                    {
                        isOverwrite = true;
                    }
                    else
                    {
                        isOverwrite = false;                        
                    }
                }

                else
                {
                    isOverwrite = true;
                }

            } while (!isOverwrite);

            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    string json = dm.GetShapesAsJson();
                    sw.Write(json);
                }

                Console.WriteLine(Massage.SAVE_SUCSESS);
            }

            catch (Exception ex)
            {
                Console.WriteLine(Massage.SAVE_FALSE + fileName + ex.Message);
            }
        }


        public string ReadFile()
        {
            
            string filePath;

            do
            {
                Console.Write(Massage.INPUT_FILE_NAME);
                string fileName = Console.ReadLine();

                filePath = BuildFilePath(fileName);

                if (!File.Exists(filePath))
                {
                    Console.WriteLine($" File {filePath} does not exist.");
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine(" Please input valid file name.");
                    Console.ForegroundColor = ConsoleColor.White;

                }

                else
                {
                    break;
                }

            } while (true);

            try
            {
                string jsonRead = File.ReadAllText(filePath);
                return jsonRead;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n Error reading file: {ex.Message}. ");
                return null;
            }

        }
        
    }

}