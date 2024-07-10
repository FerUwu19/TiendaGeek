using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Orden
{
    public int CodigoOrden { get; set; }

    public int? CodigoUsuario { get; set; }

    public int? CodigoCarrito { get; set; }

    public DateOnly? FechaOrden { get; set; }

    public virtual Carrito? CodigoCarritoNavigation { get; set; }

    public virtual Usuario? CodigoUsuarioNavigation { get; set; }
}
