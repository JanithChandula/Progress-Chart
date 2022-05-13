using Common;
using MySql.Data.MySqlClient;
using NLog;
using System;
using System.Configuration;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

 


//using Common;

namespace Progress_Chart.Controllers
{
    public class HomeController : Controller
    {

        private readonly ChartServices _chartServices;
        private string ConnectionstringMaster = ConfigurationManager.ConnectionStrings["MysqlConnectionstring"].ConnectionString;


        public HomeController()
        {
            _chartServices= new ChartServices(); // creating object from class User Services


        }


        public ActionResult Index()
             
        {
            ViewBag.Title = "Home Page";
            
            
                string Query = "select CreatedTime ,TaskStatus from sites.tasks where TaskStatus='Deleted'";
                List<TasksModel> chartData = new List<TasksModel>();
                List<TasksModel> DeletedData = new List<TasksModel>();

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
                                    CreatedTime = (sdr["CreatedTime"].ToString()).Split(' ')[0],
                                    TaskStatus = sdr["TaskStatus"].ToString()
                                });

                            }

                        }
                    }
                
//         getting deleted data




                var CreatedDate = chartData.Select(x => x.CreatedTime).Distinct();

                List<int> repartitions = new List<int>();
                var status = chartData.Select(x => x.TaskStatus).Distinct();

                foreach (var item in status)
                {
                    repartitions.Add(chartData.Count(x => x.TaskStatus == item));
                }
                // counting distinct dates in chart data
                List<int> DateCount = new List<int>();
                foreach (var item in CreatedDate)
                {
                    DateCount.Add(chartData.Count(x => x.CreatedTime == item));
                }



                // end 

                var rep = repartitions;
                ViewBag.CT = CreatedDate;
                ViewBag.STATUS = status;
                ViewBag.REP = repartitions.ToList();
                List<int> num = new List<int>() { 1, 2, 3, 4 };
                ViewBag.NUM = num;
                ViewBag.Data = chartData;
                ViewBag.DateCount = DateCount;


            }
                return View();
                /*}
                return View(chartData); */







        }



        /* public ActionResult Index()

         {
             ViewBag.Title = "Home Page";
             TasksModel task2 = new TasksModel();

             ChartServices chart1 = new ChartServices();


             return View(chart1.ProcessData());
         } 
        */
    }
}
