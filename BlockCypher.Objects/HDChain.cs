using System;

namespace BlockCypher.Objects;

/// <summary>
/// An array of HDChains are included in every HDWallet and returned from the Get Wallet, Get Wallet Addresses and Derive Address in Wallet endpoints.
/// </summary>
public class HDChain : BaseObject
{
    /// <summary>
    /// Array of HDAddresses associated with this subchain.
    /// </summary>
    public HDAddress[] ChainAddresses { get; set; } = Array.Empty<HDAddress>();

    /// <summary>
    /// Index of the subchain, returned if the wallet has subchains.
    /// </summary>
    public int? Index { get; set; }
}