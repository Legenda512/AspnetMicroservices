using AspnetRunBasics.Extensions;
using AspnetRunBasics.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName)
        {
            var responce = await _client.GetAsync($"/Order/{userName}");
            return await responce.ReadContentAs<List<OrderResponseModel>>();
        }
    }
}
