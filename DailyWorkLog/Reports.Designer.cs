namespace DailyWorkLog
{
    partial class Reports
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
            this.BtnClose = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BtnGenerate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DataGridViewClientReport = new System.Windows.Forms.DataGridView();
            this.DatePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.DatePickerStart = new System.Windows.Forms.DateTimePicker();
            this.CmbClients = new System.Windows.Forms.ComboBox();
            this.BtnExport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTimeSpent = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewClientReport)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(628, 14);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(80, 25);
            this.BtnClose.TabIndex = 5;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnGenerate
            // 
            this.BtnGenerate.Location = new System.Drawing.Point(464, 14);
            this.BtnGenerate.Name = "BtnGenerate";
            this.BtnGenerate.Size = new System.Drawing.Size(80, 25);
            this.BtnGenerate.TabIndex = 3;
            this.BtnGenerate.Text = "Generate";
            this.BtnGenerate.UseVisualStyleBackColor = true;
            this.BtnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "End";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Start";
            // 
            // DataGridViewClientReport
            // 
            this.DataGridViewClientReport.AllowUserToAddRows = false;
            this.DataGridViewClientReport.AllowUserToDeleteRows = false;
            this.DataGridViewClientReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewClientReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewClientReport.Location = new System.Drawing.Point(12, 72);
            this.DataGridViewClientReport.MultiSelect = false;
            this.DataGridViewClientReport.Name = "DataGridViewClientReport";
            this.DataGridViewClientReport.ReadOnly = true;
            this.DataGridViewClientReport.RowHeadersWidth = 51;
            this.DataGridViewClientReport.RowTemplate.Height = 24;
            this.DataGridViewClientReport.Size = new System.Drawing.Size(696, 261);
            this.DataGridViewClientReport.TabIndex = 19;
            // 
            // DatePickerEnd
            // 
            this.DatePickerEnd.Location = new System.Drawing.Point(280, 43);
            this.DatePickerEnd.Name = "DatePickerEnd";
            this.DatePickerEnd.Size = new System.Drawing.Size(168, 22);
            this.DatePickerEnd.TabIndex = 2;
            // 
            // DatePickerStart
            // 
            this.DatePickerStart.Location = new System.Drawing.Point(280, 15);
            this.DatePickerStart.Name = "DatePickerStart";
            this.DatePickerStart.Size = new System.Drawing.Size(168, 22);
            this.DatePickerStart.TabIndex = 1;
            // 
            // CmbClients
            // 
            this.CmbClients.FormattingEnabled = true;
            this.CmbClients.Location = new System.Drawing.Point(12, 14);
            this.CmbClients.Name = "CmbClients";
            this.CmbClients.Size = new System.Drawing.Size(205, 24);
            this.CmbClients.TabIndex = 0;
            this.CmbClients.SelectedIndexChanged += new System.EventHandler(this.CmbClients_SelectedIndexChanged);
            // 
            // BtnExport
            // 
            this.BtnExport.Location = new System.Drawing.Point(546, 14);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(80, 25);
            this.BtnExport.TabIndex = 4;
            this.BtnExport.Text = "Export";
            this.BtnExport.UseVisualStyleBackColor = true;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Total Time Spent";
            // 
            // txtTimeSpent
            // 
            this.txtTimeSpent.Location = new System.Drawing.Point(134, 44);
            this.txtTimeSpent.Name = "txtTimeSpent";
            this.txtTimeSpent.Size = new System.Drawing.Size(83, 22);
            this.txtTimeSpent.TabIndex = 23;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 346);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTimeSpent);
            this.Controls.Add(this.BtnExport);
            this.Controls.Add(this.BtnGenerate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataGridViewClientReport);
            this.Controls.Add(this.DatePickerEnd);
            this.Controls.Add(this.DatePickerStart);
            this.Controls.Add(this.CmbClients);
            this.Controls.Add(this.BtnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Reports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewClientReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnClose;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button BtnGenerate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DataGridViewClientReport;
        private System.Windows.Forms.DateTimePicker DatePickerEnd;
        private System.Windows.Forms.DateTimePicker DatePickerStart;
        private System.Windows.Forms.ComboBox CmbClients;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTimeSpent;
    }
}