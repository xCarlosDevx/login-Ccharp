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
    public partial class createPanel : Form
    {
        N_Agenda objAge = new N_Agenda();
        public createPanel()
        {
            InitializeComponent();
        } 
        private void clear()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtGene.Text = "";
            txtMov.Text = "";
            txtTel.Text = "";
            txtCorr.Text = "";
        }

        private void btnSend_Click_1(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string genero = txtGene.Text;
            string movil = txtMov.Text;
            string telefono = txtTel.Text;
            string correo = txtCorr.Text;
            bool isNotFull = txtNombre.Text.Equals("") | txtApellido.Text.Equals("") | txtGene.Text.Equals("") | txtMov.Text.Equals("") | txtTel.Text.Equals("") | txtCorr.Text.Equals("");

            if (isNotFull)
            {
                MessageBox.Show("Debe rellenar todos los datos");
            }
            else
            {
                int res = objAge.createData(nombre, apellido, genero, movil, telefono, correo);

                if (res == 1)
                {
                    MessageBox.Show("Se han insertado datos");
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
    }
}
