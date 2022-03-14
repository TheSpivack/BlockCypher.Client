using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using BlockCypher.Clients;
using BlockCypher.Clients.Models;
using BlockCypher.Clients.Models.Blockchain;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace BlockCypher.Client.Test;

public class CreateUrlTests
{
    class UnitTestClient : BaseClient
    {
        public UnitTestClient(HttpClient httpClient, IOptions<BlockCypherClientOptions>? options) : base(httpClient, options)
        {
        }

        public Uri TestCreateRequestUrl(string resource, BlockCypherRequest request) =>
            CreateRequestUrl(resource, request);
    }



    [Fact]
    public void ChainEndpoint_NoOptions()
    {
        //arrange
        var httpClient = new Mock<HttpClient>();
        var client = new UnitTestClient(httpClient.Object, null);

        //act
        var uri = client.TestCreateRequestUrl(string.Empty, new BlockCypherRequest());

        //assert
        uri.Should().Be(new Uri("https://api.blockcypher.com/v1/btc/main"));
    }

    [Theory]
    [InlineData("0000000000000000189bba3564a63772107b5673c940c16f12662b3e8546b412", null, null)]
    [InlineData("0000000000000000189bba3564a63772107b5673c940c16f12662b3e8546b412", 123, null)]
    [InlineData("0000000000000000189bba3564a63772107b5673c940c16f12662b3e8546b412", null, 50)]
    [InlineData("0000000000000000189bba3564a63772107b5673c940c16f12662b3e8546b412", 123, 50)]
    public void BlockHashEndpoint_NoOptions(string hash, int? txStart, int? limit)
    {
        //arrange
        var httpClient = new Mock<HttpClient>();
        var client = new UnitTestClient(httpClient.Object, null);

        //act
        var uri = client.TestCreateRequestUrl($"/blocks/{hash}", new GetByBlockHashRequest
        {
            BlockHash = hash,
            Limit = limit,
            Txstart = txStart
        });

        //assert
        var expectedUri = new UriBuilder($"https://api.blockcypher.com/v1/btc/main/blocks/{hash}");
        var queryStringValues = new Dictionary<string, string>();
        if (txStart.HasValue)
        {
            queryStringValues.Add("txstart", txStart.ToString()!);
        }
        if (limit.HasValue)
        {
            queryStringValues.Add("limit", limit.ToString()!);
        }
        if (queryStringValues.Any())
        {
            expectedUri.Query = QueryString.Create(queryStringValues.OrderBy(kvp => kvp.Key)).Value;
        }
        uri.Should().Be(expectedUri.Uri);
    }
}