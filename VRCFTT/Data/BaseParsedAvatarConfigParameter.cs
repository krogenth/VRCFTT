namespace VRCFTT.Data;

public abstract class BaseParsedAvatarConfigParameter(string address, string type)
{
    public string Address { get; set; } = address;
    public string Type { get; set; } = type;
}
