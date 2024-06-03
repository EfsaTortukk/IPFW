using Microsoft.EntityFrameworkCore;
using Internet_Programlama_Final_Work.Models;
using Microsoft.AspNetCore.Identity;

namespace Internet_Programlama_Final_Work.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Sonuc> Sonuclar { get; set; }
        public DbSet<Hasta> Hastalar { get; set; }

        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Hemsire> Hemsireler { get; set; }
        public DbSet<TestTur> TestTurler { get; set; }
        public DbSet<LabAdres> LabAdresler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define model relationships here (optional)
           
            // Define other model relationships as needed

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Internet_Programlama_Final_Work.Models.Logincs> Logincs { get; set; } = default!;
    }
}
