using System.Threading.Tasks;

namespace PeopleGenerator.Services.Peoples
{
    /// <summary>
    /// Sevice for getting a person using REST client.
    /// </summary>
    public interface IPeopleService
    {
        /// <summary>
        /// Gets the all the person data in C# classes.
        /// </summary>
        /// <returns>Class with parsed person data.</returns>
        Task<CurrentPerson> GetPersonAsync();
    }
}
