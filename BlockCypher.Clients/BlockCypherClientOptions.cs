using BlockCypher.Clients.Models;

namespace BlockCypher.Clients;

public class BlockCypherClientOptions
{
    /// <summary>
    /// We want everyone to try BlockCypher with as little friction as possible, which is why you don't need a token for any read-only GET calls. Please register for a user token if you want to use POST and DELETE calls. Once you have your token, you can append it to all your requests like any other URL parameter if you're using cURL, or through the appropriate method in the language SDK you're using.
    /// </summary>
    /// <remarks>
    /// https://www.blockcypher.com/dev/bitcoin/#rate-limits-and-tokens
    /// </remarks>
    public string? Token { get; set; }

    /// <summary>
    /// Default <see cref="CoinChain"/> to use for all requests.  Can be overriden per-request.  If not specified, BitcoinMain will be used
    /// </summary>
    public CoinChain? DefaultCoinChain { get; set; }

    /// <summary>
    /// Base URL to use for all requests.  You shouldn't need to override this :)
    /// </summary>
    public string BaseUrl { get; set; } = "https://api.blockcypher.com/";

    /// <summary>
    /// All API calls are versioned, and the current BlockCypher API is v1. We will never introduce any breaking changes within v1, but we may add new, non-breaking features from time to time.
    /// </summary>
    public string ApiVersion { get; set; } = "v1";


}