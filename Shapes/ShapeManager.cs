using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using GeometryTest;



namespace GeometryTest
{
    public class ShapeManager
    {
        private List<Shape> _shapes = new List<Shape>();
        public IFileManager FileManager { get; }

        public ShapeManager(IFileManager fileManager)
        {
            FileManager = fileManager;
        }

        public void AddTriangle(double triangleSide1, double triangleSide2, double triangleSide3)
        {
            _shapes.Add(new Triangle(triangleSide1, triangleSide2, triangleSide3));
        }

        public void AddRectangle(double rectangleWidth, double rectangleHeight)
        {
            _shapes.Add(new Rectangle(rectangleWidth, rectangleHeight));
        }

        public void AddSquare(double squareSide)
        {
            _shapes.Add(new Square(squareSide));
        }

        public void AddCircle(double circleRadius)
        {
            _shapes.Add(new Circle(circleRadius));
        }

        public void DeleteShapeByType(ShapeType shapeType)
        {
            _shapes.RemoveAll(x => x.ShapeType == shapeType);
        }

        public void TransformShapes()
        {
            for (int i = 0; i < _shapes.Count; i++)
                _shapes[i] = _shapes[i].Transform();
        }

        public void Load(string fileName, bool fromScratch)
        {
            if (fromScratch)
                _shapes.Clear();

            var loadedShapes = FileManager.Load(fileName);
            _shapes.AddRange(loadedShapes);
        }
        public void Save(string fileName) => FileManager.Save(_shapes, fileName);

        public IEnumerable<Shape> GetShapes()
        {
            foreach (var item in _shapes)
                yield return item;
        }
    }
}