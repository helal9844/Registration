using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CountryManager : ICountryManager
    {
        private readonly ICountryRepo _countryRepo;
        private readonly IMapper _mapper;
        public CountryManager(ICountryRepo countryRepo, IMapper mapper)
        {
            _countryRepo = countryRepo;
            _mapper = mapper;
        }
        public List<CountryDTO> GetAllCountries()
        {
            var dbcountey = _countryRepo.GetAll();
            var dtocountry = _mapper.Map<List<CountryDTO>>(dbcountey);
            return dtocountry;

        }
        public CountryDTO? GetCountry(int id)
        {
            var dbcountry = _countryRepo.GetById(id);
            if (dbcountry == null)
                return null;
            return _mapper.Map<CountryDTO>(dbcountry);
        }

        public CountryDTO AddCountry(CountryDTO dto)
        {
            var dbcountry = _mapper.Map<UserCountry>(dto);
            _countryRepo.Add(dbcountry);
            _countryRepo.SaveChanges();
            return _mapper.Map<CountryDTO>(dbcountry);
        }
        public bool UpdateCountry(CountryDTO dto)
        {
            var dbcountry = _countryRepo.GetById(dto.UserCountryId);
            if (dbcountry == null)
                return false;
            _mapper.Map(dto, dbcountry);
            _countryRepo.Update(dbcountry);
            _countryRepo.SaveChanges();
            return true;
        }
        public void DeleteCountry(int id)
        {
            var dbcountry = _countryRepo.GetById(id);
            if (dbcountry == null)
                return;
            _countryRepo.Delete(dbcountry);
            _countryRepo.SaveChanges();
        }

        
        

       
    }
}
