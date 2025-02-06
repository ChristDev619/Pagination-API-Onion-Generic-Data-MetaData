using Pagination_API_Onion_Generic_Data_MetaData.API.Domain;
using Pagination_API_Onion_Generic_Data_MetaData.API.Infrastructure.Repositories;
using Pagination_API_Onion_Generic_Data_MetaData.Domain;

namespace Pagination_API_Onion_Generic_Data_MetaData.API.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<PaginatedResponse<Employee>> GetEmployeesByCompanyIdAsync(int companyId, int pageIndex = 1, int pageSize = 50)
        {
            // Business Logic: Validate Inputs
            if (companyId <= 0) throw new ArgumentException("Invalid Company ID.");
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1 || pageSize > 100) pageSize = 50; // Restricting page size

            // Fetch data from Repository
            var (employees, metadata) = await _employeeRepository.GetEmployeesByCompanyIdAsync(companyId, pageIndex, pageSize);

            return new PaginatedResponse<Employee>
            {
                Data = employees,
                Metadata = metadata
            };
        }
    }


}
