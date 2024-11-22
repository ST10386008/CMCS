public class ClaimDocument
{
    public int DocumentID { get; set; } // Unique identifier for the document
    public int ClaimID { get; set; } // Foreign key linking to the Claim
    public string DocumentName { get; set; } // Name of the document
    public string FilePath { get; set; } // Path to the uploaded file
    public DateTime UploadDate { get; set; } // Date when the document was uploaded

    // Navigation property to reference the related Claim
    public Claim Claim { get; set; }
}
