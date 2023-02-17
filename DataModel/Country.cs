using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Country
    {
        public int countryId { get; set; }
        public string countryName { get; set; }
    }

    public class State
    {
        public int countryId { get; set; }
        public int stateId { get; set; }
        public string stateName { get; set; }
    }

    public class City
    {
        public int stateId { get; set; }
        public int cityId { get; set; }
        public string cityName { get; set; }
    }
}
