using System.Text.Json;
using Newtonsoft.Json;

namespace ReserveRoverBLL.Helpers.Converters;

public class DateOnlyJsonConverter : System.Text.Json.Serialization.JsonConverter<DateOnly>
{
    // Expected format "2023-12-29"
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return JsonConvert.DeserializeObject<DateOnly>(reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(JsonConvert.SerializeObject(value, Formatting.Indented));
    }
}