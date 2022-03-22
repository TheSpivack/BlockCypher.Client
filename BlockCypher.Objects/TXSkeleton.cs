using System;

namespace BlockCypher.Objects;

/// <summary>
/// A TXSkeleton is a convenience/wrapper Object that's used primarily when Creating Transactions through the New and Send endpoints.
/// </summary>
public class TXSkeleton
{
    /// <summary>
    /// A temporary TX, usually returned fully filled but missing input scripts.
    /// </summary>
    public TX Tx { get; set; } = null!;

    /// <summary>
    /// Array of signatures corresponding to all the data in tosign, typically provided by you.
    /// </summary>
    public string[] Signatures { get; set; } = Array.Empty<string>();

    /// <summary>
    /// Array of public keys corresponding to each signature. In general, these are provided by you, and correspond to the signatures you provide.
    /// </summary>
    public string[] Pubkeys { get; set; } = Array.Empty<string>();

    /// <summary>
    /// Array of hex-encoded, work-in-progress transactions; optionally returned to validate the tosign data locally.
    /// </summary>
    public string[]? TosignTx { get; set; }

    /// <summary>
    /// Array of errors in the form "error":"description-of-error". This is only returned if there was an error in any stage of transaction generation, and is usually accompanied by a HTTP 400 code.
    /// </summary>
    public string[]? Errors { get; set; }
}