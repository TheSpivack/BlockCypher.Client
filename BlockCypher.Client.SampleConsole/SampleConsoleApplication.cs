using BlockCypher.Clients.Abstractions;
using BlockCypher.Clients.Models;

namespace BlockCypher.Client.SampleConsole;

public class SampleConsoleApplication : IConsoleApplication
{
    private readonly IBlockCypherClient _blockCypherClient;

    public SampleConsoleApplication(IBlockCypherClient blockCypherClient)
    {
        _blockCypherClient = blockCypherClient;
    }

    public async Task<int> ExecuteAsync(string[] args)
    {
        var blockChain = await _blockCypherClient.BlockchainApi.ChainEndpoint();

        Console.WriteLine(blockChain.ToJsonString());

        return 0;
    }
}