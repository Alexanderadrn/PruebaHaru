using PruebaHaru.Viewmodels;

namespace PruebaHaru.Service
{
    public interface IProductos
    {
        public List<ProductosVM> ObtenerProductos();
        public bool setProductos(ProductosVM productos);
        public bool putProductos(ProductosVM productos);
        public bool deleteProductos(int idProductos);
        public bool SetCompra(SetComprasVM setCompras);
        public List<ComprasVM> ObtenerCompras();
        public List<ComprasVM> ObtenerComprasByNombre(string nombre);
        public List<ComprasVM> ObtenerComprasById(int id);
    }
}
