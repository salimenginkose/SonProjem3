using ProjeAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeAPI.Core.RepositoryConcrete
{
    public class AddProductService
    {
        [Required]
        public string ProductName { get; set; } = "";

        [Required]
        public long Stock { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public Product CreateProductObjectFromMe()
        {
            return new Product()
            {
                CompanyId = this.CompanyId,
                ProductName = this.ProductName,
                Price = this.Price,
                Stock = this.Stock
            };
        }
    }
}
