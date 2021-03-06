﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using LitJson;

namespace SQLSEVConnector
{
    public class SQLServerConnector
    {

        //private SqlConnection connection;
        //private SqlCommand command;
        //public SQLServerConnector(string server, string database, string user, string passwd)
        //{
        //    //try
        //    //{
        //    //    connection = new SqlConnection();
        //    //    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        //    //    connection.ConnectionString = "server=" + server + ";" +
        //    //                                  "database=" + database + ";"+
        //    //                                  "uid=" + user + ";" +
        //    //                                  "pwd=" + passwd;
        //    //    connection.Open();
        //    //    command = new SqlCommand();
        //    //    command.Connection = connection;
        //    //    command.CommandType = CommandType.Text;
        //    //}
        //    //catch (SqlException e)
        //    //{
        //    //    throw e;
        //    //}

        //}

        private string url;

        public SQLServerConnector(string url)
        {
            this.url = url;
        }

        public List<List<string>> ExecuteCommand(string cmd)
        {
            HttpWebRequest request = null;
            try
            {
                List<List<string>> result = new List<List<string>>();
                
                request = (HttpWebRequest) WebRequest.Create(url);
                request.Timeout = 2000;
                request.Method = WebRequestMethods.Http.Post;
                request.ContentType = "application/x-www-form-urlencoded;charset=UTF8";
                String postDataStr = "sql=" + cmd;
                byte[] bytes = Encoding.UTF8.GetBytes(postDataStr);
                request.ContentLength = bytes.Length;
                Stream myRequestStream = request.GetRequestStream();
                myRequestStream.Write(bytes, 0, (int) request.ContentLength);


                HttpWebResponse response = (HttpWebResponse) request.GetResponse();

                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("UTF-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                if (retString.Contains("Invalid") || retString.Trim().Equals("false"))
                {
                    throw new SqlException();
                }
                else if (retString.Trim().Equals("true"))
                {
                    return null;
                }

                JsonData array = JsonMapper.ToObject(retString);

                for (int i = 0; i < array.Count; i++)
                {
                    JsonData obj = array[i];
                    List<string> list = new List<string>();
                    for (int j = 0; j < obj.Count; j++)
                    {
                        list.Add(obj[j].ToString());
                    }
                    result.Add(list);
                }

                return result;

            }
            catch (WebException e)
            {
                if (request != null)
                {
                    request.GetRequestStream().Close();
                }
                throw e;
            }
        }

        //public List<List<string>> ExecuteCommand(string cmd)
        //{
        //    try
        //    {
        //        List<List<string>> result = new List<List<string>>();
        //        if (command != null)
        //        {
        //            command.CommandText = cmd;
        //            Console.WriteLine(cmd);
        //            var reader = command.ExecuteReader();
        //            Console.WriteLine(reader.FieldCount);
        //            while (reader.Read()) 
        //            {
        //                List<string> list = new List<string>();
                            
        //                for (int i = 0; i < reader.FieldCount; i ++)
        //                {
        //                    object re = reader[i];
        //                    Type type = re.GetType();
        //                    MethodInfo method = type.GetMethod("ToString", new Type[] {});
        //                    list.Add(method.Invoke(re, null) as string);
                            
        //                }
        //                result.Add(list);
        //            } 
        //            reader.Close();
        //        }
        //        return result;
        //    }
        //    catch (SqlException e)
        //    {
        //        throw e;
        //    }
        //}

        public void Close()
        {
            //connection.Close();
        }
    }
}
