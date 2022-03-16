// ReSharper disable once CheckNamespace

using System;
using BlockCypher.Clients;
using BlockCypher.Clients.Abstractions;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Configures all of the APIs for BlockCypher using the optional action to configure the <see cref="BlockCypherClientOptions"/>.
    /// </summary>
    /// <returns>
    /// The <see cref="IHttpClientBuilder"/> from calling AddHttpClient so you can add easily polly policies, additional handlers, etc.
    /// </returns>
    public static IHttpClientBuilder AddBlockCypherClient(this IServiceCollection services, Action<BlockCypherClientOptions>? configureOptions = null)
    {
        if (configureOptions != null)
        {
            services.Configure(configureOptions);
        }
        services.AddSingleton<IBlockchainApi, BlockchainApi>();
        services.AddSingleton<IAddressApi, AddressApi>();
        services.AddSingleton<IBlockCypherClient, BlockCypherClient>();
        return services.AddHttpClient(BaseClient.HTTP_CLIENT_NAME);
    }

    /// <summary>
    /// Adds the default retry policy - retry count of 5 using linear back-off and fast first 
    /// </summary>
    public static IHttpClientBuilder AddDefaultRetryPolicy(this IHttpClientBuilder builder)
    {
        var delay = Backoff.LinearBackoff(TimeSpan.FromMilliseconds(100), 5);
        var policy = HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(delay);

        return builder.AddPolicyHandler(policy);
    }
}
