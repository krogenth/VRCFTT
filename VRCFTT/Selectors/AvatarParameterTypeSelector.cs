using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Data;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Metadata;
using System;
using System.Collections.Generic;
using VRCFTT.Data;

namespace VRCFTT.Selectors;

public class AvatarParameterTypeSelector : ITreeDataTemplate
{
    [Content]
    public Dictionary<string, IDataTemplate> Templates { get; private set; } = [];

    public InstancedBinding? ItemsSelector(object item)
    {
        if (item is BaseParsedAvatarConfigParameter parameter)
        {
            return ((TreeDataTemplate)Templates[parameter.Type]).ItemsSelector(item);
        }
        else
        {
            return null;
        }
    }

    public Control? Build(object? param) =>
        Templates[((BaseParsedAvatarConfigParameter)param!).Type].Build(param);

    public bool Match(object? data) =>
        data is BaseParsedAvatarConfigParameter && Templates.ContainsKey(((BaseParsedAvatarConfigParameter)data).Type);
}
