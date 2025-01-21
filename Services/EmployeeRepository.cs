using HRMS.Data;
using HRMS.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task AddEmployeeAsync(Employee employee)
        {
            appDbContext.Employees.Add(employee);
            await appDbContext.SaveChangesAsync();
        }

        public Task DeleteEmployeeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await appDbContext.Employees
                                               .Include(e => e.Department)
                                               .Include(e => e.Project)
                                               .ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await appDbContext.Employees
                                        .Include(e => e.Department)
                                        .Include(e => e.Project)
                                        .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Employee?> GetEmployeeByEmailAsync(string email)
        {
            return await appDbContext.Employees
                                        .Include(e => e.Department)
                                        .Include(e => e.Project)
                                        .FirstOrDefaultAsync(e => e.Email == email);
        }

        public Task UpdateEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}