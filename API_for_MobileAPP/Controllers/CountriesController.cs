using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_for_MobileAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryManager _countryManager;

        public CountriesController(ICountryManager countryManager)
        {
            _countryManager = countryManager;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CountryDTO>> GetCountries()
        {
            return _countryManager.GetAllCountries();
        }
        [HttpGet("{id}")]
        public ActionResult<CountryDTO> GetCountry(int id)
        {
            var country = _countryManager.GetCountry(id);
            if (country == null)
                return BadRequest("Not Found");
            return Ok(country);
        }
        [HttpPost]
        public ActionResult<CountryDTO> AddCountry(CountryDTO countryDTO)
        {
            var country = _countryManager.AddCountry(countryDTO);
            return CreatedAtAction("GetCountry", new { id = countryDTO.UserCountryId }, countryDTO);
        }
        [HttpPut]
        public ActionResult<CountryDTO> EditCountry(CountryDTO countryDTO)
        {
            var country = _countryManager.UpdateCountry(countryDTO);
            if (country)
                return Ok("Edited");
            return BadRequest("Not Valid");

        }
        [HttpDelete("{id}")]
        public ActionResult<CountryDTO> DeleteCountry(int id)
        {
            _countryManager.DeleteCountry(id);
            return Ok("Deleted");

        }
    }
}
