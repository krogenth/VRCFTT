using System.Text.Json.Serialization;

namespace VRCFTT.Data;

public class AvatarConfigFile
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("parameters")]
    public AvatarConfigFileParamter[] Parameters { get; set; } = [];
};
