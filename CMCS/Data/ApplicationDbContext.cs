//using System.Collections.Generic;
//using System.Reflection.Emit;

//public class ApplicationDbContext : DbContext
//{
//    public DbSet<Lecturer> Lecturers { get; set; }
//    public DbSet<Claim> Claims { get; set; }
//    public DbSet<ClaimDocument> ClaimDocuments { get; set; }
//    public DbSet<Coordinator> Coordinators { get; set; }
//    public DbSet<ClaimStatus> ClaimStatuses { get; set; }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        // Lecturer to Claims (One-to-Many)
//        modelBuilder.Entity<Lecturer>()
//            .HasMany(l => l.Claims)
//            .WithOne(c => c.Lecturer)
//            .HasForeignKey(c => c.LecturerID);

//        // Claim to ClaimDocuments (One-to-Many)
//        modelBuilder.Entity<Claim>()
//            .HasMany(c => c.ClaimDocuments)
//            .WithOne(d => d.Claim)
//            .HasForeignKey(d => d.ClaimID);

//        // Claim to ClaimStatus (One-to-Many)
//        modelBuilder.Entity<Claim>()
//            .HasMany(c => c.ClaimStatuses)
//            .WithOne(s => s.Claim)
//            .HasForeignKey(s => s.ClaimID);

//        // Claim to Coordinator (One-to-One)
//        modelBuilder.Entity<Claim>()
//            .HasOne(c => c.Coordinator)
//            .WithMany(co => co.ApprovedClaims)
//            .HasForeignKey(c => c.ApprovedBy);
//    }
//}
