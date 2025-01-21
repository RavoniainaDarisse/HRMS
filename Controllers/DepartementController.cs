using HRMS.Models;
using HRMS.Models.domaine;
using HRMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    public class DepartementController : Controller
    {
        private readonly IDepartementRepository repository;
        private readonly IEmployeeRepository employeeRepository;
        public DepartementController(IDepartementRepository repository, IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
            this.repository = repository;
        }

        [HttpGet]
        public  async Task<IActionResult> Index()
        {
            var list = await repository.GetAllDepartmentsAsync();
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> AddDepartement()
        {
            ViewBag.Manager = await employeeRepository.GetAllEmployeesAsync();
            return View();
        }

        [HttpPost]
        public IActionResult AddDepartement(DepartementAdd departementAdd)
        {
            if (departementAdd != null)
            {
                var dpr = new Department
                {
                    Name = departementAdd.Name,
                    Code = departementAdd.Code,
                    Description = departementAdd.Description,
                    ManagerId = departementAdd.ManagerId,
                    Budget = departementAdd.Budget
                };
                repository.AddDepartementAsync(dpr);
                return RedirectToAction("AddDepartement");
            }

            return View();
        }
    }
}