using System.Text.Json.Serialization;

namespace SelfBackEnd.Dtos.Response;

public class TaskViewDto
{
    public TaskViewDto() { }

    public TaskViewDto(Models.Task task)
    {
        Id = task.Id;
        Task = task.TaskName;
        IsCompleted = task.IsCompleted;
    }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("task")]
    public string Task { get; set; }

    [JsonPropertyName("isCompleted")]
    public bool IsCompleted { get; set; }
}
