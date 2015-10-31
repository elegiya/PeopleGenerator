using PeopleGenerator.Models;
using System.Collections.Generic;

namespace PeopleGenerator
{
    public class CurrentPerson
    {
        public List<Result> results { get; set; }
        public string nationality { get; set; }
        public string seed { get; set; }
        public string version { get; set; }
    }
}
