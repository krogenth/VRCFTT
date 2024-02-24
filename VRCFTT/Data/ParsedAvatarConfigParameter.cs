using BuildSoft.OscCore;
using System;
using System.Net.Sockets;
using VRCFTT.Events;

namespace VRCFTT.Data;

public class ParsedAvatarConfigParameter<T> : BaseParsedAvatarConfigParameter
{
    private ReactiveObject<T> _value { get; set; }

    public ParsedAvatarConfigParameter(string address, string type, T value) : base(address, type)
    {
        _value = new(value);
        _value.ValueChanged += OnValueChanged;
    }

    public T Value
    {
        get => _value.Value;
        set => _value.Value = value;
    }

    private void OnValueChanged(object? _, ValueChangedEventArgs<T> args)
    {
        using OscClient client = new("127.0.0.1", 9000);
        using var writer = new OscWriter();
        var type = GetTypeTag();
        if (type is not null)
        {
            uint tags = ',' + ((uint)type << 8);
            writer.WriteAddressAndTags(Address, tags);
            switch (type)
            {
                case TypeTag.Float32: writer.Write(Convert.ToSingle(Value)); break;
                case TypeTag.Int32: writer.Write(Convert.ToInt32(Value)); break;
            }
            client.Socket.Send(writer.Buffer, writer.Length, SocketFlags.None);
        }
    }

    private TypeTag? GetTypeTag()
    {
        return Type.ToUpper() switch
        {
            "FLOAT" => TypeTag.Float32,
            "INT" => TypeTag.Int32,
            "BOOL" => Convert.ToBoolean(Value) != true ? TypeTag.False : TypeTag.True,
            _ => null,
        };
    }
}
