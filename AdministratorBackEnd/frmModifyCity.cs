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
    public partial class frmModifyCity : Form
    {
        private SQLAgent agent = SQLAgent.GetInstance();

        private List<CityDataBean> cityList;
        public frmModifyCity()
        {
            InitializeComponent();
        }

        private void frmModifyCity_Load(object sender, EventArgs e)
        {
            cityList = agent.GetCityList();
            dataView.Rows.Clear();
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

        private string editedCity;

        private void dataView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            editedCity = dataView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value as string;
            
        }

        private List<int> modifiedCitys = new List<int>();

        private void dataView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                modifiedCitys.Add(e.RowIndex);
                btnRevert.Enabled = true;
                btnSubmit.Enabled = true;
            }
            else
            {
                MessageBox.Show("City name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = editedCity;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            btnRevert.Enabled = false;
            btnSubmit.Enabled = false;
            try
            {
                foreach (var i in modifiedCitys)
                {
                    agent.ModifyCity(int.Parse(cityList[i].cityId), dataView.Rows[i].Cells[1].Value as string);
                }
                var ret = MessageBox.Show("Successfully modified this city. \nDo you want to modify more cities?",
                                "Finished", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ret == DialogResult.Yes)
                {
                    frmModifyCity_Load(null, null);
                }
                else
                {
                    this.Close();
                }
            }
            catch (SQLSEVConnector.SqlException ex)
            {
                MessageBox.Show("FATAL ERROR\n" + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmModifyCity_Load(null, null);
            }
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            frmModifyCity_Load(null, null);
            modifiedCitys.Clear();
            btnSubmit.Enabled = false;
            btnRevert.Enabled = false;
        }
    }
}
