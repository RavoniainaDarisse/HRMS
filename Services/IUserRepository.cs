using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HRMS.Services
{
    public interface IUserRepository
    {
        string GetUserId();
        string GetUserName();
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaims();
    }
}