using System.Text.Json.Serialization;

namespace SelfBackEnd.Dtos.Response;

public class UserViewDto
{
    public UserViewDto() { }

    public UserViewDto(string userId, string userName, string email, string fullName)
    {
        UserId = userId;
        UserName = userName;
        Email = email;
        FullName = fullName;
    }

    [JsonPropertyName("userId")]
    public string UserId { get; set; }

    [JsonPropertyName("userName")]
    public string UserName { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("fullName")]
    public string FullName { get; set; }
}
