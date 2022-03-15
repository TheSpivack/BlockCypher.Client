using System;

namespace BlockCypher.Objects;

public class Block : BaseObject
{
    /// <summary>
    /// The hash of the block; in Bitcoin, the hashing function is SHA256(SHA256(block))
    /// </summary>
    public string Hash { get; set; } = null!;

    /// <summary>
    /// The height of the block in the blockchain; i.e., there are height earlier blocks in its blockchain.
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// The depth of the block in the blockchain; i.e., there are depth later blocks in its blockchain.
    /// </summary>
    public int Depth { get; set; }

    /// <summary>
    /// The name of the blockchain represented, in the form of $COIN.$CHAIN
    /// </summary>
    public string Chain { get; set; } = null!;

    /// <summary>
    /// The total number of satoshis transacted in this block.
    /// </summary>
    public long Total { get; set; }

    /// <summary>
    /// The total number of fees---in satoshis---collected by miners in this block.
    /// </summary>
    public long Fees { get; set; }

    /// <summary>
    /// Raw size of block (including header and all transactions) in bytes.Not returned for bitcoin blocks earlier than height 389104.
    /// </summary>
    public int? Size { get; set; }

    /// <summary>
    /// Raw size of block(including header and all transactions) in virtual bytes.Not returned for bitcoin blocks earlier than height 670850.
    /// </summary>
    public int Vsize { get; set; }

    /// <summary>
    /// Block version.
    /// </summary>
    public int Ver { get; set; }

    /// <summary>
    /// Recorded time at which block was built. Note: Miners rarely post accurate clock times.
    /// </summary>
    public DateTime Time { get; set; }

    /// <summary>
    /// The time BlockCypher's servers receive the block. Our servers' clock is continuously adjusted and accurate.
    /// </summary>
    public DateTime ReceivedTime { get; set; }

    /// <summary>
    /// Address of the peer that sent BlockCypher's servers this block.
    /// </summary>
    public string RelayedBy { get; set; } = null!;

    /// <summary>
    /// The block-encoded difficulty target.
    /// </summary>
    public long Bits { get; set; }

    /// <summary>
    /// The number used by a miner to generate this block.
    /// </summary>
    public long NOnce { get; set; }

    /// <summary>
    /// Number of transactions in this block.
    /// </summary>
    public int NTx { get; set; }

    /// <summary>
    /// The hash of the previous block in the blockchain.
    /// </summary>
    public string PrevBlock { get; set; } = null!;

    /// <summary>
    /// The BlockCypher URL to query for more information on the previous block.
    /// </summary>
    public Uri PrevBlockUrl { get; set; } = null!;

    /// <summary>
    /// The base BlockCypher URL to receive transaction details. To get more details about specific transactions, you must concatenate this URL with the desired transaction hash(es).
    /// </summary>
    public Uri TxUrl { get; set; } = null!;

    /// <summary>
    /// The Merkle root of this block.
    /// </summary>
    public string MrklRoot { get; set; } = null!;

    /// <summary>
    /// An array of transaction hashes in this block.By default, only 20 are included.
    /// </summary>
    public string[] Txids { get; set; } = Array.Empty<string>();

    /// <summary>
    /// If there are more transactions that couldn't fit in the txids array, this is the BlockCypher URL to query the next set of transactions (within a Block object).
    /// </summary>
    public Uri? NextTxids { get; set; }
}