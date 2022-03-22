using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

// ReSharper disable once CheckNamespace
namespace System;

public static class BlockCypherClientExtensions
{
    /// <summary>
    /// json.net serializer settings to use for BlockCypher.  i.e. snake_case
    /// </summary>
    public static JsonSerializerSettings BlockCypherSerializerSettings
    {
        get
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            };
            settings.Converters.Add(new StringEnumConverter(new SnakeCaseNamingStrategy()));
            return settings;
        }
    }

    /// <summary>
    /// Serializes the object to BlockCypher Json string by using the <see cref="BlockCypherSerializerSettings"/>.  i.e. snake_case
    /// </summary>
    /// <param name="obj">Object being serialized</param>
    /// <param name="formatting">Indented(default) or Not</param>
    /// <param name="serializerSettingsOverride">If included, this will override the default JsonSerializerSettings used to serialize this object</param>
    public static string ToBlockCypherJsonString(this object? obj, Formatting formatting = Formatting.Indented,
        JsonSerializerSettings? serializerSettingsOverride = null)
    {
        return JsonConvert.SerializeObject(obj, formatting, serializerSettingsOverride ?? BlockCypherSerializerSettings);
    }
}