using Discount.Grpc.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Grpc.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> CreateDiscount(Coupan coupan)
        {
            using var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected = await connection.ExecuteAsync("INSERT INTO COUPAN (ProductName, Description, Amount) VALUES (@ProductName, @Discription, @Amount)",
                new { ProductName = coupan.ProductName, Discription = coupan.Description, Amount = coupan.Amount });

            return affected != 0;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            using var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected = await connection.ExecuteAsync("DELETE FROM COUPAN WHERE ProductName=@ProductName",
                new { ProductName = productName });

            return affected != 0;
        }

        public async Task<Coupan> GetDiscount(string productName)
        {
            using var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var coupan = await connection.QueryFirstOrDefaultAsync<Coupan>
                ("SELECT * FROM COUPAN WHERE ProductName = @ProductName", new { ProductName = productName });

            return coupan == null
                ? new Coupan
                {
                    ProductName = "No Discount",
                    Description = "No Discount Disc",
                    Amount = 0
                }
                : coupan;
        }

        public async Task<bool> UpdateDiscount(Coupan coupan)
        {
            using var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected = await connection.ExecuteAsync("UPDATE COUPAN SET ProductName = @ProductName, Description = @Discription , Amount = @Amount  WHERE ID=@Id",
                new { ProductName = coupan.ProductName, Discription = coupan.Description, Amount = coupan.Amount, Id = coupan.ID });

            return affected != 0;

        }
    }
}
