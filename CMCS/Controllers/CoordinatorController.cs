using Microsoft.AspNetCore.Mvc;

public class CoordinatorController : Controller
{
    private readonly IClaimService _claimService;

    public CoordinatorController(IClaimService claimService)
    {
        _claimService = claimService;
    }

    public async Task<IActionResult> PendingClaims()
    {
        var claims = await _claimService.GetPendingClaimsAsync();
        return View(claims);
    }

    [HttpPost]
    public async Task<IActionResult> Approve(int claimId)
    {
        try
        {
            var result = await _claimService.ApproveClaimAsync(claimId);
            if (!result)
            {
                // Handle case when approval fails (e.g., invalid claimId)
                ModelState.AddModelError("", "Failed to approve the claim.");
                return RedirectToAction(nameof(PendingClaims));
            }
        }
        catch (Exception ex)
        {
            // Log the error
            ModelState.AddModelError("", "An error occurred while approving the claim.");
        }

        return RedirectToAction(nameof(PendingClaims));
    }

    [HttpPost]
    public async Task<IActionResult> Reject(int claimId)
    {
        try
        {
            var result = await _claimService.RejectClaimAsync(claimId);
            if (!result)
            {
                // Handle case when rejection fails
                ModelState.AddModelError("", "Failed to reject the claim.");
                return RedirectToAction(nameof(PendingClaims));
            }
        }
        catch (Exception ex)
        {
            // Log the error
            ModelState.AddModelError("", "An error occurred while rejecting the claim.");
        }

        return RedirectToAction(nameof(PendingClaims));
    }
}
