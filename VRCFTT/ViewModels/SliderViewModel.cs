using System;
using VRCFTT.Events;

namespace VRCFTT.ViewModels;

public class SliderViewModel(string endpoint, float startValue = 0.0f) : BaseViewModel
{
    public EventHandler<EndpointValueChangedArgs>? EndpointValueChanged;

    private readonly string _endpoint = endpoint;
    private float _value = startValue;

    public float Value
    {
        get => _value;
        set
        {
            if (value == _value) return;

            _value = value;
            OnPropertyChanged();
            EndpointValueChanged?.Invoke(this, new EndpointValueChangedArgs(_endpoint, _value));
        }
    }
}
