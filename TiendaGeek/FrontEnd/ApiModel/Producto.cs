﻿using System;
using System.Collections.Generic;

namespace FrontEnd.ApiModel;

public partial class Producto
{
    public int CodigoProducto { get; set; }

    public int? CodigoCategoria { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public int? Unidades { get; set; }

    public string? Estado { get; set; }
}
