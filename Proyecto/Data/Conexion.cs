using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Data
{
    public class Conexion
    {

        private readonly string _connectionString;
        

        public Conexion(string valor) {

            _connectionString = valor;
        }
    
            public SqlConnection GetConexion()
            {

             var conexion = new SqlConnection(_connectionString);
            conexion.Open();
            return conexion;
           
             }
        
    
    }

}
