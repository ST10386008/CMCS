using System.ComponentModel.DataAnnotations;

namespace ContractMonthlyClaimSystem.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public string LecturerId { get; set; } // Foreign key to identify lecturer
        public int HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal TotalAmount { get; set; } // Auto-calculated field
        public string Notes { get; set; }
        public string Status { get; set; } // Pending, Approved, Rejected
        public DateTime SubmissionDate { get; set; }
        public List<SupportingDocument> Documents { get; set; }
    }

}
