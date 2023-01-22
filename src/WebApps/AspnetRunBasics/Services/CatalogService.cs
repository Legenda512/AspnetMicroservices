using AspnetRunBasics.Extensions;
using AspnetRunBasics.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;

        public CatalogService(HttpClient client)
        {
            _client = client;
        }

        public async Task<CatalogModel> CreateCatalog(CatalogModel model)
        {
            var responce = await _client.PostAsJson("/Catalog", model);
            if (responce.IsSuccessStatusCode)
            {
                return await responce.ReadContentAs<CatalogModel>();
            }
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }

        }

        public async Task<IEnumerable<CatalogModel>> GetCatalog()
        {
            var responce = await _client.GetAsync("/Catalog");
            return await responce.ReadContentAs<List<CatalogModel>>();
        }

        public async Task<CatalogModel> GetCatalog(string id)
        {
            var responce = await _client.GetAsync($"/Catalog/{id}");
            return await responce.ReadContentAs<CatalogModel>();

        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category)
        {
            var responce = await _client.GetAsync($"/Catalog/GetProductByCategory/{category}");
            return await responce.ReadContentAs<List<CatalogModel>>();
        }
    }
}
