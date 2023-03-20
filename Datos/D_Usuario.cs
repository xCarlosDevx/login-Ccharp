using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
//Importamos las referencias  
namespace Datos
{
    //Agregar la referencia a FrameWork-System.Configuration y en Project-CapaEntidad 
    public class D_Usuario
    {
        private D_conSQL con = new D_conSQL();
        SqlCommand query = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataReader rd;
        public DataTable D_listado()
        {
            SqlCommand cmd = new SqlCommand("sp_listar", con.cone);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int insertUser(string nombre, string apellido, string nombreUsuario, string contraseña)
        {
            int res;
            using (SqlCommand query = new SqlCommand())
            {
                query.Connection = con.cone;
                query.CommandText = "Insert into Usuarios (nombre,apellido,nombreUsuario,contraseña) Values (@nombre, @apellido, @user, @pass)";
                query.CommandType = CommandType.Text;
                query.Parameters.AddWithValue("@nombre", nombre);
                query.Parameters.AddWithValue("@apellido", apellido);
                query.Parameters.AddWithValue("@user",nombreUsuario);
                query.Parameters.AddWithValue("@pass", contraseña);
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
        public int selectUser(string nombreUsuario, string contraseña)
        {
            using (SqlCommand query = new SqlCommand())
            {
                query.Connection = con.cone;
                query.CommandText = "select * from Usuarios where nombreUsuario = @user and contraseña =@pass";
                query.CommandType = CommandType.Text;
                query.Parameters.AddWithValue("@user", nombreUsuario);
                query.Parameters.AddWithValue("@pass",contraseña); 
                try
                {
                    con.abrirCon();
                    query.ExecuteNonQuery();
                    return 1;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                    con.cerrarCon();
                    return 0;
                }
            }
        }
    }
}
