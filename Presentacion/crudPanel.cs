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
    public partial class crudPanel : Form
        
    {
        N_Usuario objUser = new N_Usuario();
        public crudPanel()
        {
            InitializeComponent();
        }

        private void ponerPanel(object panel)
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
        private void btnCreate_Click(object sender, EventArgs e)
        {
            ponerPanel(new createPanel());
        }

        private void crudPanel_Load(object sender, EventArgs e)
        {

        }

        private void btnRead_Click_1(object sender, EventArgs e)
        {

            ponerPanel(new readPanel());
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {

            ponerPanel(new updatePanel());
        }
    }
}
