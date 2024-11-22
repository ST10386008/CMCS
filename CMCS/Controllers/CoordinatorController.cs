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
        var claims = await _claimService.GetPendingClaimsAsync(); // Add this method to service
        return View(claims);
    }

    [HttpPost]
    public async Task<IActionResult> Approve(int claimId)
    {
        await _claimService.ApproveClaimAsync(claimId);
        return RedirectToAction(nameof(PendingClaims));
    }

    [HttpPost]
    public async Task<IActionResult> Reject(int claimId)
    {
        await _claimService.RejectClaimAsync(claimId);
        return RedirectToAction(nameof(PendingClaims));
    }
}
