using gestionCuentasApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using gestionCuentasApi.Models;

namespace gestionCuentasApi.Controllers
{
    [ApiController]
    [Route("apiGestionCuentas/[controller]")]
    public class ClientesControllers : ControllerBase
    {
        private readonly IClientesRepository _clientesRepository;

        public ClientesControllers (IClientesRepository clientesRepository)
        {
            _clientesRepository = clientesRepository;
        }

        //Método para la creación de clientes
        [HttpPost("creacionCliente")]
        public IActionResult Get(Clientes cliente)
        {
            _clientesRepository.Add(cliente);
            return Ok(new { mensaje = "Cliente creado exitosamente." });
        }
        //Método para listar clientes
        [HttpGet("listaClientes")]
        public IActionResult Get()
        {
            var clientes = _clientesRepository.GetAll();
            return Ok(clientes);
        }



    }
}
