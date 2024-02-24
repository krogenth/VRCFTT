using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using VRCFTT.Events;

namespace VRCFTT.Data;

public class LoadedAvatarConfig
{
    public static LoadedAvatarConfig Instance { get; private set; } = new();
    public AvatarConfigFile? AvatarConfig { get; private set; }
    public EventHandler<AvatarConfigChangedArgs>? AvatarConfigChanged;


    private readonly string _oscDir = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}Low\\VRChat\\VRChat\\OSC";

    private LoadedAvatarConfig()
    {
        OSCServerWrapper.Instance.OSCEventReceived += OnOSCEventReceived;
    }

    private void OnOSCEventReceived(object? _, OSCEventArgs args)
    {
        if (args.Endpoint.Equals("/avatar/change"))
        {
            LoadAvatarConfig(args.Args.ReadStringElement(0));
        }
    }

    private void LoadAvatarConfig(string avatarId)
    {
        foreach (var avatarFolder in Directory.GetDirectories(_oscDir).Where(folder => Directory.Exists(Path.Combine(folder, "Avatars"))))
        {
            var filepath = Path.Combine(avatarFolder, "Avatars", avatarId + ".json");
            if (File.Exists(filepath))
            {
                var configText = File.ReadAllText(filepath);
                AvatarConfig = JsonSerializer.Deserialize<AvatarConfigFile>(configText);
                if (AvatarConfig != null)
                {
                    AvatarConfigChanged?.Invoke(this, new AvatarConfigChangedArgs(AvatarConfig));
                }
            }
        }
    }
}
