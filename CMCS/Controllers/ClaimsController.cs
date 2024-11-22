using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class ClaimsController : Controller
{
    private readonly ClaimService _claimService;

    public ClaimsController(ClaimService claimService)
    {
        _claimService = claimService;
    }

    // GET: Show form to create a new claim
    public IActionResult Create()
    {
        return View();
    }

    // POST: Submit a new claim
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(LecturerClaim claim, IFormFile document)
    {
        if (ModelState.IsValid)
        {
            // Validate and save the uploaded document
            if (document != null && IsValidFileType(document))
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", document.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await document.CopyToAsync(stream);
                }
                claim.DocumentPath = "/files/" + document.FileName;
            }

            // Submit the claim
            await _claimService.CreateClaim(claim);
            return RedirectToAction(nameof(TrackClaims)); // Redirect to claim tracking
        }
        return View(claim); // Return the view with the claim data if model state is invalid
    }

    // GET: Verify pending claims
    public async Task<IActionResult> VerifyClaims()
    {
        var pendingClaims = await _claimService.GetPendingClaimsAsync();
        return View(pendingClaims);
    }

    // POST: Approve a claim
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ApproveClaim(int claimId)
    {
        await _claimService.UpdateClaimStatusAsync(claimId, ClaimStatus.Approved);
        return RedirectToAction(nameof(VerifyClaims));
    }

    // POST: Reject a claim
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RejectClaim(int claimId)
    {
        await _claimService.UpdateClaimStatusAsync(claimId, ClaimStatus.Rejected);
        return RedirectToAction(nameof(VerifyClaims));
    }

    // GET: Track claims by lecturer ID
    public async Task<IActionResult> TrackClaims(int lecturerId)
    {
        var claims = await _claimService.GetClaimsByLecturerId(lecturerId);
        return View(claims);
    }

    // Helper method to validate file type
    private bool IsValidFileType(IFormFile file)
    {
        var allowedExtensions = new[] { ".pdf", ".docx", ".xlsx" };
        var extension = Path.GetExtension(file.FileName).ToLower();
        return allowedExtensions.Contains(extension);
    }
}
