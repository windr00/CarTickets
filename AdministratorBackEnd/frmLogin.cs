using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlAgent;

namespace AdministratorBackEnd
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text != string.Empty && txtPass.Text != string.Empty)
            {
                try
                {
                    var sqlAgent = SQLAgent.GetInstance();
                    
                    sqlAgent.Connect(File.ReadAllText("server.inf"));
                    sqlAgent.AdminLogin("sa", "???|||");
                    this.Hide();
                    frmFunctions functions = new frmFunctions();
                    functions.Show();
                }
                catch (Exception ex)
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
                MessageBox.Show("Please enter both user name and password", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
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
