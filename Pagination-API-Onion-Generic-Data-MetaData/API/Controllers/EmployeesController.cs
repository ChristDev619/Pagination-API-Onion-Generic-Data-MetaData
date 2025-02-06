using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pagination_API_Onion_Generic_Data_MetaData.API.Application.Services;
using Pagination_API_Onion_Generic_Data_MetaData.API.Domain;
using Pagination_API_Onion_Generic_Data_MetaData.Domain;

namespace Pagination_API_Onion_Generic_Data_MetaData.API.API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResponse<Employee>>> GetEmployees([FromQuery] int companyId, [FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 50)
        {
            var response = await _employeeService.GetEmployeesByCompanyIdAsync(companyId, pageIndex, pageSize);
            return Ok(response);
        }
    }

}
