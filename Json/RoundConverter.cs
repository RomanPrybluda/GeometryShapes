using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryShapes
{
    public class RoundConverter : JsonConverter
    {
        private readonly int _decimalPlaces;

        public RoundConverter(int decimalPlaces)
        {
            _decimalPlaces = decimalPlaces;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(double) || objectType == typeof(float);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            
            if (value is double || value is float)
            {
                double roundedValue = Math.Round(Convert.ToDouble(value), _decimalPlaces);
                writer.WriteValue(roundedValue);
            }
            else
            {
                writer.WriteValue(value);
            }
        }
    }
}
