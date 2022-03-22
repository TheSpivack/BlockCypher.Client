using System;

namespace BlockCypher.Objects;

/// <summary>
/// A TX represents the current state of a particular transaction from either a Block within a Blockchain, or an unconfirmed transaction that has yet to be included in a Block. Typically returned from the Unconfirmed Transactions and Transaction Hash endpoints.
/// </summary>
public class TX
{
    /// <summary>
    /// Height of the block that contains this transaction.If this is an unconfirmed transaction, it will equal -1.
    /// </summary>
    public int BlockHeight { get; set; }

    /// <summary>
    /// The hash of the transaction. While reasonably unique, using hashes as identifiers may be unsafe.
    /// </summary>
    public string Hash { get; set; } = null!;

    /// <summary>
    /// Array of bitcoin public addresses involved in the transaction.
    /// </summary>
    public string[] Addresses { get; set; } = Array.Empty<string>();

    /// <summary>
    /// The total number of satoshis exchanged in this transaction.
    /// </summary>
    public long Total { get; set; }

    /// <summary>
    /// The total number of fees---in satoshis---collected by miners in this transaction.
    /// </summary>
    public long Fees { get; set; }

    /// <summary>
    /// The size of the transaction in bytes.
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    /// The virtual size of the transaction in bytes.
    /// </summary>
    public int Vsize { get; set; }

    /// <summary>
    /// The likelihood that this transaction will make it to the next block; reflects the preference level miners have to include this transaction.Can be high, medium or low.
    /// </summary>
    public string Preference { get; set; } = null!;

    /// <summary>
    /// Address of the peer that sent BlockCypher's servers this transaction.
    /// </summary>
    public string RelayedBy { get; set; } = null!;

    /// <summary>
    /// Time this transaction was received by BlockCypher's servers.
    /// </summary>
    public DateTime ReceivedTime { get; set; }

    /// <summary>
    /// Version number, typically 1 for Bitcoin transactions.
    /// </summary>
    public int Ver { get; set; }

    /// <summary>
    /// Time when transaction can be valid. Can be interpreted in two ways: if less than 500 million, refers to block height. If more, refers to Unix epoch time.
    /// </summary>
    public long LockTime { get; set; }

    /// <summary>
    /// true if this is an attempted double spend; false otherwise.
    /// </summary>
    public bool DoubleSpend { get; set; }

    /// <summary>
    /// Total number of inputs in the transaction.
    /// </summary>
    public int VinSz { get; set; }

    /// <summary>
    /// Total number of outputs in the transaction.
    /// </summary>
    public int VoutSz { get; set; }

    /// <summary>
    /// Number of subsequent blocks, including the block the transaction is in. Unconfirmed transactions have 0 confirmations.
    /// </summary>
    public int Confirmations { get; set; }

    /// <summary>
    /// TXInput Array, limited to 20 by default.
    /// </summary>
    public TXInput[] Inputs { get; set; } = Array.Empty<TXInput>();

    /// <summary>
    /// TXOutput Array, limited to 20 by default.
    /// </summary>
    public TXOutput[] Outputs { get; set; } = Array.Empty<TXOutput>();

    /// <summary>
    /// Returns true if this transaction has opted in to Replace-By-Fee (RBF), either true or not present. You can read more about Opt-In RBF here.
    /// </summary>
    public bool? OptInRbf { get; set; }

    /// <summary>
    /// The percentage chance this transaction will not be double-spent against, if unconfirmed. For more information, check the section on Confidence Factor.
    /// </summary>
    public float? Confidence { get; set; }

    /// <summary>
    /// Time at which transaction was included in a block; only present for confirmed transactions.
    /// </summary>
    public DateTime? Confirmed { get; set; }

    /// <summary>
    /// Number of peers that have sent this transaction to BlockCypher; only present for unconfirmed transactions.
    /// </summary>
    public int? ReceiveCount { get; set; }

    /// <summary>
    /// Address BlockCypher will use to send back your change, if you constructed this transaction. If not set, defaults to the address from which the coins were originally sent.
    /// </summary>
    public string? ChangeAddress { get; set; }

    /// <summary>
    /// Hash of the block that contains this transaction; only present for confirmed transactions.
    /// </summary>
    public string? BlockHash { get; set; }

    /// <summary>
    /// Canonical, zero - indexed location of this transaction in a block; only present for confirmed transactions.
    /// </summary>
    public int? BlockIndex { get; set; }

    /// <summary>
    /// If this transaction is a double - spend(i.e.double_spend == true) then this is the hash of the transaction it's double-spending.
    /// </summary>
    public string? DoubleOf { get; set; }

    /// <summary>
    /// Returned if this transaction contains an OP_RETURN associated with a known data protocol. Data protocols currently detected: blockchainid; openassets; factom; colu; coinspark; omni
    /// </summary>
    public string? DataProtocol { get; set; }

    /// <summary>
    /// Hex - encoded bytes of the transaction, as sent over the network.
    /// </summary>
    public string? Hex { get; set; }

    /// <summary>
    /// If there are more transaction inptus that couldn't fit into the TXInput array, this is the BlockCypher URL to query the next set of TXInputs (within a TX object).
    /// </summary>
    public Uri? NextInputs { get; set; }

    /// <summary>
    /// If there are more transaction outputs that couldn't fit into the TXOutput array, this is the BlockCypher URL to query the next set of TXOutputs(within a TX object).
    /// </summary>
    public Uri? NextOutputs { get; set; }
}