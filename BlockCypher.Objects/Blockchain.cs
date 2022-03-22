using System;

namespace BlockCypher.Objects;

/// <summary>
/// A Blockchain represents the current state of a particular blockchain from the  Coin/Chain resources that BlockCypher supports. Typically returned from the Chain API endpoint.
/// </summary>
public class Blockchain
{
    /// <summary>
    /// The name of the blockchain represented, in the form of $COIN.$CHAIN.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// The current height of the blockchain; i.e., the number of blocks in the blockchain.
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// The hash of the latest confirmed block in the blockchain; in Bitcoin, the hashing function is SHA256(SHA256(block)).
    /// </summary>
    public string Hash { get; set; } = null!;

    /// <summary>
    /// The time of the latest update to the blockchain; typically when the latest block was added.
    /// </summary>
    public DateTime Time { get; set; }

    /// <summary>
    /// The BlockCypher URL to query for more information on the latest confirmed block; returns a <see cref="Block"/>.
    /// </summary>
    public Uri LatestUrl { get; set; } = null!;

    /// <summary>
    /// The hash of the second-to-latest confirmed block in the blockchain.
    /// </summary>
    public string PreviousHash { get; set; } = null!;

    /// <summary>
    /// The BlockCypher URL to query for more information on the second-to-latest confirmed block; returns a <see cref="Block"/>.
    /// </summary>
    public Uri PreviousUrl { get; set; } = null!;

    /// <summary>
    /// N/A, will be deprecated soon.
    /// </summary>
    public int PeerCount { get; set; }

    /// <summary>
    /// A rolling average of the fee (in satoshis) paid per kilobyte for transactions to be confirmed within 1 to 2 blocks.
    /// </summary>
    public int HighFeePerKb { get; set; }

    /// <summary>
    /// A rolling average of the fee (in satoshis) paid per kilobyte for transactions to be confirmed within 3 to 6 blocks.
    /// </summary>
    public int MediumFeePerKb { get; set; }

    /// <summary>
    /// A rolling average of the fee (in satoshis) paid per kilobyte for transactions to be confirmed in 7 or more blocks.
    /// </summary>
    public int LowFeePerKb { get; set; }

    /// <summary>
    /// Number of unconfirmed transactions in memory pool (likely to be included in next block).
    /// </summary>
    public int UnconfirmedCount { get; set; }

    /// <summary>
    /// The current height of the latest fork to the blockchain; when no competing blockchain fork present, not returned with endpoints that return Blockchains.
    /// </summary>
    /// <remarks>Optional</remarks>
    public int? LastForkHeight { get; set; }

    /// <summary>
    /// Optional The hash of the latest confirmed block in the latest fork of the blockchain; when no competing blockchain fork present, not returned with endpoints that return Blockchains.
    /// </summary>
    /// <remarks>Optional</remarks>
    public string? LastForkHash { get; set; }
}