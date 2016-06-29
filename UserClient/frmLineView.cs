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

        public delegate void backLogin();

        public backLogin back;
        public frmLineRUD(bool login)
        {
            InitializeComponent();
            agent = SQLAgent.GetInstance();
            isLogin = login;
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
        }
        
    }
}
