using System.Net.Http;
using System.Threading.Tasks;
using BlockCypher.Clients.Abstractions;
using BlockCypher.Clients.Requests;
using BlockCypher.Clients.Requests.Address;
using BlockCypher.Objects;
using Microsoft.Extensions.Options;

namespace BlockCypher.Clients;

public class AddressApi : BaseClient, IAddressApi
{
    public AddressApi(IHttpClientFactory httpClientFactory, IOptions<BlockCypherClientOptions>? options)
        : base(httpClientFactory, options)
    {
    }

    public async Task<AddressObj> AddressBalanceEndpoint(string address, AddressBalanceRequest? request = null)
    {
        return (await GetAsync<AddressObj>($"/addrs/{address}/balance", request))!;
    }

    public async Task<AddressObj> AddressEndpoint(string address, AddressRequest? request = null)
    {
        return (await GetAsync<AddressObj>($"/addrs/{address}", request))!;
    }

    public async Task<AddressObj> AddressFullEndpoint(string address, AddressFullRequest? request = null)
    {
        return (await GetAsync<AddressObj>($"/addrs/{address}/full", request))!;
    }

    public async Task<AddressKeychain> GenerateAddressEndpoint(GenerateAddressRequest? request = null)
    {
        return (await PostAsync<AddressKeychain>("/addrs", request))!;
    }

    public async Task<AddressKeychain> GenerateMultisigAddressEndpoint(AddressKeychain requestBody, BlockCypherRequest? request = null)
    {
        return (await PostAsync<AddressKeychain>("/addrs", request, requestBody))!;
    }
}