using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdministratorBackEnd
{
    public partial class frmServerConfigure : Form
    {
        public frmServerConfigure()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!txtIP.Text.Equals(string.Empty))
            {
                using (var stream = File.Open("server.inf", FileMode.OpenOrCreate))
                {
                    var b = Encoding.UTF8.GetBytes(txtIP.Text);
                    stream.Write(b, 0, b.Length);
                }
                this.Close();
            }
        }
    }
}
