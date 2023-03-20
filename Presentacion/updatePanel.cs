using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Negocios;
namespace Presentacion
{
    public partial class updatePanel : Form
    {
        N_Agenda objAge = new N_Agenda();
        public updatePanel()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            int id = Int16.Parse(txtId.Text);
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text; 
            string genero = txtGene.Text; 
            string movil = txtMov.Text;
            string telefono = txtTel.Text;
            string correo = txtCorr.Text;

            bool isNotFull = txtId.Text.Equals("") | txtNombre.Text.Equals("") | txtApellido.Text.Equals("")  | txtGene.Text.Equals("") |   txtMov.Text.Equals("") | txtTel.Text.Equals("") | txtCorr.Text.Equals("");
             if (isNotFull)
            {
                MessageBox.Show("Debe rellenar todos los datos");
            }
            else
            {

                int res = objAge.changeData(id, nombre, apellido, genero, movil, telefono, correo);
                if (res == 1)
                {
                    MessageBox.Show("Se han modificado los datos con id " + id);
                    clear();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
        }
        private void clear()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtGene.Text = "";
            txtMov.Text = "";
            txtTel.Text = "";
            txtCorr.Text = "";
        }
         
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            int id = Int16.Parse(txtId.Text);

            bool isNotFull = txtId.Text.Equals("");
            int res;
            if (isNotFull)
            {
                MessageBox.Show("Debe poner un ID");
            }
            else
            {
                res = objAge.removeData(id);
                if (res == 1)
                {
                    MessageBox.Show("Se han eliminado los datos con id " + id);
                    clear();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            } 
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            clear();
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            bool isNotFull = txtId.Text.Equals("");
            if (isNotFull)
            {
                MessageBox.Show("Debe poner un ID");
            }
            else
            {
                int id;
                try
                {
                    id = Int16.Parse(txtId.Text);
                }
                catch
                {
                    id = 0;
                    txtId.Text = "0";
                }
                
                SqlDataReader res = objAge.getData(id);
                if (res.Read())
                {
                    txtNombre.Text = (res["Nombre"].ToString());
                    txtApellido.Text = (res["Apellido"].ToString());
                    txtGene.Text = (res["Genero"].ToString());
                    txtMov.Text = (res["Movil"].ToString());
                    txtTel.Text = (res["Telefono"].ToString());
                    txtCorr.Text = (res["Email"].ToString());

                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error o el registro no existe");
                }
            }
        }
    }
}
