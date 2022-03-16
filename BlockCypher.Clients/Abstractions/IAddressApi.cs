using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BlockCypher.Clients.Requests;
using BlockCypher.Clients.Requests.Address;
using BlockCypher.Objects;

namespace BlockCypher.Clients.Abstractions
{
    /// <summary>
    /// Interface for the Address API. https://www.blockcypher.com/dev/bitcoin/#address-api
    /// <para>BlockCypher's Address API allows you to look up information about public addresses on the blockchain, generate single-use, low-value key pairs with corresponding addresses, help generate multisig addresses, and collect multiple addresses into a single shortcut for address viewing, all based on the coin/chain resource you've selected for your endpoints.</para>
    /// <para>
    /// If you're new to blockchains, you can think of public addresses as similar to bank account numbers in a traditional ledger. The biggest differences:
    /// <list type="bullet">
    /// <item>Anyone can generate a public address themselves (through ECDSA in Bitcoin). No single authority is needed to generate new addresses; it's just public-private key cryptography.</item>
    /// <item>Public addresses are significantly more lightweight. Consequently, and unlike traditional bank accounts, you can (and should!) generate new addresses for every transaction.</item>
    /// <item>Addresses can also leverage pay-to-script-hash, which means they can represent exotic things beyond a single private-public key pair; the most prominent example being multi-signature addresses that require n-of-m signatures to spend.</item>
    /// </list>
    /// </para>
    /// </summary>
    public interface IAddressApi
    {
        /// <summary>
        /// The Address Balance Endpoint is the simplest---and fastest---method to get a subset of information on a public address.
        /// </summary>
        /// <param name="address">A string representing the public address (or wallet/HD wallet name) you're interested in querying, for example: 1DEP8i3QJCsomS4BSMY2RpU1upv62aGvhD</param>
        /// <param name="request">Optional query string parameters for this endpoint.  Can also override the default coin/chain</param>
        /// <returns>
        /// The returned object contains information about the address, including its balance in satoshis and the number of transactions associated with it. The endpoint omits any detailed transaction information, but if that isn't required by your application, then it's the fastest and preferred way to get public address information.
        /// </returns>
        public Task<AddressObj> AddressBalanceEndpoint(string address, AddressBalanceRequest? request = null);

        /// <summary>
        /// The default Address Endpoint strikes a balance between speed of response and data on Addresses. It returns more information about an address' transactions than the Address Balance Endpoint but doesn't return full transaction information (like the Address Full Endpoint).
        /// </summary>
        /// <param name="address">A string representing the public address (or wallet/HD wallet name) you're interested in querying, for example: 1DEP8i3QJCsomS4BSMY2RpU1upv62aGvhD</param>
        /// <param name="request">Optional query string parameters for this endpoint.  Can also override the default coin/chain</param>
        /// <returns>
        /// The returned object contains information about the address, including its balance in satoshis, the number of transactions associated with it, and transaction inputs/outputs in descending order by block height---and if multiple transaction inputs/outputs associated with this address exist within the same block, by descending block index (position in block).
        /// </returns>
        public Task<AddressObj> AddressEndpoint(string address, AddressRequest? request = null);

        /// <summary>
        /// The Address Full Endpoint returns all information available about a particular address, including an array of complete transactions instead of just transaction inputs and outputs. Unfortunately, because of the amount of data returned, it is the slowest of the address endpoints, but it returns the most detailed data record.
        /// </summary>
        /// <param name="address">A string representing the public address (or wallet/HD wallet name) you're interested in querying, for example: 1DEP8i3QJCsomS4BSMY2RpU1upv62aGvhD</param>
        /// <param name="request">Optional query string parameters for this endpoint.  Can also override the default coin/chain</param>
        /// <returns>
        /// The returned object contains information about the address, including its balance in satoshis, the number of transactions associated with it, and the corresponding full transaction records in descending order by block height---and if multiple transactions associated with this address exist within the same block, by descending block index (position in block).
        /// </returns>
        public Task<AddressObj> AddressFullEndpoint(string address, AddressFullRequest? request = null);

        /// <summary>
        /// The Generate Address endpoint allows you to generate private-public key-pairs along with an associated public address. No information is required with this POST request.
        /// <para> The private key returned is immediately discarded by our servers, but we advise that these keys should not be used for any high-value---or long-term storage---addresses.</para>
        /// </summary>
        /// <param name="request">Optional override to default coin/chain.</param>
        /// <returns>
        /// The returned object contains a private key in hex-encoded and wif-encoded format, a public key, and a public address.
        /// </returns>
        public Task<AddressKeychain> GenerateAddressEndpoint(GenerateAddressRequest? request = null);

        /// <summary>
        /// The Generate Multisig Address Endpoint is a convenience method to help you generate multisig addresses from multiple public keys.
        /// </summary>
        /// <param name="requestBody">A partially filled-out AddressKeychain object, including only an array of hex-encoded public keys and the script type</param>
        /// <param name="request"></param>
        /// <returns>
        /// The returned AddressKeychain object includes the computed public address.
        /// </returns>
        public Task<AddressKeychain> GenerateMultisigAddressEndpoint(AddressKeychain requestBody, BlockCypherRequest? request = null);
    }
}
