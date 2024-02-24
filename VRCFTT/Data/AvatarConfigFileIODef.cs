using System.Text.Json.Serialization;

namespace VRCFTT.Data;

public class AvatarConfigFileIODef
{
    [JsonPropertyName("address")]
    public string Address { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;
};
