using System;

namespace BlockCypher.Objects;

/// <summary>
/// An HDWallet contains addresses derived from a single seed. Like normal wallets, it can be used interchangeably with all the Address API endpoints, and in many places that require addresses, like when Creating Transactions.
/// </summary>
public class HDWallet : BaseObject
{
    /// <summary>
    /// User token associated with this HD wallet.
    /// </summary>
    public string Token { get; set; } = null!;

    /// <summary>
    /// Name of the HD wallet.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// List of HD chains associated with this wallet, each containing HDAddresses.A single chain is returned if the wallet has no subchains.
    /// </summary>
    public HDChain[] Chains { get; set; } = Array.Empty<HDChain>();

    /// <summary>
    /// true for HD wallets, not present for normal wallets.
    /// </summary>
    public bool Hd { get; set; }

    /// <summary>
    /// The extended public key all addresses in the HD wallet are derived from.It's encoded in BIP32 format
    /// </summary>
    public string ExtendedPublicKey { get; set; } = null!;

    /// <summary>
    /// Returned for HD wallets created with subchains.
    /// </summary>
    public int[]? SubchainIndexes { get; set; } = Array.Empty<int>();
}