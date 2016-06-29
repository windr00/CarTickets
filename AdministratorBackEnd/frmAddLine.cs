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
using SqlAgent;

namespace AdministratorBackEnd
{
    public partial class frmAddLine : Form
    {

        private SQLAgent agent;
        private List<CityDataBean> cityList;
        public frmAddLine()
        {
            InitializeComponent();
            agent = SQLAgent.GetInstance();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtNum.Text != string.Empty && txtPrice.Text != string.Empty 
                && cmbDep.Items.Contains(cmbDep.Text) && cmbArr.Items.Contains(cmbArr.Text) &&
                (dateArr.Value - dateDep.Value > TimeSpan.Zero))
            {
                try
                {
                    agent.AddLine(txtNum.Text, int.Parse(cityList[cmbDep.SelectedIndex].cityId),
                        int.Parse(cityList[cmbArr.SelectedIndex].cityId), float.Parse(txtPrice.Text),
                        dateDep.Value, dateArr.Value);
                    var ret = MessageBox.Show(
                        "Successfully added this line.\nDo you want to continue to add new lines?", "Finished",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ret == DialogResult.Yes)
                    {
                        txtNum.Text = string.Empty;
                        txtPrice.Text = string.Empty;
                        cmbDep.Text = string.Empty;
                        cmbArr.Text = string.Empty;
                        dateDep.Value = DateTime.Today;
                        dateArr.Value = DateTime.Today;
                    }
                    else
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
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

        private void frmAdd_Load(object sender, EventArgs e)
        {
            try
            {
                cityList = agent.GetCityList();
                foreach (var bean in cityList)
                {
                    cmbDep.Items.Add(bean.cityName);
                    cmbArr.Items.Add(bean.cityName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("FATAL Error\n" + e.ToString(), "Error", MessageBoxButtons.OK,
       MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char) 8)
            {
                e.Handled = true;
            }
        }
    }
}
