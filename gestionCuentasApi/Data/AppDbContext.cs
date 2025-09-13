// Importación de modelos
using Microsoft.EntityFrameworkCore;
using gestionCuentasApi.Models;

namespace gestionCuentasApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        //Definición de Dbset
        public DbSet<Clientes> Clientes { get; set; } = null!;
        public DbSet<Cuentas> Cuentas { get; set; } = null!;

        public DbSet<Transacciones> Transacciones { get; set; } = null!;
    }
}
