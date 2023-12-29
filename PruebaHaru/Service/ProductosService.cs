using Microsoft.Identity.Client;
using PruebaHaru.Models;
using PruebaHaru.Viewmodels;

namespace PruebaHaru.Service
{
    public class ProductosService: IProductos
    {
        private PruebaHaruContext _context;

        public ProductosService(PruebaHaruContext context)
        {
            this._context = context;
        }
        public List<ProductosVM> ObtenerProductos()
        {
            List<ProductosVM> listaProductos = new List<ProductosVM>();
            var productos = _context.Productos.ToList();
            foreach (var item in productos)
            {
                ProductosVM producto = new ProductosVM
                {
                    idProductos = item.IdProductos,
                    valorProducto = item.ValorProducto,
                    stockProducto = item.StockProducto,
                    nombreProductos = item.NombreProductos,
                    codProducto=item.CodProducto
                };
                listaProductos.Add(producto);
            }
            return listaProductos;
        }
        public bool setProductos(ProductosVM productos)
        {
            bool registrado = false;
            try
            {
                Producto productoBD = new Producto();
                productoBD.IdProductos = productos.idProductos;
                productoBD.NombreProductos = productos.nombreProductos;
                productoBD.ValorProducto = productos.valorProducto;
                productoBD.StockProducto=productos.stockProducto;
                productoBD.CodProducto = productos.codProducto;

                _context.Productos.Add(productoBD);
                _context.SaveChanges();
                registrado = true;
            }
            catch (Exception)
            {
                registrado = false;
            }
            return registrado;
        }
        public bool putProductos(ProductosVM productos)
        {
            bool registrado = false;
            try
            {
                var putProductos = _context.Productos.Where(x => x.IdProductos == productos.idProductos).FirstOrDefault();
                putProductos.NombreProductos = productos.nombreProductos;
                putProductos.ValorProducto = productos.valorProducto;
                putProductos.StockProducto = productos.stockProducto;
                putProductos.CodProducto = productos.codProducto;

                _context.SaveChanges();
                registrado = true;
            }
            catch (Exception)
            {
                registrado = false;
            }
            return registrado;
        }
        public bool deleteProductos(int idProductos)
        {
            bool registrado = false;
            var deleteProductos = _context.Productos.Where(X => X.IdProductos == idProductos).FirstOrDefault();
            try
            {
                _context.Productos.Remove(deleteProductos);
                _context.SaveChanges();
                registrado = true;
            }
            catch
            {
                registrado = false;
            }
            return registrado;
        }

        public bool SetCompra(SetComprasVM setCompras)
        {
            bool registrado = false;
            if (setCompras.idPersonas != 0 && setCompras.idProductos != 0)
            {
                try
                {
                    Compra compraBD = new Compra();
                    compraBD.IdPersonas = setCompras.idPersonas;
                    compraBD.IdProductos = setCompras.idProductos;
                    _context.Compras.Add(compraBD);
                    _context.SaveChanges();
                    registrado = true;
                }
                catch (Exception)
                {
                    registrado = false;
                }

            }
            else
            {
                Console.WriteLine("No existe el numero de cedula o codgido seguro");
                registrado = false;
            }
            return registrado;
        }

        public List<ComprasVM> ObtenerCompras()
        {
            List<ComprasVM> lista = new List<ComprasVM> ();
            var relacion = (from compras in _context.Compras
                            join personas in _context.Personas
                            on compras.IdPersonas equals personas.IdPersonas
                            join productos in _context.Productos
                            on compras.IdProductos equals productos.IdProductos
                            where compras.IdCompras != 0
                            select new
                            {
                                compras.IdCompras,
                                compras.IdPersonas,
                                compras.IdProductos,
                                personas.NombrePersona,
                                personas.TelefonoPersona,
                                personas.EmailPersona,
                                productos.NombreProductos,
                                productos.ValorProducto,
                                productos.CodProducto
                            }
                            ).ToList();
                    foreach(var item in relacion)
            {
                ComprasVM registro = new ComprasVM
                {
                    idCompras = item.IdCompras,
                    idPersonas = item.IdPersonas,
                    idProductos = item.IdProductos,
                    nombrePersona = item.NombrePersona,
                    telefonoPersona = item.TelefonoPersona,
                    emailPersona = item.EmailPersona,
                    nombreProductos = item.NombreProductos,
                    valorProducto = item.ValorProducto,
                    codProductos = item.CodProducto
                };
                lista.Add(registro);
            }
                    return lista;

        }

        public List<ComprasVM> ObtenerComprasByNombre(string nombre)
        {
            List<ComprasVM> lista = new List<ComprasVM>();
            var relacion = (from compras in _context.Compras
                            join personas in _context.Personas
                            on compras.IdPersonas equals personas.IdPersonas
                            join productos in _context.Productos
                            on compras.IdProductos equals productos.IdProductos
                            where personas.NombrePersona==nombre
                            select new
                            {
                                compras.IdCompras,
                                compras.IdPersonas,
                                compras.IdProductos,
                                personas.NombrePersona,
                                personas.TelefonoPersona,
                                personas.EmailPersona,
                                productos.NombreProductos,
                                productos.ValorProducto,
                                productos.CodProducto
                            }
                            ).ToList();
            foreach (var item in relacion)
            {
                ComprasVM registro = new ComprasVM
                {
                    idCompras = item.IdCompras,
                    idPersonas = item.IdPersonas,
                    idProductos = item.IdProductos,
                    nombrePersona = item.NombrePersona,
                    telefonoPersona = item.TelefonoPersona,
                    emailPersona = item.EmailPersona,
                    nombreProductos = item.NombreProductos,
                    valorProducto = item.ValorProducto,
                    codProductos = item.CodProducto
                };
                lista.Add(registro);
            }
            return lista;

        }
        public List<ComprasVM> ObtenerComprasById(int id)
        {
            List<ComprasVM> lista = new List<ComprasVM>();
            var relacion = (from compras in _context.Compras
                            join personas in _context.Personas
                            on compras.IdPersonas equals personas.IdPersonas
                            join productos in _context.Productos
                            on compras.IdProductos equals productos.IdProductos
                            where personas.IdPersonas == id
                            select new
                            {
                                compras.IdCompras,
                                compras.IdPersonas,
                                compras.IdProductos,
                                personas.NombrePersona,
                                personas.TelefonoPersona,
                                personas.EmailPersona,
                                productos.NombreProductos,
                                productos.ValorProducto,
                                productos.CodProducto
                            }
                            ).ToList();
            foreach (var item in relacion)
            {
                ComprasVM registro = new ComprasVM
                {
                    idCompras = item.IdCompras,
                    idPersonas = item.IdPersonas,
                    idProductos = item.IdProductos,
                    nombrePersona = item.NombrePersona,
                    telefonoPersona = item.TelefonoPersona,
                    emailPersona = item.EmailPersona,
                    nombreProductos = item.NombreProductos,
                    valorProducto = item.ValorProducto,
                    codProductos = item.CodProducto
                };
                lista.Add(registro);
            }
            return lista;

        }
    }
}
