public class LecturerClaim
{
    public int ClaimID { get; set; }
    public int LecturerID { get; set; }
    public decimal HoursWorked { get; set; }
    public decimal HourlyRate { get; set; }
    public DateTime ClaimDate { get; set; }
    public string DocumentPath { get; set; }
    public string Notes { get; set; }
    public ClaimStatus Status { get; set; } = ClaimStatus.Pending;
}
public enum ClaimStatus
{
    Pending,
    Approved,
    Rejected
}
