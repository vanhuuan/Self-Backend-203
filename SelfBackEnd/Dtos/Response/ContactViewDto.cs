using SelfBackEnd.Dtos.Request;
using System.Text.Json.Serialization;

namespace SelfBackEnd.Dtos.Response;

public class ContactViewDto : CreateContactRequest
{
    [JsonPropertyName("contactId")]
    public string ContactId { get; set; }
}
