using BlockCypher.Clients;
using BlockCypher.Clients.Abstractions;
using BlockCypher.Clients.Requests;

namespace BlockCypher.Client.SampleConsole;

public class BlockchainCommandRunner : ICommandRunner
{
    private readonly IBlockCypherClient _blockCypherClient;

    public BlockchainCommandRunner(IBlockCypherClient blockCypherClient)
    {
        _blockCypherClient = blockCypherClient;
    }

    public async Task RunAsync(string command, CoinChain? coinChain)
    {
        switch (command)
        {
            case Commands.Blockchain.CHAIN:
                await ChainEndpoint(coinChain);
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(command),
                    $"Value received: '{command}'. Acceptable values: chain|hash|height|feature");
        }
    }

    private async Task ChainEndpoint(CoinChain? coinChain)
    {
        Console.WriteLine("Calling BlockchainApi.ChainEndpoint()");
        var blockChain = await _blockCypherClient.BlockchainApi.ChainEndpoint(new BlockCypherRequest { CoinChain = coinChain });
        Console.WriteLine($"OK: {blockChain.Name} - {blockChain.Time:R} - {blockChain.Hash}");
    }
}