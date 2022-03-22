using BlockCypher.Clients.Abstractions;

namespace BlockCypher.Clients;

public class BlockCypherClient : IBlockCypherClient
{
    public BlockCypherClient(IBlockchainApi blockchainApi, IAddressApi addressApi, ITransactionApi transactionApi)
    {
        BlockchainApi = blockchainApi;
        AddressApi = addressApi;
        TransactionApi = transactionApi;
    }

    /// <inheritdoc />
    public IBlockchainApi BlockchainApi { get; }

    /// <inheritdoc />
    public IAddressApi AddressApi { get; }

    /// <inheritdoc />
    public ITransactionApi TransactionApi { get; }
}