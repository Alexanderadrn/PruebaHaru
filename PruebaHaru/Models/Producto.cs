using System;
using System.Collections.Generic;

namespace PruebaHaru.Models;

public partial class Producto
{
    public int IdProductos { get; set; }

    public string? NombreProductos { get; set; }

    public double? ValorProducto { get; set; }

    public int? StockProducto { get; set; }

    public string? CodProducto { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
