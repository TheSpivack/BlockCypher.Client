using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BlockCypher.Clients.Abstractions;
using BlockCypher.Clients.Requests;
using BlockCypher.Clients.Requests.Transaction;
using BlockCypher.Objects;
using Microsoft.Extensions.Options;

namespace BlockCypher.Clients;

public class TransactionApi : BaseClient, ITransactionApi
{
    public TransactionApi(IHttpClientFactory httpClientFactory, IOptions<BlockCypherClientOptions>? options) : base(httpClientFactory, options)
    {
    }

    public async Task<TX> TransactionHash(string txHash, TransactionHashRequest? request = null)
    {
        return (await GetAsync<TX>($"/txs/{txHash}", request))!;
    }

    public async Task<IEnumerable<TX>> UnconfirmedTransactions(UnconfirmedTransactionsRequest? request = null)
    {
        return (await GetAsync<IEnumerable<TX>>("/txs", request))!;
    }

    public async Task<TXSkeleton> NewTransaction(TX requestBody, NewTransactionRequest? request = null)
    {
        return (await PostAsync<TXSkeleton>("/txs/new", request, requestBody))!;
    }

    public async Task<TXSkeleton> SendTransaction(TXSkeleton requestBody, BlockCypherRequest? request = null)
    {
        return (await PostAsync<TXSkeleton>("/txs/send", request, requestBody))!;
    }

    public async Task<TX> PushRawTransaction(string txHex, BlockCypherRequest? request = null)
    {
        return (await PostAsync<TX>("/txs/push", request, new
        {
            Tx = txHex
        }))!;
    }

    public async Task<TX> DecodeRawTransaction(string txHex, BlockCypherRequest? request = null)
    {
        return (await PostAsync<TX>("/txs/decode", request, new
        {
            Tx = txHex
        }))!;
    }

    public async Task<WitnessToSignTx> DecodeTransactionWitnessToSign(string witnessToSignTxHex, BlockCypherRequest? request = null)
    {
        return (await PostAsync<WitnessToSignTx>("/txs/decodeWitnessToSign", request, new
        {
            WitnessTosignTx = witnessToSignTxHex
        }))!;
    }
}