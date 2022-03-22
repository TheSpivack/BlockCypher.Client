using System;

namespace BlockCypher.Objects;

/// <summary>
/// A TXOutput represents an output created by a transaction. Typically found within an array in a <see cref="TX" />.
/// </summary>
public class TXOutput
{
    /// <summary>
    /// Value in this transaction output, in satoshis.
    /// </summary>
    public long Value { get; set; }

    /// <summary>
    /// Raw hexadecimal encoding of the encumbrance script for this output.
    /// </summary>
    public string Script { get; set; } = null!;

    /// <summary>
    /// Addresses that correspond to this output; typically this will only have a single address, and you can think of this output as having "sent" value to the address contained herein.
    /// </summary>
    public string[] Addresses { get; set; } = Array.Empty<string>();

    /// <summary>
    /// The type of encumbrance script used for this output.
    /// </summary>
    public string ScriptType { get; set; } = null!;

    /// <summary>
    /// The transaction hash that spent this output.Only returned for outputs that have been spent.The spending transaction may be unconfirmed.
    /// </summary>
    public string? SpentBy { get; set; }

    /// <summary>
    /// A hex-encoded representation of an OP_RETURN data output, without any other script instructions.Only returned for outputs whose script_type is null-data.
    /// </summary>
    public string? DataHex { get; set; }

    /// <summary>
    /// An ASCII representation of an OP_RETURN data output, without any other script instructions.Only returned for outputs whose script_type is null-data and if its data falls into the visible ASCII range.
    /// </summary>
    public string? DataString { get; set; }
}