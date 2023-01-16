using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;

        public CatalogService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalog()
        {
            var responce = await _client.GetAsync("/api/v1/Catalog");
            return await responce.ReadContentAs<List<CatalogModel>>();
        }

        public async Task<CatalogModel> GetCatalog(string id)
        {
            var responce = await _client.GetAsync($"/api/v1/Catalog/{id}");
            return await responce.ReadContentAs<CatalogModel>();
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category)
        {
            var responce = await _client.GetAsync($"/api/v1/Catalog/GetProductByCategory/{category}");
            return await responce.ReadContentAs<List<CatalogModel>>();
        }
    }
}
