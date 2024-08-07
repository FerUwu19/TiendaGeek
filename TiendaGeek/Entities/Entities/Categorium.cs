using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Categorium
{
    public int CodigoCategoria { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
