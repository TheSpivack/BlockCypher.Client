using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Invocation;
using System.CommandLine.NamingConventionBinder;
using BlockCypher.Client.SampleConsole.Commands;
using BlockCypher.Clients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NBitcoin;
using Serilog;

namespace BlockCypher.Client.SampleConsole;


public class Program
{

    public class Commands
    {
        public const string BLOCKCHAIN = "blockchain";

        public const string ADDRESS = "address";

        public class Blockchain
        {
            public const string CHAIN = "chain";
            public const string HASH = "hash";
            public const string HEIGHT = "height";
            public const string FEATURE = "feature";
        }
    }

    public static async Task<int> Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args);
        try
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();

            Log.Logger.Information("Application starting: {args}", args);

            PrintWelcomeText();

            //var commandLineBuilder = new CommandLineBuilder();
            //commandLineBuilder.

            //var blockChainCommand = new Command(Commands.BLOCKCHAIN, "Call methods in the blockchain api");


            //{
            //    //Handler = CommandHandler.Create<string, CoinChain?, bool>((method, coinChain, showRestLogs) =>
            //    //{
            //    //    Log.Logger.Debug("Running {command} {method} on {coinChain}", Commands.BLOCKCHAIN, method, coinChain?.ToString() ?? "default");
            //    //    return BuildHost<BlockchainCommandRunner>(host, showRestLogs)
            //    //        .Services
            //    //        .GetRequiredService<ICommandRunner>()
            //    //        .RunAsync(method, coinChain);
            //    //})
            //};
            //blockChainCommand.AddArgument(new Argument("method", "Specific method to run").FromAmong("chain", ""));

            //var addressChainCommand = new Command(Commands.ADDRESS, "Examples of calling address api")
            //{
            //    Handler = CommandHandler.Create<CoinChain?, bool>((coinChain, showRestLogs) =>
            //    {
            //        Log.Logger.Debug("Running {command} on {coinChain}", Commands.ADDRESS, coinChain);
            //        return Console.Out.WriteLineAsync($"I will do address things! {coinChain} {showRestLogs}");
            //    })
            //};

            var rootCommand = new RootCommand
            {
                new BlockchainCommand(),
                new AddressCommand()
            };

            var showRestLogsOption = new Option<bool>("--show-rest-logs",
                () => false,
                "If present, REST logs will be printed to console.  They will always be logged to serilog!");

            rootCommand.AddGlobalOption(showRestLogsOption);
            rootCommand.AddGlobalOption(new Option<CoinChain?>("--coin-chain",
                () => null,
                "Coin and Chain to use.  If not set value from appsettings.config will be used.  If that's not set, then BitcoinMain will be used"));



            var parsedCommand = rootCommand.Parse(args);

            var val = parsedCommand.GetValueForOption(showRestLogsOption);


            return await rootCommand.InvokeAsync(args);
        }
        catch (Exception ex)
        {
            Log.Logger.Fatal(ex, $"Unhandled exception: {ex.Message}");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    /// <summary>
    /// Builds the host after the cli commands and options have been parsed
    /// </summary>
    private static IHost BuildHost<TCommandRunner>(IHostBuilder host, bool showRestLogs)
        where TCommandRunner : class, ICommandRunner

    {
        return host
            .ConfigureServices((context, services) =>
            {
                var httpBuilder = services
                    .AddSingleton<ICommandRunner, TCommandRunner>()
                    .AddBlockCypherClient(options => context.Configuration.GetSection("BlockCypherClientOptions").Bind(options))
                    .AddDefaultRetryPolicy();

                if (showRestLogs)
                {
                    services.AddTransient<ConsoleLoggingDelegatingHandler>();
                    httpBuilder.AddHttpMessageHandler<ConsoleLoggingDelegatingHandler>();
                }
            })
            .UseSerilog()
            .Build();
    }

    private static void PrintWelcomeText()
    {
        Console.WriteLine(@"Thank you for running the BlockCypher.Client Sample cli!
─╔══╗╔╗──────╔╗─╔═══╗──────╔╗──────╔═══╦╗───────╔╗──
─║╔╗║║║──────║║─║╔═╗║──────║║──────║╔═╗║║──────╔╝╚╗─
─║╚╝╚╣║╔══╦══╣║╔╣║─╚╬╗─╔╦══╣╚═╦══╦═╣║─╚╣║╔╦══╦═╬╗╔╝─
─║╔═╗║║║╔╗║╔═╣╚╝╣║─╔╣║─║║╔╗║╔╗║║═╣╔╣║─╔╣║╠╣║═╣╔╗╣║──
─║╚═╝║╚╣╚╝║╚═╣╔╗╣╚═╝║╚═╝║╚╝║║║║║═╣╠╣╚═╝║╚╣║║═╣║║║╚╗─
─╚═══╩═╩══╩══╩╝╚╩═══╩═╗╔╣╔═╩╝╚╩══╩╩╩═══╩═╩╩══╩╝╚╩═╝─
────────────────────╔═╝║║║──────────────────────────
────────────────────╚══╝╚╝──────────────────────────");
        Console.WriteLine();
        Console.WriteLine();
    }
}