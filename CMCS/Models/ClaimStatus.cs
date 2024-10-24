public class ClaimStatus
{
    public int StatusID { get; set; }
    public int ClaimID { get; set; }
    public string Status { get; set; }
    public DateTime StatusDate { get; set; }

    // Navigation property
    public Claim Claim { get; set; }
}
