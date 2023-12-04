using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SelfBackEnd.Dtos.Request;

public class CreateContactRequest
{
    [JsonPropertyName("firstName")]
    [Required]
    public string FirstName { get; set; }
    [JsonPropertyName("lastName")]
    [Required]
    public string LastName { get; set; }
    [JsonPropertyName("title")]
    [Required]
    public string Title { get; set; }
    [JsonPropertyName("department")]
    [Required]
    public string Department { get; set; }
    [JsonPropertyName("project")]
    [Required]
    public string Project { get; set; }
    [JsonPropertyName("avatar")]
    [Required]
    public string Avatar { get; set; }
    [JsonPropertyName("employeeId")]
    [Required]
    public int? EmployeeId { get; set; }
}

public class UpdateContactRequest : CreateContactRequest
{

}
