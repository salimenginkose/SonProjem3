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
    public interface ICompanyService
    {
        Task<OperationResult<Company>> AddCompany(AddCompanyService newCompany);
        Task<OperationResult<bool>> UpdateCompany(UpdateCompanyService updatedCompany);
        Task<OperationResult<IEnumerable<Company>>> GetAllCompanies();
    }
}
