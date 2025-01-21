using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMS.Models;

namespace HRMS.Services
{
    public interface ICongeRepository
    {
        Task SaveCongeAsync(LeaveRequest conge);
        Task UpdateCongeAsync(LeaveRequest conge);
        Task<List<LeaveRequest>> ListConge();
        Task<LeaveRequest?> GetCongeByIdAsync(int id);
    }
}