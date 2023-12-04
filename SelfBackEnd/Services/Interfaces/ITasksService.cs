using SelfBackEnd.Dtos.Request;
using SelfBackEnd.Dtos.Response;

namespace SelfBackEnd.Services.Interfaces;

public interface ITasksService
{
    public IList<TaskViewDto> GetAllTasks(string userId);

    public IList<TaskViewDto> SearchTasks(string userId, string keyword);

    public bool CreateTask(string userId, CreateTaskRequest request);

    public bool UpdateTask(string userId, string taskId ,UpdateTaskRequest request);

    public bool DeleteTask(string taskId, string userId);

    public TaskViewDto GetTask(string userId, string taskId);
}
