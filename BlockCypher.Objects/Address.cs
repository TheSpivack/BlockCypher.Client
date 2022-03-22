using System;
using System.Collections.Generic;

namespace BlockCypher.Objects;

/// <summary>
/// An Address represents a public address on a blockchain, and contains information about the state of balances and transactions related to this address. Typically returned from the Address Balance, Address, and Address Full Endpoint.
/// </summary>
public class AddressObj
{
    /// <summary>
    /// The requested address.Not returned if querying a wallet/HD wallet.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// The requested wallet object. Only returned if querying by wallet name instead of public address.
    /// </summary>
    public Wallet? Wallet { get; set; }

    /// <summary>
    /// The requested HD wallet object. Only returned if querying by HD wallet name instead of public address.
    /// </summary>
    public HDWallet? HdWallet { get; set; }

    /// <summary>
    /// Total amount of confirmed satoshis received by this address.
    /// </summary>
    public long TotalReceived { get; set; }

    /// <summary>
    /// Total amount of confirmed satoshis sent by this address.
    /// </summary>
    public long TotalSent { get; set; }

    /// <summary>
    /// Balance of confirmed satoshis on this address.This is the difference between outputs and inputs on this address, but only for transactions that have been included into a block (i.e., for transactions whose confirmations > 0).
    /// </summary>
    public long Balance { get; set; }

    /// <summary>
    /// Balance of unconfirmed satoshis on this address. Can be negative (if unconfirmed transactions are just spending outputs). Only unconfirmed transactions(haven't made it into a block) are included.
    /// </summary>
    public long UnconfirmedBalance { get; set; }

    /// <summary>
    /// Total balance of satoshis, including confirmed and unconfirmed transactions, for this address.
    /// </summary>
    public long FinalBalance { get; set; }

    /// <summary>
    /// Number of confirmed transactions on this address.Only transactions that have made it into a block (confirmations > 0) are counted.
    /// </summary>
    public int NTx { get; set; }

    /// <summary>
    /// Number of unconfirmed transactions for this address.Only unconfirmed transactions (confirmations == 0) are counted.
    /// </summary>
    public int UnconfirmedNTx { get; set; }

    /// <summary>
    /// Final number of transactions, including confirmed and unconfirmed transactions, for this address.
    /// </summary>
    public int FinalNTx { get; set; }

    /// <summary>
    /// To retrieve base URL transactions. To get the full URL, concatenate this URL with a transaction's hash.
    /// </summary>
    public Uri? TxUrl { get; set; }

    /// <summary>
    /// Array of full transaction details associated with this address.Usually only returned from the Address Full Endpoint.
    /// </summary>
    public TX[]? Txs { get; set; }

    /// <summary>
    /// Array of transaction inputs and outputs for this address.Usually only returned from the standard Address Endpoint.
    /// </summary>
    public TXRef[]? Txrefs { get; set; }

    /// <summary>
    /// All unconfirmed transaction inputs and outputs for this address.Usually only returned from the standard Address Endpoint.
    /// </summary>
    public TXRef[]? UnconfirmedTxrefs { get; set; }

    /// <summary>
    /// If true, then the Address object contains more transactions than shown. Useful for determining whether to poll the API for more transaction information.
    /// </summary>
    public bool? hasMore { get; set; }
}