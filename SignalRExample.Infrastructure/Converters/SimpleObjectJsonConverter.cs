
using SignalRExample.Domain;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SignalRExample.Infrastructure.Converters;

public class SimpleObjectJsonConverter : JsonConverter<SimpleObjectId>
{
    public override SimpleObjectId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var guid = reader.GetGuid();
        return new SimpleObjectId(guid);
    }

    public override void Write(Utf8JsonWriter writer, SimpleObjectId value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Id);
    }
}
