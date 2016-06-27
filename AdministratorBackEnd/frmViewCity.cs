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
    public partial class frmViewCity : Form
    {

        public frmViewCity()
        {
            InitializeComponent();
        }

        private void frmViewCity_Load(object sender, EventArgs e)
        {
            SQLAgent agent = SQLAgent.GetInstance();
            List<CityDataBean> cityList = agent.GetCityList();
            dataView.Columns.Add("city_id", "城市ID");
            dataView.Columns.Add("city_name", "城市名称");
            for (int i = 0; i < cityList.Count; i++)
            {
                dataView.Rows.Add(cityList[i].cityId, cityList[i].cityName);
            }
        }


        private List<int> searchedRows = new List<int>();

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.White;
            foreach (int i in searchedRows)
            {
                dataView.Rows[i].DefaultCellStyle = style;
            }
            if (txtName.Text != string.Empty)
            {
                style.BackColor = Color.OrangeRed;
                foreach (DataGridViewRow row in dataView.Rows)
                {
                    if ((row.Cells[1].Value as string).Equals(txtName.Text))
                    {
                        row.DefaultCellStyle = style;
                        searchedRows.Add(row.Index);
                    } 
                }
            }
        }
    }
}
