using gestionCuentasApi.DTOs;
using gestionCuentasApi.Interfaces;
using gestionCuentasApi.Models;
using gestionCuentasApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace gestionCuentasApi.Controllers
{
    [ApiController]
    [Route("apiGestionCuentas/[controller]")]
    public class CuentasController : ControllerBase
    {
        private readonly ICuentasRepository _cuentasRepository;

        //Definición del constructor
        public CuentasController(ICuentasRepository cuentasRepository)
        {
            _cuentasRepository = cuentasRepository;
        }

        //Método para la creación de cuentas
        [HttpPost("creacionCuenta")]
        public IActionResult Get(Cuentas cuenta)
        {
            _cuentasRepository.Add(cuenta);
            return Ok(new { mensaje = "Cuenta creada exitosamente." });
        }

        //Método para listar cuentas
        [HttpGet("listaCuentas")]
        public IActionResult Get()
        {
            var cuentas = _cuentasRepository.GetAll();
            return Ok(cuentas);
        }

        // Método para listar una cuenta
        [HttpGet("informacionCuenta")]
        public IActionResult Get(int cuenta)
        {
            var cuentaIndividual = _cuentasRepository.GetByID(cuenta);
            return Ok(cuentaIndividual);
        }

        // Método para gestionar transacciones
        [HttpPut("registroTransacciones/{codigo_cuenta}")]
        public async Task<IActionResult> registroTransacciones(int codigo_cuenta, [FromBody] informacionTransaccion request)
        {
            var bandera = await _cuentasRepository.registroTransacciones(codigo_cuenta, request.monto_transaccion, request.tipo_transaccion, request.fecha_transaccion);

            if (!bandera)
                return NotFound(new { mensaje = "Cuenta bancaria no encontrada y/o saldo insuficiente" });

            return Ok(new { mensaje = "Saldo de la cuenta y transacción registrada de forma exitosa" });
        }

        // Método para visualizar transacciones por cuentas
        [HttpGet("transaccionesPorCuentas/{codigo_cuenta}")]
        public async Task<IActionResult> transaccionesPorCuenta(int codigo_cuenta)
        {
            var transacciones = await _cuentasRepository.transaccionesPorCuenta(codigo_cuenta);

            if (transacciones == null || !transacciones.Any())
                return NotFound(new { mensaje = "Transacciones no disponibles para esta cuenta" });

            return Ok(transacciones);
        }
    }
}
