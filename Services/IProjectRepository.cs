using HRMS.Models;

namespace HRMS.Services
{
    public interface IProjectRepository
    {
        Task <List<Project>> GetAllProjectAsync();
        Task AddProjectAsync(Project project);
    }
}