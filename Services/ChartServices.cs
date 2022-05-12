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

        public ChartServices()
        {
            _taskRepository = new TaskRepository();
        }


        public TasksModel ProcessData()
        {
            return _taskRepository.GetData();
        }
    }
}
