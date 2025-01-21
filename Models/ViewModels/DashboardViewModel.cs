namespace HRMS.Models.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalConges { get; set; }
        public int EnAttente { get; set; }
        public int Approuves { get; set; }
        public int Refuses { get; set; }
        public List<LeaveRequest>? RecentConges { get; set; }
    }
}