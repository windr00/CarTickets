using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLSEVConnector;

namespace AdministratorBackEnd
{
    class SQLAgent
    {
        private static SQLServerConnector connector;
        private static SQLAgent agent;
        public static SQLAgent GetInstance()
        {
            if (agent == null)
            {
                agent = new SQLAgent();
            }
            return agent;
        }
        private SQLAgent()
        {
            try
            {
                connector = new SQLServerConnector("localhost", "tickets", "sa", "???|||");
            }
            catch (SqlException e)
            {
                throw e;
            }
        }


        public bool AdminLogin(string user, string pass)
        {
            try
            {
                string cmdStr = "select * from administrator where admin_user_name='" + user + "' and admin_user_pass='" +
                                pass + "'";
                if (connector.ExecuteCommand(cmdStr).Count == 0)
                {
                    return false;
                }
                return true;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public List<string> GetCityList()
        {
            try
            {
                List<string> cityList = new List<string>();
                string cmdStr = "select * from city";
                var result = connector.ExecuteCommand(cmdStr);
                foreach (List<string> i in result)
                {
                    cityList.Add(i[1]);
                }
                return cityList;

            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public void AddLine(string num, int dep_city, int arr_city, float price, DateTime dep_date, DateTime arr_date)
        {
            try
            {
                string cmdStr =
                    "insert into line(line_train_num, line_dep_city, line_arr_city, line_price, line_dep_date, line_arr_date) " +
                    "values( '"
                    + num + "','" + dep_city + "','" + arr_city + "','" + price + "','" + dep_date.ToString() + "','" +
                    arr_date.ToString() + "');";
                connector.ExecuteCommand(cmdStr);
            }
            catch (SqlException e)
            {
                throw e;
            }
        }


    }
}
