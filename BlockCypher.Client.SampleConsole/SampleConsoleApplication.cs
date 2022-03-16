using BlockCypher.Clients.Abstractions;

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
        Console.WriteLine("Calling BlockchainApi.ChainEndpoint()");
        var blockChain = await _blockCypherClient.BlockchainApi.ChainEndpoint();
        return 0;
    }
}

//public class CreateMultisignatureWalletApplication : IConsoleApplication
//{
//    public async Task<int> ExecuteAsync(string[] args)
//    {
//        throw new NotImplementedException();
//    }
//}