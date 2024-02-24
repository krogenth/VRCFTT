using System.Text.Json.Serialization;

namespace VRCFTT.Data;

public class AvatarConfigFileParamter
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("input")]
    public AvatarConfigFileIODef Input { get; set; } = new();

    [JsonPropertyName("output")]
    public AvatarConfigFileIODef Output { get; set; } = new();
};
