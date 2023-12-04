using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SelfBackEnd.Dtos.Request;

public class RegisterRequestDto
{
    [JsonPropertyName("userName")]

    [MaxLength(255)]
    public String UserName {  get; set; }

    [JsonPropertyName("email")]
    [EmailAddress]
    [MaxLength(30)]
    public String Email {  get; set; }

    [JsonPropertyName("password")]

    [MaxLength(255)]
    public String Password { get; set; }

    [JsonPropertyName("fullName")]
    [MaxLength(255)]
    public String FullName { get; set; }
}
