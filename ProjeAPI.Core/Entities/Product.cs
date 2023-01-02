using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeAPI.Core.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; } = "";
        public long Stock { get; set; }
        public double Price { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; } 
    }
}
