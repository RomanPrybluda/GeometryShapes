using GeometryShapes.Shapes;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;

namespace GeometryShapes
{
    public static class Serializer
    {
        public static string Serialize(List<Shape> shapes)
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.NullValueHandling = NullValueHandling.Ignore;
            serializerSettings.Converters.Add(new StringEnumConverter());

            RoundConverter roundConverter = new RoundConverter(2);
            serializerSettings.Converters.Add(roundConverter);

            return JsonConvert.SerializeObject(shapes, Formatting.Indented, serializerSettings);
        }

        public static List<Shape> DeSerialize(string json)
        {
            List<Shape> shapes = new List<Shape>();

            if (string.IsNullOrEmpty(json.Trim()))
                return shapes;

            JArray jArray = JArray.Parse(json);

            foreach (JObject jObject in jArray)
            {
                ShapeType shapeType = jObject["ShapeType"].ToObject<ShapeType>();

                switch (shapeType)
                {
                    case ShapeType.Triangle:
                        shapes.Add(jObject.ToObject<Triangle>());
                        break;

                    case ShapeType.Rectangle:
                        shapes.Add(jObject.ToObject<Rectangle>());
                        break;

                    case ShapeType.Square:
                        shapes.Add(jObject.ToObject<Square>());
                        break;

                    case ShapeType.Circle:
                        shapes.Add(jObject.ToObject<Circle>());
                        break;

                    default:
                        throw new JsonSerializationException("Wrong json format");
                }
            }

            return shapes;
        }
    }
}
