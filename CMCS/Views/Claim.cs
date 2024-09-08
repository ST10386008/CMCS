namespace CMCS.Models
{
    public class Claim
    {
        public int ClaimID { get; set; }
        public int LecturerID { get; set; }
        public decimal HoursWorked { get; set; }
        public string Status { get; set; }
        public DateTime ClaimDate { get; set; }
    }
}
