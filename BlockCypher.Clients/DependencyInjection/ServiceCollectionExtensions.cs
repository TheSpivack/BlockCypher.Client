// ReSharper disable once CheckNamespace

using System;
using BlockCypher.Clients;
using BlockCypher.Clients.Abstractions;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Configures all of the APIs for BlockCypher using the specified action to configure the <see cref="BlockCypherClientOptions"/>.
    /// </summary>
    /// <returns>
    /// The <see cref="IHttpClientBuilder"/> from calling AddHttpClient so you can add easily polly policies, additional handlers, etc.
    /// </returns>
    public static IHttpClientBuilder AddBlockCypherClient(this IServiceCollection services, Action<BlockCypherClientOptions> configureOptions)
    {
        services.Configure(configureOptions);
        services.AddSingleton<IBlockchainApi, BlockchainApi>();
        services.AddSingleton<IBlockCypherClient, BlockCypherClient>();
        return services.AddHttpClient("BlockCypherApi");
    }
}
