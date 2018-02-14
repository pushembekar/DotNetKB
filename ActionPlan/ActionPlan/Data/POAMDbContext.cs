using ActionPlan.Entities;
using Microsoft.EntityFrameworkCore;
using ActionPlan.Models.PlanOfActionViewModels;

namespace ActionPlan.Data
{
    public class POAMDbContext : DbContext
    {
        public POAMDbContext()
        {
                
        }

        public POAMDbContext(DbContextOptions<POAMDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<AuthSystem> AuthSystems { get; set; }
        public DbSet<DelayReason> DelayReasons { get; set; }
        public DbSet<ResponsiblePOC> ResponsiblePOCs  { get; set; }
        public DbSet<RiskLevel> RiskLevels { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Weakness> Weaknesses { get; set; }
        public DbSet<POAM> POAMs { get; set; }
        public DbSet<ActionPlan.Models.PlanOfActionViewModels.POAMViewModel> POAMViewModel { get; set; }
        
    }
}
