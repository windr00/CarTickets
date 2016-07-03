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
    public partial class frmLineRUD : Form
    {

        private SQLAgent agent;
        List<LineDataBean> lineList ;
        List<CityDataBean> cityList;
        private bool isLogin = false;
        private string user_id;

        public delegate void backLogin();

        public backLogin back;
        public frmLineRUD(bool login, string user_id)
        {
            InitializeComponent();
            agent = SQLAgent.GetInstance();
            isLogin = login;
            this.user_id = user_id;
        }

        private void frmLineRUD_Load(object sender, EventArgs e)
        {
            lineList = agent.GetLines();
            cityList = agent.GetCityList();

            foreach (var line in lineList)
            {
                line.remainSeat = agent.GetLineRemainSeat(line.id);
            }
            dataView.Rows.Clear();
            foreach (var line in lineList)
            {
                string depCity = string.Empty;
                string arrCity = string.Empty;
                foreach (var city in cityList)
                {
                    if (city.cityId.Equals(line.depCity.ToString()))
                    {
                        depCity = city.cityName;
                        
                    }
                    if (city.cityId.Equals(line.arrCity.ToString()))
                    {
                        arrCity = city.cityName;
                    }
                }

                dataView.Rows.Add(line.id.ToString(), line.trainNum, depCity, arrCity, line.price.ToString(), line.depDate.ToString(), line.arrDate.ToString(), line.remainSeat.ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataView.Rows.Count; i ++)
            {
                if ((dataView.Rows[i].Cells[1].Value as string).Equals(txtName.Text))
                {
                    dataView.Rows[i].Selected = true;
                }
            }
        }

       

        private void dataView_SelectionChanged(object sender, EventArgs e)
        {
            
            btnOrder.Enabled = true;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (!isLogin)
            {
                MessageBox.Show("You must login before ordering", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                back.Invoke();
                this.Close();
            }
            else
            {
                int index = dataView.SelectedCells[0].RowIndex;
                LineDataBean line = lineList[index];
                var orders = agent.GetOrdersByUser(this.user_id);
                foreach (var o in orders)
                {
                    if (line.id == o.line_id)
                    {
                        MessageBox.Show("You have already ordered one ticket on this train", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                btnOrder.Enabled = false;
                List<int> seats = new List<int>();
                for (int i = 1; i <= 50; i++)
                {
                    seats.Add(i);
                }
                List<int> takenSeats = agent.GetSeatNumsByLine(line.id.ToString());
                if (takenSeats.Count >= 50)
                {
                    MessageBox.Show("This line has been sold out", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (var i in takenSeats)
                {
                    seats.Remove(i);
                }
                Random rdm = new Random(DateTime.Now.TimeOfDay.Milliseconds);

                int seat = seats[rdm.Next() % 50];
                var ret = MessageBox.Show("Train Num: " + dataView.Rows[index].Cells[1].Value + "\n" +
                                "Depature City: " + dataView.Rows[index].Cells[2].Value + "\n" +
                                "Arrival City: " + dataView.Rows[index].Cells[3].Value + "\n" +
                                "Departure Time: " + dataView.Rows[index].Cells[5].Value + "\n" +
                                "Arrival Time: " + dataView.Rows[index].Cells[6].Value + "\n" +
                                "Seat NUm: " + seat + "\n" +
                                "Price: " + dataView.Rows[index].Cells[4].Value, "Order Preview",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ret == DialogResult.Yes)
                {
                    try
                    {
                        agent.AddOrder(user_id, line.id.ToString(), seat);
                        MessageBox.Show("Tickets ordered", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmLineRUD_Load(null, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("FATAL ERROR\nORDER CANCELED\n" + ex.ToString(),
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            if (!isLogin)
            {
                MessageBox.Show("You must login before ordering", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                back.Invoke();
                this.Close();
                return;
            }
            dataGridView1.Rows.Clear();
            var orders = agent.GetOrdersByUser(user_id);
            foreach (OrderDataBean i in orders)
            {
                string train_num = string.Empty;
                foreach (var l in lineList)
                {
                    if (l.id == i.line_id)
                    {
                        train_num = l.trainNum;
                        break;
                        
                    }
                }
                dataGridView1.Rows.Add(i.order_id.ToString(), train_num, i.seat_num.ToString());
            }
        
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedCells[0].RowIndex;
            var ret = MessageBox.Show("Do you really want to delete those orders?", "Delete Order",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                agent.DeleteOrder(dataGridView1.Rows[index].Cells[0].Value as string);
                tabPage2_Enter(null, null);
            }
        }

        private void frmLineRUD_FormClosing(object sender, FormClosingEventArgs e)
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

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            frmLineRUD_Load(null, null);
        }
    }
}
