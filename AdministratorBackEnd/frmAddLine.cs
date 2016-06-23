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
    public partial class frmAddLine : Form
    {

        private SQLAgent agent;
        public frmAddLine()
        {
            InitializeComponent();
            agent = SQLAgent.GetInstance();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtNum.Text != string.Empty && txtPrice.Text != string.Empty && cmbDep.Text != string.Empty && cmbArr.Text != string.Empty && (dateArr.Value - dateDep.Value > TimeSpan.Zero))
            {
                try
                {
                    agent.AddLine(txtNum.Text, cmbDep.SelectedIndex, cmbArr.SelectedIndex, float.Parse(txtPrice.Text),
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
                catch (SqlException ex)
                {
                    MessageBox.Show("FATAL Error\n" + e.ToString(), "Error", MessageBoxButtons.OK,
           MessageBoxIcon.Error);
                } 
            }
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {
            try
            {
                var citylist = agent.GetCityList();
                cmbDep.Items.AddRange(citylist.ToArray());
                cmbArr.Items.AddRange(citylist.ToArray());
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
    }
}
