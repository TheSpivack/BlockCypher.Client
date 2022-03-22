using System;

namespace BlockCypher.Objects;

/// <summary>
/// A TXInput represents an input consumed within a transaction. Typically found within an array in a TX. In most cases, TXInputs are from previous UTXOs, with the most prominent exceptions being attempted double-spend and coinbase inputs.
/// </summary>
public class TXInput
{
    /// <summary>
    /// The previous transaction hash where this input was an output.Not present for coinbase transactions.
    /// </summary>
    public string? PrevHash { get; set; }

    /// <summary>
    /// The index of the output being spent within the previous transaction.Not present for coinbase transactions.
    /// </summary>
    public int? OutputIndex { get; set; }

    /// <summary>
    /// The value of the output being spent within the previous transaction.Not present for coinbase transactions.
    /// </summary>
    public long? OutputValue { get; set; }

    /// <summary>
    /// The type of script that encumbers the output corresponding to this input.
    /// </summary>
    public string ScriptType { get; set; } = null!;

    /// <summary>
    /// Raw hexadecimal encoding of the script.
    /// </summary>
    public string Script { get; set; } = null!;

    /// <summary>
    /// An array of public addresses associated with the output of the previous transaction.
    /// </summary>
    public string[] Addresses { get; set; } = Array.Empty<string>();

    /// <summary>
    /// Legacy 4-byte sequence number, not usually relevant unless dealing with locktime encumbrances.
    /// </summary>
    public int? Sequence { get; set; }

    /// <summary>
    /// Number of confirmations of the previous transaction for which this input was an output. Currently, only returned in unconfirmed transactions.
    /// </summary>
    public int? Age { get; set; }

    /// <summary>
    /// Name of Wallet or HDWallet from which to derive inputs. Only used when constructing transactions via the Creating Transactions process.
    /// </summary>
    public string? WalletName { get; set; }

    /// <summary>
    /// Token associated with Wallet or HDWallet used to derive inputs. Only used when constructing transactions via the Creating Transactions process.
    /// </summary>
    public string? WalletToken { get; set; }
}