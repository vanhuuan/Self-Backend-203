using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SelfBackEnd.Dtos.Request;

public class CreateTaskRequest
{
    [JsonPropertyName("task")]
    [MaxLength(255)]
    public string Task { get; set; }
}

public class UpdateTaskRequest : CreateTaskRequest
{
    [JsonPropertyName("isCompleted")]
    public bool IsCompleted { get; set; } = false;
}
