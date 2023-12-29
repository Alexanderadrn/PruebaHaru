using System;
using System.Collections.Generic;

namespace PruebaHaru.Models;

public partial class Compra
{
    public int IdCompras { get; set; }

    public int? IdPersonas { get; set; }

    public int? IdProductos { get; set; }

    public virtual Persona? IdPersonasNavigation { get; set; }

    public virtual Producto? IdProductosNavigation { get; set; }
}
