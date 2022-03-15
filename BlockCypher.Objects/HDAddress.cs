namespace BlockCypher.Objects;

/// <summary>
/// An HD Address object contains an address and its BIP32 HD path (location of the address in the HD tree). It also contains the hex-encoded public key when returned from the Derive Address in Wallet endpoint.
/// </summary>
public class HDAddress : BaseObject
{
    /// <summary>
    /// Standard address representation.
    /// </summary>
    public string Address { get; set; } = null!;

    /// <summary>
    /// The BIP32 path of the HD address.
    /// </summary>
    public string Path { get; set; } = null!;

    /// <summary>
    /// Contains the hex-encoded public key if returned by Derive Address in Wallet endpoint.
    /// </summary>
    public string? Public { get; set; }
}