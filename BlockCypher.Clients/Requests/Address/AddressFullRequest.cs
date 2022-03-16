﻿namespace BlockCypher.Clients.Requests.Address;

public class AddressFullRequest : BlockCypherRequest
{
    /// <summary>
    /// Filters response to only include transactions below before height in the blockchain.
    /// </summary>
    public int? Before { get; set; }

    /// <summary>
    /// Filters response to only include transactions above after height in the blockchain.
    /// </summary>
    public int? After { get; set; }

    /// <summary>
    /// limit sets the minimum number of returned TXRefs; there can be less if there are less than limit TXRefs associated with this address, but there can be more in the rare case of more TXRefs in the block at the bottom of your call.This ensures paging by block height never misses TXRefs. Defaults to 200, maximum is 2000.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// This filters the TXInputs/TXOutputs within the returned TXs to include a maximum of txlimit items.
    /// </summary>
    public int? Txlimit { get; set; }

    /// <summary>
    /// If set, only returns the balance and TXRefs that have at least this number of confirmations.
    /// </summary>
    public int? Confirmations { get; set; }

    /// <summary>
    /// Filters response to only include TXRefs above confidence in percent; e.g., if this is set to 99, will only return TXRefs with 99% confidence or above(including all confirmed TXRefs). For more detail on confidence, check the Confidence Factor documentation.
    /// </summary>
    public int? Confidence { get; set; }

    /// <summary>
    /// Litecoin Only. Replaces P2SH prefix with legacy 3 instead of M. Disabled by default.
    /// </summary>
    public bool? Logacyaddrs { get; set; }

    /// <summary>
    /// If true, includes hex-encoded raw transaction for each TX; false by default.
    /// </summary>
    public bool? IncludeHex { get; set; }

    /// <summary>
    /// If true, includes the confidence attribute (useful for unconfirmed transactions) within returned TXs. For more info about this figure, check the Confidence Factor documentation.
    /// </summary>
    public bool? IncludeConfidence { get; set; }

    /// <summary>
    /// If omitWalletAddresses is true and you're querying a Wallet or HDWallet, the response will omit address information (useful to speed up the API call for larger wallets).
    /// </summary>
    public bool? OmitWalletAddresses { get; set; }
}