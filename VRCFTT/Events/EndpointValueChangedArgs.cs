using System;

namespace VRCFTT.Events;

public class EndpointValueChangedArgs(string endpoint, float value) : EventArgs
{
    public string Endpoint { get; private set; } = endpoint;
    public float Value { get; private set; } = value;
}
