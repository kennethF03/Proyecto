using Dapper;
using System.Data.SqlClient;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace Proyecto.Data
{
    public class IMProducto : IProducto
    {

        private readonly Conexion _conexion;


        public IMProducto (Conexion conexion) {

            _conexion = conexion;

        }


        public void ActulizarProducto(Producto producto)
        {

            using (var conexion = _conexion.GetConexion()) {

                var parametro = new DynamicParameters();
                parametro.Add("@ID_Producto", producto.ID_Producto, DbType.Int32);
                parametro.Add("@Nombre", producto.Nombre, DbType.String);
                parametro.Add("@Descripcion", producto.Descripcion, DbType.String);
                parametro.Add("@Cantidad", producto.Cantidad, DbType.Int32);
                parametro.Add("@Precio", producto.Precio, DbType.Double);

                conexion.Execute("Actualizar", parametro, commandType: CommandType.StoredProcedure);


            }

        }

        public void Eliminar(int ID_producto)
        {

            using (var conexion = _conexion.GetConexion()) {

                var parametro = new DynamicParameters();
                parametro.Add("@ID_Producto", ID_producto, DbType.Int32);
                conexion.Execute("EliminarProducto", parametro, commandType: CommandType.StoredProcedure);
            
            }

        }

        public void InsertarProducto(Producto producto)
        {
            using (var conexion = _conexion.GetConexion()) {

                var parametro = new DynamicParameters();
                parametro.Add("@Nombre", producto.Nombre, DbType.String);
                parametro.Add("@Descripcion", producto.Descripcion, DbType.String);
                parametro.Add("@Cantidad", producto.Cantidad, DbType.Int32);
                parametro.Add("@Precio", producto.Precio, DbType.Double);

                conexion.Execute("InsertarProducto", parametro, commandType: CommandType.StoredProcedure);


            }
           
        }

        public Producto ObtenerProductoID(int ID_Producto)
        {
            using (var conexion = _conexion.GetConexion()) {

                var parametro = new DynamicParameters();

                parametro.Add("ID_Producto", ID_Producto, DbType.Int32);

                return conexion.QueryFirstOrDefault<Producto>("ObtenerProductoID", parametro,commandType:CommandType.StoredProcedure);

            }
            
        }

        public IEnumerable<Producto> ObtenerProductos()
        {
            using (var conexion = _conexion.GetConexion())
            {
                return conexion.Query<Producto>("obtener_Producto", commandType: CommandType.StoredProcedure).ToList();

            }
        }
    }
}
