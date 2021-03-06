using Discount.API.Entities;
using Discount.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Discount.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DiscountController :ControllerBase
    {
        private readonly IDiscountRepository _repository;

        public DiscountController(IDiscountRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{productName}", Name = "GetDiscount")]
        [ProducesResponseType(typeof(Coupan), (int)HttpStatusCode.OK)]
        public  async Task<ActionResult<Coupan>> GetDiscount(string productName)
        {
           var coupan= await _repository.GetDiscount(productName);
            return Ok(coupan);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Coupan), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupan>> CreateDiscount([FromBody] Coupan coupan)
        {
            await _repository.CreateDiscount(coupan);

            return CreatedAtRoute("GetDiscount", new { productName = coupan.ProductName }, coupan);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Coupan), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> UpdateDiscount([FromBody] Coupan coupan)
        {
            return Ok(await _repository.UpdateDiscount(coupan));
        }

        [HttpDelete("{productName}", Name = "DeleteDiscount")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteDiscount(string productName)
        {
            return Ok(await _repository.DeleteDiscount(productName));
        }
    }
}
