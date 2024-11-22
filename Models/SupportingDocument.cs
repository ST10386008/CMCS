namespace ContractMonthlyClaimSystem.Models
{
    public class SupportingDocument
    {
        public int DocumentId { get; set; }
        public int ClaimId { get; set; }
        public Claim Claim { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }

}
