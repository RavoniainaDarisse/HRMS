
using HRMS.Data;
using HRMS.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Services
{
    public class DepartementRepository : IDepartementRepository
    {
        private readonly AppDbContext appDbContext;

        public DepartementRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task AddDepartementAsync(Department department)
        {
            appDbContext.Departments.Add(department);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
           return await appDbContext.Departments
                                                .Include(e => e.Manager)
                                                .ToListAsync();
        }
    }
}