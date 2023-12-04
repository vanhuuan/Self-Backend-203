using SelfBackEnd.Dtos.Request;
using SelfBackEnd.Dtos.Response;
using SelfBackEnd.Models;
using SelfBackEnd.Repositories.Interfaces;
using SelfBackEnd.Services.Interfaces;

namespace SelfBackEnd.Services;

public class TasksService : ITasksService
{
    private readonly IBaseRepository<Models.Task> _taskRepository;

    public TasksService(IBaseRepository<Models.Task> taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public bool CreateTask(string userId, CreateTaskRequest request)
    {
        try
        {
            var task = new Models.Task()
            {
                IsCompleted = false,
                TaskName = request.Task,
                UserId = userId,
            };
            _taskRepository.Insert(task);
            _taskRepository.Save();
            return true;
        }catch (Exception ex)
        {
            return false;
        }
    }

    public bool DeleteTask(string taskId, string userId)
    {
        var task = _taskRepository.GetById(taskId);
        if (task == null || task.UserId != userId) {
            return false;
        }

        _taskRepository.Delete(taskId);
        _taskRepository.Save();
        return true;
    }

    public IList<TaskViewDto> GetAllTasks(string userId)
    {
        var tasks = _taskRepository.Find(x => x.UserId == userId).ToList();

        var taskView = new List<TaskViewDto>();

        tasks.ForEach(x => taskView.Add(new TaskViewDto(x)));

        return taskView;
    }

    public TaskViewDto GetTask(string userId, string taskId)
    {
        var task = _taskRepository.GetById(taskId);
        if(task == null || task.UserId != userId) return null;
        return new TaskViewDto(task);
    }

    public IList<TaskViewDto> SearchTasks(string userId, string keyword)
    {
        var tasks = _taskRepository.Find(x => x.UserId == userId && x.TaskName.Contains(keyword)).ToList();

        var taskView = new List<TaskViewDto>();

        tasks.ForEach(x => taskView.Add(new TaskViewDto(x)));

        return taskView;
    }

    public bool UpdateTask(string userId, string taskId, UpdateTaskRequest request)
    {
        var task = _taskRepository.GetById(taskId);
        if (task == null || task.UserId != userId) return false;

        task.IsCompleted = request.IsCompleted;
        task.TaskName = request.Task;

        try
        {
            _taskRepository.Update(task);
            _taskRepository.Save();
        }catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return false;
        }
        
        return true;

    }
}
