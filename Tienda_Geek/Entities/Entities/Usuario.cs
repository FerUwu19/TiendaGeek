using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Usuario
{
    public int CodigoUsuario { get; set; }

    public string? Rol { get; set; }

    public string? Nombre { get; set; }

    public string? PrimerApellido { get; set; }

    public string? SegundoApellido { get; set; }

    public string? Contrasena { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();
}
