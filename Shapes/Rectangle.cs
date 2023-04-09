using GeometryTest;  
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GeometryTest
{
    public class Rectangle : Shape
    {
        [JsonProperty(Order = 2)]
        public double RectangleSide1 { get; private set; }

        [JsonProperty(Order = 3)]
        public double RectangleSide2 { get; private set; }

        [JsonProperty(Order = 4)]
        public double Perimeter { get { return CalculatePerimeter(); } }

        public Rectangle(double rectangleSide1, double rectangleSide2) : base(ShapeType.Rectangle)
        {
            if (rectangleSide1 <= 0)
                throw new ArgumentOutOfRangeException(nameof(rectangleSide1), $" First rectangle side must be more than 0.");

            if (rectangleSide2 <= 0)
                throw new ArgumentOutOfRangeException(nameof(rectangleSide2), $" Second rectangle side must be more than 0.");

            if (double.IsNaN(rectangleSide1) || double.IsNaN(rectangleSide2))
                throw new ArgumentException(" Value for side a causes overflow.");

            if (double.IsInfinity(rectangleSide1) || double.IsInfinity(rectangleSide2))
                throw new ArgumentException(" Value for side a causes overflow.");

            RectangleSide1 = rectangleSide1;
            RectangleSide2 = rectangleSide2;

        }

        protected override double CalculatePerimeter() => 2 * (RectangleSide1 + RectangleSide2);

        public override Shape Transform() => new Triangle(RectangleSide1, RectangleSide2, RectangleSide1 + RectangleSide2);

        public override string ToString()
        {
            return $" {Enum.GetName(typeof(ShapeType), ShapeType)}, " +
                    $"first side = {RectangleSide1:F2} mm, " +
                    $"second side = {RectangleSide2:F2} mm, " +
                    $"perimeter = {CalculatePerimeter():F2} mm.";
        }

    }
}