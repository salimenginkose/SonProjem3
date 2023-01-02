using Microsoft.AspNetCore.Mvc;
using ProjeAPI.Core.API;
using ProjeAPI.Core.Entities;
using ProjeAPI.Core.Enums.Errors;
using ProjeAPI.Core.RepositoryConcrete;
using ProjeAPI.Core.Services;


namespace ProjeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerProcess
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("AddCompany")]
        [ProducesResponseType(typeof(Company), (int)HttpCodes.Succeded)]
        [ProducesResponseType(typeof(Company), (int)HttpCodes.ServerError)]
        public async Task<IActionResult> AddCompany([FromBody] AddCompanyService model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _companyService.AddCompany(model);
            return this.ProccessResult(res);
        }

        [HttpGet("GetAllCompanies")]
        [ProducesResponseType(typeof(IEnumerable<Company>), (int)HttpCodes.Succeded)]
        [ProducesResponseType(typeof(IEnumerable<Company>), (int)HttpCodes.ServerError)]
        public async Task<IActionResult> GetAllCompanies()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _companyService.GetAllCompanies();
            return this.ProccessResult(res);
        }

        [HttpPut("UpdateCompany")]
        [ProducesResponseType(typeof(bool), (int)HttpCodes.Succeded)]
        [ProducesResponseType(typeof(bool), (int)HttpCodes.NotFound)]
        [ProducesResponseType(typeof(bool), (int)HttpCodes.ServerError)]
        public async Task<IActionResult> UpdateCompany([FromBody] UpdateCompanyService model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _companyService.UpdateCompany(model);
            return this.ProccessResult(res);
        }
    }
}
