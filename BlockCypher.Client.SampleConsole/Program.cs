using BlockCypher.Clients;
using BlockCypher.Clients.Abstractions;
using BlockCypher.Clients.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlockCypher.Client.SampleConsole;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        return await CreateHost(args)
            .Services.GetRequiredService<IConsoleApplication>()
            .ExecuteAsync(args);
    }

    static IHost CreateHost(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices(ConfigureServices)
            .Build();

    static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddSingleton<IConsoleApplication, SampleConsoleApplication>();
        services.AddBlockCypherClient(options =>
        {
            options.DefaultCoinChain = CoinChain.BitcoinTestnet3;
            options.Token = "****";
        });
    }
}