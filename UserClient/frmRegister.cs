using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlAgent;

namespace SQLSEVConnector
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 'x' && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SQLAgent agent = SQLAgent.GetInstance();
            if (!txtPass.Text.Equals(string.Empty) || !txtId.Text.Equals(string.Empty) ||
                !txtRName.Text.Equals(string.Empty) ||
                !txtTel.Text.Equals(string.Empty) || !txtUser.Text.Equals(string.Empty) ||
                cmbSex.Items.Contains(cmbSex.Text))
            {
                agent.AddUser(txtId.Text,txtRName.Text, cmbSex.SelectedIndex, txtTel.Text, txtUser.Text, txtPass.Text);
                MessageBox.Show("Registered", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Not enough information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
    }
}
