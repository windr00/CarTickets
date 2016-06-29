using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdministratorBackEnd;
using SqlAgent;

namespace UserClient
{
    public partial class frmMain : Form
    {

        private SQLAgent agent = SQLAgent.GetInstance();
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!txtUser.Text.Equals(string.Empty) && !txtPass.Text.Equals(string.Empty))
            {
                var userList = agent.GetUserList();
                foreach (var user in userList)
                {
                    if (user.user_name.Equals(txtUser.Text) && user.user_pass.Equals(txtPass.Text))
                    {
                        this.Hide();
                        frmLineRUD frm = new frmLineRUD(true);
                        frm.back += Frm_FormClosed1;
                        frm.Show();
                        return;

                    }
                }
                MessageBox.Show("User name or password incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MessageBox.Show("User name or password empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_FormClosed1()
        {
            
                this.Show();
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLineRUD frm = new frmLineRUD(false);
            frm.back += Frm_FormClosed1;
            frm.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            frmRegister frm = new frmRegister();
            frm.FormClosed += Frm_FormClosed;
            frm.Show();
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
        }
    }
}
