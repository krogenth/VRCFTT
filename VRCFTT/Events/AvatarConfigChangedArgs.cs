using System;
using VRCFTT.Data;

namespace VRCFTT.Events;

public class AvatarConfigChangedArgs(AvatarConfigFile config) : EventArgs
{
    public AvatarConfigFile Config { get; private set; } = config;
}
