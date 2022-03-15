using BlockCypher.Clients.Abstractions;

namespace BlockCypher.Clients;

public class BlockCypherClient : IBlockCypherClient
{
    public BlockCypherClient(IBlockchainApi blockchainApi, IAddressApi addressApi)
    {
        BlockchainApi = blockchainApi;
        AddressApi = addressApi;
    }

    /// <inheritdoc />
    public IBlockchainApi BlockchainApi { get; }

    /// <inheritdoc />
    public IAddressApi AddressApi { get; }
}