﻿using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Carrito
{
    public int Id { get; set; }

    public double Monto { get; set; }

    public string? UsuarioId { get; set; }

    public string? CarritoTemporalId { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<ItemCarrito>? ItemCarritos { get; set; } = new List<ItemCarrito>();

    public virtual AspNetUser? Usuario { get; set; }
}
