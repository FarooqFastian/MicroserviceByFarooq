using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;


        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);

            return string.IsNullOrEmpty(basket) ? null : JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        //public async Task<bool> UpdateBasket(string userName, string productId)
        //{

        //    var productIds = await _redisCache.GetStringAsync("id_" + userName);
        //    productIds = productIds != null ? productIds + ", " + productId : productId;


        //    await _redisCache.SetStringAsync("id_" + userName, productIds);

        //    return true;
        //}

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            var baskets = await GetBasket(basket.UserName);

            if (baskets == null)
                baskets = new ShoppingCart(basket.UserName);

            if (baskets.Items.Where(x => x.ProductId == basket.Items[0].ProductId).Any())
            {
                baskets.Items.Where(x => x.ProductId == basket.Items[0].ProductId).First().Quantity += basket.Items[0].Quantity;
            }
            else
            {
                baskets?.Items?.Add(basket.Items[0]);
            }

            await _redisCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(baskets));
            return await GetBasket(basket.UserName);
        }

        public async Task DeleteBasket(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }
    }
}
