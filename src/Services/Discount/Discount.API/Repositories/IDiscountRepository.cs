using Discount.API.Entities;
using System.Threading.Tasks;

namespace Discount.API.Repositories
{
    public interface IDiscountRepository
    {
        Task<Coupan> GetDiscount(string productName);
        Task<bool> CreateDiscount(Coupan coupan);
        Task<bool> UpdateDiscount(Coupan coupan);
        Task<bool> DeleteDiscount(string productName);


    }
}
