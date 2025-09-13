using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionCuentasApi.Models
{
    public class Cuentas
    {
        [Key]
        public int codigo_cuenta { get; set; }
        
        [ForeignKey("codigo_cliente")]
        public required int codigo_cliente { get; set; }
        public  decimal saldo_cuenta { get; set; } = 100m;
        public  string estado_cuenta { get; set; } = "A";
    }
}
