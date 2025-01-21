using HRMS.Data;
using HRMS.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Services
{
    public class CongeRepository : ICongeRepository
    {
        private readonly AppDbContext context;
        public CongeRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<LeaveRequest?> GetCongeByIdAsync(int id)
        {
            return await context.LeaveRequests
                                             .Include(e => e.Employee)
                                             .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<LeaveRequest>> ListConge()
        {
            return await context.LeaveRequests
                                            .Include(e => e.Employee)
                                            .ToListAsync();
        }

        public async Task SaveCongeAsync(LeaveRequest conge)
        {
            Console.WriteLine("💾 Tentative d'enregistrement d'une demande de congé...");
            context.LeaveRequests.Add(conge);
            await context.SaveChangesAsync();
            Console.WriteLine("✅ Enregistrement réussi !");

        }

        public async Task UpdateCongeAsync(LeaveRequest conge)
        {
            context.LeaveRequests.Update(conge);
            await context.SaveChangesAsync();
            Console.WriteLine("✅ Modification réussi !");
        }
    }
}