public class Lecturer
{
    public int LecturerID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public decimal HourlyRate { get; set; }

    // Navigation property
    public ICollection<Claim> Claims { get; set; }
}
