using Microsoft.AspNetCore.Mvc;

public class ClaimsController : Controller
{
    private readonly ClaimService _claimService;

    public ClaimsController(ClaimService claimService)
    {
        _claimService = claimService;
    }

    // GET: Show form
    public IActionResult Create()
    {
        return View();
    }

    // POST: Submit Claim
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(LecturerClaim claim, IFormFile document)
    {
        if (ModelState.IsValid)
        {
            if (document != null && IsValidFileType(document))
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", document.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await document.CopyToAsync(stream);
                }
                claim.DocumentPath = "/files/" + document.FileName;
            }

            await _claimService.CreateClaimAsync(claim);
            return RedirectToAction(nameof(TrackClaims)); // Redirect to claim tracking
        }
        return View(claim);
    }

    public async Task<IActionResult> VerifyClaims()
    {
        var pendingClaims = await _claimService.GetPendingClaimsAsync();
        return View(pendingClaims);
    }

    [HttpPost]
    public async Task<IActionResult> ApproveClaim(int claimId)
    {
        await _claimService.UpdateClaimStatusAsync(claimId, ClaimStatus.Approved);
        return RedirectToAction(nameof(VerifyClaims));
    }

    [HttpPost]
    public async Task<IActionResult> RejectClaim(int claimId)
    {
        await _claimService.UpdateClaimStatusAsync(claimId, ClaimStatus.Rejected);
        return RedirectToAction(nameof(VerifyClaims));
    }

    public async Task<IActionResult> TrackClaims(int lecturerId)
    {
        var claims = await _claimService.GetClaimsByLecturerAsync(lecturerId);
        return View(claims);
    }

    private bool IsValidFileType(IFormFile file)
    {
        var allowedExtensions = new[] { ".pdf", ".docx", ".xlsx" };
        var extension = Path.GetExtension(file.FileName).ToLower();
        return allowedExtensions.Contains(extension);
    }
}
