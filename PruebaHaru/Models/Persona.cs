using System;
using System.Collections.Generic;

namespace PruebaHaru.Models;

public partial class Persona
{
    public int IdPersonas { get; set; }

    public string? NombrePersona { get; set; }

    public string? DireccionPersona { get; set; }

    public string? CedulaPersona { get; set; }

    public string? TelefonoPersona { get; set; }

    public string? EmailPersona { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
