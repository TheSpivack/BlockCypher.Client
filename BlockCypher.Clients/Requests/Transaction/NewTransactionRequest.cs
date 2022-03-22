namespace BlockCypher.Clients.Requests.Transaction;

public class NewTransactionRequest : BlockCypherRequest
{
    /// <summary>
    /// If true, includes tosign_tx array in TXSkeleton, useful for validating data to sign; false by default.
    /// </summary>
    public bool? IncludeToSignTx { get; set; }
}