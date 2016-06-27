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
    public partial class frmDeleteCity : Form
    {
        private SQLAgent agent = SQLAgent.GetInstance();
        private List<CityDataBean> cityList;
        public frmDeleteCity()
        {
            InitializeComponent();
        }

        private void frmDeleteCity_Load(object sender, EventArgs e)
        {
            cityList = agent.GetCityList();
            cmbCity.Items.Clear();
            foreach (var i in cityList)
            {
                cmbCity.Items.Add(i.cityName);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cmbCity.Items.Contains(cmbCity.Text))
            {
                try
                {
                    agent.DeleteCity(int.Parse(cityList[cmbCity.SelectedIndex].cityId));
                    var ret = MessageBox.Show("Successfully added this city. \nDo you want to add more cities?",
                        "Finished", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ret == DialogResult.Yes)
                    {
                        frmDeleteCity_Load(null, null);
                    }
                    else
                    {
                        this.Close();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("FATAL Error\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("City name is empty or doesn't exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
