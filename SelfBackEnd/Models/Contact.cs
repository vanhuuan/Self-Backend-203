using System.ComponentModel.DataAnnotations;

namespace SelfBackEnd.Models;

public class Contact : BaseModel
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Department { get; set; }
    [Required]
    public string Project { get; set; }
    [Required]
    public string Avatar { get; set; }
    [Required]
    public int? EmployeeId { get; set; }
}
