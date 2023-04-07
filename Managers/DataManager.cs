using GeometryTest.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;


namespace GeometryTest
{
    public class DataManager
    {

        private readonly List<Shape> shapes = new List<Shape>();

        public string json { get; private set; }

        public object fileName { get; private set; }

        public DataManager(FileManager fm)
        {

        }

        #region 1. Add new shape

        public void AddNewTriangle(double triangleSide1, double triangleSide2, double triangleSide3)
        {
            var triangle = new Triangle(triangleSide1, triangleSide2, triangleSide3);

            Console.WriteLine(Massage.ADDED_NEW_SHAPE);
            Console.WriteLine(triangle);

            shapes.Add(triangle);
        }

        public void AddNewRectangle(double rectangleWidth, double rectangleHeight)
        {
            var rectangle = new Rectangle(rectangleWidth, rectangleHeight);

            Console.WriteLine(Massage.ADDED_NEW_SHAPE);
            Console.WriteLine(rectangle);

            shapes.Add(rectangle);
        }

        public void AddNewSquare(double squareSide)
        {
            var square = new Square(squareSide);

            Console.WriteLine(Massage.ADDED_NEW_SHAPE);
            Console.WriteLine(square);

            shapes.Add(square);
        }

        public void AddNewCircle(double circleRadius)
        {
            var circle = new Circle(circleRadius);

            Console.WriteLine(Massage.ADDED_NEW_SHAPE);
            Console.WriteLine(circle);

            shapes.Add(circle);
        }
        #endregion


        #region 2. View all data

        public void ViewAllShapes()
        {

            if (shapes.Count == 0)
            {
                Console.Write(Massage.VIEW_NOTHNG);
                return;
            }

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.ToString());
            }

        }
        #endregion


        #region 3. Delete type of shapes

        public void DeleteTypeShapes(string shapeType)
        {
            shapes.RemoveAll(match: shape => shape.ShapeType == shapeType);
        }
        #endregion


        #region 4. Transform shapes

        public void TransformShapes()
        {

            if (shapes.Count == 0)
            {
                Console.WriteLine("\n No shapes to transform.");
                return;
            }

            List<Shape> transformedShapes = new List<Shape>();

            foreach (var shape in shapes)
            {
                switch (shape)
                {
                    case Triangle triangle: // Triangle to a rectangle
                        {
                            var rectangle = new Rectangle(triangle.Side1, triangle.Side2);
                            transformedShapes.Add(rectangle);
                            break;
                        }

                    case Rectangle rectangle: // Rectangle to a triangle
                        {
                            var triangle = new Triangle(rectangle.RectangleSide1, rectangle.RectangleSide2, rectangle.RectangleSide1);
                            transformedShapes.Add(triangle);
                            break;
                        }

                    case Circle circle: // Circle to a square
                        {
                            var square = new Square(circle.Radius * 2);
                            transformedShapes.Add(square);
                            break;
                        }

                    case Square square:// Square to a circle
                        {
                            var circle = new Circle(square.Side / 2);
                            transformedShapes.Add(circle);
                            break;
                        }
                }
            }

            shapes.Clear();
            shapes.AddRange(transformedShapes);
            Console.Write(Massage.TRANSFORMATION_COMPLITE);


        }
        #endregion


        #region 5. Shapes to JSON

        public string GetShapesAsJson()
        {

            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            string json = JsonConvert.SerializeObject(shapes, Formatting.Indented);

            return json;

        }
        #endregion


        #region 6. Upload shapes from JSON

        public void UploadShapes(FileManager fm)
        {

            string json = fm.ReadFile();

            try
            {                
                JArray jArray = JArray.Parse(json);

                foreach (JObject jObject in jArray)
                {
                    string shapeType = (string)jObject["ShapeType"];

                    switch (shapeType)
                    {
                        case "Triangle":
                            shapes.Add(jObject.ToObject<Triangle>());
                            break;

                        case "Rectangle":
                            shapes.Add(jObject.ToObject<Rectangle>());
                            break;

                        case "Square":
                            shapes.Add(jObject.ToObject<Square>());
                            break;

                        case "Circle":
                            shapes.Add(jObject.ToObject<Circle>());
                            break;

                        default:
                            Console.WriteLine($"Shape type {shapeType} not recognized.");
                            break;
                    }
                }

                Console.WriteLine(Massage.UPLOAD_SUCSESS);
                
            }

            catch (Exception ex)
            {
                Console.WriteLine($"\n Error reading file {fileName}: {ex.Message}");                
            }

        }
        #endregion

    }

}