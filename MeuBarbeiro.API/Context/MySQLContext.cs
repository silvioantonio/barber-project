using MeuBarbeiro.API.Models.Appointment;
using MeuBarbeiro.API.Models.Provider;
using MeuBarbeiro.API.Models.ProviderHour;
using MeuBarbeiro.API.Models.User;
using MeuBarbeiro.API.Models.Worker;
using Microsoft.EntityFrameworkCore;

namespace MeuBarbeiro.API.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<Provider> Providers { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<ProviderHour> ProviderHours { get; set; }
    }
}
