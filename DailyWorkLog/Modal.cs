using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyWorkLog
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Activity
    {
        public int ClientId { get; set; }
        public int TaskId { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public DateTime DateTimeStamp { get; set; }
    }
}
