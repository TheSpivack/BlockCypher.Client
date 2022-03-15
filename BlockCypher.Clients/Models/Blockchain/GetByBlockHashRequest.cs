using BlockCypher.Clients.Models.Attributes;

namespace BlockCypher.Clients.Models.Blockchain;

public class GetByBlockHashRequest : BlockCypherRequest
{
    /// <summary>
    /// BLOCK_HASH is a string representing the hash of the block you're interested in querying, for example: 0000000000000000189bba3564a63772107b5673c940c16f12662b3e8546b412
    /// </summary>

    [PathVariable]
    public string BlockHash { get; set; } = null!;

    /// <summary>
    /// Filters response to only include transaction hashes after txstart in the block.
    /// </summary>

    [QueryStringVariable]
    public int? Txstart { get; set; }

    /// <summary>
    /// Filters response to only include a maximum of limit transactions hashes in the block. Maximum value allowed is 500.
    /// </summary>

    [QueryStringVariable]
    public int? Limit { get; set; }
}