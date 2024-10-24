public class ClaimService
{
    private readonly ApplicationDbContext _context;

    public ClaimService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateClaim(Claim claim)
    {
        _context.Claims.Add(claim);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Claim>> GetClaimsByLecturerId(int lecturerId)
    {
        return await _context.Claims
            .Where(c => c.LecturerID == lecturerId)
            .ToListAsync();
    }
}
