using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;
using Discount.Grpc.Repositories;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Discount.Grpc.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<DiscountService> _logger;

        public DiscountService(IDiscountRepository repository, IMapper mapper, ILogger<DiscountService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override async Task<CoupanModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupan = await _repository.GetDiscount(request.ProductName);

            if (coupan == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName={request.ProductName} is not found."));
            }

            _logger.LogInformation($"Discount is retrieved for ProductName: {coupan.ProductName}, Amount: {coupan.Amount}");
            var coupanModel = _mapper.Map<CoupanModel>(coupan);
            return coupanModel;
        }

        public override async Task<CoupanModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupan = _mapper.Map<Coupan>(request.Coupan);

            await _repository.CreateDiscount(coupan);
            _logger.LogInformation($"Discount is successfully created. ProductName: {coupan.ProductName}");

            var coupanModel = _mapper.Map<CoupanModel>(coupan);
            return coupanModel;
        }

        public override async Task<CoupanModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupan = _mapper.Map<Coupan>(request.Coupan);

            await _repository.UpdateDiscount(coupan);
            _logger.LogInformation($"Discount is successfully updated. ProductName: {coupan.ProductName}");

            var coupanModel = _mapper.Map<CoupanModel>(coupan);
            return coupanModel;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var deleted = await _repository.DeleteDiscount(request.ProductName);
            var response = new DeleteDiscountResponse
            {
                Success = deleted
            };

            return response;
        }
    }
}
