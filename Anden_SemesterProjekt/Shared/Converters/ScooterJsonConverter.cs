using Anden_SemesterProjekt.Shared.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class ScooterJsonConverter : JsonConverter<Scooter>
{
    public override Scooter Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
        {
            var rootElement = doc.RootElement;

            // Tjek hvilken type scooter der er
            string scooterType = rootElement.GetProperty("ScooterType").GetString();

            Scooter scooter;

            if (scooterType == "KundeScooter")
            {
                scooter = JsonSerializer.Deserialize<KundeScooter>(rootElement.GetRawText(), options);
            }
            else if (scooterType == "UdlejningsScooter")
            {
                scooter = JsonSerializer.Deserialize<UdlejningsScooter>(rootElement.GetRawText(), options);
            }
            else
            {
                throw new JsonException("Unknown scooter type.");
            }

            return scooter;
        }
    }

    public override void Write(Utf8JsonWriter writer, Scooter value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}

