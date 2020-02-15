using System.Text.Json.Serialization;

namespace Storage.Domain.DTOs
{
    public class GameCodeDTO
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
    }
}