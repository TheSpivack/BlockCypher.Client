using BlockCypher.Clients.Models.Attributes;

namespace BlockCypher.Clients.Models.Blockchain;

public class GetFeatureRequest : BlockCypherRequest
{
    /// <summary>
    /// The $NAME field of the Feature endpoint. For example, for bip65 on bitcoin.
    /// Generally speaking, for bitcoin, this will follow the form of tracking bipXX (where XX = a number),
    /// but the list of features we're tracking is always changing.
    ///
    /// https://www.blockcypher.com/dev/bitcoin/#feature-endpoint
    /// </summary>

    [PathVariable]
    public string Name { get; set; } = null!;
}