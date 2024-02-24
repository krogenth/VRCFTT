using System;

namespace VRCFTT.Data;

public static class ParsedAvatarConfigParameterType
{
    public static Type? GetParamterType(string Type)
    {
        return Type.ToUpper() switch
        {
            "FLOAT" => typeof(float),
            "BOOL" => typeof(bool),
            "INT" => typeof(int),
            _ => null,
        };
    }

    public static ParsedAvatarConfigParameter<T> GetParsedParameter<T>(string address, string type)
    {
        return new ParsedAvatarConfigParameter<T>(address, type, default);
    }
}
