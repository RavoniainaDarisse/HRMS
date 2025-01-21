using HRMS.Models;
using HRMS.Models.domaine;
using HRMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository repository;
        private readonly IDepartementRepository departementRepository;
        private readonly IProjectRepository projectRepository;

        public EmployeeController(IEmployeeRepository repository, IDepartementRepository departementRepository, IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
            this.departementRepository = departementRepository;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await repository.GetAllEmployeesAsync();
            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> AddEmployee()
        {
            ViewBag.Departments = await departementRepository.GetAllDepartmentsAsync();
            ViewBag.Projects = await projectRepository.GetAllProjectAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeADD employeeADD)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    FirstName = employeeADD.FirstName,
                    LastName = employeeADD.LastName,
                    Email = employeeADD.Email,
                    DateOfBirth = employeeADD.DateOfBirth,
                    DateHired = employeeADD.DateHired,
                    DepartmentId = employeeADD.DepartmentId,
                    ProjectId = employeeADD.ProjectId
                };
                await repository.AddEmployeeAsync(employee);

                TempData["Email"] = employeeADD.Email;
                return RedirectToAction("Register", "Auth");
            }
            ViewBag.Departments = await departementRepository.GetAllDepartmentsAsync();
            ViewBag.Projects = await projectRepository.GetAllProjectAsync();
            return View(employeeADD);
        }
    }
}