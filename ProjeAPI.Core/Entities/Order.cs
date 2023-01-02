using ProjeAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeAPI.Core.Entities
{
    public class Order : BaseEntity
    {
        public string CustomerName { get; set; } = "";
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
