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


        public bool login(string user, string pass)
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


    }
}
