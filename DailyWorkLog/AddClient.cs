using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DailyWorkLog
{
    public partial class AddClient : Form
    {

        int selectedClientId = 0;
        CoreOperations coreOperations = CoreOperations.GetInstance();
        public AddClient()
        {
            InitializeComponent();
            btnAddClient.Text = "Add Client";
            FillCombo();
        }

        private void FillCombo()
        {
            try
            {
                List<Client> allClientsForCombo = coreOperations.GetAllClientsFromFile();
                allClientsForCombo.Insert(0, new Client() { Id = 0, Name = "Add New Client" });

                cmbClients.DataSource = allClientsForCombo;

                cmbClients.DisplayMember = "Name";
                cmbClients.ValueMember = "Id";

                txtName.Text = "";
                txtDescription.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                coreOperations.WriteLog("AddClient", "FillCombo", ex.Message);
            }
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    List<Client> clients = coreOperations.GetAllClientsFromFile();
                    if (selectedClientId > 0)
                    {
                        foreach (Client c in clients.Where(u => u.Id == selectedClientId))
                        {
                            c.Name = txtName.Text;
                            c.Description = txtDescription.Text;
                        }
                        coreOperations.WriteAllClientsToFile(clients);
                    }
                    else
                    {
                        Client newClient = new Client() { Id = clients.Count + 1, Name = txtName.Text, Description = txtDescription.Text };
                        clients.Add(newClient);
                        coreOperations.WriteAllClientsToFile(clients);
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
                coreOperations.WriteLog("AddClient", "btnAddClient_Click", ex.Message);
            }
        }
        private void cmbClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int.TryParse(cmbClients.SelectedValue.ToString(), out selectedClientId);
                btnAddClient.Text = "Add Client";
                txtName.Text = "";
                txtDescription.Text = "";
                if (selectedClientId > 0)
                {
                    List<Client> clients = coreOperations.GetAllClientsFromFile();
                    Client selectedClient = clients.FirstOrDefault(x => x.Id == selectedClientId);
                    txtName.Text = selectedClient.Name;
                    txtDescription.Text = selectedClient.Description;
                    btnAddClient.Text = "Update Client";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                coreOperations.WriteLog("AddClient", "cmbClients_SelectedIndexChanged", ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            Main parent = (Main)this.Owner;
            parent.NotificationFromChild("client");
        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedClientId > 0)
                {
                    List<Activity> activities = coreOperations.GetAllActivitiesFromFile();
                    List<Activity> activitiesInUse = activities.Where(x => x.ClientId == selectedClientId).ToList();
                    if (activitiesInUse.Count > 0)
                    {
                        MessageBox.Show("The client is already in use");
                    }
                    else
                    {
                        List<Client> clients = coreOperations.GetAllClientsFromFile();
                        Client client = clients.Where(x => x.Id == selectedClientId).FirstOrDefault();
                        clients.Remove(client);
                        coreOperations.WriteAllClientsToFile(clients);
                        MessageBox.Show("The client is deleted");
                        FillCombo();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                coreOperations.WriteLog("AddClient", "btnDeleteClient_Click", ex.Message);
            }
        }
    }
}
