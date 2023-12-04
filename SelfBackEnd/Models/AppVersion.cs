using System.ComponentModel.DataAnnotations;

namespace SelfBackEnd.Models;

public class AppVersion : BaseModel
{
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    [Required]
    [MaxLength(255)]
    public string Version { get; set; }
}
