using System;
using System.Net;
using System.Net.Http;

namespace BlockCypher.Clients;

public class BlockCypherHttpResponseException : Exception
{
    public BlockCypherHttpResponseException(HttpRequestMessage request, HttpResponseMessage response) : base(
        $"Exception calling {request.RequestUri}.  Status code {response.StatusCode}")
    {
        Request = request;
        Response = response;
        StatusCode = response.StatusCode;
    }

    public HttpStatusCode StatusCode { get; }
    public HttpRequestMessage Request { get; }
    public HttpResponseMessage Response { get; }

}