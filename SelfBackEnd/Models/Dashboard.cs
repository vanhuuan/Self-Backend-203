using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SelfBackEnd.Models;

public class Dashboard : BaseModel
{
    [Required]
    public string Title { get; set; }

    [Required]
    public string LayoutType { get; set; }

    [Required]
    public string UserId { get; set; }

    public User User { get; set; }
    
    public ICollection<Widget> Widgets { get; set; }

}
