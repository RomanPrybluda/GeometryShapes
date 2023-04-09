using GeometryShapes.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;


namespace GeometryShapes
{
    public class FileManager : IFileManager
    {
        private string _fileName;
        private string _folderName;
        private string _fileExtension;
        private string _fullFolderPath;
        
        public FileManager(string fileName = "GeometryTest", string folderName = "GeometryTest", string fileExtension = ".json")
        {
            ValidateNames(new[] { fileName, folderName, fileExtension });

            _fileExtension = fileExtension;
            _fileName = fileName + fileExtension;
            _folderName = folderName;

            _fullFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), _folderName);

            if (!Directory.Exists(_fullFolderPath))
                Directory.CreateDirectory(_fullFolderPath);

            var filePath = Path.Combine(_fullFolderPath, _fileName);

            //if (!File.Exists(filePath))
            //    File.Create(filePath).Close();

        }

        public void Save(List<Shape> shapes, string fileName = "")
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                ValidateNames(new[] { fileName });
                _fileName = fileName + _fileExtension;
            }

            var filePath = Path.Combine(_fullFolderPath, _fileName);
            var json = Serializer.Serialize(shapes);

            using var sw = new StreamWriter(filePath);
            try
            {
                sw.Write(json);
            }
            catch (Exception e) 
            {
                throw new FileLoadException(Messages.SAVE_FALSE, e);
            }
        }

        public List<Shape> Load(string fileName = "")
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                ValidateNames(new[] { fileName });
                _fileName = fileName + _fileExtension;
            }

            var filePath = Path.Combine(_fullFolderPath, _fileName);
            string json = "";
            try
            {
                json = File.ReadAllText(filePath);
            }
            catch (Exception e )
            {
                throw new FileLoadException(Messages.UPLOAD_FALSE, e);
            }

            var shapes = Serializer.DeSerialize(json);

            return shapes;
        }

        private void ValidateNames(string[] names)
        {
            foreach (string name in names)
            {
                if (Path.GetInvalidFileNameChars().Any(name.Contains))
                    throw new ArgumentException("Invalid symbol!");
            }
        }

    }

}