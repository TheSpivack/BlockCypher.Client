namespace BlockCypher.Clients.Abstractions;

/// <summary>
/// Interface containing references to all BlockCypher APIs
/// </summary>
public interface IBlockCypherClient
{
    /// <inheritdoc cref="IBlockchainApi"/>
    public IBlockchainApi BlockchainApi { get; }

    /// <inheritdoc cref="IAddressApi"/>
    public IAddressApi AddressApi { get; }
}