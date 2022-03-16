namespace BlockCypher.Clients.Requests.Address;

public class AddressBalanceRequest : BlockCypherRequest
{
    /// <summary>
    /// If omitWalletAddresses is true and you're querying a Wallet or HDWallet, the response will omit address information (useful to speed up the API call for larger wallets).
    /// </summary>
    public bool? OmitWalletAddresses { get; set; }

}