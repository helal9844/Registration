using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CountryRepo : GenaticRepo<UserCountry>,ICountryRepo
    {
        private readonly SkyContext _skyContext;
        public CountryRepo(SkyContext skyContext) : base(skyContext)
        {
            _skyContext = skyContext;
        }
        public List<UserCountry> GetUserByCountry(string country)
        {
            return _skyContext.Set<UserCountry>().Where(p => p.Country == country).ToList();
        }
    }
}
