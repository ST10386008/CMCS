public class Claim
{
    public int ClaimID { get; set; }
    public int LecturerID { get; set; }
    public decimal HoursWorked { get; set; }
    public DateTime ClaimDate { get; set; }
    public string Status { get; set; }
    public int ApprovedBy { get; set; }

    public Lecturer Lecturer { get; set; }
    public Coordinator Coordinator { get; set; }
    public ICollection<ClaimDocument> ClaimDocuments { get; set; }
    public ICollection<ClaimStatus> ClaimStatuses { get; set; }
}
