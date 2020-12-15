using ClosedXML.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;

namespace DailyWorkLog
{
    public class CoreOperations
    {
        private static readonly string clientDataFileName = "Client.json";
        private readonly string clientDataFile = Path.Combine(ConfigurationManager.AppSettings["DatabaseFolder"], clientDataFileName);
        public readonly string UserName = ConfigurationManager.AppSettings["UserName"];
        private static readonly string taskDataFileName = "Task.json";
        private readonly string taskDataFile = Path.Combine(ConfigurationManager.AppSettings["DatabaseFolder"], taskDataFileName);
        private readonly string errorLog = Path.Combine(ConfigurationManager.AppSettings["DatabaseFolder"], "ErrorLog.txt");
        private readonly string activityFolder = ConfigurationManager.AppSettings["ActivitiesFolder"];
        public readonly string reportFolder = ConfigurationManager.AppSettings["ReportFolder"];
        private static readonly object _lock = new object();
        private static CoreOperations _firstInstance;
        public static int counter = 0;
        public static CoreOperations GetInstance()
        {
            if (_firstInstance == null)
            {
                lock (_lock)
                {
                    if (_firstInstance == null)
                    {
                        _firstInstance = new CoreOperations();
                    }
                }
            }
            return _firstInstance;
        }
        private CoreOperations()
        {
            counter++;
            if (!File.Exists(clientDataFile))
            {
                File.Create(clientDataFile).Dispose();
            }

            if (!File.Exists(taskDataFile))
            {
                File.Create(taskDataFile).Dispose();
            }

            if (!File.Exists(errorLog))
            {
                File.Create(errorLog).Dispose();
            }

            Directory.CreateDirectory(activityFolder);
            Directory.CreateDirectory(reportFolder);

        }

        #region Clients
        public List<Client> GetAllClientsFromFile()
        {
            List<Client> clients = new List<Client>();
            if (File.Exists(clientDataFile))
            {
                string jsonData = File.ReadAllText(clientDataFile);
                clients = !string.IsNullOrEmpty(jsonData) ? JsonConvert.DeserializeObject<List<Client>>(jsonData) : new List<Client>();
            }

            return clients;
        }
        public void WriteAllClientsToFile(List<Client> allClients)
        {
            string jsonData = JsonConvert.SerializeObject(allClients);
            File.WriteAllText(clientDataFile, jsonData);
        }
        #endregion

        #region Tasks
        public List<Task> GetAllTasksFromFile()
        {
            List<Task> tasks = new List<Task>();
            if (File.Exists(taskDataFile))
            {
                string jsonData = File.ReadAllText(taskDataFile);
                tasks = !string.IsNullOrEmpty(jsonData) ? JsonConvert.DeserializeObject<List<Task>>(jsonData) : new List<Task>();
            }

            return tasks;
        }

        public void WriteAllTasksToFile(List<Task> allTasks)
        {
            string jsonData = JsonConvert.SerializeObject(allTasks);
            File.WriteAllText(taskDataFile, jsonData);
        }

        #endregion

        #region Activity
        public List<Activity> GetAllActivitiesFromFile()
        {
            string activityDataFileName = "Activity.json";
            string activityDataFile = Path.Combine(activityFolder, activityDataFileName);
            List<Activity> activities = new List<Activity>();
            if (File.Exists(activityDataFile))
            {
                string jsonData = File.ReadAllText(activityDataFile);
                activities = !string.IsNullOrEmpty(jsonData) ? JsonConvert.DeserializeObject<List<Activity>>(jsonData) : new List<Activity>();
            }
            else
            {
                File.Create(activityDataFile).Dispose();
            }
            return activities;
        }

        public List<Activity> GetAllActivitiesForDate(DateTime dateTime)
        {
            string activityDataFileName = $"{dateTime.Year}_{dateTime.Month}_{dateTime.Day}.json";
            string activityDataFile = Path.Combine(activityFolder, activityDataFileName);
            List<Activity> activities = new List<Activity>();
            if (File.Exists(activityDataFile))
            {
                string jsonData = File.ReadAllText(activityDataFile);
                activities = !string.IsNullOrEmpty(jsonData) ? JsonConvert.DeserializeObject<List<Activity>>(jsonData) : new List<Activity>();
            }
            return activities;
        }

        public List<Activity> GetAllActivitiesForDateRange(DateTime startDate, DateTime endDate)
        {
            List<Activity> activities = new List<Activity>();
            var dates = Enumerable.Range(0, (endDate - startDate).Days + 1)
                            .Select(day => startDate.AddDays(day)).ToList();
            foreach (DateTime d in dates)
            {
                activities.AddRange(GetAllActivitiesForDate(d));
            }

            
            return activities;
        }
        public void WriteAllActivitiesToFile(List<Activity> allActivities, DateTime dateTime)
        {
            string activityDataFileName = $"{dateTime.Year}_{dateTime.Month}_{dateTime.Day}.json";
            string activityDataFile = Path.Combine(activityFolder, activityDataFileName);
            if (!File.Exists(activityDataFile))
            {
                File.Create(activityDataFile).Dispose();
            }
            allActivities.ForEach(x => x.DateTimeStamp = dateTime);
            string jsonData = JsonConvert.SerializeObject(allActivities);
            //File.WriteAllText(activityDataFile, jsonData);
            using (StreamWriter sw = File.CreateText(activityDataFile))
            {
                sw.WriteLine(jsonData);
            }
        }

        public List<DateTime> GetValidDates()
        {
            List<DateTime> validDates = new List<DateTime>();
            return validDates;
        }

        public string GetTheTotalTime(List<Activity> activities)
        {
            ///Fill the Total Time Spent
            int totalTime = 0;
            activities.ForEach(x => totalTime += x.Duration);
            int hours = totalTime / 60;
            int minutes = totalTime % 60;
            string totalTimeStr = $"{hours:D2}:{minutes:D2}";
            return totalTimeStr;
        }

        #endregion

        #region Create Reports
        public void ExportToExcel(DataTable dataTable, string workbookName, string worksheetName="Sheet1")
        {
            using (var workbook = new XLWorkbook())
            {
                workbook.Worksheets.Add(dataTable, worksheetName);
                workbook.SaveAs(Path.Combine(reportFolder, $"{workbookName}.xlsx"));
            }
        }
        #endregion

        #region Log Writing

        public void WriteLog(string className, string methodName, string error)
        {
            string log = $"{DateTime.Now}\t{className}\t{methodName}\t{error}";
            using (StreamWriter sw = File.AppendText(errorLog))
            {
                sw.WriteLine(log);
            }
        }

        #endregion
    }
}
