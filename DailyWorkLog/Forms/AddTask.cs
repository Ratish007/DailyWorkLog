using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DailyWorkLog
{
    public partial class AddTask : Form
    {
        int selectedTaskId = 0;
        CoreOperations coreOperations = CoreOperations.GetInstance();
        public AddTask()
        {
            InitializeComponent();
            btnAddTask.Text = "Add Task";
            FillCombo();
        }
        private void FillCombo()
        {
            try
            {
                List<Task> allTasksForCombo = coreOperations.GetAllTasksFromFile();
                allTasksForCombo.Insert(0, new Task() { Id = 0, Name = "Add New Task" });

                cmbTasks.DataSource = allTasksForCombo;

                cmbTasks.DisplayMember = "Name";
                cmbTasks.ValueMember = "Id";

                txtName.Text = "";
                txtDescription.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                coreOperations.WriteLog("AddTask", "FillCombo", ex.Message);
            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    List<Task> tasks = coreOperations.GetAllTasksFromFile();
                    if (selectedTaskId > 0)
                    {
                        foreach (Task c in tasks.Where(u => u.Id == selectedTaskId))
                        {
                            c.Name = txtName.Text;
                            c.Description = txtDescription.Text;
                        }
                        coreOperations.WriteAllTasksToFile(tasks);
                    }
                    else
                    {
                        Task newTask = new Task() { Id = tasks.Count + 1, Name = txtName.Text, Description = txtDescription.Text };
                        tasks.Add(newTask);
                        coreOperations.WriteAllTasksToFile(tasks);

                    }
                    MessageBox.Show("Data Updated");
                    FillCombo();
                }
                else
                {
                    MessageBox.Show("Name cannot be blank");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                coreOperations.WriteLog("AddTask", "btnAddTask_Click", ex.Message);
            }
        }




        private void cmbTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int.TryParse(cmbTasks.SelectedValue.ToString(), out selectedTaskId);
                txtName.Text = "";
                txtDescription.Text = "";
                if (selectedTaskId > 0)
                {
                    List<Task> tasks = coreOperations.GetAllTasksFromFile();
                    Task selectedTask = tasks.FirstOrDefault(x => x.Id == selectedTaskId);
                    txtName.Text = selectedTask.Name;
                    txtDescription.Text = selectedTask.Description;
                }
                btnAddTask.Text = selectedTaskId > 0 ? "Update Task" : "Add Task";
                btnDeleteTask.Visible = selectedTaskId > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                coreOperations.WriteLog("AddTask", "cmbTasks_SelectedIndexChanged", ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            Main parent = (Main)this.Owner;
            parent.NotificationFromChild("task");
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedTaskId > 0)
                {
                    List<Activity> activities = coreOperations.GetAllActivitiesFromFile();
                    List<Activity> activitiesInUse = activities.Where(x => x.TaskId == selectedTaskId).ToList();
                    if (activitiesInUse.Count > 0)
                    {
                        MessageBox.Show("The task is already in use");
                    }
                    else
                    {
                        List<Task> tasks = coreOperations.GetAllTasksFromFile();
                        Task task = tasks.Where(x => x.Id == selectedTaskId).FirstOrDefault();
                        tasks.Remove(task);
                        coreOperations.WriteAllTasksToFile(tasks);
                        MessageBox.Show("The task is deleted");
                        FillCombo();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                coreOperations.WriteLog("AddTask", "btnDeleteTask_Click", ex.Message);
            }
        }
    }
}
