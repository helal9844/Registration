using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface ICountryManager
    {
        List<CountryDTO> GetAllCountries();
        CountryDTO? GetCountry(int id);
        CountryDTO AddCountry(CountryDTO t);
        bool UpdateCountry(CountryDTO t);
        void DeleteCountry(int id);
    }
}
