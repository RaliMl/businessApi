using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GoodeBooks.Services.Converter
{
    public class DateConverter : JsonConverter<DateTime>
    {
        private const string DateFormat = "yyyy-MM"; // Adjust the date format based on your API response

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String && reader.TryGetDateTime(out var date))
            {
                return date;
            }

            if (reader.TokenType == JsonTokenType.String && DateTime.TryParseExact(reader.GetString(), DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                return date;
            }

            return default;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(DateFormat, CultureInfo.InvariantCulture));
        }
    }
}

