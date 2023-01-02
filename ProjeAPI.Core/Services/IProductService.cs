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
    public interface IProductService
    {
        Task<OperationResult<Product>> AddProduct(AddProductService newProduct);
        Task<OperationResult<IEnumerable<Product>>> GetAllProducts();
    }
}
