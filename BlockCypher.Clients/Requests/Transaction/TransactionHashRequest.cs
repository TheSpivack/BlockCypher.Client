using System;
using System.Collections.Generic;
using System.Text;

namespace BlockCypher.Clients.Requests.Transaction;

public class TransactionHashRequest : BlockCypherRequest
{
    /// <summary>
    /// Filters TXInputs/TXOutputs, if unset, default is 20.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Filters TX to only include TXInputs from this input index and above.
    /// </summary>
    public int? Instart { get; set; }

    /// <summary>
    /// Filters TX to only include TXOutputs from this output index and above.
    /// </summary>
    public int? Outstart { get; set; }

    /// <summary>
    /// <strong>Litecoin Only.</strong> Replaces P2SH prefix with legacy 3 instead of M. Disabled by default.
    /// </summary>
    public bool? Legacyaddrs { get; set; }

    /// <summary>
    /// If true, includes hex-encoded raw transaction; false by default.
    /// </summary>
    public bool? IncludeHex { get; set; }

    /// <summary>
    /// If true, includes the confidence attribute (useful for unconfirmed transactions). For more info about this figure, check the Confidence Factor documentation.
    /// </summary>
    public bool? IncludeConfidence { get; set; }
}