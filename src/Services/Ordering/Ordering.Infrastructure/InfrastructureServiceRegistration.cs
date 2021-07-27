using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ordering.Application.Contracts.Persistence;
using Ordering.Infrastructure.Repositories;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Infrastructure.Mail;

namespace Ordering.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(options => options.UseSqlServer(configuration.GetConnectionString("OrderingConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.Configure<EmailService>(c => configuration.GetConnectionString("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}


