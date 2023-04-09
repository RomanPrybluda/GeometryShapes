using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using GeometryTest;
using GeometryTest;

namespace GeometryTest
{
    public class FileManager : IFileManager
    {
        private string _folderName;
        private string _fileExtension;
        private string _fullFolderPath;

        public FileManager(string folderName = "GeometryTest", string fileExtension = ".json")
        {
            ValidateNames(new[] { folderName, fileExtension });

            _fileExtension = fileExtension;
            _folderName = folderName;

            _fullFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), _folderName);

            if (!Directory.Exists(_fullFolderPath))
                Directory.CreateDirectory(_fullFolderPath);
        }

        public void Save(List<Shape> shapes, string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                ValidateNames(new[] { fileName });
                fileName += _fileExtension;
            }

            var filePath = Path.Combine(_fullFolderPath, fileName);
            var json = Serializer.Serialize(shapes);

            using var sw = new StreamWriter(filePath);
            try
            {
                sw.Write(json);
            }
            catch (Exception e)
            {
                throw new FileLoadException(Messages.SAVE_FALSE + fileName + e.Message);
            }
        }

        public List<Shape> Load(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                ValidateNames(new[] { fileName });
                fileName += _fileExtension;
            }

            var filePath = Path.Combine(_fullFolderPath, fileName);
            string json = "";

            try
            {
                json = File.ReadAllText(filePath);
            }
            catch (Exception e)
            {
                throw new FileLoadException(Messages.UPLOAD_FALSE + e.Message);
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

        public bool CheckExists(string fileName)
        {
            var filePath = Path.Combine(_fullFolderPath, fileName + _fileExtension);
            return File.Exists(filePath);
        }

    }

}