using gestionCuentasApi.Models;

namespace gestionCuentasApi.Interfaces
{
    public interface IClientesRepository
    {
        // Definición del método para la creación de clientes
        void Add(Clientes clientes);
        
        //Definición del método para listar clientes
        IEnumerable<Clientes> GetAll();
       
    }
}
