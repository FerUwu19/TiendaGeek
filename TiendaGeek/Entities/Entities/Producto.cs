﻿using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Producto
{
    public int CodigoProducto { get; set; }

    public int? CodigoCategoria { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public int? Unidades { get; set; }

    public string? Estado { get; set; }

    public virtual Categorium? CodigoCategoriaNavigation { get; set; }

    public virtual ICollection<ImagenProducto> ImagenProductos { get; set; } = new List<ImagenProducto>();

    public virtual ICollection<ItemCarrito> ItemCarritos { get; set; } = new List<ItemCarrito>();
}
