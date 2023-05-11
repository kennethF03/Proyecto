using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Proyecto.Data
{
   public interface IProducto
    {
        IEnumerable<Producto> ObtenerProductos();

        Producto ObtenerProductoID(int ID_Producto);

        void InsertarProducto(Producto producto);

        void ActulizarProducto(Producto producto);

        void Eliminar(int ID_producto);


    }
}
