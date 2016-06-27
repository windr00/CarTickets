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

        public List<CityDataBean> GetCityList()
        {
            try
            {
                List<CityDataBean> cityList = new List<CityDataBean>();
                string cmdStr = "select * from city";
                var result = connector.ExecuteCommand(cmdStr);
                foreach (List<string> i in result)
                {
                    cityList.Add(new CityDataBean(i[0], i[1]));
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

        public void ModifyLine(int id, string num, int dep_city, int arr_city, float price, DateTime dep_date, DateTime arr_date)
        {
            try
            {
                string cmdStr = "update line set line_train_num='" + num +
                                "', line_dep_city='" + dep_city + "'" +
                                " ,line_arr_city='" + arr_city + "'" +
                                " ,line_price='" + price + "'" +
                                " ,line_dep_date='" + dep_date + "'" +
                                " ,line_arr_date='" + arr_date + "' where line_id='" + id + "';";
                connector.ExecuteCommand(cmdStr);

            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public List<LineDataBean> GetLines()
        {
            List<LineDataBean> lineList = new List<LineDataBean>();

            try
            {
                string cmdStr = "select * from line";
                var result = connector.ExecuteCommand(cmdStr);
                foreach (List<string> i in result)
                {
                    lineList.Add(new LineDataBean(int.Parse(i[0]), i[1], int.Parse(i[2]), int.Parse(i[3]),
                        float.Parse(i[4]), DateTime.Parse(i[5]), DateTime.Parse(i[6])));
                }
                return lineList;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public void DeleteLine(int id)
        {
            try
            {
                string cmdStr = "delete from line where line_id='" + id + "';";
                connector.ExecuteCommand(cmdStr);

            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public uint GetLineRemainSeat(int id)
        {
            try
            {
                string cmdStr = "select * from user_order where line_id='" + id + "';";
                var taken = connector.ExecuteCommand(cmdStr).Count;
                return 50 - (uint) taken;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public void AddCity(string name)
        {
            try
            {
                string cmdStr = "insert into city(city_name) values('" + name + "');";
                connector.ExecuteCommand(cmdStr);
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public void ModifyCity(int id, string newName)
        {
            try
            {
                string cmdStr = "update city set city_name='" + newName + "' where city_id='" + id.ToString() + "';";
                connector.ExecuteCommand(cmdStr);
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public void DeleteCity(int id)
        {
            try
            {
                string cmdStr = "delete from city where city_id='" + id.ToString() + "';";
                connector.ExecuteCommand(cmdStr);
            }
            catch (SqlException e)
            {
                throw e;
            }
        }


    }
}
