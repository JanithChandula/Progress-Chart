using Common;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ChartServices
    {
        public readonly TaskRepository _taskRepository;
        List<TasksModel> chartData = new List<TasksModel>();
        List<string> CreatedDate=new List<string> ();
        public ChartServices()
        {
            _taskRepository = new TaskRepository();
            
         

        }
        



        public List<int> DeletedData()
        {
            // counting deleted values in each date
            chartData = _taskRepository.GetData();
            var CreatedDate = chartData.Select(x => x.CreatedTime).Distinct();
            var DelList = chartData.FindAll(x => x.TaskStatus == "Deleted");

            List<int> DeletedCount = new List<int>();
            foreach (var item in CreatedDate)
            {
                DeletedCount.Add(DelList.Count(x => x.CreatedTime == item));
            }

            return DeletedCount;

        }

        public List<int> ApprovedData()
        {
            // counting Approved values in each date
            chartData = _taskRepository.GetData();
            var CreatedDate = chartData.Select(x => x.CreatedTime).Distinct();
            var ApprovedList = chartData.FindAll(x => x.TaskStatus == "Approved");

            List<int> ApprovedCount = new List<int>();
            foreach (var item in CreatedDate)
            {
                ApprovedCount.Add(ApprovedList.Count(x => x.CreatedTime == item));
            }


            return ApprovedCount;
        }

        public List<int> ClosededData()
        {
            // counting closed values in each date
            chartData = _taskRepository.GetData();
            var CreatedDate = chartData.Select(x => x.CreatedTime).Distinct();
            var ClosedList = chartData.FindAll(x => x.TaskStatus == "Closed");

            List<int> ClosedCount = new List<int>();
            foreach (var item in CreatedDate)
            {
                ClosedCount.Add(ClosedList.Count(x => x.CreatedTime == item));
            }

            return ClosedCount;
        }

        public List<int> OngoingData()
        {
            // counting ongoing values in each date
            chartData = _taskRepository.GetData();
            var CreatedDate = chartData.Select(x => x.CreatedTime).Distinct();
            var OngoingList = chartData.FindAll(x => x.TaskStatus == "Ongoing");

            List<int> OngoingCount = new List<int>();
            foreach (var item in CreatedDate)
            {
                OngoingCount.Add(OngoingList.Count(x => x.CreatedTime == item));
            }

            return OngoingCount;
        }
        public List<int> NewData()
        {
            // counting New values in each date
            chartData = _taskRepository.GetData();
            var CreatedDate = chartData.Select(x => x.CreatedTime).Distinct();
            var NewList = chartData.FindAll(x => x.TaskStatus == "New");

            List<int> NewCount = new List<int>();
            foreach (var item in CreatedDate)
            {
                NewCount.Add(NewList.Count(x => x.CreatedTime == item));
            }

            return NewCount;
        }
        public List<int> ToBeAcceptedData()
        {
            // counting ToBeAccepetd values in each date
            chartData = _taskRepository.GetData();
            var CreatedDate = chartData.Select(x => x.CreatedTime).Distinct();
            var ToBeAccepetdList = chartData.FindAll(x => x.TaskStatus == "TobeAccepted");

            List<int> ToBeAccepetdCount = new List<int>();
            foreach (var item in CreatedDate)
            {
                ToBeAccepetdCount.Add(ToBeAccepetdList.Count(x => x.CreatedTime == item));
            }

            return ToBeAccepetdCount;
        }
        public List<string> CratedDateList()
        {
            // counting deleted values in each date
            //_taskRepository = new TaskRepository();


            chartData = _taskRepository.GetData();
            var CreatedDate = chartData.Select(x => x.CreatedTime).Distinct();

            return CreatedDate.ToList();

        }

    }
}
