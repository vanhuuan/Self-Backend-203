using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SelfBackEnd.Dtos.Request;
using SelfBackEnd.Dtos.Response;
using SelfBackEnd.Services;
using SelfBackEnd.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SelfBackEnd.Controllers;

[Route("tasks")]
[ApiController]
[Authorize]
public class TasksController : BaseController
{
    private readonly ITasksService _tasksService;

    public TasksController(ITasksService tasksService) {
        _tasksService = tasksService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TaskViewDto>> GetAllTasks()
    {
        var tasks = _tasksService.GetAllTasks(GetUserId());
        return Ok(tasks);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<TaskViewDto> GetTasks([FromRoute] string id) 
    {
        var task = _tasksService.GetTask(GetUserId(), id);
        if(task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpPost]
    public ActionResult CreateTask([FromBody] CreateTaskRequest createTaskRequest)
    {
        var check = _tasksService.CreateTask(GetUserId(), createTaskRequest);
        if (check) return Ok();
        return BadRequest();
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult UpdateTask([FromRoute] string id, [FromBody] UpdateTaskRequest updateTaskRequest)
    {
        var check = _tasksService.UpdateTask(GetUserId(), id,updateTaskRequest);
        if (check) return Ok();
        return BadRequest();
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeleteTask([FromRoute] string id)
    {
        var check = _tasksService.DeleteTask(id, GetUserId());
        if (check) return Ok();
        return BadRequest();
    }

    [HttpGet]
    [Route("search")]
    public ActionResult<IEnumerable<TaskViewDto>> SearchTasks([FromQuery][Required] string keyqword)
    {
        var tasks = _tasksService.SearchTasks(GetUserId(), keyqword);
        return Ok(tasks);
    }
}
