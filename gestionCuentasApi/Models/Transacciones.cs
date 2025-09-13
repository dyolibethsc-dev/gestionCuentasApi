using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionCuentasApi.Models
{
    public class Transacciones
    {
        [Key]
        public int codigo_transaccion { get; set; }

        [ForeignKey("codigo_cuenta")]
        public required int codigo_cuenta { get; set; }
        public required string tipo_transaccion { get; set; }
        public string fecha_transaccion { get; set; }
        public required decimal monto_transaccion { get; set; }

    }
}
