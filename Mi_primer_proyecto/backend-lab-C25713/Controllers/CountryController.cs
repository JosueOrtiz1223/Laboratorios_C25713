using backend_lab_C25713.Models;
using backend_lab_C25713.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend_lab_C25713.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly CountryService countryService;

        public CountryController()
        {
            countryService = new CountryService();
        }
    [HttpGet]
    public List<CountryModel> Get() {
        return countryService.GetCountries();
        }
    }
}