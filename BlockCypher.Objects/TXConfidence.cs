using System;

namespace BlockCypher.Objects;

/// <summary>
/// A TXConfidence represents information about the confidence that an unconfirmed transaction will make it into the next block.Typically used as a return object from the Transaction Confidence Endpoint.
/// </summary>
public class TXConfidence
{
    /// <summary>
    /// The age of the transaction in milliseconds, based on the earliest time BlockCypher saw it relayed in the network.
    /// </summary>
    public int AgeMillis { get; set; }

    /// <summary>
    /// Number of peers that have sent this transaction to BlockCypher; only positive for unconfirmed transactions. -1 for confirmed transactions.
    /// </summary>
    public int ReceiveCount { get; set; }

    /// <summary>
    /// A number from 0 to 1 representing BlockCypher's confidence that the transaction won't be double-spent against.
    /// </summary>
    public float Confidence { get; set; }

    /// <summary>
    /// The hash of the transaction. While reasonably unique, using hashes as identifiers may be unsafe.
    /// </summary>
    public string Txhash { get; set; } = null!;

    /// <summary>
    /// The BlockCypher URL one can use to query more detailed information about this transaction.
    /// </summary>
    public Uri Url { get; set; } = null!;
}