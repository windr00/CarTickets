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
    public partial class frmViewOrders : Form
    {
        private SQLAgent agent = SQLAgent.GetInstance();

        public frmViewOrders()
        {
            InitializeComponent();
        }

        private void frmViewOrders_Load(object sender, EventArgs e)
        {
            List<LineDataBean> lineList = new List<LineDataBean>();
            
        }
    }
}
