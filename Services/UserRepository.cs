using System.Collections.Generic;
using System.Security.Claims;
using HRMS.Services;
using Microsoft.AspNetCore.Http;

public class UserRepository : IUserRepository
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    // Le IHttpContextAccessor permet d'accéder au HttpContext de la requête en cours
    public UserRepository(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetUserId()
    {
        return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    public string GetUserName()
    {
        return _httpContextAccessor.HttpContext.User.Identity.Name;
    }

    public bool IsAuthenticated()
    {
        return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
    }

    public IEnumerable<Claim> GetClaims()
    {
        return _httpContextAccessor.HttpContext.User.Claims;
    }
}
