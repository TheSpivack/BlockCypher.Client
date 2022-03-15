namespace BlockCypher.Clients.Abstractions;

/// <summary>
/// Interface containing references to all BlockCypher APIs
/// </summary>
public interface IBlockCypherClient
{
    public IBlockchainApi BlockchainApi { get; }
}