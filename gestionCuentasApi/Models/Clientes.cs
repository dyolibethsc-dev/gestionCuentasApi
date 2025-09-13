using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionCuentasApi.Models;

public class Clientes
{
    [Key]
    public int codigo_cliente { get; set; }

    public required string primer_nombre { get; set; }
    public string? segundo_nombre { get; set; }
    public required string primer_apellido { get; set; }
    public string? segundo_apellido { get; set; }
    public required string fecha_nacimiento { get; set; }
    public required string sexo_cliente { get; set; }
    public required decimal ingresos_cliente { get; set; }
    public string? fecha_creacion { get; set; }
    public required string estado_cliente { get; set; }
}
