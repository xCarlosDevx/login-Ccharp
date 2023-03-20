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
    public partial class P_Usuario : Form
    {
        N_Usuario obj = new N_Usuario();
        N_Usuario objUser = new N_Usuario();
        public void ponerPanel(object panel)
        {
            if (this.pnlContainer.Controls.Count > 0)
                this.pnlContainer.Controls.RemoveAt(0);
            Form pn = panel as Form;
            pn.TopLevel = false;
            pn.Dock = DockStyle.Fill;
            this.pnlContainer.Controls.Add(pn);
            this.pnlContainer.Tag = pn;
            pn.Show();

        }

        public P_Usuario()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void P_Usuario_Load(object sender, EventArgs e)
        {
        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            P_Usuario main = new P_Usuario();
            main.pnlContainer.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
         
        }
         
       public void showLog()
        { 
            pnlLog.Show();
            pnlContainer.Hide();
        }
        public void hideLog()
        { 
            pnlLog.Hide();
            pnlContainer.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            registerPanel regi = new registerPanel();
            string name = regi.txtName.Text;
            string last = regi.txtLast.Text;
            string user = regi.txtUser.Text;
            string pass = regi.txtPass.Text;
            MessageBox.Show(regi.txtLast.Text);
            bool isNotFull = name.Equals("") | last.Equals("") | user.Equals("") | pass.Equals("");

            if (isNotFull)
            {
                MessageBox.Show("Debe rellenar todos los datos",name + last + user + pass);
            }
            else
            {
                int res = objUser.createUser(name, last, user, pass);

                if (res == 1)
                {
                    MessageBox.Show("Se ha creado un nuevo usuario");
                    regi.clear();
                    pnlContainer.Hide();
                    pnlLog.Show();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {

            registerPanel regi = new registerPanel();
            regi.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
         
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click_2(object sender, EventArgs e)
        {
            bool isNotFull = txtPass.Text.Equals("") || txtPass.Text.Equals("");
            if (isNotFull)
            {
                MessageBox.Show("Debe llenar todos los datos");
            }
            else
            {
                int res;
                res = obj.loginUser(txtUser.Text, txtPass.Text);
                if (res == 1)
                {
                    ponerPanel(new crudPanel());
                    pnlLog.Visible = false;
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error o la contraseña o usuario es incorrecta");
                }
            }
        }
    }
}
