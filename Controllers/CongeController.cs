using HRMS.Models;
using HRMS.Models.domaine;
using HRMS.Models.ViewModels;
using HRMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    public class CongeController : Controller
    {
        private new readonly IUserRepository User;
        private readonly IEmployeeRepository employee;
        private readonly ICongeRepository congeRepository;

        public CongeController(IUserRepository user, IEmployeeRepository employee, ICongeRepository congeRepository)
        {
            this.congeRepository = congeRepository;
            this.User = user;
            this.employee = employee;
        }
        
        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
           
            var allConges = await congeRepository.ListConge();
            var stats = new DashboardViewModel
            {
                TotalConges = allConges.Count,
                EnAttente = allConges.Count(c => c.Status == LeaveStatus.Pending),
                Approuves = allConges.Count(c => c.Status == LeaveStatus.Approved),
                Refuses = allConges.Count(c => c.Status == LeaveStatus.Denied),
                RecentConges = allConges.OrderByDescending(c => c.StartDate).Take(5).ToList()
            };
            return View(stats);
        }

        [HttpGet]
        public IActionResult DemandeDeConge()
        {
            var nameUser = User.GetUserName();
            ViewBag.email = nameUser;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DemandeDeConge(CongeSend congeSend)
        {
            var emailConnect = congeSend.emailRecup;  // Vérifier si GetUserName() est bien défini
            Console.WriteLine($"📧 Email connecté : {emailConnect}");

            if (emailConnect != null)
            {
                var employees = await employee.GetEmployeeByEmailAsync(emailConnect);
                if (employees == null)
                {
                    Console.WriteLine("⚠ Aucun employé trouvé !");
                    return RedirectToAction("DemandeDeConge");
                }

                try
                {
                    Console.WriteLine("📝 Création d'une demande de congé...");
                    var conge = new LeaveRequest
                    {
                        EmployeeId = employees.Id,
                        Reason = congeSend.Reason,
                        Status = (LeaveStatus)congeSend.Status,
                        StartDate = congeSend.StartDate,
                        EndDate = congeSend.EndDate
                    };

                    await congeRepository.SaveCongeAsync(conge);
                    Console.WriteLine("✅ Demande enregistrée avec succès !");

                    return RedirectToAction("DemandeDeConge");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Erreur lors de l'enregistrement : {ex.Message}");
                }
            }

            return RedirectToAction("DemandeDeConge");
        }

        [HttpGet]
        public async Task<IActionResult> ListDemande()
        {
            var listConge = await congeRepository.ListConge();
            return View(listConge);
        }

        [HttpGet("Conge/ModifierDemande/{CongeId}")]
        public async Task<IActionResult> ModifierDemande(int CongeId)
        {
            var conge = await congeRepository.GetCongeByIdAsync(CongeId);
            if (conge == null)
            {
                Console.WriteLine("page n'est trouve");
                return NotFound();
            }
            var changeConge = new CongeUpdate
            {
                Id = CongeId,
                Reason = conge.Reason,
                EmployeeId = conge.EmployeeId,
                StartDate = conge.StartDate,
                EndDate = conge.EndDate,
                Status = (CongeUpdate.LeaveStatus)conge.Status
            };
            return View(changeConge);
        }

        [HttpPost]
        public async Task<IActionResult> ModifierDemande(CongeUpdate conge)
        {
            if (conge != null)
            {
                var conges = new LeaveRequest
                {
                    Id = conge.Id,
                    StartDate = conge.StartDate,
                    EndDate = conge.EndDate,
                    EmployeeId = conge.EmployeeId,
                    Reason = conge.Reason,
                    Status = (LeaveStatus)conge.Status
                };
                try
                {
                    await congeRepository.UpdateCongeAsync(conges);
                    Console.WriteLine("✅ Modification reussis");
                    return RedirectToAction("ModifierDemande");
                }
                catch (Exception)
                {
                    Console.WriteLine("❌ Modification echouer");
                }
            }
            return NotFound();
        }

    }
}