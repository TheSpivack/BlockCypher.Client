using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace BlockCypher.Client.SampleConsole;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        try
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();

            Log.Logger.Information("Application starting: {args}", args);

            PrintWelcomeText();

            return await Host.CreateDefaultBuilder(args)
                .ConfigureServices(ConfigureServices)
                .UseSerilog()
                .Build()
                .Services.GetRequiredService<IConsoleApplication>()
                .ExecuteAsync(args);
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

    private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddSingleton<IConsoleApplication, SampleConsoleApplication>();

        services.AddTransient<ConsoleLoggingDelegatingHandler>();
        services.AddBlockCypherClient(options =>
                context.Configuration.GetSection("BlockCypherClientOptions").Bind(options))
            .AddDefaultRetryPolicy()
            .AddHttpMessageHandler<ConsoleLoggingDelegatingHandler>();
    }

    private static void PrintWelcomeText()
    {
        Console.WriteLine(@"Thank you for running the BlockCypher.Client sample console application!
╔══╗╔╗──────╔╗─╔═══╗──────╔╗──────╔═══╦╗───────╔╗
║╔╗║║║──────║║─║╔═╗║──────║║──────║╔═╗║║──────╔╝╚╗
║╚╝╚╣║╔══╦══╣║╔╣║─╚╬╗─╔╦══╣╚═╦══╦═╣║─╚╣║╔╦══╦═╬╗╔╝
║╔═╗║║║╔╗║╔═╣╚╝╣║─╔╣║─║║╔╗║╔╗║║═╣╔╣║─╔╣║╠╣║═╣╔╗╣║
║╚═╝║╚╣╚╝║╚═╣╔╗╣╚═╝║╚═╝║╚╝║║║║║═╣╠╣╚═╝║╚╣║║═╣║║║╚╗
╚═══╩═╩══╩══╩╝╚╩═══╩═╗╔╣╔═╩╝╚╩══╩╩╩═══╩═╩╩══╩╝╚╩═╝
───────────────────╔═╝║║║
───────────────────╚══╝╚╝");
        Console.WriteLine();
        Console.WriteLine();
    }
}