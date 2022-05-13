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

 




namespace Progress_Chart.Controllers
{
    public class HomeController : Controller
    {

        private readonly ChartServices _chartServices;                                                        
        public HomeController()
        {
            _chartServices = new ChartServices(); // creating object from class chartServices


        }



        public ActionResult Index()
             
        {
            ViewBag.Title = "Task";
            
           
            

                ViewBag.DeletedCount = _chartServices.DeletedData();
                ViewBag.ApprovedCount = _chartServices.ApprovedData();
                ViewBag.ClosedCount = _chartServices.ClosededData();
                ViewBag.OngoingCount = _chartServices.OngoingData();
                ViewBag.NewCount = _chartServices.NewData();
                ViewBag.ToBeAccepetdCount = _chartServices.ToBeAcceptedData();
                ViewBag.dates = _chartServices.CratedDateList();

               return View();

        }
       
               







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
