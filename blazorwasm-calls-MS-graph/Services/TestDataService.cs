using blazorwasm_calls_MS_graph.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace blazorwasm_calls_MS_graph.Services
{
    public class TestDataService : ITestDataService
    {
        private readonly HttpClient _httpClient;

        public TestDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Person> GetData()
        {
            try
            {
                var response = await _httpClient.GetStreamAsync($"Test/Authorized");
                var result = await JsonSerializer.DeserializeAsync<Person>
                     (response, 
                    new JsonSerializerOptions() { 
                         PropertyNameCaseInsensitive = true });
                return result;
            }
            catch(System.Exception ex)
            {
                throw;
            }
        }
    }
}
