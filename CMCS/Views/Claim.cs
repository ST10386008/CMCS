﻿namespace CMCS.Models
{
    public class ClaimModel
    {
        public int ClaimID { get; set; }
        public int LecturerID { get; set; }
        public decimal HoursWorked { get; set; }
        public required string Status { get; set; }
        public DateTime ClaimDate { get; set; }
    }
}
