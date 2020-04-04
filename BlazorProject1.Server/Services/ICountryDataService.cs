using BethanysPieShopHRM.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorProject1.Server.Services
{
    public interface ICountryDataService
    {
        Task<IEnumerable<Country>> GetAllCountries();

        Task<Country> GetCountryById(int countryId);
    }
}
