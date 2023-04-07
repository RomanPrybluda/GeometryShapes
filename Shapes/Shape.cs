using System;


namespace GeometryTest.Shapes
{
    public abstract class Shape
    {
        
        public virtual string ShapeType { get; protected set; } 

        public virtual double Perimeter { get; set; }
                
        public abstract void CalculatePerimeter();

    }
}
