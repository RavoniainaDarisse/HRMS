using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HRMS.Models;
using Microsoft.AspNetCore.Authorization;

namespace HRMS.Controllers;

[Authorize(Roles = "Employee")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
         var email = TempData["Email"] as string; 
        ViewBag.Email = email;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
