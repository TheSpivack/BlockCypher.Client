namespace BlockCypher.Clients.Requests.Address;

public class GenerateAddressRequest : BlockCypherRequest
{
    /// <summary>
    /// Whether or not to generate a p2wpkh bech32 address. Default is false.
    /// </summary>
    public bool? Bech32 { get; set; }
}