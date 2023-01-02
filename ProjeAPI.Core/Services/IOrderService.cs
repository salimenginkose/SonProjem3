using ProjeAPI.Core.API;
using ProjeAPI.Core.Entities;
using ProjeAPI.Core.RepositoryConcrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeAPI.Core.Services
{
    public interface IOrderService
    {
        Task<OperationResult<Order>> MakeNewOrder(AddOrderService newOrder);
        Task<OperationResult<IEnumerable<Order>>> GetAllOrders();
    }
}
