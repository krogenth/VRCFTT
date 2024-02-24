using BuildSoft.OscCore;
using VRCFTT.Events;
using BlobHandles;
using System;

namespace VRCFTT;

public class OSCServerWrapper
{
    public static OSCServerWrapper Instance { get; private set; } = new();
    public EventHandler<OSCEventArgs>? OSCEventReceived;

    private readonly OscServer _server;

    private OSCServerWrapper()
    {
        _server = new(9001);
        _server.AddMonitorCallback((BlobString address, OscMessageValues values) =>
        {
            OnOSCEventReceived(address.ToString(), values);
        });
    }

    private void OnOSCEventReceived(string endpoint, OscMessageValues args)
    {
        OSCEventReceived?.Invoke(this, new OSCEventArgs(endpoint, args));
    }
}
