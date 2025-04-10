using CropWise.Models;
using Microsoft.EntityFrameworkCore;


namespace CropWise.Data
{
    public class CropWiseDbContext : DbContext
    {
        public CropWiseDbContext(DbContextOptions<CropWiseDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Crop> Crops { get; set; }
        public DbSet<CropHealthReport> CropHealthReports { get; set; }
        public DbSet<CropAnalysis> CropAnalyses { get; set;}



    }
}