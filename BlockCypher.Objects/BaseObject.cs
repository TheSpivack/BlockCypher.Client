using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace BlockCypher.Objects;

public abstract class BaseObject
{
    /// <summary>
    /// json.net serializer settings to use for BlockCypher.  i.e. snake case
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
    /// Serializes this object to JSON using serializer settings to work with the API.  i.e. snake_case
    /// </summary>
    public string ToJsonString(Formatting formatting = Formatting.Indented)
    {
        return JsonConvert.SerializeObject(this, formatting, BlockCypherSerializerSettings);
    }
}