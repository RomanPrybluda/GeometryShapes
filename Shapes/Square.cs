using GeometryShapes.Shapes;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace GeometryShapes
{
    public class Square : Shape
    {
        [JsonProperty(Order = 2)]
        [Newtonsoft.Json.JsonConverter(typeof(RoundConverter), 2)]
        public double Side { get; private set; }

        [JsonProperty(Order = 3)]
        [Newtonsoft.Json.JsonConverter(typeof(RoundConverter), 2)]
        public double Perimeter { get { return CalculatePerimeter(); } }

        public Square(double side) : base(ShapeType.Square)
        {
            if (side <= 0)
                throw new ArgumentOutOfRangeException(nameof(side), $" Square side must be more than 0.");

            if (double.IsNaN(side))
                throw new ArgumentException(" Value for side a causes overflow.");

            if (double.IsInfinity(side))
                throw new ArgumentException(" Value for side a causes overflow.");

            Side = side;
        }

        protected override double CalculatePerimeter() => Side * 4;

        public override Shape Transform() => new Circle(Side);

        public override string ToString()
        {
            return $" {Enum.GetName(typeof(ShapeType), ShapeType)}, " +
                    $"side = {Side:F2} mm, " +
                    $"perimeter = {CalculatePerimeter():F2} mm.";
        }
    }
}