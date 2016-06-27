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
    public partial class frmLineRUD : Form
    {

        private SQLAgent agent;
        List<LineDataBean> lineList ;
        List<CityDataBean> cityList;
        public frmLineRUD()
        {
            InitializeComponent();
            agent = SQLAgent.GetInstance();
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

                dataView.Rows.Add(line.id, line.trainNum, depCity, arrCity, line.price, line.depDate.ToString(), line.arrDate.ToString(), line.remainSeat);
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
            
            btnModify.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            btnModify.Enabled = false;
            btnDelete.Enabled = false;
            frmLineModify frm = new frmLineModify(lineList[
            dataView.SelectedCells[0].RowIndex]);
            frm.FormClosed += Frm_FormClosed;
            frm.Show();
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLineRUD_Load(null, null);
            this.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if ((int.Parse(dataView.SelectedRows[dataView.SelectedCells[0].RowIndex].Cells[7].Value as string)) != 50)
                {
                    MessageBox.Show("Cannot delete a line which is already ordered.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                agent.DeleteLine((int.Parse(dataView.SelectedRows[dataView.SelectedCells[0].RowIndex].Cells[7].Value as string)));
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
