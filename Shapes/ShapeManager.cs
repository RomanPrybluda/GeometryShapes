using GeometryShapes.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;


namespace GeometryShapes
{
    public class ShapeManager
    {

        private List<Shape> _shapes = new List<Shape>();
        private IFileManager _fileManager;

        public ShapeManager(IFileManager fileManager)
        {
            _fileManager = fileManager;

            Load();
        }

        public void AddTriangle(double triangleSide1, double triangleSide2, double triangleSide3)
        {
            _shapes.Add(new Triangle(triangleSide1, triangleSide2, triangleSide3));
            Save();
        }

        public void AddRectangle(double rectangleWidth, double rectangleHeight)
        {
            _shapes.Add(new Rectangle(rectangleWidth, rectangleHeight));
            Save();
        }

        public void AddSquare(double squareSide)
        {
            _shapes.Add(new Square(squareSide));
            Save();
        }

        public void AddCircle(double circleRadius)
        {
            _shapes.Add(new Circle(circleRadius));
            Save();
        }

        public void DeleteShapeByType(ShapeType shapeType)
        {
            _shapes.RemoveAll(x => x.ShapeType == shapeType);
            Save();
        }

        public void TransformShapes()
        {
            for (int i = 0; i < _shapes.Count; i++)
                _shapes[i] = _shapes[i].Transform();

            Save();
        }

        public void Load(string fileName = "") => _shapes = _fileManager.Load(fileName);
        public void Save(string fileName = "") => _fileManager.Save(_shapes, fileName);

        public IEnumerable<Shape> GetShapes()
        {
            foreach (var item in _shapes)
                yield return item;
        }

    }

}