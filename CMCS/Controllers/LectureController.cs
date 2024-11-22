using CMCS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class LecturerController : Controller
{
    private readonly IClaimService _claimService;

    public LecturerController(IClaimService claimService)
    {
        _claimService = claimService;
    }

    public async Task<IActionResult> Index()
    {
        var lecturerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (lecturerId == null)
        {
            return Unauthorized(); // Redirect or handle unauthorized access
        }

        var claims = await _claimService.GetClaimsByLecturerAsync(lecturerId);
        return View(claims);
    }

    public IActionResult SubmitClaim()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SubmitClaim(CMCS.Models.Claim claim)
    {
        if (!ModelState.IsValid)
        {
            return View(claim); // Return form with validation errors
        }

        var lecturerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (lecturerId == null)
        {
            return Unauthorized(); // Handle unauthorized access
        }

        claim.LecturerId = lecturerId;
        await _claimService.SubmitClaimAsync(claim);
        return RedirectToAction(nameof(Index));
    }
}
