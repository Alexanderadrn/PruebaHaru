namespace PruebaHaru.Viewmodels
{
    public class ComprasVM
    {
        public int idCompras {get; set;}
        public int? idPersonas { get; set; }
        public string? nombrePersona { get; set; }
        public string? telefonoPersona { get; set; }
        public string? emailPersona { get; set; }
        public int? idProductos { get; set; }
        public string? codProductos {get; set;}
        public string? nombreProductos { get; set; }

        public double? valorProducto { get; set; }
    }
    public class SetComprasVM
    {
        public int idCompras { get; set; }
        public int? idPersonas { get; set; }

        public int? idProductos { get; set; }

    }
}
