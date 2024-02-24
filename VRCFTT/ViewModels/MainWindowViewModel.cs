using System.Collections.ObjectModel;
using VRCFTT.Data;
using VRCFTT.Events;

namespace VRCFTT.ViewModels;

public class MainWindowViewModel : BaseViewModel
{
    private string _avatarName { get; set; } = string.Empty;
    private readonly ObservableCollection<BaseParsedAvatarConfigParameter> _avatarParameters = [];

    public MainWindowViewModel()
    {
        LoadedAvatarConfig.Instance.AvatarConfigChanged += OnAvatarConfigChanged;
    }

    public void OnAvatarConfigChanged(object? obj, AvatarConfigChangedArgs args)
    {
        AvatarParameters.Clear();
        foreach (var parameter in args.Config.Parameters)
        {
            var type = ParsedAvatarConfigParameterType.GetParamterType(Type: parameter.Output.Type);
            if (type is not null)
            {
                switch (type)
                {
                    case var _ when type == typeof(float):
                        AvatarParameters.Add(
                            ParsedAvatarConfigParameterType.GetParsedParameter<float>(
                                parameter.Output.Address,
                                parameter.Output.Type
                            )
                        );
                        break;
                    case var _ when type == typeof(int):
                        AvatarParameters.Add(
                            ParsedAvatarConfigParameterType.GetParsedParameter<int>(
                                parameter.Output.Address,
                                parameter.Output.Type
                            )
                        );
                        break;
                    case var _ when type == typeof(bool):
                        AvatarParameters.Add(
                            ParsedAvatarConfigParameterType.GetParsedParameter<bool>(
                                parameter.Output.Address,
                                parameter.Output.Type
                            )
                        );
                        break;
                }
            }
        }

        AvatarName = args.Config.Name;
        OnPropertyChanged(nameof(AvatarParameters));
    }

    public string AvatarName
    {
        get => string.IsNullOrEmpty(_avatarName) ? "n/a" : _avatarName;
        set
        {
            _avatarName = value;
            OnPropertyChanged(nameof(AvatarName));
        }
    }

    public ObservableCollection<BaseParsedAvatarConfigParameter> AvatarParameters
    {
        get => _avatarParameters;
    }
}
