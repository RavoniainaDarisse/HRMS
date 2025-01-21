using HRMS.Models;

namespace HRMS.Services
{
    public interface IDepartementRepository
    {
        Task<List<Department>> GetAllDepartmentsAsync();
        Task AddDepartementAsync(Department department);
    }
}