using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class HistorialPedido
{
    public int Id { get; set; }

    public int? IdOrden { get; set; }

    public DateTime? FechaDeCreacion { get; set; }
}
