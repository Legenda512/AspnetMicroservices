using AspnetRunBasics.Extensions;
using AspnetRunBasics.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _client;

        public BasketService(HttpClient client)
        {
            _client = client;
        }

        public async Task CheckoutBasket(BasketCheckoutModel model)
        {
            var responce = await _client.PostAsJson("/Basket/Checkout", model);
            if (!responce.IsSuccessStatusCode)
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }

        public async Task<BasketModel> GetBasket(string userName)
        {
            var responce = await _client.GetAsync($"/Basket/{userName}");
            return await responce.ReadContentAs<BasketModel>();
        }

        public async Task<BasketModel> UpdateBasket(BasketModel model)
        {
            var responce = await _client.PostAsJson("/Basket", model);
            if (responce.IsSuccessStatusCode)
            {
                return await responce.ReadContentAs<BasketModel>();
            }
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }
    }
}
