using System.Threading.Tasks;

namespace PeopleGenerator.Services.Networking
{
    /// <summary>
    /// Service for getting data on server side.
    /// </summary>
    public interface IRestClient
    {
        /// <summary>
        /// All content from server about the person.
        /// </summary>
        /// <param name="uri">Link to get a data.</param>
        /// <returns>Row server data.</returns>
        Task<string> GetAsync(string uri);
    }
}
