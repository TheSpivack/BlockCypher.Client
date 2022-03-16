using System;

namespace BlockCypher.Clients.Models.Attributes;

/// <summary>
/// Attribute used by <see cref="CoinChain"/> enum to specify which codes to use when building the request url
/// </summary>
public class BlockCypherResourceAttribute : Attribute
{
    /// <summary>
    /// Value to use for $COIN in https://api.blockcypher.com/$API_VERSION/$COIN/$CHAIN/
    /// </summary>
    public string Coin { get; set; } = string.Empty;

    /// <summary>
    /// Value to use for $CHAIN in https://api.blockcypher.com/$API_VERSION/$COIN/$CHAIN/
    /// </summary>
    public string Chain { get; set; } = string.Empty;
}