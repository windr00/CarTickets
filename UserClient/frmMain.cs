using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
                agent.Connect(File.ReadAllText("server.inf"));
                try
                {
                    var userList = agent.GetUserList();
                    foreach (var user in userList)
                    {
                        if (user.user_name.Equals(txtUser.Text) && user.user_pass.Equals(txtPass.Text))
                        {
                            this.Hide();
                            frmLineRUD frm = new frmLineRUD(true, user.user_id);
                            frm.back += Frm_FormClosed1;
                            frm.Show();
                            return;

                        }
                    }
                    MessageBox.Show("User name or password incorrect", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch (WebException ex)
                {
                    MessageBox.Show("Error connecting server\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (ex is WebException)
                    {
                        frmServerConfigure frm = new frmServerConfigure();
                        this.Enabled = false;
                        frm.FormClosed += (o, arg) =>
                        {
                            this.Enabled = true;
                        };
                        frm.Show();
                    }
                }

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
            agent.Connect(File.ReadAllText("server.inf"));
            frmLineRUD frm = new frmLineRUD(false, string.Empty);
            frm.back += Frm_FormClosed1;
            frm.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            agent.Connect(File.ReadAllText("server.inf"));
            frmRegister frm = new frmRegister();
            frm.FormClosed += Frm_FormClosed;
            frm.Show();
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!File.Exists("server.inf"))
            {
                frmServerConfigure frm = new frmServerConfigure();
                frm.FormClosed += (o, arg) =>
                {
                    this.Enabled = true;
                };
                this.Enabled = false;
                frm.Show();

            }
        }
    }
}
