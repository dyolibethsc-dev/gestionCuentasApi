using gestionCuentasApi.Models;

namespace gestionCuentasApi.Interfaces
{
    public interface ICuentasRepository
    {
        // Definición del método para la creación de cuentas
        void Add(Cuentas cuenta);

        //Definición del método para obtener los datos de las cuentas por una en específico
        Cuentas? GetByID(int cuenta);

        //Definición del método para listar cuentas
        IEnumerable<Cuentas> GetAll();

        //Definición del método para gestionar las transacciones ligadas a una cuenta
        Task<bool> registroTransacciones(int cuenta, decimal monto, string tipoMovimiento, string fecha);

        //Definición del método para listar transacciones de una cuenta específica
        Task<List<Transacciones>> transaccionesPorCuenta(int cuenta);
    }
}
