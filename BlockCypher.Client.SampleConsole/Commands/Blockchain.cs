using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.NamingConventionBinder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockCypher.Clients;
using BlockCypher.Clients.Abstractions;
using BlockCypher.Clients.Requests;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlockCypher.Client.SampleConsole.Commands
{
    public class BlockchainCommand : Command
    {
        public BlockchainCommand() : base("blockchain", "Call endpoints on the Blockchain Api")
        {
            AddCommand(new BlockchainChainCommand());
        }
    }

    public class AddressCommand : Command
    {
        public AddressCommand() : base("address", "Call endpoints on the Address Api")
        {
            Handler = CommandHandler.Create(() => Console.WriteLine("I will do stuff soon!"));
        }
    }

    public class BlockchainChainCommand : Command
    {
        public BlockchainChainCommand() : base("chain", "Call the Chain Endpoint on the Blockchain API")
        {
            Handler = CommandHandler.Create(async (IHost host, CoinChain? coinChain) =>
                await CallEndpointAsync(host, coinChain));
        }

        private async Task CallEndpointAsync(IHost host, CoinChain? coinChain)
        {
            Console.WriteLine("Calling BlockchainApi.ChainEndpoint()");
            var blockChain = await host.Services.GetRequiredService<IBlockchainApi>().ChainEndpoint(new BlockCypherRequest { CoinChain = coinChain });
            Console.WriteLine($"OK: {blockChain.Name} - {blockChain.Time:R} - {blockChain.Hash}");
        }
    }
}
