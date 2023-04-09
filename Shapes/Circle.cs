using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace GeometryTest
{
    public class Circle : Shape
    {
        [JsonProperty(Order = 2)]
        public double Radius { get; private set; }

        [JsonProperty(Order = 3)]
        public double Perimeter { get { return CalculatePerimeter(); } }

        private const double PI = 3.14;

        public Circle(double radius) : base(ShapeType.Circle)
        {
            if (radius <= 0)
                throw new ArgumentOutOfRangeException(nameof(radius), $"Circle radius must be more than 0.");

            if (double.IsNaN(radius))
                throw new ArgumentException(" Value for radius a causes overflow.");

            if (double.IsInfinity(radius))
                throw new ArgumentException(" Value for radius a causes overflow.");

            Radius = radius;
        }

        protected override double CalculatePerimeter() => 2 * PI * Radius;


        public override Shape Transform() => new Square(Radius);


        public override string ToString()
        {
            return $" {Enum.GetName(typeof(ShapeType), ShapeType)}, " +
                    $"radius = {Radius:F2} mm, " +
                    $"perimeter = {CalculatePerimeter():F2} mm.";
        }

    }
}