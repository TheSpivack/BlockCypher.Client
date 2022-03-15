using BlockCypher.Clients.Models.Attributes;

namespace BlockCypher.Clients.Models.Blockchain;

public class GetByBlockHeightRequest : BlockCypherRequest
{
    /// <summary>
    /// BLOCK_HEIGHT is an integer representing the height of the block you're interested in querying, for example: 294322
    /// </summary>

    [PathVariable]
    public int BlockHeight { get; set; }

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