﻿using System.ComponentModel.DataAnnotations;

namespace SelfBackEnd.Models;

public class BaseModel
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
