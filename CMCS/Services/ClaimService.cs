using CMCS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface IClaimService
{
    Task<List<Claim>> GetClaimsByLecturerAsync(string lecturerId);
    Task<Claim> GetClaimByIdAsync(int claimId);
    Task SubmitClaimAsync(Claim claim);
    Task<bool> ApproveClaimAsync(int claimId);
    Task<bool> RejectClaimAsync(int claimId);
    Task<List<Claim>> GetPendingClaimsAsync();
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
        if (string.IsNullOrWhiteSpace(lecturerId))
        {
            throw new ArgumentException("Lecturer ID cannot be null or empty", nameof(lecturerId));
        }

        return await _context.Claims
                             .Where(c => c.LecturerId == lecturerId)
                             .Include(c => c.Documents)
                             .ToListAsync();
    }

    public async Task<Claim> GetClaimByIdAsync(int claimId)
    {
        if (claimId <= 0)
        {
            throw new ArgumentException("Invalid claim ID", nameof(claimId));
        }

        return await _context.Claims
                             .Include(c => c.Documents)
                             .FirstOrDefaultAsync(c => c.ClaimId == claimId);
    }

    public async Task SubmitClaimAsync(Claim claim)
    {
        if (claim == null)
        {
            throw new ArgumentNullException(nameof(claim), "Claim cannot be null");
        }

        claim.Status = "Pending";
        claim.SubmissionDate = DateTime.Now;
        claim.TotalAmount = claim.HoursWorked * claim.HourlyRate;

        await _context.Claims.AddAsync(claim);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ApproveClaimAsync(int claimId)
    {
        var claim = await _context.Claims.FindAsync(claimId);
        if (claim == null)
        {
            return false; // Claim not found
        }

        if (claim.Status != "Pending")
        {
            throw new InvalidOperationException("Only pending claims can be approved");
        }

        claim.Status = "Approved";
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RejectClaimAsync(int claimId)
    {
        var claim = await _context.Claims.FindAsync(claimId);
        if (claim == null)
        {
            return false; // Claim not found
        }

        if (claim.Status != "Pending")
        {
            throw new InvalidOperationException("Only pending claims can be rejected");
        }

        claim.Status = "Rejected";
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Claim>> GetPendingClaimsAsync()
    {
        return await _context.Claims
                             .Where(c => c.Status == "Pending")
                             .Include(c => c.Documents)
                             .ToListAsync();
    }
}
