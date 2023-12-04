using System.ComponentModel.DataAnnotations;

namespace SelfBackEnd.Models;

public class User : BaseModel
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string FullName { get; set; }

    public ICollection<Task> Tasks { get; set; }
    public ICollection<Dashboard> Dashboards { get; set; }
}
