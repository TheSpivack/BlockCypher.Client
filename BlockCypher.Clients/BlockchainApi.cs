using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlockCypher.Clients.Abstractions;
using BlockCypher.Clients.Models;
using BlockCypher.Clients.Requests;
using BlockCypher.Clients.Requests.Blockchain;
using BlockCypher.Objects;
using Microsoft.Extensions.Options;

namespace BlockCypher.Clients;

public class BlockchainApi : BaseClient, IBlockchainApi
{
    public BlockchainApi(IHttpClientFactory httpClientFactory, IOptions<BlockCypherClientOptions>? options)
        : base(httpClientFactory, options)
    {
    }

    public async Task<Blockchain> Chain(BlockCypherRequest? request = null)
    {
        return (await GetAsync<Blockchain>("", request))!;
    }

    public async Task<Block> BlockHash(string blockHash, GetByBlockHashRequest? request = null)
    {
        return (await GetAsync<Block>($"/blocks/{blockHash}", request))!;
    }

    public async Task<Block> BlockHeight(int blockHeight, GetByBlockHeightRequest? request = null)
    {
        return (await GetAsync<Block>($"/blocks/{blockHeight}", request))!;
    }

    public async Task<string> Feature(string name, BlockCypherRequest? request = null)
    {
        return (await GetAsync($"/feature/{name}", request))!;
    }
}