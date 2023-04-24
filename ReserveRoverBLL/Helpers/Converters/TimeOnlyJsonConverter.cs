using System.Text.Json;
using Newtonsoft.Json;

namespace ReserveRoverBLL.Helpers.Converters;

public class TimeOnlyJsonConverter : System.Text.Json.Serialization.JsonConverter<TimeOnly>
{
    public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return JsonConvert.DeserializeObject<TimeOnly>(reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(JsonConvert.SerializeObject(value, Formatting.Indented));
    }
}