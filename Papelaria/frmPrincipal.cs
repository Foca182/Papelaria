using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Papelaria.Properties
{
    public partial class frmPrincipal : Form
    {
        DateTime data_atual;
        public frmPrincipal(string nomeusuario)
        {
            this.nomeusuario = nomeusuario;
            InitializeComponent();
        }
        private string nomeusuario;
        
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            data_atual = DateTime.Now;
            lbldata.Text = lbldata.Text +data_atual.ToLongDateString();
            lblnomeusuario.Text = lblnomeusuario.Text + nomeusuario;
        }

        private void lblnomeusuario_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbldata_Click(object sender, EventArgs e)
        {

        }
    }
}
