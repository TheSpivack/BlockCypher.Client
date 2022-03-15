using BlockCypher.Clients.Models.Attributes;

namespace BlockCypher.Clients.Models.Address;

public class AddressBalanceRequest : BlockCypherRequest
{
    /// <summary>
    /// ADDRESS is a string representing the public address (or wallet/HD wallet name) you're interested in querying, for example: 1DEP8i3QJCsomS4BSMY2RpU1upv62aGvhD
    /// </summary>

    [PathVariable]
    public string Address { get; set; } = null!;

    /// <summary>
    /// If omitWalletAddresses is true and you're querying a Wallet or HDWallet, the response will omit address information (useful to speed up the API call for larger wallets).
    /// </summary>

    [QueryStringVariable]
    public bool? OmitWalletAddresses { get; set; }

}