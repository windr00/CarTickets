using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SQLSEVConnector
{
    public class SQLServerConnector
    {

        private SqlConnection connection;
        private SqlCommand command;
        public SQLServerConnector(string server, string database, string user, string passwd)
        {
            try
            {
                connection = new SqlConnection();
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                connection.ConnectionString = "server=" + server + ";" +
                                              "database=" + database + ";"+
                                              "uid=" + user + ";" +
                                              "pwd=" + passwd;
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
            }
            catch (SqlException e)
            {
                throw e;
            }

        }

        public List<List<string>> ExecuteCommand(string cmd)
        {
            try
            {
                List<List<string>> result = new List<List<string>>();
                command.CommandText = cmd;
                var reader = command.ExecuteReader();
                do
                {
                    while (reader.Read())
                    {
                        List<string> list = new List<string>();
                        foreach (var filed in reader)
                        {
                            list.Add(filed.ToString());
                        }
                        result.Add(list);
                    }
                } while (reader.NextResult());
                reader.Close();
                return result;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
