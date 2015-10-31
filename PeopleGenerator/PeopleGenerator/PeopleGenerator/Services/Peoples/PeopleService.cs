using Newtonsoft.Json;
using PeopleGenerator.Services.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleGenerator.Services.Peoples
{
    /// <summary>
    /// Sevice for getting data on clint side (a person using REST client).
    /// </summary>
    public class PeopleService : IPeopleService
    {
        private readonly IRestClient _restClient;

        private const string PERSON_URI = "http://api.randomuser.me/?format=csv";

        public PeopleService()
        {
            _restClient = new RestClient();
        }

        /// <summary>
        /// Gets all the people data in C# classes.
        /// </summary>
        /// <returns>Class with parsed person data.</returns>
        public async Task<CurrentPerson> GetPersonAsync()
        {
            var response = await _restClient.GetAsync(PERSON_URI);
            var actualObject = JsonConvert.DeserializeObject<CurrentPerson>(response);
            return actualObject;
        }
    }
}
