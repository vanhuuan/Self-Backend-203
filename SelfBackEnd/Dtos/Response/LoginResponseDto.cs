using System.Text.Json.Serialization;

namespace SelfBackEnd.Dtos.Response
{
    public class LoginResponseDto
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
