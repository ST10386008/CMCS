using ContractMonthlyClaimSystem.Models;
using Microsoft.AspNetCore.Mvc;

public class LecturerController : Controller
{
    private readonly IClaimService _claimService;

    public LecturerController(IClaimService claimService)
    {
        _claimService = claimService;
    }

    public async Task<IActionResult> Index()
    {
        var lecturerId = User.Identity.Name; // Assuming logged-in user's ID
        var claims = await _claimService.GetClaimsByLecturerAsync(lecturerId);
        return View(claims);
    }

    public IActionResult SubmitClaim()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SubmitClaim(Claim claim)
    {
        if (ModelState.IsValid)
        {
            claim.LecturerId = User.Identity.Name; // Assuming logged-in user's ID
            await _claimService.SubmitClaimAsync(claim);
            return RedirectToAction(nameof(Index));
        }
        return View(claim);
    }
}
