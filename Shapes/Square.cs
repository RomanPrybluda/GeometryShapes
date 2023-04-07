using GeometryTest.Shapes;

namespace GeometryTest
{
    public class Square : Shape
    {

        public override string ShapeType { get; protected set; }

        public override double Perimeter { get; set; }

        public double Side { get; private set; }


        public Square(double side)
        {
            if (side <= 0)
                throw new ArgumentOutOfRangeException(nameof(side), $" Square side must be more than 0.");

            if (double.IsNaN(side))
                throw new ArgumentException(" Value for side a causes overflow.");

            if (double.IsInfinity(side))
                throw new ArgumentException(" Value for side a causes overflow.");


            ShapeType = "Square";
            Side = side;

            CalculatePerimeter();           
        }

        public override void CalculatePerimeter()
        {
            Perimeter = Side * 4;
        }

        public override string ToString()
        {
            return $" {ShapeType}, side = {Side:F2} mm, perimeter = {Perimeter:F2} mm.";
        }
    }
}