namespace BlockCypher.Clients.Requests.Blockchain;

public class GetByBlockHashRequest : BlockCypherRequest
{
    /// <summary>
    /// Filters response to only include transaction hashes after txstart in the block.
    /// </summary>
    public int? Txstart { get; set; }

    /// <summary>
    /// Filters response to only include a maximum of limit transactions hashes in the block. Maximum value allowed is 500.
    /// </summary>
    public int? Limit { get; set; }
}