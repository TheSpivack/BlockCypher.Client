namespace BlockCypher.Clients.Requests.Transaction;

public class UnconfirmedTransactionsRequest : BlockCypherRequest
{
    /// <summary>
    /// Maximum number of transactions returned, if unset, default is 10. Maximum is 100.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Filter transactions that transfer a total above the minimal value provided (in satoshis).
    /// </summary>
    public long? MinValue { get; set; }
}