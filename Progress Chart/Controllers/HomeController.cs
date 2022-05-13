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
            
            
                //string Query = "select CreatedTime ,TaskStatus from sites.tasks where TaskStatus='Deleted'";
                string Query = "select CreatedTime ,TaskStatus from sites.tasks ";

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
                //List<TasksModel> DelList = new List<TasksModel>();

              


                var CreatedDate = chartData.Select(x => x.CreatedTime).Distinct();

                /*List<int> repartitions = new List<int>();
                var status = chartData.Select(x => x.TaskStatus).Distinct();

                foreach (var item in status)
                {
                    repartitions.Add(chartData.Count(x => x.TaskStatus == item));
                }*/

                // counting distinct dates in chart data
                List<int> DateCount = new List<int>();
                foreach (var item in CreatedDate)
                {
                    DateCount.Add(chartData.Count(x => x.CreatedTime == item));
                }



                // end 

                // counting deleted values in each date
                var DelList = chartData.FindAll(x => x.TaskStatus == "Deleted");

                List<int> DeletedCount = new List<int>();
                foreach (var item in CreatedDate)
                {
                    DeletedCount.Add(DelList.Count(x => x.CreatedTime == item));
                }


                // counting Approved values in each date
                var ApprovedList = chartData.FindAll(x => x.TaskStatus == "Approved");

                List<int> ApprovedCount = new List<int>();
                foreach (var item in CreatedDate)
                {
                    ApprovedCount.Add(ApprovedList.Count(x => x.CreatedTime == item));
                }



                // counting closed values in each date
                var ClosedList = chartData.FindAll(x => x.TaskStatus == "Closed");

                List<int> ClosedCount = new List<int>();
                foreach (var item in CreatedDate)
                {
                    ClosedCount.Add(ClosedList.Count(x => x.CreatedTime == item));
                }


                // counting ongoing values in each date
                var OngoingList = chartData.FindAll(x => x.TaskStatus == "Ongoing");

                List<int> OngoingCount = new List<int>();
                foreach (var item in CreatedDate)
                {
                    OngoingCount.Add(OngoingList.Count(x => x.CreatedTime == item));
                }


                // counting New values in each date
                var NewList = chartData.FindAll(x => x.TaskStatus == "New");

                List<int> NewCount = new List<int>();
                foreach (var item in CreatedDate)
                {
                    NewCount.Add(NewList.Count(x => x.CreatedTime == item));
                }


                // counting ToBeAccepetd values in each date
                var ToBeAccepetdList = chartData.FindAll(x => x.TaskStatus == "TobeAccepted");

                List<int> ToBeAccepetdCount = new List<int>();
                foreach (var item in CreatedDate)
                {
                    ToBeAccepetdCount.Add(ToBeAccepetdList.Count(x => x.CreatedTime == item));
                }



                //Exporting data 
                ViewBag.DeletedCount = DeletedCount;
                ViewBag.ApprovedCount = ApprovedCount;
                ViewBag.ClosedCount = ClosedCount;
                ViewBag.OngoingCount = OngoingCount;
                ViewBag.NewCount = NewCount;
                ViewBag.ToBeAccepetdCount = ToBeAccepetdCount;
                ViewBag.dates = CreatedDate;

                /*var rep = repartitions;
                
                ViewBag.STATUS = status;
                ViewBag.REP = repartitions.ToList();
               
                ViewBag.Data = chartData;
                ViewBag.DeletedCount = DeletedCount;
                ViewBag.DelList = DelList;
                ViewBag.DateCount = DateCount;
                */
                
                


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
