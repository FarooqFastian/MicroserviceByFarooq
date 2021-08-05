using Microsoft.AspNetCore.Mvc;
using Shopping.Aggregator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Controllers
{
    public class ShoppingController: ControllerBase  
    {
        private readonly ICatalogService _catalogService;
        private readonly IBasketService _basketService;
        private readonly IOrderService _orderService;

        public ShoppingController(ICatalogService catalogService, IBasketService basketService, IOrderService orderService)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }
    }
}
