namespace ContractMonthlyClaimSystem.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string Role { get; set; } // Lecturer, Coordinator, Manager
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
