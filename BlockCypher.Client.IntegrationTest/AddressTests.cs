using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockCypher.Clients;
using BlockCypher.Clients.Abstractions;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlockCypher.Client.IntegrationTest
{
    public class AddressTests
    {
        private IServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();
            services
                .AddBlockCypherClient(options =>
                {
                    options.DefaultCoinChain = CoinChain.BlockCypherTest;
                    options.Token = "b861958e302d4c89b3cd814df04c7531"; //inactive, only works for bcy testnet
                })
                .AddDefaultRetryPolicy();

            return services.BuildServiceProvider();
        }

        [Fact]
        public async Task GenerateAddressEndpoint_ShouldSucceed()
        {
            //arrange
            var client = BuildServiceProvider().GetRequiredService<IAddressApi>();

            //act
            var keychain = await client.GenerateAddressEndpoint();

            //assert
            keychain.Should()
                .NotBeNull();

            keychain.Address
                .Should().NotBeNullOrWhiteSpace();

            keychain.Private
                .Should().NotBeNullOrWhiteSpace();

            keychain.Wif
                .Should().NotBeNullOrWhiteSpace();
        }
    }
}
