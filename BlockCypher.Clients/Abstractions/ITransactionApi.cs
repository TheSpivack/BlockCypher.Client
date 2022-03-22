using System.Collections.Generic;
using System.Threading.Tasks;
using BlockCypher.Clients.Requests;
using BlockCypher.Clients.Requests.Transaction;
using BlockCypher.Objects;

namespace BlockCypher.Clients.Abstractions;

/// <summary>
/// <para>BlockCypher's Transaction API allows you to look up information about unconfirmed transactions, query transactions based on hash, create and propagate your own transactions, including multisignature transactions, and embed data on the blockchain---all based on the coin/chain resource you've selected for your endpoints.</para>
/// <para>If you're new to blockchains, the idea of transactions is relatively self-explanatory. Here's what's going on underneath the hood: a transaction takes previous "unspent transaction outputs" (also known as UTXOs) as "transaction inputs" and creates new "locking scripts" on those inputs such that they are "sent" to new addresses (to become new UTXOs). While most of these public addresses are reference points for single private keys that can "unlock" the newly created UTXOs, occasionally they are sent to more exotic addresses through pay-to-script-hash, typically multisignature addresses.</para>
/// <para>Generally speaking, UTXOs are generated from previous transactions (except for Coinbase inputs).</para>
/// </summary>
public interface ITransactionApi
{
    /// <summary>
    /// The Transaction Hash Endpoint returns detailed information about a given transaction based on its hash.
    /// </summary>
    /// <param name="txHash">A string representing the hex-encoded transaction hash you're interested in querying, for example: f854aebae95150b379cc1187d848d58225f3c4157fe992bcd166f58bd5063449</param>
    /// <param name="request">Optional query string parameters for this endpoint.  Can also override the default coin/chain</param>
    /// <returns>
    /// The returned object contains detailed information about the transaction, including the value transfered, date received, and a full listing of inputs and outputs.
    /// </returns>
    public Task<TX> TransactionHash(string txHash, TransactionHashRequest? request = null);

    /// <summary>
    /// The Unconfirmed Transactions Endpoint returns an array of the latest transactions relayed by nodes in a blockchain that haven't been included in any blocks.
    /// <para>Due to transaction malleability it can be difficult to deal with transaction hashes before they've been confirmed in blocks. Use caution, and consider applying our Confidence Factor to mitigate potential issues.</para>
    /// </summary>
    /// <param name="request">Optional query string parameters for this endpoint.  Can also override the default coin/chain</param>
    /// <returns>
    /// The returned object is an array of transactions that haven't been included in blocks, arranged in reverse chronological order (latest is first, then older transactions follow).
    /// </returns>
    public Task<IEnumerable<TX>> UnconfirmedTransactions(UnconfirmedTransactionsRequest? request = null);

    /// <summary>
    /// <para>To use BlockCypher's two-endpoint transaction creation tool, first you need to provide the input address(es), output address, and value to transfer (in satoshis). Provide this in a partially-filled out TX request object.</para>
    /// <para>As you can see from the code example, you only need to provide a single public address within the addresses array of both the input and output of your TX request object. You also need to fill in the value with the amount you'd like to transfer from one address to another.</para>
    /// <para>If you'd like, you can even use a Wallet instead of addresses as your input. You just need to use two non-standard fields (your wallet_name and wallet_token) within the inputs array in your transaction, instead of addresses:</para>
    /// </summary>
    /// <param name="requestBody">As you can see from the code example, you only need to provide a single public address within the addresses array of both the input and output of your TX request object. You also need to fill in the value with the amount you'd like to transfer from one address to another.</param>
    /// <param name="request">Optional query string parameters for this endpoint.  Can also override the default coin/chain</param>
    /// <returns>
    /// As a return object, you'll receive a TXSkeleton containing a slightly-more complete TX alongside data you need to sign in the tosign array. You'll need this object for the next steps of the transaction creation process.
    /// </returns>
    public Task<TXSkeleton> NewTransaction(TX requestBody, NewTransactionRequest? request = null);

    /// <summary>
    /// Once you've finished signing the tosign array locally, put that (hex-encoded) data into the signatures array of the TXSkeleton. You also need to include the corresponding (hex-encoded) public key(s) in the pubkeys array, in the order of the addresses/inputs provided. Signature and public key order matters, so make sure they are returned in the same order as the inputs you provided.
    /// </summary>
    /// <param name="requestBody">The TXSkeleton returned from <see cref="NewTransaction"/> with the signatures added</param>
    /// <param name="request">Can override the default coin/chain</param>
    /// <returns>
    /// If the transaction was successful, you'll receive a TXSkeleton with the completed TX (which contains its final hash) and an HTTP Status Code 201.
    /// </returns>
    public Task<TXSkeleton> SendTransaction(TXSkeleton requestBody, BlockCypherRequest? request = null);

    /// <summary>
    /// If you'd prefer to use your own transaction library instead of the recommended path of our two-endpoint transaction generation we're still happy to help you propagate your raw transactions. Simply send your raw hex-encoded transaction to this endpoint and we'll leverage our huge network of nodes to propagate your transaction faster than anywhere else.
    /// </summary>
    /// <param name="txHex">a hex-encoded raw representation of your transaction, for example: 01000000011935b41d12936df99d322ac...000</param>
    /// <param name="request">Can override the default coin/chain</param>
    /// <returns>
    /// If it succeeds, you'll receive a decoded TX object and an HTTP Status Code 201. If you'd like, you can use the decoded transaction hash alongside an Event to track its progress in the network.
    /// </returns>
    public Task<TX> PushRawTransaction(string txHex, BlockCypherRequest? request = null);

    /// <summary>
    /// We also offer the ability to decode raw transactions without sending propagating them to the network; perhaps you want to double-check another client library or confirm that another service is sending proper transactions.
    /// </summary>
    /// <param name="txHex">a hex-encoded raw representation of your transaction, for example: 01000000011935b41d12936df99d322ac...000</param>
    /// <param name="request">Can override the default coin/chain</param>
    /// <returns>
    /// If it succeeds, you'll receive your decoded TX object.
    /// </returns>
    public Task<TX> DecodeRawTransaction(string txHex, BlockCypherRequest? request = null);

    /// <summary>
    /// This endpoint allows you to decode the tosign_tx only in the case of the spending of a native segwit input (P2WPKH). This allows you to double check the which input you are spending and the value transfered.
    /// </summary>
    /// <param name="witnessToSignTxHex">a hex-encoded raw given by the #creating-transactions when includeToSignTx is to true, for example: 01000000011935b41d12936df99d322ac...000</param>
    /// <param name="request">Can override the default coin/chain</param>
    /// <returns>
    /// If it succeeds, you'll receive your decoded WitnessToSignTx object.
    /// </returns>
    public Task<WitnessToSignTx> DecodeTransactionWitnessToSign(string witnessToSignTxHex, BlockCypherRequest? request = null);
}