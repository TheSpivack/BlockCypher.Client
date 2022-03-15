using BlockCypher.Clients.Abstractions;

namespace BlockCypher.Clients;

public class BlockCypherClient : IBlockCypherClient
{
    public BlockCypherClient(IBlockchainApi blockchainApi)
    {
        BlockchainApi = blockchainApi;
    }

    public IBlockchainApi BlockchainApi { get; }
}