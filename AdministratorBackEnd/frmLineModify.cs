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
    public partial class frmLineModify : Form
    {

        private SQLAgent agent;
        private List<CityDataBean> cityList;
        private int id;
        public frmLineModify(LineDataBean line)
        {
            InitializeComponent();
            agent = SQLAgent.GetInstance();
            cityList = agent.GetCityList();
            foreach (var city in cityList)
            {
                cmbDep.Items.Add(city.cityName);
                cmbArr.Items.Add(city.cityName);
                if (city.cityId.Equals(line.depCity.ToString()))
                {
                    cmbDep.Text = city.cityName;
                }
                if (city.cityId.Equals(line.arrCity.ToString()))
                {
                    cmbArr.Text = city.cityName;
                }

            }
            id = line.id;
            
            txtNum.Text = line.trainNum;
            txtPrice.Text = line.price.ToString();
            dateArr.Value = line.arrDate;
            dateDep.Value = line.depDate;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtNum.Text != string.Empty && txtPrice.Text != string.Empty
                && cmbDep.Items.Contains(cmbDep.Text) && cmbArr.Items.Contains(cmbArr.Text) &&
                (dateArr.Value - dateDep.Value > TimeSpan.Zero))
            {
                try
                {
                    agent.ModifyLine(id,txtNum.Text, int.Parse(cityList[cmbDep.SelectedIndex].cityId),
                        int.Parse(cityList[cmbArr.SelectedIndex].cityId), float.Parse(txtPrice.Text),
                        dateDep.Value, dateArr.Value);
                    MessageBox.Show(
                        "Successfully modified this line.", "Finished",
                        MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.Close();
                    
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("FATAL Error\n" + e.ToString(), "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Not enough information or information illegal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
