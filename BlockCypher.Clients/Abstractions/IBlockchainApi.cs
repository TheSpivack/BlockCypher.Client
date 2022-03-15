using System.Threading.Tasks;
using BlockCypher.Clients.Models;
using BlockCypher.Clients.Models.Blockchain;
using BlockCypher.Objects;
using Newtonsoft.Json.Linq;

namespace BlockCypher.Clients.Abstractions;

/// <summary>
/// Interface for the Blockchain API.  https://www.blockcypher.com/dev/bitcoin/#blockchain-api
/// <para>The first component---and highest level---of the BlockCypher API allows you to query general information about blockchain and blocks based on the coin/chain resource you've selected for your endpoints.</para>
/// <para>If you're new to blockchains, you can think of the blockchain itself as an immutable, distributed ledger. Each block in the blockchain is like a "page" in the ledger containing information about transactions between parties. A great place to start understanding the mechanics behind blockchains is the original Bitcoin whitepaper.</para>
/// </summary>
public interface IBlockchainApi
{
    /// <summary>
    /// General information about a blockchain is available by GET-ing the base resource.
    /// </summary>
    /// <returns>
    /// The returned object contains a litany of information about the blockchain, including its height, the time/hash of the latest block, and more. For more detailed information about the data returned, check the <see cref="Blockchain"/> object.
    /// </returns>
    public Task<Blockchain> ChainEndpoint(BlockCypherRequest? request = null);

    /// <summary>
    /// If you want more data on a particular block, you can use the Block Hash endpoint.
    /// </summary>
    /// <returns>
    /// The returned object contains information about the block, including its height, the total amount of satoshis transacted within it, the number of transactions in it, transaction hashes listed in the canonical order in which they appear in the block, and more. For more detail on the data returned, check the <see cref="Block" /> object.
    /// </returns>
    public Task<Block> BlockHashEndpoint(GetByBlockHashRequest request);

    /// <summary>
    /// You can also query for information on a block using its height, using the same resource but with a different variable type.
    /// </summary>
    /// <returns>
    /// As above, the returned object contains information about the block, including its hash, the total amount of satoshis transacted within it, the number of transactions in it, transaction hashes listed in the canonical order in which they appear in the block, and more. For more detail on the data returned, check the <see cref="Block" /> object.
    /// </returns>
    public Task<Block> BlockHeightEndpoint(GetByBlockHeightRequest request);

    /// <summary>
    /// If you're curious about the adoption of upgrade features on a blockchain, you can use this endpoint to get some information about its state on the network. For example, for bip65 on bitcoin, you could check its state via this URL: https://api.blockcypher.com/v1/btc/main/feature/bip65?token=YOURTOKEN. Generally speaking, for bitcoin, this will follow the form of tracking bipXX (where XX = a number), but the list of features we're tracking is always changing.
    /// </summary>
    /// <returns>String version of the respone because it's not defined!</returns>
    public Task<string> FeatureEndpoint(GetFeatureRequest request);
}