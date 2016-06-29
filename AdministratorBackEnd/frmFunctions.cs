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

        private void btnCityAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Enabled = false;
            frmAddCity frm = new frmAddCity();
            frm.FormClosed += frmAdd_FormClosed;
            frm.Show();
        }

        private void btnCityView_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Enabled = false;
            frmViewCity frm = new frmViewCity();
            frm.FormClosed += frmAdd_FormClosed;
            frm.Show();
        }

        private void btnCityModify_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Enabled = false;
            frmModifyCity frm = new frmModifyCity();
            frm.FormClosed += frmAdd_FormClosed;
            frm.Show();
        }

        private void btnCityDelete_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Enabled = false;
            frmDeleteCity frm = new frmDeleteCity();
            frm.FormClosed += frmAdd_FormClosed;
            frm.Show();
        }

        private void frmFunctions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                var ret = MessageBox.Show("Are you sure to quit?", "Closing", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                if (ret == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void btnLineRUD_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Enabled = false;
            frmLineRUD frm = new frmLineRUD();
            frm.FormClosed += frmAdd_FormClosed;
            frm.Show();
        }

        private void btnOrderView_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Enabled = false;
            frmViewOrders frm = new frmViewOrders();
            frm.FormClosed += frmAdd_FormClosed;
            frm.Show();
        }
    }
}
