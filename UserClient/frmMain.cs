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

        }
    }
}
