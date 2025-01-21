using HRMS.Models;
using HRMS.Models.domaine;
using HRMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    public class ProjectController: Controller
    {
        private readonly IProjectRepository repository;

        public ProjectController(IProjectRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var project = await repository.GetAllProjectAsync();
            return View(project);
        }


        [HttpGet]
        public IActionResult AddProject()
        {
            ViewBag.StatusList = Enum.GetValues(typeof(Models.ProjectStatus))
                                     .Cast<Models.ProjectStatus>()
                                     .Select(s => new { Id = (int)s, Name = s.ToString() })
                                     .ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(ProjectAdd projectAdd)
        {
               if (projectAdd != null )
               {
                    var prjt = new Project
                    {
                        Name = projectAdd.Name,
                        StartDate = projectAdd.StartDate,
                        EndDate = projectAdd.EndDate,
                        Code = projectAdd.Code,
                        Description = projectAdd.Description,
                        Budget = projectAdd.Budget,
                        Client = projectAdd.Client,
                        Status = (Models.ProjectStatus)projectAdd.Status
                    };
                    await  repository.AddProjectAsync(prjt);
                    return RedirectToAction("AddProject");
               } 
                ViewBag.StatusList = Enum.GetValues(typeof(Models.ProjectStatus))
                             .Cast<Models.ProjectStatus>()
                             .Select(s => new { Id = (int)s, Name = s.ToString() })
                             .ToList();
               return RedirectToAction("AddProject");
        }
    }
}