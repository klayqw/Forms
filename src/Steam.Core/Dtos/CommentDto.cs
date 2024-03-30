using System.Text.Json.Serialization;

namespace Steam.Core.Dto;

public class CommentDto
{
    [JsonPropertyName("GameId")]
    public int GameId { get; set; }
    [JsonPropertyName("UserId")]
    public string UserId { get; set; }
    [JsonPropertyName("Comment")]
    public string Comment { get; set; }
}
