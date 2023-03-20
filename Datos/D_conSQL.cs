using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    class D_conSQL
    {
        public SqlConnection cone = new SqlConnection("server = LAPTOP-2GI3ISEG ; database =MultiCapas; integrated security = true; ");
        public void abrirCon()
        {
            try
            {
                cerrarCon();
                cone.Open();
                Console.WriteLine("Conexion Establecida");

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error en conexion " + ex);
            }
        }
        public void cerrarCon()
        {
            cone.Close();
        }
    }
}
