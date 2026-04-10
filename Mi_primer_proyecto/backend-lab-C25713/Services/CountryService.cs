using backend_lab_C25713.Models;
using backend_lab_C25713.Repositories;

namespace backend_lab_C25713.Services;

public class CountryService
{
    private readonly CountryRepository countryRepository;

    public CountryService()
    {
        countryRepository = new CountryRepository();
    }

    public List<CountryModel> GetCountries()
    {
        return countryRepository.GetCountries();
    }
}