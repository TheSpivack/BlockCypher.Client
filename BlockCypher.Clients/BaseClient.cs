using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using BlockCypher.Clients.Models;
using BlockCypher.Clients.Models.Attributes;
using BlockCypher.Clients.Requests;
using BlockCypher.Objects;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace BlockCypher.Clients;

public abstract class BaseClient
{
    public const string HTTP_CLIENT_NAME = "BlockCypherApi";

    private readonly HttpClient _httpClient;
    private readonly BlockCypherClientOptions _options;



    protected BaseClient(IHttpClientFactory httpClientFactory, IOptions<BlockCypherClientOptions>? options)
    {
        _httpClient = httpClientFactory.CreateClient(HTTP_CLIENT_NAME);
        _options = options?.Value ?? new BlockCypherClientOptions();
    }

    /// <summary>
    /// Wrapper for all API calls.  The URL will be constructed by using ""
    /// </summary>
    protected async Task<T?> GetAsync<T>(string resource, BlockCypherRequest? request = null)
    {
        return JsonConvert.DeserializeObject<T>(await GetAsync(resource, request), BaseObject.BlockCypherSerializerSettings);
    }

    protected async Task<string> GetAsync(string resource, BlockCypherRequest? request = null)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, CreateRequestUrl(resource, request));
        var responseMessage = await _httpClient.SendAsync(requestMessage);
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new BlockCypherHttpResponseException(requestMessage, responseMessage);
        }

        return await responseMessage.Content.ReadAsStringAsync();
    }

    protected Uri CreateRequestUrl(string resource, BlockCypherRequest? request = null)
    {
        //which coinChain to use?
        var coinChain = request?.CoinChain ?? _options.DefaultCoinChain ?? CoinChain.BitcoinMain;

        //get the attribute to get the values for the URL
        var type = coinChain.GetType();
        var cc = type.GetField(Enum.GetName(type, coinChain)).GetCustomAttribute<BlockCypherResourceAttribute>();

        var uriBuilder = new UriBuilder($"{_options.BaseUrl}{_options.ApiVersion}/{cc.Coin}/{cc.Chain}");
        if (!string.IsNullOrWhiteSpace(resource))
        {
            uriBuilder.Path += $"{resource}";
        }

        //build query string.
        var queryStringValues = new Dictionary<string, string>();

        if (!string.IsNullOrWhiteSpace(_options.Token))
        {
            queryStringValues.Add("token", _options.Token);
        }

        if (request != null)
        {
            //go through request and get all of the properties to be included as QueryString properties
            var properties = request.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(CoinChain?))
                {
                    //don't include the CoinChain in query string.  that's special for the path and handled above
                    continue;
                }

                var value = property.GetValue(request);
                if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                {
                    //don't include values that are null or whitespace
                    continue;
                }

                queryStringValues.Add(char.ToLowerInvariant(property.Name[0]) + property.Name[1..], value.ToString());
            }
        }

        if (queryStringValues.Any())
        {
            uriBuilder.Query = QueryString.Create(queryStringValues.OrderBy(kvp => kvp.Key)).Value;
        }

        return uriBuilder.Uri;
    }

}