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
    public partial class readPanel : Form
    {
        N_Agenda objAge = new N_Agenda();
        public readPanel()
        {
            InitializeComponent();
        }
        void listar(int id)
        {
            DataTable dt = objAge.N_lista(id);
            dgvData.DataSource = dt;
        } 
        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvData.DataSource = null;
            dgvData.Rows.Clear();
            txtId.Text = "";
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
                DataTable dt = objAge.N_lista(id);
               dgvData.DataSource = dt; 
            }
        }
    }
}
