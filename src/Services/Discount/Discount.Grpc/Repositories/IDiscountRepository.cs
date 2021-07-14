using Discount.Grpc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Grpc.Repositories
{
    public interface IDiscountRepository
    {
        Task<Coupan> GetDiscount(string productName);
        Task<bool> CreateDiscount(Coupan coupan);
        Task<bool> UpdateDiscount(Coupan coupan);
        Task<bool> DeleteDiscount(string productName);


    }
}
