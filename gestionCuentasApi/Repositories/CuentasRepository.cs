using gestionCuentasApi.Data;
using gestionCuentasApi.Interfaces;
using gestionCuentasApi.Models;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace gestionCuentasApi.Repositories
{
    public class CuentasRepository : ICuentasRepository
    {
        private readonly AppDbContext _context;
        
        //Definición del constructor
        public CuentasRepository(AppDbContext context)
        {
            _context = context;
        }

        // Construcción de los métodos

        // Método para la creación de cuentas
        public void Add(Cuentas cuenta)
        {
            _context.Cuentas.Add(cuenta);
            _context.SaveChanges();
        }

        //Método para la obtención de una cuenta en específico
        public Cuentas? GetByID(int cuenta)
        {
            return  _context.Cuentas.Find(cuenta);
        }

        // Método para listar cuentas
        public IEnumerable<Cuentas> GetAll()
        {
            return _context.Cuentas.ToList();
        }

        //Método para gestionar las transacciones de las cuentas
        public async Task<bool> registroTransacciones(int codigoCuenta, decimal monto, string tipoMovimiento, string fecha)
        {
            using var transaccion = await _context.Database.BeginTransactionAsync();

            try
            {

                var cuenta = await _context.Cuentas.FirstOrDefaultAsync(Cuentas => Cuentas.codigo_cuenta == codigoCuenta);
                if (cuenta == null)
                    return false;
                if ((cuenta.saldo_cuenta <= 0 || cuenta.saldo_cuenta < monto) && (tipoMovimiento == "retiro"))
                    return false;

                if (tipoMovimiento == "retiro")
                    cuenta.saldo_cuenta = cuenta.saldo_cuenta - monto;
                else
                    cuenta.saldo_cuenta = cuenta.saldo_cuenta + monto;
                var registroTransaccion = new Transacciones
                {
                    codigo_cuenta = codigoCuenta,
                    monto_transaccion = monto,
                    fecha_transaccion = fecha,
                    tipo_transaccion = tipoMovimiento

                };

                _context.Transacciones.Add(registroTransaccion);

                await _context.SaveChangesAsync();
                await transaccion.CommitAsync();
                return true;

            }
            catch
            {
                await transaccion.RollbackAsync();
                throw;
            }


        }

        //Método para visualizar transacciones por cuentas
        public async Task<List<Transacciones>> transaccionesPorCuenta(int cuenta)
           {
            return await _context.Transacciones
                .Where(t => t.codigo_cuenta == cuenta)
                .OrderByDescending(t => t.fecha_transaccion)
                .ToListAsync();
        }


    }
}
