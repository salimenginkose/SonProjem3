using ProjeAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeAPI.Core.RepositoryConcrete
{
    public class AddOrderService
    {
        [Required]
        public string CustomerName { get; set; } = "";

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Order createOrderObjectFromMe()
        {
            return new Order()
            {
                CustomerName = this.CustomerName,
                CompanyId = this.CompanyId,
                ProductId = this.ProductId,
                OrderDate = DateTime.UtcNow
            };
        }
    }
}
