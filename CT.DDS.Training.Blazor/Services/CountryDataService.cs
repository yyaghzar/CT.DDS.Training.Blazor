using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CT.DDS.Training.Blazor.Services
{
    public class CountryDataService : ICountryDataService
    {
        private readonly HttpClient _httpClient;
        public CountryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
      
        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            var data = await JsonSerializer.DeserializeAsync<IEnumerable<Country>>
                (await _httpClient.GetStreamAsync($"api/Country"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return data;
        }

        public async Task<Country> GetCountryById(int countryId)
        {
            return await JsonSerializer.DeserializeAsync<Country>
                (await _httpClient.GetStreamAsync($"api/Country/{countryId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
