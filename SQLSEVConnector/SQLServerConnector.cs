using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

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
                if (command != null)
                {
                    command.CommandText = cmd;
                    Console.WriteLine(cmd);
                    var reader = command.ExecuteReader();
                    Console.WriteLine(reader.FieldCount);
                    while (reader.Read()) 
                    {
                        List<string> list = new List<string>();
                            
                        for (int i = 0; i < reader.FieldCount; i ++)
                        {
                            object re = reader[i];
                            Type type = re.GetType();
                            MethodInfo method = type.GetMethod("ToString", new Type[] {});
                            list.Add(method.Invoke(re, null) as string);
                            
                        }
                        result.Add(list);
                    } 
                    reader.Close();
                }
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
