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
    public class CompanyServices : ICompanyService
    {
        private readonly ICrossCuttingRepository<Company> _companyRepository;

        public CompanyServices(
            ICrossCuttingRepository<Company> companyRepository
            )
        {
            _companyRepository = companyRepository;
        }

        public async Task<OperationResult<Company>> AddCompany(AddCompanyService newCompany)
        {
            try
            {
                if (newCompany is null)
                    return OperationResult<Company>.Fail(HttpCodes.NotFound, SystemErrors.INVALID_INPUT);

                var res = this.IsHourAndMinuteValid(newCompany.StartingMinute, newCompany.StartingHour, newCompany.EndingMinute, newCompany.EndingHour);
                if (!res)
                    return OperationResult<Company>.Fail(HttpCodes.NotFound, SystemErrors.INVALID_INPUT);

                var company = newCompany.CreateCompanyObjectFromMe();
                await _companyRepository.Add(company);
                return OperationResult<Company>.Success(company);
            }
            catch (Exception ex)
            {
                return OperationResult<Company>.Fail(HttpCodes.ServerError, SystemErrors.INTERNAL_SERVER_ERROR, ex.ToString());
            }

        }
        public async Task<OperationResult<IEnumerable<Company>>> GetAllCompanies()
        {
            try
            {
                var companies = await _companyRepository.FindAllAsync(com => true);
                return OperationResult<IEnumerable<Company>>.Success(companies);
            }
            catch (Exception ex)
            {
                return OperationResult<IEnumerable<Company>>.Fail(HttpCodes.ServerError, SystemErrors.INTERNAL_SERVER_ERROR, ex.ToString());
            }
        }
        public async Task<OperationResult<bool>> UpdateCompany(UpdateCompanyService updatedCompany)
        {
            try
            {
                var currentCompany = await _companyRepository.FindOneAsync(comp => comp.Id == updatedCompany.Id);

                if (currentCompany is null)
                    return OperationResult<bool>.Fail(HttpCodes.NotFound, SystemErrors.COMPANY_NOT_FOUND);

                var res = this.IsHourAndMinuteValid(updatedCompany.StartingMinute, updatedCompany.StartingHour, updatedCompany.EndingMinute, updatedCompany.EndingHour);
                if (!res)
                    return OperationResult<bool>.Fail(HttpCodes.NotFound, SystemErrors.INVALID_INPUT);

                var company = updatedCompany.CreateCompanyObjectFromMe(currentCompany);
                await _companyRepository.Update(company);

                return OperationResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail(HttpCodes.ServerError, SystemErrors.INTERNAL_SERVER_ERROR, ex.ToString());
            }
        }

        private bool IsHourAndMinuteValid(int StartingMinute, int StartingHour, int EndingMinute, int EndingHour)
        {
            bool validateStartingHour = StartingHour >= 0 && StartingHour <= 23;
            bool validateEndingHour = EndingHour >= 0 && EndingHour <= 23;

            bool validateStartingMinute = StartingMinute >= 0 && StartingMinute <= 59;
            bool validateEndingMinute = EndingMinute >= 0 && EndingMinute <= 59;

            return (validateStartingHour && validateStartingMinute && validateEndingHour && validateEndingMinute);
        }
    }
}
