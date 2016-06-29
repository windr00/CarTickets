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
            var lineList = agent.GetLines();
            var orderList = agent.GetOrderList();
            foreach (var i in orderList)
            {
                string line_num = string.Empty;
                foreach (var line
                     in lineList)
                {
                    if (line.id == i.line_id)
                    {
                        line_num = line.trainNum;
                        break;
                    }
                }

                dataView.Rows.Add(i.order_id, line_num, i.user_id, i.seat_num);

            }

        }
    }
}
