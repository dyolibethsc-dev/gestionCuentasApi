using gestionCuentasApi.Data;
using gestionCuentasApi.Interfaces;
using gestionCuentasApi.Models;
using Microsoft.EntityFrameworkCore;

namespace gestionCuentasApi.Repositories
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly AppDbContext _context;
        
        //Definición del constructor
        public ClientesRepository(AppDbContext context)
            {
                _context = context;
            }
        // Construcción de los métodos
        public void Add(Clientes clientes)
        {
            _context.Clientes.Add(clientes);
            _context.SaveChanges();
        }

        public IEnumerable<Clientes> GetAll()
        {
            return _context.Clientes.ToList();
        }
    }
}
