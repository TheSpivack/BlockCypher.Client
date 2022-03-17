using BlockCypher.Clients;

namespace BlockCypher.Client.SampleConsole;

public interface ICommandRunner
{
    /// <summary>
    /// Run the command
    /// </summary>
    Task RunAsync(string command, CoinChain? coinChain);
}