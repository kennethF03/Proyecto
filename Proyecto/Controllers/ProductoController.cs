using Microsoft.AspNetCore.Mvc;
using Proyecto.Data;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Controllers
{
    public class ProductoController : Controller
    {

        private readonly IProducto i_producto;


       public ProductoController(IProducto iproducto) {

            i_producto = iproducto;
        
        }

        [HttpGet]
        public IActionResult Index()
        {

            var producto = i_producto.ObtenerProductos();

            return View(producto);
        }
        [HttpGet]

        public IActionResult Detalle(int id) {

            var producto = i_producto.ObtenerProductoID(id);

            return View(producto);
        
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Crear(Producto producto )
        {
            i_producto.InsertarProducto(producto);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var producto = i_producto.ObtenerProductoID(id);// practicamente aqui mando el parametro de id si existe y lo cargo en el view por detalle si recordamos en la implementacion ya hace un select con todo los campos

            return View(producto);
        }

        [HttpPost]

        public IActionResult Editar(Producto producto)
        {
            i_producto.ActulizarProducto(producto);
            return RedirectToAction("Index");// una ves finalize la operacion POST al usuario lo va redigir pal index

        }


        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            var producto = i_producto.ObtenerProductoID(id);// practicamente aqui mando el parametro de id si existe y lo cargo en el view por detalle si recordamos en la implementacion ya hace un select con todo los campos

            if (producto == null)
            {
                return NotFound();

            }

            return View(producto);
        }

        [HttpPost]

        public IActionResult EliminarConfirmado(int id)
        {
            i_producto.Eliminar(id);
            return RedirectToAction("Index");

        }


    }
}
