using System;
using System.Collections;
using Newtonsoft.Json;

namespace Tasks.Api.Core.Json
{
    public class StringEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                if (TryParse(objectType, reader.Value, out var enumValue))
                    return enumValue;
            }
            catch
            {
            }

            throw new ArgumentException(
                $"[{nameof(StringEnumConverter)}]: {reader.Value} is not part of the {objectType.FullName} Enum");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        private static bool TryParse(Type enumType, object value, out object enumValue)
        {
            return Enum.TryParse(enumType, Convert.ToString(value), true, out enumValue) &&
                ValidEnumValue(enumType, enumValue);
        }

        private static bool ValidEnumValue(Type enumType, object value)
        {
            var enumValues = (IList) enumType.GetEnumValues();
            return enumValues.Contains(value);
        }
    }
}
