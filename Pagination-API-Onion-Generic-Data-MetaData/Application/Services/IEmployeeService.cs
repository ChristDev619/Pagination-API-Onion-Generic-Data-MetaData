using Pagination_API_Onion_Generic_Data_MetaData.API.Domain;
using Pagination_API_Onion_Generic_Data_MetaData.Domain;

namespace Pagination_API_Onion_Generic_Data_MetaData.API.Application.Services
{
    public interface IEmployeeService
    {
        Task<PaginatedResponse<Employee>> GetEmployeesByCompanyIdAsync(int companyId, int pageIndex = 1, int pageSize = 50);
    }

}
