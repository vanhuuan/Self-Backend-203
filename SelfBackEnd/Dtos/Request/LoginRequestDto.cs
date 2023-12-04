using System.Text.Json.Serialization;

namespace SelfBackEnd.Dtos.Request
{
    public class LoginRequestDto
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
