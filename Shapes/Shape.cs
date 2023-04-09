using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;


namespace GeometryShapes.Shapes
{ 

    public abstract class Shape
    {
        public ShapeType ShapeType { get; protected set; }


        public Shape(ShapeType shapeType)
        {

            ShapeType = shapeType;
        }

        protected abstract double CalculatePerimeter();
        public abstract Shape Transform();

    }
}
