using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlAgent;

namespace AdministratorBackEnd
{
    public partial class frmAddCity : Form
    {
        private SQLAgent agent;
        private List<CityDataBean> cityList;
        public frmAddCity()
        {
            InitializeComponent();
            agent = SQLAgent.GetInstance();
            cityList = new List<CityDataBean>();
        }

        private void frmAddCity_Load(object sender, EventArgs e)
        {
            try
            {
                cityList = agent.GetCityList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("FATAL Error\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCityName.Text != string.Empty )
            {
                foreach (var city in cityList)
                {
                    if (city.cityName.Equals(txtCityName.Text))
                    {
                        MessageBox.Show("City already added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                try
                {
                    agent.AddCity(txtCityName.Text);
                    var ret = MessageBox.Show("Successfully added this city. \nDo you want to add more cities?",
                        "Finished", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ret == DialogResult.Yes)
                    {
                        frmAddCity_Load(null, null);
                        txtCityName.Text = string.Empty;
                    }
                    else
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("FATAL Error\n" + ex.ToString(), "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("City name is empty or already exists in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void txtCityName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex("^[\u4e00-\u9fa5]+$");
            if (!regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
