namespace Finals_Project
{
    partial class frmImport
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
            this.listBoxImportID = new System.Windows.Forms.ListBox();
            this.dataGridViewImportDetail = new System.Windows.Forms.DataGridView();
            this.lblAccountImport = new System.Windows.Forms.Label();
            this.lblImportID = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.lblTimeCreated = new System.Windows.Forms.Label();
            this.txtImportID = new System.Windows.Forms.TextBox();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.dateTimePickerImportCreated = new System.Windows.Forms.DateTimePicker();
            this.lblImport = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImportDetail)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxImportID
            // 
            this.listBoxImportID.FormattingEnabled = true;
            this.listBoxImportID.Location = new System.Drawing.Point(576, 49);
            this.listBoxImportID.Name = "listBoxImportID";
            this.listBoxImportID.Size = new System.Drawing.Size(207, 342);
            this.listBoxImportID.TabIndex = 0;
            this.listBoxImportID.SelectedIndexChanged += new System.EventHandler(this.listBoxImportID_SelectedIndexChanged);
            // 
            // dataGridViewImportDetail
            // 
            this.dataGridViewImportDetail.AllowUserToAddRows = false;
            this.dataGridViewImportDetail.AllowUserToDeleteRows = false;
            this.dataGridViewImportDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewImportDetail.Location = new System.Drawing.Point(12, 225);
            this.dataGridViewImportDetail.Name = "dataGridViewImportDetail";
            this.dataGridViewImportDetail.ReadOnly = true;
            this.dataGridViewImportDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewImportDetail.Size = new System.Drawing.Size(546, 166);
            this.dataGridViewImportDetail.TabIndex = 1;
            // 
            // lblAccountImport
            // 
            this.lblAccountImport.AutoSize = true;
            this.lblAccountImport.Location = new System.Drawing.Point(14, 24);
            this.lblAccountImport.Name = "lblAccountImport";
            this.lblAccountImport.Size = new System.Drawing.Size(50, 13);
            this.lblAccountImport.TabIndex = 2;
            this.lblAccountImport.Text = "Account:";
            // 
            // lblImportID
            // 
            this.lblImportID.AutoSize = true;
            this.lblImportID.Location = new System.Drawing.Point(14, 54);
            this.lblImportID.Name = "lblImportID";
            this.lblImportID.Size = new System.Drawing.Size(53, 13);
            this.lblImportID.TabIndex = 3;
            this.lblImportID.Text = "Import ID:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.txtTotal);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.lblDisplay);
            this.panel1.Controls.Add(this.lblTimeCreated);
            this.panel1.Controls.Add(this.txtImportID);
            this.panel1.Controls.Add(this.txtAccount);
            this.panel1.Controls.Add(this.dateTimePickerImportCreated);
            this.panel1.Controls.Add(this.lblAccountImport);
            this.panel1.Controls.Add(this.lblImportID);
            this.panel1.Location = new System.Drawing.Point(288, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 148);
            this.panel1.TabIndex = 4;
            // 
            // lblDisplay
            // 
            this.lblDisplay.AutoSize = true;
            this.lblDisplay.BackColor = System.Drawing.Color.AliceBlue;
            this.lblDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplay.Location = new System.Drawing.Point(14, 5);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(59, 13);
            this.lblDisplay.TabIndex = 9;
            this.lblDisplay.Text = "DISPLAY";
            // 
            // lblTimeCreated
            // 
            this.lblTimeCreated.AutoSize = true;
            this.lblTimeCreated.Location = new System.Drawing.Point(14, 115);
            this.lblTimeCreated.Name = "lblTimeCreated";
            this.lblTimeCreated.Size = new System.Drawing.Size(73, 13);
            this.lblTimeCreated.TabIndex = 11;
            this.lblTimeCreated.Text = "Time Created:";
            // 
            // txtImportID
            // 
            this.txtImportID.Location = new System.Drawing.Point(101, 54);
            this.txtImportID.Name = "txtImportID";
            this.txtImportID.Size = new System.Drawing.Size(149, 20);
            this.txtImportID.TabIndex = 9;
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(101, 21);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(149, 20);
            this.txtAccount.TabIndex = 10;
            // 
            // dateTimePickerImportCreated
            // 
            this.dateTimePickerImportCreated.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerImportCreated.Location = new System.Drawing.Point(101, 115);
            this.dateTimePickerImportCreated.Name = "dateTimePickerImportCreated";
            this.dateTimePickerImportCreated.Size = new System.Drawing.Size(149, 20);
            this.dateTimePickerImportCreated.TabIndex = 5;
            // 
            // lblImport
            // 
            this.lblImport.AutoSize = true;
            this.lblImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImport.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblImport.Location = new System.Drawing.Point(271, 8);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(278, 31);
            this.lblImport.TabIndex = 6;
            this.lblImport.Text = "IMPORT MANAGER";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(576, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(674, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(101, 85);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(149, 20);
            this.txtTotal.TabIndex = 13;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(14, 85);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(31, 13);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "Total";
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 406);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblImport);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewImportDetail);
            this.Controls.Add(this.listBoxImportID);
            this.Name = "frmImport";
            this.Text = "frmImport";
            this.Load += new System.EventHandler(this.frmImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImportDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxImportID;
        private System.Windows.Forms.DataGridView dataGridViewImportDetail;
        private System.Windows.Forms.Label lblAccountImport;
        private System.Windows.Forms.Label lblImportID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerImportCreated;
        private System.Windows.Forms.Label lblImport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.TextBox txtImportID;
        private System.Windows.Forms.Label lblTimeCreated;
        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblTotal;
    }
}