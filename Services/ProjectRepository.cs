using HRMS.Data;
using HRMS.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Services
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext context;

        public ProjectRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddProjectAsync(Project project)
        {
            if (project != null)
            {
                context.Projects.Add(project);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Project>> GetAllProjectAsync()
        {
            return await context.Projects
                                        .Include(e => e.Employees)
                                        .ToListAsync();
        }
    }
}