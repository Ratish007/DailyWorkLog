using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DailyWorkLog
{
    public partial class Reports : Form
    {
        private readonly DataTable baseDt;
        private int selectedClientId = 0;
        private readonly CoreOperations coreOperations = CoreOperations.GetInstance();
        private const string columnTaskName = "Task";
        private const string columnTaskHeader = "Task";
        private const string columnDescriptionName = "Description";
        private const string columnDescriptionHeader = "Description";
        private const string columnDurationName = "Duration";
        private const string columnDurationHeader = "Duration (In Min.)";
        private const string columnDateName = "Date";
        private const string columnDateHeader = "Date";
        List<Task> allTasks = new List<Task>();
        List<Client> allClients = new List<Client>();
        public Reports()
        {
            InitializeComponent();
            FillClientCombo();
            baseDt = new DataTable();
            baseDt.Columns.Add(columnDateName, typeof(string));
            baseDt.Columns.Add(columnTaskName, typeof(string));
            baseDt.Columns.Add(columnDescriptionName, typeof(string));
            baseDt.Columns.Add(columnDurationName, typeof(int));
            FormatDataGrid();
            allTasks = coreOperations.GetAllTasksFromFile();
            allClients = coreOperations.GetAllClientsFromFile();
        }

        private void FillClientCombo()
        {
            try
            {
                List<Client> allClientsForCombo = coreOperations.GetAllClientsFromFile();
                allClientsForCombo.Insert(0, new Client() { Id = 0, Name = "Select Client" });

                CmbClients.DataSource = allClientsForCombo;

                CmbClients.DisplayMember = "Name";
                CmbClients.ValueMember = "Id";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                coreOperations.WriteLog("Reports", "FillClientCombo", ex.Message);
            }
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                int.TryParse(CmbClients.SelectedValue.ToString(), out selectedClientId);

                if (selectedClientId == 0)
                {
                    MessageBox.Show("Please select a Client!!!");
                }
                else if (DatePickerStart.Value.Date > DatePickerEnd.Value.Date)
                {
                    MessageBox.Show("Start date should be less than end date!!!");
                }
                else
                {
                    List<Activity> allActivities = coreOperations.GetAllActivitiesForDateRange(DatePickerStart.Value, DatePickerEnd.Value);

                    FillDataGrid(allActivities.Where(x => x.ClientId == selectedClientId).ToList());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                coreOperations.WriteLog("Reports", "BtnGenerate_Click", ex.Message);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormatDataGrid()
        {
            try
            {
                DataGridViewClientReport.AutoGenerateColumns = false;

                DataGridViewColumn dcDate = new DataGridViewColumn
                {
                    ValueType = typeof(string),
                    Name = columnDateHeader,
                    DataPropertyName = columnDateName,
                    CellTemplate = new DataGridViewTextBoxCell(),
                    DisplayIndex = 0,
                    MinimumWidth = 8
                };
                DataGridViewClientReport.Columns.Add(dcDate);

                DataGridViewColumn dcTask = new DataGridViewColumn
                {
                    ValueType = typeof(string),
                    Name = columnTaskHeader,
                    DataPropertyName = columnTaskName,
                    CellTemplate = new DataGridViewTextBoxCell(),
                    DisplayIndex = 1,
                    MinimumWidth = 8
                };
                DataGridViewClientReport.Columns.Add(dcTask);

                DataGridViewColumn dcDescription = new DataGridViewColumn
                {
                    ValueType = typeof(string),
                    Name = columnDescriptionHeader,
                    DataPropertyName = columnDescriptionName,
                    CellTemplate = new DataGridViewTextBoxCell(),
                    DisplayIndex = 2,
                    MinimumWidth = 15
                };
                DataGridViewClientReport.Columns.Add(dcDescription);

                DataGridViewColumn dcDuration = new DataGridViewColumn
                {
                    ValueType = typeof(int),
                    Name = columnDurationHeader,
                    CellTemplate = new DataGridViewTextBoxCell(),
                    DataPropertyName = columnDurationName,
                    DisplayIndex = 3
                };
                DataGridViewClientReport.Columns.Add(dcDuration);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                coreOperations.WriteLog("Reports", "FormatDataGrid", ex.Message);
            }
        }

        private void FillDataGrid(List<Activity> allActivities)
        {
            try
            {
                baseDt?.Clear();

                foreach (Activity activity in allActivities)
                {
                    DataRow dr = baseDt.NewRow();
                    dr[columnDateName] = activity.DateTimeStamp.ToShortDateString();
                    dr[columnTaskName] = allTasks.Where(x => x.Id == activity.TaskId).FirstOrDefault().Name;
                    dr[columnDescriptionName] = activity.Description;
                    dr[columnDurationName] = activity.Duration;
                    baseDt.Rows.Add(dr);
                }
                BindingSource bSource = new BindingSource
                {
                    DataSource = baseDt
                };
                DataGridViewClientReport.DataSource = bSource;
                txtTimeSpent.Text = coreOperations.GetTheTotalTime(allActivities);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                coreOperations.WriteLog("Reports", "FillDataGrid", ex.Message);
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (baseDt?.Rows.Count > 0)
                {
                    string clientName = allClients.Where(x => x.Id == selectedClientId).FirstOrDefault().Name;
                    string name = $"Report_{clientName}_{DatePickerStart.Value:yyyy-MMM-dd}_TO_{DatePickerEnd.Value:yyyy-MMM-dd}";
                    coreOperations.ExportToExcel(baseDt, name);
                    MessageBox.Show($"Report saved as {name} to location {coreOperations.reportFolder}");
                }
                else
                {
                    MessageBox.Show("No Data to export!!!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                coreOperations.WriteLog("Reports", "BtnExport_Click", ex.Message);
            }
        }

        private void CmbClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDataGrid(new List<Activity>());
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
