using Microsoft.EntityFrameworkCore;
using Pagination_API_Onion_Generic_Data_MetaData.API.Application.Services;
using Pagination_API_Onion_Generic_Data_MetaData.API.Domain;
using Pagination_API_Onion_Generic_Data_MetaData.API.Infrastructure.Database;
using Pagination_API_Onion_Generic_Data_MetaData.Domain;
using System;
using System.Data;

namespace Pagination_API_Onion_Generic_Data_MetaData.API.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Employee>, PaginationMetadata)> GetEmployeesByCompanyIdAsync(int companyId, int pageIndex = 1, int pageSize = 50)
        {
            var totalRecords = await _context.Employees.CountAsync(e => e.CompanyId == companyId);
            var employees = await _context.Employees
      .Where(e => e.CompanyId == companyId)
      .AsNoTracking()  // Prevents EF Core from tracking changes
      .Skip((pageIndex - 1) * pageSize)
      .Take(pageSize)
      .ToListAsync();

            var metadata = new PaginationMetadata { TotalItems = totalRecords, PageSize = pageSize, CurrentPage = pageIndex };

            return (employees, metadata);
        }
    }
}
