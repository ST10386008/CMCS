using ContractMonthlyClaimSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;

public interface IClaimService
{
    Task<List<Claim>> GetClaimsByLecturerAsync(string lecturerId);
    Task<Claim> GetClaimByIdAsync(int claimId);
    Task SubmitClaimAsync(Claim claim);
    Task ApproveClaimAsync(int claimId);
    Task RejectClaimAsync(int claimId);
}

public class ClaimService : IClaimService
{
    private readonly ApplicationDbContext _context;

    public ClaimService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Claim>> GetClaimsByLecturerAsync(string lecturerId)
    {
        return await _context.Claims
                             .Where(c => c.LecturerId == lecturerId)
                             .Include(c => c.Documents)
                             .ToListAsync();
    }

    public async Task<Claim> GetClaimByIdAsync(int claimId)
    {
        return await _context.Claims
                             .Include(c => c.Documents)
                             .FirstOrDefaultAsync(c => c.ClaimId == claimId);
    }

    public async Task SubmitClaimAsync(Claim claim)
    {
        claim.Status = "Pending";
        claim.SubmissionDate = DateTime.Now;
        claim.TotalAmount = claim.HoursWorked * claim.HourlyRate;
        _context.Claims.Add(claim);
        await _context.SaveChangesAsync();
    }

    public async Task ApproveClaimAsync(int claimId)
    {
        var claim = await _context.Claims.FindAsync(claimId);
        if (claim != null)
        {
            claim.Status = "Approved";
            await _context.SaveChangesAsync();
        }
    }

    public async Task RejectClaimAsync(int claimId)
    {
        var claim = await _context.Claims.FindAsync(claimId);
        if (claim != null)
        {
            claim.Status = "Rejected";
            await _context.SaveChangesAsync();
        }
    }
}
