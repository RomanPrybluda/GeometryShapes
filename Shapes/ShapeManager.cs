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

        public void Load(string fileName)
        {
            var loadedShapes = FileManager.Load(fileName);
            _shapes.AddRange(loadedShapes);
        }

        public void Save(string fileName) => FileManager.Save(_shapes, fileName);

        public IEnumerable<Shape> GetShapes()
        {
            foreach (var item in _shapes)
                yield return item;
        }

        public bool CheckIfShapesExist(ShapeType shapeType)
        {
            switch (shapeType)
            {
                case ShapeType.Circle:
                    return _shapes.Any(s => s is Circle);
                case ShapeType.Triangle:
                    return _shapes.Any(s => s is Triangle);
                case ShapeType.Rectangle:
                    return _shapes.Any(s => s is Rectangle);
                case ShapeType.Square:
                    return _shapes.Any(s => s is Square);
                default:
                    return false;
            }
        }
    }
}