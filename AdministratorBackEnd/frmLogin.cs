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
                    sqlAgent.AdminLogin("sa", "???|||");
                    this.Hide();
                    frmFunctions functions = new frmFunctions();
                    functions.Show();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error connecting database\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter both user name and password", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
