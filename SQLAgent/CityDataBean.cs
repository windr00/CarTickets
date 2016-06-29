using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlAgent
{
    public class CityDataBean
    {
        public string cityId { get; set; }

        public string cityName { get; set; }

        public CityDataBean(string cityId, string cityName)
        {
            this.cityId = cityId;
            this.cityName = cityName;
        }
    }
}
