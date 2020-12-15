using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DailyWorkLog
{
    public partial class Main : Form
    {
        CoreOperations coreOperations = CoreOperations.GetInstance();
        DataTable baseDt;
        private const string columnClientName = "Client";
        private const string columnClientHeader = "Client";

        private const string columnTaskName = "Task";
        private const string columnTaskHeader = "Task";

        private const string columnDescriptionName = "Description";
        private const string columnDescriptionHeader = "Description";

        private const string columnDurationName = "Duration";
        private const string columnDurationHeader = "Duration(In Min.)";
        public Main()
        {
            InitializeComponent();
            try
            {
                LblHi.Text = $"Hi {coreOperations.UserName}";
                baseDt = new DataTable();
                baseDt.Columns.Add(columnClientName, typeof(int));
                baseDt.Columns.Add(columnTaskName, typeof(int));
                baseDt.Columns.Add(columnDescriptionName, typeof(string));
                baseDt.Columns.Add(columnDurationName, typeof(int));
                FormatDataGrid();
                List<Activity> todaysActivities = coreOperations.GetAllActivitiesForDate(DateTime.Today);
                FillDataGrid(todaysActivities);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                coreOperations.WriteLog("Main", "Constructor", ex.Message);
            }

            ///Need a functionality to calculate the total hours spent on a client for a particular duration.
        }

        private void FormatDataGrid()
        {
            try
            {
                dataGridViewDailyTaks.AutoGenerateColumns = false;

                DataGridViewComboBoxCell dccbTasks = new DataGridViewComboBoxCell();
                dccbTasks.DataSource = coreOperations.GetAllTasksFromFile();
                dccbTasks.DisplayMember = "Name";
                dccbTasks.ValueMember = "Id";

                DataGridViewColumn dcTask = new DataGridViewColumn
                {
                    ValueType = typeof(string),
                    DataPropertyName = columnTaskName,
                    CellTemplate = dccbTasks,
                    Name = columnTaskHeader,
                    DisplayIndex = 0
                };
                dataGridViewDailyTaks.Columns.Add(dcTask);


                DataGridViewComboBoxCell dccbClients = new DataGridViewComboBoxCell();
                dccbClients.DataSource = coreOperations.GetAllClientsFromFile();
                dccbClients.DisplayMember = "Name";
                dccbClients.ValueMember = "Id";

                DataGridViewColumn dcClient = new DataGridViewColumn
                {
                    ValueType = typeof(string),
                    DataPropertyName = columnClientName,
                    CellTemplate = dccbClients,
                    Name = columnClientHeader,
                    DisplayIndex = 1,
                };
                dataGridViewDailyTaks.Columns.Add(dcClient);

                DataGridViewCell dct = new DataGridViewTextBoxCell();
                DataGridViewColumn dcDescription = new DataGridViewColumn
                {
                    ValueType = typeof(string),
                    Name = columnDescriptionHeader,
                    DataPropertyName = columnDescriptionName,
                    CellTemplate = dct,
                    DisplayIndex = 2,
                    MinimumWidth = 200
                };
                dataGridViewDailyTaks.Columns.Add(dcDescription);

                DataGridViewColumn dcDuration = new DataGridViewColumn
                {
                    ValueType = typeof(int),
                    Name = columnDurationHeader,
                    CellTemplate = dct,
                    DataPropertyName = columnDurationName,
                    DisplayIndex = 3
                };
                dataGridViewDailyTaks.Columns.Add(dcDuration);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                coreOperations.WriteLog("Main", "FormatDataGrid", ex.Message);
            }
        }

        private void FillDataGrid(List<Activity> todaysActivities)
        {
            try
            {
                baseDt.Clear();
                foreach (Activity activity in todaysActivities)
                {
                    DataRow dr = baseDt.NewRow();
                    dr[columnClientName] = activity.ClientId;
                    dr[columnTaskName] = activity.TaskId;
                    dr[columnDescriptionName] = activity.Description;
                    dr[columnDurationName] = activity.Duration;
                    baseDt.Rows.Add(dr);
                }
                BindingSource bSource = new BindingSource
                {
                    DataSource = baseDt
                };
                dataGridViewDailyTaks.DataSource = bSource;

                txtTimeSpent.Text = coreOperations.GetTheTotalTime(todaysActivities);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                coreOperations.WriteLog("Main", "FillDataGrid", ex.Message);
            }
        }

        private void btnAddNewClient_Click(object sender, EventArgs e)
        {
            var clientPopup = new AddClient();
            clientPopup.ShowDialog(this);
        }

        public void NotificationFromChild(string child)
        {
            try
            {
                switch (child)
                {
                    case "client":
                        foreach (DataGridViewRow row in dataGridViewDailyTaks.Rows)
                        {
                            ((DataGridViewComboBoxCell)row.Cells[columnClientName]).DataSource = coreOperations.GetAllClientsFromFile();
                        }
                        break;
                    case "task":
                        foreach (DataGridViewRow row in dataGridViewDailyTaks.Rows)
                        {
                            ((DataGridViewComboBoxCell)row.Cells[columnTaskName]).DataSource = coreOperations.GetAllTasksFromFile();
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                coreOperations.WriteLog("Main", "NotificationFromChild", ex.Message);
            }
        }

        private void btnAddNewTask_Click(object sender, EventArgs e)
        {
            var taskPopup = new AddTask();
            taskPopup.ShowDialog(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<Activity> allActivities = GetAllActivitiesFromGrid();
                coreOperations.WriteAllActivitiesToFile(allActivities, dtPicker.Value);
                MessageBox.Show("Data Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                coreOperations.WriteLog("Main", "btnSave_Click", ex.Message);
            }
        }

        private List<Activity> GetAllActivitiesFromGrid()
        {
            List<Activity> allActivities = new List<Activity>();
            try
            {
                foreach (DataGridViewRow row in dataGridViewDailyTaks.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        Activity act = new Activity
                        {
                            ClientId = row.Cells[columnClientHeader].Value != DBNull.Value ? Convert.ToInt32(row.Cells[columnClientHeader].Value) : 0,
                            TaskId = row.Cells[columnTaskHeader].Value != DBNull.Value ? Convert.ToInt32(row.Cells[columnTaskHeader].Value) : 0,
                            Description = Convert.ToString(row.Cells[columnDescriptionHeader].Value),
                            Duration = row.Cells[columnDurationHeader].Value != DBNull.Value ? Convert.ToInt32(row.Cells[columnDurationHeader].Value) : 0,
                            DateTimeStamp = DateTime.Now
                        };
                        allActivities.Add(act);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                coreOperations.WriteLog("Main", "GetAllActivitiesFromGrid", ex.Message);
            }
            return allActivities;
        }

        private void dtPicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ///Comment when you want to enable the user to save the activities on any date.
                // btnSave.Enabled = dtPicker.Value.ToShortDateString().Equals(DateTime.Today.ToShortDateString());

                List<Activity> activities = coreOperations.GetAllActivitiesForDate(dtPicker.Value);
                FillDataGrid(activities);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                coreOperations.WriteLog("Main", "dtPicker_ValueChanged", ex.Message);
            }
        }

        private void dataGridViewDailyTaks_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    List<Activity> allActivities = GetAllActivitiesFromGrid();

                    txtTimeSpent.Text = coreOperations.GetTheTotalTime(allActivities);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                coreOperations.WriteLog("Main", "dataGridViewDailyTaks_RowLeave", ex.Message);
            }
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            var reportPopup = new Reports();
            reportPopup.ShowDialog(this);
        }
    }
}
