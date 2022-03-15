using System;

namespace BlockCypher.Objects;

/// <summary>
/// A TXRef object represents summarized data about a transaction input or output. Typically found in an array within an Address object, which is usually returned from the standard Address Endpoint.
/// </summary>
public class TXRef : BaseObject
{
    /// <summary>
    /// The address associated with this transaction input/output.Only returned when querying an address endpoint via a wallet/HD wallet name.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Height of the block that contains this transaction input/output.If it's unconfirmed, this will equal -1.
    /// </summary>
    public int BlockHeight { get; set; }

    /// <summary>
    /// The hash of the transaction containing this input/output.While reasonably unique, using hashes as identifiers may be unsafe.
    /// </summary>
    public string TxHash { get; set; } = null!;

    /// <summary>
    /// Index of this input in the enclosing transaction.It's a negative number for an output.
    /// </summary>
    public int TxInputN { get; set; }

    /// <summary>
    /// Index of this output in the enclosing transaction.It's a negative number for an input.
    /// </summary>
    public int TxOutputN { get; set; }

    /// <summary>
    /// The value transfered by this input/output in satoshis exchanged in the enclosing transaction.
    /// </summary>
    public long Value { get; set; }

    /// <summary>
    /// The likelihood that this transaction will make it to the next block; reflects the preference level miners have to include this transaction.Can be high, medium or low.
    /// </summary>
    public string Preference { get; set; } = null!;

    /// <summary>
    /// true if this is an output and was spent. If it's an input, or an unspent output, it will be false.
    /// </summary>
    public bool Spent { get; set; }

    /// <summary>
    /// true if this is an attempted double spend; false otherwise.
    /// </summary>
    public bool DoubleSpend { get; set; }

    /// <summary>
    /// Number of subsequent blocks, including the block the transaction is in. Unconfirmed transactions have 0 confirmations.
    /// </summary>
    public int Confirmations { get; set; }

    /// <summary>
    /// Raw, hex-encoded script of this input/output.
    /// </summary>
    public string? Script { get; set; }

    /// <summary>
    /// The past balance of the parent address the moment this transaction was confirmed. Not present for unconfirmed transactions.
    /// </summary>
    public long? RefBalance { get; set; }

    /// <summary>
    /// The percentage chance this transaction will not be double-spent against, if unconfirmed. For more information, check the section on Confidence Factor.
    /// </summary>
    public float? Confidence { get; set; }

    /// <summary>
    /// Time at which transaction was included in a block; only present for confirmed transactions.
    /// </summary>
    public DateTime? Confirmed { get; set; }

    /// <summary>
    /// The transaction hash that spent this output. Only returned for outputs that have been spent. The spending transaction may be unconfirmed.
    /// </summary>
    public string? SpentBy { get; set; }

    /// <summary>
    /// Time this transaction was received by BlockCypher's servers; only present for unconfirmed transactions.
    /// </summary>
    public DateTime? Received { get; set; }

    /// <summary>
    /// Number of peers that have sent this transaction to BlockCypher; only present for unconfirmed transactions.
    /// </summary>
    public int? ReceiveCount { get; set; }

    /// <summary>
    /// If this transaction is a double-spend (i.e. double_spend == true) then this is the hash of the transaction it's double-spending.
    /// </summary>
    public string? DoubleOf { get; set; }
}