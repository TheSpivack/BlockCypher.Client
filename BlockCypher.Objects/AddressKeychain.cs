namespace BlockCypher.Objects;

/// <summary>
/// An AddressKeychain represents an associated collection of public and private keys alongside their respective public address. Generally returned and used with the Generate Address Endpoint.
/// </summary>
public class AddressKeychain : BaseObject
{
    /// <summary>
    /// Standard address representation.
    /// </summary>
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Hex-encoded Public key.
    /// </summary>
    public string Public { get; set; } = string.Empty;

    /// <summary>
    /// Hex-encoded Private key.
    /// </summary>
    public string Private { get; set; } = string.Empty;

    /// <summary>
    /// Wallet import format, a common encoding for the private key.
    /// </summary>

    public string Wif { get; set; } = string.Empty;

    /// <summary>
    /// Optional Array of public keys to provide to generate a multisig address.
    /// </summary>
    public string[]? Pubkeys { get; set; }

    /// <summary>
    /// If generating a multisig address, the type of multisig script; typically "multisig-n-of-m", where n and m are integers.
    /// </summary>
    public string? ScriptType { get; set; }

    /// <summary>
    /// If generating an OAP address, this represents the parent blockchain's underlying address (the typical address listed above).
    /// </summary>
    public string? OriginalAddress { get; set; }

    /// <summary>
    /// The OAP address, if generated using the Generate Asset Address Endpoint.
    /// </summary>
    public string? OapAddress { get; set; }
}