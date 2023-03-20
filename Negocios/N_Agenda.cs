using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Datos;
using System.Data;
using System.Data.SqlClient;

namespace Negocios
{
   public class N_Agenda
    {
        private D_Agenda data = new D_Agenda();

        public DataTable N_lista(int id)
        {
            return data.D_listado(id);
        }
        public int createData(string nombre, string apellido, string genero, string movil, string telefono, string email)
        {
            try
            { 
                 return data.insertData(nombre, apellido, genero, movil, telefono, email);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }
        public int changeData(int id, string nombre, string apellido, string genero, string movil, string telefono, string email)
        {
            try
            {
                return data.updateData(id, nombre, apellido, genero, movil, telefono, email);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }
        public int removeData(int id)
        {
            try
            {
                return data.deleteData(id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }
        public SqlDataReader getData(int id)
        {
            try
            {
                return data.searchData(id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
