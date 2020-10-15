using Microsoft.AspNetCore.Components;
using Startup_models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Startup_blazor.Services
{
    public class LinkRepositoryService : ILinkRepositoryService
    {
        private readonly HttpClient httpClient;

        public LinkRepositoryService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async Task<IEnumerable<LinkRepository>> GetLinks()
        {
            return await httpClient.GetJsonAsync<LinkRepository[]>("api/linkrepository");
        }

        public async Task<IEnumerable<LinkRepository>> GetLinksbyCategoryId(int id)
        {
            return await httpClient.GetJsonAsync<LinkRepository[]>($"api/linkrepository/{id}");
        }
    }
}
