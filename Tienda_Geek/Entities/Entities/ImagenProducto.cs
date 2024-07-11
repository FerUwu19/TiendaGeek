using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class ImagenProducto
{
    public int CodigoImagen { get; set; }

    public int CodigoProducto { get; set; }

    public string RutaImagen { get; set; }

    public virtual Producto? CodigoProductoNavigation { get; set; }
}
