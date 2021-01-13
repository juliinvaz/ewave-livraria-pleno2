using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Livraria.Infra.EF
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}