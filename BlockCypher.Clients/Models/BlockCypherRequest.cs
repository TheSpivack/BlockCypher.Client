using BlockCypher.Clients.Models.Attributes;

namespace BlockCypher.Clients.Models;

/// <summary>
/// Base class used for all requests.  Can be used to override default <see cref="CoinChain"/> configured
/// </summary>
public class BlockCypherRequest
{
    /// <summary>
    /// Provide the coin and chain codes to use for this single request.  If not specified, the default from the configured <see cref="BlockCypherOptions" />.
    /// If that is also not specified, default will be BitcoinMain
    /// </summary>
    /// <remarks>
    /// Bitcoin, Dash, Dogecoin, etc. https://www.blockcypher.com/dev/bitcoin/#restful-resources
    /// </remarks>

    [PathVariable]
    public CoinChain? CoinChain { get; set; }
}

