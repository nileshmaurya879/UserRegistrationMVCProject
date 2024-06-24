using Microsoft.EntityFrameworkCore;

namespace RegistartionProject001.Models
{
    public class RegistrationDBContext : DbContext
    {
        public RegistrationDBContext(DbContextOptions<RegistrationDBContext> options) : base(options)
        {

        }
        public virtual DbSet<tblState> tblState { get; set; }
        public virtual DbSet<tblCity> tblCity { get; set; }
        public virtual DbSet<sp_getStates> sp_getStates { get; set; }
        public virtual DbSet<sp_getCity> sp_getCity { get; set; }
        public virtual DbSet<sp_getUserRegistration> sp_getUserRegistration { get; set; }
        public virtual DbSet<sp_CityByStatus> sp_CityByStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<sp_getUserRegistration>().HasNoKey();
            modelBuilder.Entity<sp_CityByStatus>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
    }
}
