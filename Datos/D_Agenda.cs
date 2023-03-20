using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
   public class D_Agenda
    {
        private D_conSQL con = new D_conSQL(); 
        DataTable dt = new DataTable();  
        public DataTable D_listado(int id)
        {
            using (SqlCommand query = new SqlCommand())
            {
                query.Connection = con.cone;
                query.CommandText = "select Nombre, Apellido,   Genero, Movil, Telefono, Email from Agenda where id = @id";
                query.CommandType = CommandType.Text;
                query.Parameters.AddWithValue("@id", id);
                
                try
                {
                    con.abrirCon();
                    SqlDataAdapter da = new SqlDataAdapter(query); 
                    da.Fill(dt);
                    return dt;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                    con.cerrarCon();
                    return null;
                }
            }
        }
      
        public int insertData(string nombre, string apellido, string genero,string movil, string telefono, string email)
        {
            int res;
            using (SqlCommand query = new SqlCommand())
            {
                query.Connection = con.cone;
                query.CommandText = "Insert into Agenda(Nombre, Apellido, Genero, Movil, Telefono, Email) Values(@nombre, @apellido, @genero, @movil, @telefono, @email)";
                query.CommandType = CommandType.Text;
                query.Parameters.AddWithValue("@nombre", nombre);
                query.Parameters.AddWithValue("@apellido", apellido);
                query.Parameters.AddWithValue("@genero", genero);
                query.Parameters.AddWithValue("@movil", movil);
                query.Parameters.AddWithValue("@telefono", telefono);
                query.Parameters.AddWithValue("@email", email);
                try
                {
                    con.abrirCon();
                    return res = query.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                    con.cerrarCon(); 
                    return res = 0;
                } 
            }

        }

        public int updateData(int id,string nombre, string apellido, string genero, string movil, string telefono, string email)
        {
            int res;
            using (SqlCommand query = new SqlCommand())
            {
                query.Connection = con.cone;
                query.CommandText = "update Agenda set Nombre=@nombre,Apellido= @apellido,Genero= @genero,Movil=@movil,Telefono=@telefono,Email= @email where id = @id";
                query.CommandType = CommandType.Text;
                query.Parameters.AddWithValue("@id", id);
                query.Parameters.AddWithValue("@nombre", nombre);
                query.Parameters.AddWithValue("@apellido", apellido);
                query.Parameters.AddWithValue("@genero", genero);
                query.Parameters.AddWithValue("@movil", movil);
                query.Parameters.AddWithValue("@telefono", telefono);
                query.Parameters.AddWithValue("@email", email);
                try
                {
                    con.abrirCon();
                    res = query.ExecuteNonQuery();
                    return res;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                    con.cerrarCon();
                    return res = 0;
                } 
            }

        }

        public int deleteData(int id)
        {
            int res;
            using (SqlCommand query = new SqlCommand())
            {
                query.Connection = con.cone;
                query.CommandText = "Delete from Agenda where id = @id";
                query.CommandType = CommandType.Text;
                query.Parameters.AddWithValue("@id", id); 
                try
                {
                    con.abrirCon();
                    res = query.ExecuteNonQuery();
                    con.cerrarCon();
                    return res;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                    con.cerrarCon();
                    return res = 0;
                } 
            }

        }

        public SqlDataReader searchData(int id)
        {
            using (SqlCommand query = new SqlCommand())
            {
                query.Connection = con.cone;
                query.CommandText = "select Nombre,Apellido,Genero,Movil,Telefono,Email from Agenda where id=@id";
                query.CommandType = CommandType.Text;
                query.Parameters.AddWithValue("@id",id); 
                try
                {
                    con.abrirCon(); 
                    SqlDataReader res = query.ExecuteReader();
                    return res;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                    con.cerrarCon();
                    return null;
                } 
            }

        }
    }
}
