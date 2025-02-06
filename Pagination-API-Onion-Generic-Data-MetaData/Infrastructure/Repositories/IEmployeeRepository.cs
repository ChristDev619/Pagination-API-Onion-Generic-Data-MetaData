using Pagination_API_Onion_Generic_Data_MetaData.API.Domain;
using Pagination_API_Onion_Generic_Data_MetaData.Domain;

namespace Pagination_API_Onion_Generic_Data_MetaData.API.Infrastructure.Repositories
{
    public interface IEmployeeRepository
    {
        Task<(IEnumerable<Employee>, PaginationMetadata)> GetEmployeesByCompanyIdAsync(int companyId, int pageIndex, int pageSize);
    }

}
