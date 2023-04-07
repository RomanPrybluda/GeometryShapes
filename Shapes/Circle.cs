using GeometryTest.Shapes;


namespace GeometryTest
{
    public class Circle : Shape
    {

        public override string ShapeType { get; protected set; }
                        
        public override double Perimeter { get; set; }

        public double Radius { get; private set; }

        public const double PI = 3.14;

        public Circle(double radius)
        {

            if (radius <= 0)
                throw new ArgumentOutOfRangeException(nameof(radius), $"Square side must be more than 0.");

            if (double.IsNaN(radius))
                throw new ArgumentException(" Value for side a causes overflow.");

            if (double.IsInfinity(radius))
                throw new ArgumentException(" Value for side a causes overflow.");

            Radius = radius;
            ShapeType = "Circle";

            CalculatePerimeter();
        }

        public override void CalculatePerimeter()
        {
            Perimeter = 2 * PI * Radius;
        }

        public override string ToString()
        {
            return $" {ShapeType}, radius = {Radius:F2} mm, perimeter = {Perimeter:F2} mm.";
        }

    }
}