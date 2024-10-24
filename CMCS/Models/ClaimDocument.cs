public class ClaimDocument
{
    public int DocumentID { get; set; }
    public int ClaimID { get; set; }
    public string DocumentName { get; set; }
    public string FilePath { get; set; }
    public DateTime UploadDate { get; set; }

    public Claim Claim { get; set; }
}
