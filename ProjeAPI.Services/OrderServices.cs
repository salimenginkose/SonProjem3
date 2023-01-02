using ProjeAPI.Core.API;
using ProjeAPI.Core.Entities;
using ProjeAPI.Core.Enums;
using ProjeAPI.Core.Enums.Errors;
using ProjeAPI.Core.RepositoryConcrete;
using ProjeAPI.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeAPI.Services
{
    public class OrderServices : IOrderService
    {
        private readonly ICrossCuttingRepository<Company> _companyRepository;
        private readonly ICrossCuttingRepository<Product> _productRepository;
        private readonly ICrossCuttingRepository<Order> _orderRepository;

        public OrderServices(ICrossCuttingRepository<Order> orderRepository,ICrossCuttingRepository<Product> productRepository,ICrossCuttingRepository<Company> companyRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _companyRepository = companyRepository;
        }

        public async Task<OperationResult<IEnumerable<Order>>> GetAllOrders()
        {
            var orders = await _orderRepository.FindAllAsync(ord => true, nameof(Order.Product), nameof(Order.Company));
            return OperationResult<IEnumerable<Order>>.Success(orders);
        }

        public async Task<OperationResult<Order>> MakeNewOrder(AddOrderService newOrder)
        {
            try
            {
                if (newOrder is null)
                    return OperationResult<Order>.Fail(HttpCodes.NotFound, SystemErrors.INVALID_INPUT);

                var company = await _companyRepository.FindOneAsync(comp => comp.Id == newOrder.CompanyId);

                if (company is null)
                    return OperationResult<Order>.Fail(HttpCodes.NotFound, SystemErrors.COMPANY_NOT_FOUND);

                if (company.CompanyStatus == CompanyApproveService.NotReviewed || company.CompanyStatus == CompanyApproveService.Rejected)
                    return OperationResult<Order>.Fail(HttpCodes.NotFound, SystemErrors.YOU_CAN_NOT_MAKE_ORDER_BECAUSE_COMPANY_STATUS_NOT_APPROVED);

                var currentHour = DateTime.UtcNow.Hour;
                var currentMinute = DateTime.UtcNow.Minute;

                bool validateHour = currentHour >= company.StartingHour && currentHour <= company.EndingHour;
                bool validateMinute = currentMinute >= company.StartingMinute && currentMinute <= company.EndingMinute;
                if (!(validateHour && validateMinute))
                    return OperationResult<Order>.Fail(HttpCodes.NotFound, SystemErrors.YOU_CAN_NOT_MAKE_ORDER_BECAUSE_COMPANY_IS_CLOSED_NOW);


                var product = await _productRepository.FindOneAsync(prod => prod.Id == newOrder.ProductId);
                if (product is null)
                    return OperationResult<Order>.Fail(HttpCodes.NotFound, SystemErrors.PRODUCT_NOT_FOUND);

                var order = newOrder.createOrderObjectFromMe();
                await _orderRepository.Add(order);
                return OperationResult<Order>.Success(order);
            }
            catch (Exception ex)
            {
                return OperationResult<Order>.Fail(HttpCodes.ServerError, SystemErrors.INTERNAL_SERVER_ERROR, ex.ToString());

            }
        }
    }
}
