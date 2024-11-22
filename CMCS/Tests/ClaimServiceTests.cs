//public class ClaimServiceTests
//{
//    private readonly ClaimService _claimService;
//    private readonly Mock<IClaimRepository> _mockClaimRepository;

//    public ClaimServiceTests()
//    {
//        _mockClaimRepository = new Mock<IClaimRepository>();
//        _claimService = new ClaimService(_mockClaimRepository.Object);
//    }

//    [Fact]
//    public async Task CreateClaim_Should_Add_Claim()
//    {
//        var claim = new LecturerClaim { LecturerID = 1, HoursWorked = 5, HourlyRate = 50 };

//        await _claimService.CreateClaimAsync(claim);

//        _mockClaimRepository.Verify(x => x.AddAsync(It.IsAny<LecturerClaim>()), Times.Once);
//    }

//    [Fact]
//    public async Task UpdateClaimStatus_Should_Change_Status()
//    {
//        var claim = new LecturerClaim { ClaimID = 1, Status = ClaimStatus.Pending };

//        await _claimService.UpdateClaimStatusAsync(claim.ClaimID, ClaimStatus.Approved);

//        Assert.Equal(ClaimStatus.Approved, claim.Status);
//    }
//}
