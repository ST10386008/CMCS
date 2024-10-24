using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ClaimsController : ControllerBase
{
    private readonly ClaimService _claimService;

    public ClaimsController(ClaimService claimService)
    {
        _claimService = claimService;
    }

    [HttpPost]
    public async Task<IActionResult> SubmitClaim([FromBody] Claim claim)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _claimService.CreateClaim(claim);
        return Ok();
    }

    [HttpGet("{lecturerId}")]
    public async Task<IActionResult> GetClaims(int lecturerId)
    {
        var claims = await _claimService.GetClaimsByLecturerId(lecturerId);
        return Ok(claims);
    }
}
