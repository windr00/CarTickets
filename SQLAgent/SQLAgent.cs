using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLSEVConnector;

namespace SqlAgent
{



    public class SQLAgent
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
        }

        public void Connect(string  ip)
        {
            try
            {
                connector = new SQLServerConnector("http://" + ip + ":8080/CarTickets/DBSrv");
            }
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
            {
                throw e;
            }
        }


        public List<OrderDataBean> GetOrderList()
        {
            List<OrderDataBean> orders = new List<OrderDataBean>();
            try
            {
                string cmdStr = "select * from user_order;";
                var result = connector.ExecuteCommand(cmdStr);
                foreach (var list in result)
                {
                    OrderDataBean data = new OrderDataBean(int.Parse(list[0]), 
                        list[1], 
                        int.Parse(list[2]), 
                        int.Parse(list[3]));
                    orders.Add(data);
                }

                return orders;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<UserDataBean> GetUserList()
        {
            List<UserDataBean> users = new List<UserDataBean>();
            try
            {
                string cmdStr = "select * from users;";
                var result = connector.ExecuteCommand(cmdStr);
                foreach (var list in result)
                {
                    var u = new UserDataBean(list[0], list[1], int.Parse(list[2]), list[3], list[4], list[5]);
                    users.Add(u);
                }
                return users;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AddUser(string id, string name, int sex, string tel, string uname, string pass)
        {
            try
            {
                string cmdStr = "insert into users values('" + id + "','" +
                                name + "','" +
                                sex + "','" +
                                tel + "','" +
                                uname + "','" +
                                pass +
                                "');";
                connector.ExecuteCommand(cmdStr);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<int> GetSeatNumsByLine(string order_line_id)
        {
            try
            {
                List<int> seats = new List<int>();
                string cmdStr = "select * from user_order where line_id='" + order_line_id + "';";
                var result = connector.ExecuteCommand(cmdStr);
                foreach (var ilist   in result)
                {
                    seats.Add(int.Parse(ilist[3]));
                }
                return seats;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<OrderDataBean> GetOrdersByUser(string order_user_id)
        {
            try
            {
                List<OrderDataBean> orders = new List<OrderDataBean>();

                string cmdStr = "select * from user_order where user_id='" + order_user_id + "';";
                var result = connector.ExecuteCommand(cmdStr);
                foreach (var list in result)
                {
                    orders.Add(new OrderDataBean(int.Parse(list[0]), list[1], int.Parse(list[2]), int.Parse(list[3])));
                }
                return orders;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public void AddOrder(string user, string line, int seat
            )
        {
            try
            {
                string cmdStr = "insert into user_order(user_id, line_id, seat_num) values('" + user + "','" + line +
                                "','" + seat + "');";
                connector.ExecuteCommand(cmdStr);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteOrder(string order_id)
        {
            try
            {
                string cmdStr = "delete from user_order where order_id='" + order_id + "';";
                connector.ExecuteCommand(cmdStr);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
