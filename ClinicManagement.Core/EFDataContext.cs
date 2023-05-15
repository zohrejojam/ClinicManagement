using ClinicManagement.Core.Models;
using ClinicManagement.Core.Models.Doctors;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Core
{
    public class EFDataContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; protected set; }
        public DbSet<Patient> Patients { get; protected set; }
        public DbSet<Doctor> Doctors { get; protected set; }

        public EFDataContext(string connectionString= @"Server=(LocalDb)\MSSQLLocalDB;Initial Catalog=ClinicManagement;Integrated Security=True")
          : this(new DbContextOptionsBuilder<EFDataContext>().UseSqlServer(connectionString).Options)
        {
        }
        public EFDataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Initial Catalog=ClinicManagement;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
