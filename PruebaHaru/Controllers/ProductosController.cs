using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaHaru.Models;
using PruebaHaru.Service;
using PruebaHaru.Viewmodels;

namespace PruebaHaru.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        public IProductos producto;
        public ProductosController(IProductos _producto)
        {
            this.producto = _producto;
        }
        [HttpGet("ObtenerProductos")]
        public ActionResult ObtenerProductos()
        {
            return new JsonResult(producto.ObtenerProductos());
        }
        [HttpPost("setProductos")]
        public bool setEmpleado(ProductosVM productos)
        {
            return producto.setProductos(productos);
        }
        [HttpPost("putProductos")]
        public bool putPersonas(ProductosVM productos)
        {
            return producto.putProductos(productos);
        }
        [HttpPost("deletProducto")]
        public bool deletProducto(int id)
        {
            return producto.deleteProductos(id);
        }
        [HttpGet("ObtenerCompras")]
        public ActionResult ObtenerCompras()
        {
            return new JsonResult(producto.ObtenerCompras());
        }
        [HttpPost("SetCompras")]
        public ActionResult SetCompras(SetComprasVM compra)
        {
            return new JsonResult(producto.SetCompra(compra));
        }
        [HttpGet("ObtenerComprasNombre")]
        public ActionResult ObtenerComprasByNombre(string nombre)
        {
            return new JsonResult(producto.ObtenerComprasByNombre(nombre));
        }
        [HttpGet("ObtenerComprasId")]
        public ActionResult ObtenerComprasById(int id)
        {
            return new JsonResult(producto.ObtenerComprasById(id));
        }

    }
}
