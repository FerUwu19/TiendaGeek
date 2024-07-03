using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Carrito
{
    public int CodigoCarrito { get; set; }

    public int? CodigoUsuario { get; set; }

    public int? CodigoProducto { get; set; }

    public decimal? TotalCompra { get; set; }

    public virtual Producto? CodigoProductoNavigation { get; set; }

    public virtual Usuario? CodigoUsuarioNavigation { get; set; }

    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();
}
