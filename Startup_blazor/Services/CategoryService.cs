using Microsoft.AspNetCore.Components;
using Startup_models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Startup_blazor.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient httpClient;

        public CategoryService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Categories>> Getcategories()
        {
            return await httpClient.GetJsonAsync<Categories[]>("api/categories");
        }

        public async Task<IEnumerable<Categories>> GetcategoryDetails(string name)
        {
            return await httpClient.GetJsonAsync<Categories[]>($"api/categories/{name}");
        }
    }
}
