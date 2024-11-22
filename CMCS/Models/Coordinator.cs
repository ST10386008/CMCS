public class Coordinator
{
    public int CoordinatorID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
    public string Email { get; set; }

    // Navigation property
    public ICollection<Claim> ApprovedClaims { get; set; } = new List<Claim>(); // Initialize to avoid null reference
}
