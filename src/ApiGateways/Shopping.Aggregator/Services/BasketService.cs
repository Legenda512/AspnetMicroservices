﻿using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _client;

        public BasketService(HttpClient client)
        {
            _client = client;
        }

        public async Task<BasketModel> GetBasket(string userName)
        {
            var responce = await _client.GetAsync($"/api/v1/Basket/{userName}");
            return await responce.ReadContentAs<BasketModel>();
        }
    }
}
