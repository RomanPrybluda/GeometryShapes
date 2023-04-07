using GeometryTest.Shapes;


namespace GeometryTest
{
    public class Rectangle : Shape
    {

        public override string ShapeType { get; protected set; }

        public override double Perimeter { get; set; }

        public double RectangleSide1 { get; private set; }

        public double RectangleSide2 { get; private set; }
               

        public Rectangle(double rectangleSide1, double rectangleSide2)
        {
            if (rectangleSide1 <= 0)
                throw new ArgumentOutOfRangeException(nameof(rectangleSide1), $" First rectangle side must be more than 0.");

            if (rectangleSide2 <= 0)
                throw new ArgumentOutOfRangeException(nameof(rectangleSide2), $" Second rectangle side must be more than 0.");

            if (double.IsNaN(rectangleSide1) || double.IsNaN(rectangleSide2))
                throw new ArgumentException(" Value for side a causes overflow.");
            
            if (double.IsInfinity(rectangleSide1) || double.IsInfinity(rectangleSide2))
                throw new ArgumentException(" Value for side a causes overflow.");
            
           
            ShapeType = "Rectangle";

            RectangleSide1 = rectangleSide1;
            RectangleSide2 = rectangleSide2;

            CalculatePerimeter();
        }

        public override void CalculatePerimeter()
        {
            Perimeter = 2 * (RectangleSide1 + RectangleSide2);
        }

        public override string ToString()
        {
            return $" {ShapeType}, first side = {RectangleSide1:F2} mm, second side = {RectangleSide2:F2} mm, perimeter = {Perimeter:F2} mm.";
        }
    
    }
}