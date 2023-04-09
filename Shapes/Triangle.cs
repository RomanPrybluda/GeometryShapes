using GeometryShapes.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GeometryShapes
{
    public class Triangle : Shape
    {
        [JsonProperty(Order = 2)]
        [JsonConverter(typeof(RoundConverter), 2)]
        public double Side1 { get; private set; }

        [JsonProperty(Order = 3)]
        [JsonConverter(typeof(RoundConverter), 2)]
        public double Side2 { get; private set; }

        [JsonProperty(Order = 4)]
        [JsonConverter(typeof(RoundConverter), 2)]
        public double Side3 { get; private set; }

        [JsonProperty(Order = 5)]
        [JsonConverter(typeof(RoundConverter), 2)]
        public double Perimeter { get { return CalculatePerimeter(); } }
                
        public Triangle(double side1, double side2, double side3) : base(ShapeType.Triangle)
        {
            if (side1 <= 0 || side2 <= 0 || side3 <= 0)
                throw new ArgumentOutOfRangeException(nameof(side1), $" Triangle sides must be more than 0.");
            
            if (double.IsNaN(side1) || double.IsNaN(side2) || double.IsNaN(side3))
                throw new ArgumentException(" Value for side a causes overflow.");

            if (double.IsInfinity(side1) || double.IsInfinity(side2) || double.IsInfinity(side3))
                throw new ArgumentException(" Value for side a causes overflow.");

            if (side1 + side2 <= Math.Abs(side1 - side2) || side2 + side3 <= Math.Abs(side2 - side3) || side3 + side1 <= Math.Abs(side3 - side1))
                throw new ArgumentException(" The sides of the triangle entered cannot form a triangle.");

            Side1 = side1;
            Side2 = side2;
            Side3 = side3;

            CalculatePerimeter();
        }

        protected override double CalculatePerimeter() => Side1 + Side2 + Side3;

        public override Shape Transform() => new Rectangle(Side1, Side2);

        public override string ToString()
        {
            return $" {Enum.GetName(typeof(ShapeType), ShapeType)}, " +
                    $"first side = {Side1:F2} mm, " +
                    $"second side = {Side2:F2} mm, " +
                    $"thirt side = {Side3:F2} mm, " +
                    $"perimeter = {CalculatePerimeter():F2} mm.";
        }

    }
}