using System.ComponentModel.DataAnnotations;

namespace SelfBackEnd.Models;

public class Widget : BaseModel
{
    [Required]
    public string Title { get; set; }

    [Required]
    public string WidgetType { get; set; }

    [Required]
    public int MinWidth {get; set; }

    [Required]
    public int MaxHeight { get; set; }
}
