using ProjeAPI.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeAPI.Core.Entities
{
    public class Company : BaseEntity
    {
        public string CompanyName { get; set; } = "";
        public CompanyApproveService CompanyStatus { get; set; }
        public short StartingHour { get; set; }
        public short StartingMinute { get; set; }
        public short EndingHour { get; set; }
        public short EndingMinute { get; set; }
        public IEnumerable<Product> Product { get; set; }

    }
}
