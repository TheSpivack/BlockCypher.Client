using System;
using System.Reflection;
using System.Threading.Tasks;
using BlockCypher.Clients;
using BlockCypher.Clients.Abstractions;
using BlockCypher.Clients.Models.Attributes;
using BlockCypher.Clients.Requests.Blockchain;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlockCypher.Client.IntegrationTest;

public class BlockchainTests
{
    private IServiceProvider BuildServiceProvider(Action<BlockCypherClientOptions>? options = null)
    {
        var services = new ServiceCollection();
        services
            .AddBlockCypherClient(options)
            .AddDefaultRetryPolicy();

        return services.BuildServiceProvider();
    }


    [Theory]
    //I don't want to burn my free level quota, so let's leave most of these commented
    [InlineData(CoinChain.BitcoinMain)]
    [InlineData(CoinChain.BitcoinTestnet3)]
    [InlineData(CoinChain.BlockCypherTest)]
    [InlineData(CoinChain.DashMain)]
    [InlineData(CoinChain.DogecoinMain)]
    [InlineData(CoinChain.LitecoinMain)]
    public async Task ChainEndpoint_ShouldSucceed(CoinChain coinChain)
    {
        //arrange
        var expectedCoinChain = coinChain.GetType().GetField(Enum.GetName(coinChain.GetType(), coinChain)!)!
            .GetCustomAttribute<BlockCypherResourceAttribute>()!;

        var client = BuildServiceProvider(options =>
        {
            options.DefaultCoinChain = coinChain;
        }).GetRequiredService<IBlockchainApi>();

        //act
        var blockchain = await client.ChainEndpoint();


        //assert
        blockchain.Should()
            .NotBeNull();

        blockchain.Name.Should()
            .Be($"{expectedCoinChain.Coin.ToUpper()}.{expectedCoinChain.Chain}");
    }

    [Theory]
    [InlineData("00000000000000000003dc20b868d17121303308f6bba329302e75913f0790db", 671142)]
    public async Task BlockHashEndpoint_ShouldSucceed(string hash, int expectedHeight)
    {
        var request = new GetByBlockHashRequest
        {
            Limit = 1
        };

        var block = await BuildServiceProvider()
            .GetRequiredService<IBlockchainApi>()
            .BlockHashEndpoint(hash, request);

        block.Should()
            .NotBeNull();

        block.Height.Should()
            .Be(expectedHeight);

        block.Hash.Should()
            .Be(hash);
    }

    [Theory]
    [InlineData(671142, "00000000000000000003dc20b868d17121303308f6bba329302e75913f0790db")]
    public async Task BlockHeightEndpoint_ShouldSucceed(int height, string expectedHash)
    {
        var request = new GetByBlockHeightRequest
        {
            Limit = 1
        };

        var block = await BuildServiceProvider()
            .GetRequiredService<IBlockchainApi>()
            .BlockHeightEndpoint(height, request);

        block.Should()
            .NotBeNull();

        block.Hash.Should()
            .Be(expectedHash);

        block.Height.Should()
            .Be(height);
    }
}
