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
    }
}
