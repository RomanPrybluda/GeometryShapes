using GeometryTest.Shapes;


namespace GeometryTest
{
    public class Triangle : Shape
    {

        public override string ShapeType { get; protected set; }

        public override double Perimeter { get; set; }

        public double Side1 { get; private set; }

        public double Side2 { get; private set; }

        public double Side3 { get; private set; }


        public Triangle(double side1, double side2, double side3)
        {
            
            if (side1 <= 0 || side2 <= 0 || side3 <= 0)
                throw new ArgumentOutOfRangeException(nameof(side1), $" Triangle sides must be more than 0.");
            
            if (double.IsNaN(side1) || double.IsNaN(side2) || double.IsNaN(side3))
                throw new ArgumentException(" Value for side a causes overflow.");
            

            if (double.IsInfinity(side1) || double.IsInfinity(side2) || double.IsInfinity(side3))
                throw new ArgumentException(" Value for side a causes overflow.");
            

            if (side1 + side2 <= Math.Abs(side1 - side2) || side2 + side3 <= Math.Abs(side2 - side3) || side3 + side1 <= Math.Abs(side3 - side1))
                throw new ArgumentException(" The sides of the triangle entered cannot form a triangle.");
            

            ShapeType = "Triangle";
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;

            CalculatePerimeter();
        }

        public override void CalculatePerimeter()
        {
            Perimeter = Side1 + Side2 + Side3;
        }
        
        public override string ToString()
        {
            return $" {ShapeType}, first side = {Side1:F2} mm, second side = {Side2:F2} mm, thirt side = {Side3:F2} mm, perimeter = {Perimeter:F2} mm.";
        }
                
    }
}