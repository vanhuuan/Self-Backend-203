using System.ComponentModel.DataAnnotations;

namespace SelfBackEnd.Models;

public class Task : BaseModel
{
    [Required]
    public string TaskName { get; set; }

    [Required]
    public bool IsCompleted { get; set; }

    [Required]
    public string UserId { get; set; }

    public User User { get; set; }
}
