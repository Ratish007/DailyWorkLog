namespace DailyWorkLog
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnAddNewClient = new System.Windows.Forms.Button();
            this.btnAddNewTask = new System.Windows.Forms.Button();
            this.LblHi = new System.Windows.Forms.Label();
            this.dataGridViewDailyTaks = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtPicker = new System.Windows.Forms.DateTimePicker();
            this.txtTimeSpent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnReports = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDailyTaks)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddNewClient
            // 
            this.btnAddNewClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewClient.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnAddNewClient.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAddNewClient.Location = new System.Drawing.Point(636, 9);
            this.btnAddNewClient.Name = "btnAddNewClient";
            this.btnAddNewClient.Size = new System.Drawing.Size(83, 48);
            this.btnAddNewClient.TabIndex = 3;
            this.btnAddNewClient.Text = "Add New Client";
            this.btnAddNewClient.UseVisualStyleBackColor = true;
            this.btnAddNewClient.Click += new System.EventHandler(this.btnAddNewClient_Click);
            // 
            // btnAddNewTask
            // 
            this.btnAddNewTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewTask.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnAddNewTask.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAddNewTask.Location = new System.Drawing.Point(547, 9);
            this.btnAddNewTask.Name = "btnAddNewTask";
            this.btnAddNewTask.Size = new System.Drawing.Size(83, 48);
            this.btnAddNewTask.TabIndex = 2;
            this.btnAddNewTask.Text = "Add New Task";
            this.btnAddNewTask.UseVisualStyleBackColor = true;
            this.btnAddNewTask.Click += new System.EventHandler(this.btnAddNewTask_Click);
            // 
            // LblHi
            // 
            this.LblHi.AutoSize = true;
            this.LblHi.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHi.Location = new System.Drawing.Point(7, 9);
            this.LblHi.Name = "LblHi";
            this.LblHi.Size = new System.Drawing.Size(50, 39);
            this.LblHi.TabIndex = 0;
            this.LblHi.Text = "Hi";
            // 
            // dataGridViewDailyTaks
            // 
            this.dataGridViewDailyTaks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDailyTaks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDailyTaks.Location = new System.Drawing.Point(7, 109);
            this.dataGridViewDailyTaks.Name = "dataGridViewDailyTaks";
            this.dataGridViewDailyTaks.RowHeadersWidth = 51;
            this.dataGridViewDailyTaks.RowTemplate.Height = 24;
            this.dataGridViewDailyTaks.Size = new System.Drawing.Size(800, 312);
            this.dataGridViewDailyTaks.TabIndex = 100;
            this.dataGridViewDailyTaks.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDailyTaks_CellValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSave.Location = new System.Drawing.Point(458, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 48);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtPicker
            // 
            this.dtPicker.Location = new System.Drawing.Point(642, 72);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.Size = new System.Drawing.Size(165, 22);
            this.dtPicker.TabIndex = 5;
            this.dtPicker.ValueChanged += new System.EventHandler(this.dtPicker_ValueChanged);
            // 
            // txtTimeSpent
            // 
            this.txtTimeSpent.Location = new System.Drawing.Point(545, 72);
            this.txtTimeSpent.Name = "txtTimeSpent";
            this.txtTimeSpent.Size = new System.Drawing.Size(83, 22);
            this.txtTimeSpent.TabIndex = 100;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(423, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 100;
            this.label2.Text = "Total Time Spent";
            // 
            // BtnReports
            // 
            this.BtnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnReports.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.BtnReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BtnReports.Location = new System.Drawing.Point(724, 9);
            this.BtnReports.Name = "BtnReports";
            this.BtnReports.Size = new System.Drawing.Size(83, 48);
            this.BtnReports.TabIndex = 4;
            this.BtnReports.Text = "Reports";
            this.BtnReports.UseVisualStyleBackColor = true;
            this.BtnReports.Click += new System.EventHandler(this.BtnReports_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 429);
            this.Controls.Add(this.BtnReports);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTimeSpent);
            this.Controls.Add(this.dtPicker);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridViewDailyTaks);
            this.Controls.Add(this.LblHi);
            this.Controls.Add(this.btnAddNewTask);
            this.Controls.Add(this.btnAddNewClient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDailyTaks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewClient;
        private System.Windows.Forms.Button btnAddNewTask;
        private System.Windows.Forms.Label LblHi;
        private System.Windows.Forms.DataGridView dataGridViewDailyTaks;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtPicker;
        private System.Windows.Forms.TextBox txtTimeSpent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnReports;
    }
}

