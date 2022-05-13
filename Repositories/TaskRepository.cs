using Common;
using System.Data;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Collections.Generic;

namespace Repositories
{
    public class TaskRepository

    {
        private string ConnectionstringMaster = ConfigurationManager.ConnectionStrings["MysqlConnectionstring"].ConnectionString;


        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();


        public List<TasksModel> GetData()
        {
            TasksModel task1 = new TasksModel();

            try
            {
                string Query = "select CreatedTime ,TaskStatus from sites.tasks ";
                List<TasksModel> chartData = new List<TasksModel>();
                using (var connection = new MySqlConnection(ConnectionstringMaster))

                {
                    
                    using (var command = new MySqlCommand(Query, connection))
                    {
                        connection.Open();
                        using (var sdr = command.ExecuteReader())
                        {
                            while (sdr.Read())
                            {

                                chartData.Add(new TasksModel
                                {
                                    CreatedTime = (sdr["CreatedTime"].ToString()).Split(' ')[0],
                                    TaskStatus = sdr["TaskStatus"].ToString()
                                });

                            }

                        }
                    }


                }
                return chartData;
            }
            catch (Exception e)
            {
                Logger.Info("inside Exception Repo Userregistration  " + e.ToString());
                List<TasksModel> chartData = new List<TasksModel>();
                return chartData;
            }

        }






    }
}
