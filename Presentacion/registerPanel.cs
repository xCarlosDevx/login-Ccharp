using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Negocios;
namespace Presentacion
{
    public partial class registerPanel : Form
    {
        N_Usuario objUser = new N_Usuario();
        public void clear()
        {
            txtName.Text = "";
            txtLast.Text = "";
            txtPass.Text = "";
            txtUser.Text = "";
        }
        public registerPanel()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string name = txtName.Text;
            string last = txtLast.Text;
            string user = txtUser.Text;
            string pass = txtPass.Text;
          
            bool isNotFull = txtName.Text.Equals("") | txtLast.Text.Equals("") |  txtPass.Text.Equals("") | txtUser.Text.Equals("");

            if (isNotFull)
            {
                MessageBox.Show("Debe rellenar todos los datos");
            }
            else
            {
                int res = objUser.createUser(name,last,user,pass);

                if (res == 1)
                {
                    MessageBox.Show("Se ha creado un nuevo usuario");
                    clear(); 
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            P_Usuario main = new P_Usuario();
            clear();
            this.Close();
        }
    }
}
