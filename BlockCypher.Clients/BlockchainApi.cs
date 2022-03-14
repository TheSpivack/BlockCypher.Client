using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlockCypher.Clients.Abstractions;
using BlockCypher.Clients.Models;
using BlockCypher.Clients.Models.Blockchain;
using BlockCypher.Objects;
using Microsoft.Extensions.Options;

namespace BlockCypher.Clients;

public class BlockchainApi : BaseClient, IBlockchainApi
{
    public BlockchainApi(IHttpClientFactory httpClientFactory, IOptions<BlockCypherClientOptions>? options)
        : base(httpClientFactory, options)
    {
    }

    public async Task<Blockchain> ChainEndpoint(BlockCypherRequest? request)
    {
        return (await GetAsync<Blockchain>("", request ?? new BlockCypherRequest()))!;
    }

    public async Task<Block> BlockHashEndpoint(GetByBlockHashRequest request)
    {
        return (await GetAsync<Block>($"/blocks/{request.BlockHash}", request))!;
    }

    public async Task<Block> BlockHeightEndpoint(GetByBlockHeightRequest request)
    {
        return (await GetAsync<Block>($"/blocks/{request.BlockHeight}", request))!;
    }

    public async Task<string> FeatureEndpoint(GetFeatureRequest request)
    {
        return (await GetAsync($"/feature/{request.Name}", request))!;
    }
}