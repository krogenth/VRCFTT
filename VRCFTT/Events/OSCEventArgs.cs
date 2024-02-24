using BuildSoft.OscCore;
using System;

namespace VRCFTT.Events;

public class OSCEventArgs(string endpoint, OscMessageValues args) : EventArgs
{
    public string Endpoint { get; private set; } = endpoint;
    public OscMessageValues Args { get; private set; } = args;
}
