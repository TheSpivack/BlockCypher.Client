namespace BlockCypher.Objects;

/// <summary>
/// A WitnessToSignTx is created when creating a transaction which spend a P2WPKH input and includeToSignTx is set to true.
/// </summary>
public class WitnessToSignTx : BaseObject
{
    /// <summary>
    /// Version of the transaction.
    /// </summary>
    public int Version { get; set; }

    /// <summary>
    /// Hash of the previous output.
    /// </summary>
    public string HashPrevouts { get; set; } = null!;

    /// <summary>
    /// Hash sequence.
    /// </summary>
    public string HashSequence { get; set; } = null!;

    /// <summary>
    /// Hash of the outpoint.
    /// </summary>
    public string Outpoint { get; set; } = null!;

    /// <summary>
    /// Outpoint index.
    /// </summary>
    public int OutpointIndex { get; set; }

    /// <summary>
    /// Script code of the input.
    /// </summary>
    public string ScriptCode { get; set; } = null!;

    /// <summary>
    /// Value of the output spent by this input.
    /// </summary>
    public int Value { get; set; }

    /// <summary>
    /// Sequence number of the input.
    /// </summary>
    public int Sequence { get; set; }

    /// <summary>
    /// Hash of the output.
    /// </summary>
    public string HashOutputs { get; set; } = null!;

    /// <summary>
    /// Lock time of the transaction.
    /// </summary>
    public long LockTime { get; set; }

    /// <summary>
    /// sighash type of the signature.
    /// </summary>
    public int SighashType { get; set; }
}