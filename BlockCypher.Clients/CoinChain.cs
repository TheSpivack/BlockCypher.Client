using BlockCypher.Clients.Models.Attributes;

namespace BlockCypher.Clients;

/// <summary>
/// Enum used to select which Coin and Chain to use when making requests to Block Cypher  https://www.blockcypher.com/dev/bitcoin/#restful-resources
/// </summary>
public enum CoinChain
{
    [BlockCypherResource(Coin = "btc", Chain = "main")]
    BitcoinMain,

    [BlockCypherResource(Coin = "btc", Chain = "test3")]
    BitcoinTestnet3,

    [BlockCypherResource(Coin = "dash", Chain = "main")]
    DashMain,

    [BlockCypherResource(Coin = "doge", Chain = "main")]
    DogecoinMain,

    [BlockCypherResource(Coin = "ltc", Chain = "main")]
    LitecoinMain,

    [BlockCypherResource(Coin = "bcy", Chain = "test")]
    BlockCypherTest
}