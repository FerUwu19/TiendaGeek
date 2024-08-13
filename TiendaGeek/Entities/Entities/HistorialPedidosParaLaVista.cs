using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public partial class HistorialPedidosParaLaVista
    {
        public int Id { get; set; }
        public int IdOrden { get; set; }
        public string? Producto { get; set; } = string.Empty;
        public DateTime? FechaDeCreacion { get; set; }

    }
}
