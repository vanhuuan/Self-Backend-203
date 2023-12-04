using System.Text.Json.Serialization;

namespace SelfBackEnd.Dtos.Response;

public class VersionViewDto
{
    [JsonPropertyName("version")]
    public string Version { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}
