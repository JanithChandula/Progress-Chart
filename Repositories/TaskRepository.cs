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


        public TasksModel GetData()
        {
            TasksModel task1 = new TasksModel();

            try
            {
                string Query = "select CreatedTime,TaskStatus from sites.tasks where Id > 1 AND Id < 19";
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
                                //task1.CreatedTime = sdr["CreatedTime"];
                                //task1 = (string)sdr["TaskStatus"];
                                //var task2 = sdr["TaskStatus"].ToList();
                                //return sdr["TaskStatus"];
                                chartData.Add(new TasksModel
                                {
                                    CreatedTime = sdr["CreatedTime"].ToString(),
                                    TaskStatus = sdr["TaskStatus"].ToString()
                                });

                            }

                        }
                    }


                }
                return task1;
            }
            catch (Exception e)
            {
                Logger.Info("inside Exception Repo Userregistration  " + e.ToString());

                return task1;
            }

        }






    }
}
