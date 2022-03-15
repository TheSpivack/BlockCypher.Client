using System;

namespace BlockCypher.Objects;

/// <summary>
/// <para>A Wallet contains a list of addresses associated by its name and the user's token. It can be used interchangeably with all the Address API endpoints, and in many places that require addresses, like when Creating Transactions.</para>
/// <para>The name of a wallet must be 1-25 characters long and cannot start with any characters that start an address for the currency contained in the wallet.For example, bitcoin wallet names cannot start with '1' or '3'.</para>
/// </summary>
public class Wallet : BaseObject
{
    /// <summary>
    /// User token associated with this wallet.
    /// </summary>
    public string Token { get; set; } = null!;

    /// <summary>
    /// Name of the wallet.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// List of addresses associated with this wallet.
    /// </summary>
    public string[] Addresses { get; set; } = Array.Empty<string>();
}