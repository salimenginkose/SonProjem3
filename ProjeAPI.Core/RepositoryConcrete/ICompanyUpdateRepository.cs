using ProjeAPI.Core.Entities;
using ProjeAPI.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeAPI.Core.RepositoryConcrete
{
    public class UpdateCompanyService
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public CompanyApproveService CompanyStatus { get; set; }

        [Required]
        public short StartingHour { get; set; }

        [Required]
        public short StartingMinute { get; set; }

        [Required]
        public short EndingHour { get; set; }

        [Required]
        public short EndingMinute { get; set; }
        public Company CreateCompanyObjectFromMe(Company currentCompany)
        {
            return new Company()
            {
                Id = currentCompany.Id,
                CompanyName = currentCompany.CompanyName,
                CompanyStatus = this.CompanyStatus,
                EndingHour = this.EndingHour,
                EndingMinute = this.EndingMinute,
                StartingMinute = this.StartingMinute,
                StartingHour = this.StartingHour,
            };
        }
    }
}
