using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class Producto
    {
        public int ID_Producto { get; set; }

        public string ? Nombre { get; set; }

        public string ? Descripcion { get; set; }

        public int Cantidad { get; set; }

        public double Precio { get; set; }

    }
}
