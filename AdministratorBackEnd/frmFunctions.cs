using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdministratorBackEnd
{
    public partial class frmFunctions : Form
    {
        public frmFunctions()
        {
            InitializeComponent();
        }

        private void btnLineAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Enabled = false;
            frmAddLine frm = new frmAddLine();
            frm.FormClosed += frmAdd_FormClosed;
            frm.Show();
        }

        private void frmAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
            this.Show();
        }
    }
}
