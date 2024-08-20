using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Contacto
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Message { get; set; } = null!;
}
