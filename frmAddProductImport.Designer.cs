namespace Finals_Project
{
    partial class frmAddProductImport
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
            this.cbbxProductID = new System.Windows.Forms.ComboBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblProductPrice = new System.Windows.Forms.Label();
            this.lblProductOrigin = new System.Windows.Forms.Label();
            this.lblProductQuantity = new System.Windows.Forms.Label();
            this.txtbxProductID = new System.Windows.Forms.TextBox();
            this.txtbxProductPrice = new System.Windows.Forms.TextBox();
            this.txtbxOrigin = new System.Windows.Forms.TextBox();
            this.txtbxProductQuantity = new System.Windows.Forms.TextBox();
            this.lblProductID = new System.Windows.Forms.Label();
            this.dataGridViewAddedProduct = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblADDPROD = new System.Windows.Forms.Label();
            this.lblDisplay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddedProduct)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbxProductID
            // 
            this.cbbxProductID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbxProductID.FormattingEnabled = true;
            this.cbbxProductID.Location = new System.Drawing.Point(114, 23);
            this.cbbxProductID.Name = "cbbxProductID";
            this.cbbxProductID.Size = new System.Drawing.Size(221, 21);
            this.cbbxProductID.TabIndex = 1;
            this.cbbxProductID.SelectedIndexChanged += new System.EventHandler(this.cbbxProductID_SelectedIndexChanged);
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(5, 23);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(75, 13);
            this.lblProductName.TabIndex = 2;
            this.lblProductName.Text = "Product Name";
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.AutoSize = true;
            this.lblProductPrice.Location = new System.Drawing.Point(5, 88);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(71, 13);
            this.lblProductPrice.TabIndex = 3;
            this.lblProductPrice.Text = "Product Price";
            // 
            // lblProductOrigin
            // 
            this.lblProductOrigin.AutoSize = true;
            this.lblProductOrigin.Location = new System.Drawing.Point(5, 153);
            this.lblProductOrigin.Name = "lblProductOrigin";
            this.lblProductOrigin.Size = new System.Drawing.Size(49, 13);
            this.lblProductOrigin.TabIndex = 5;
            this.lblProductOrigin.Text = "Originate";
            // 
            // lblProductQuantity
            // 
            this.lblProductQuantity.AutoSize = true;
            this.lblProductQuantity.Location = new System.Drawing.Point(5, 120);
            this.lblProductQuantity.Name = "lblProductQuantity";
            this.lblProductQuantity.Size = new System.Drawing.Size(86, 13);
            this.lblProductQuantity.TabIndex = 4;
            this.lblProductQuantity.Text = "Product Quantity";
            // 
            // txtbxProductID
            // 
            this.txtbxProductID.Location = new System.Drawing.Point(114, 58);
            this.txtbxProductID.Name = "txtbxProductID";
            this.txtbxProductID.Size = new System.Drawing.Size(79, 20);
            this.txtbxProductID.TabIndex = 6;
            // 
            // txtbxProductPrice
            // 
            this.txtbxProductPrice.Location = new System.Drawing.Point(114, 88);
            this.txtbxProductPrice.Name = "txtbxProductPrice";
            this.txtbxProductPrice.Size = new System.Drawing.Size(79, 20);
            this.txtbxProductPrice.TabIndex = 7;
            // 
            // txtbxOrigin
            // 
            this.txtbxOrigin.Location = new System.Drawing.Point(114, 153);
            this.txtbxOrigin.Name = "txtbxOrigin";
            this.txtbxOrigin.Size = new System.Drawing.Size(151, 20);
            this.txtbxOrigin.TabIndex = 9;
            // 
            // txtbxProductQuantity
            // 
            this.txtbxProductQuantity.Location = new System.Drawing.Point(114, 120);
            this.txtbxProductQuantity.Name = "txtbxProductQuantity";
            this.txtbxProductQuantity.Size = new System.Drawing.Size(79, 20);
            this.txtbxProductQuantity.TabIndex = 8;
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.Location = new System.Drawing.Point(5, 58);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(58, 13);
            this.lblProductID.TabIndex = 10;
            this.lblProductID.Text = "Product ID";
            // 
            // dataGridViewAddedProduct
            // 
            this.dataGridViewAddedProduct.AllowUserToAddRows = false;
            this.dataGridViewAddedProduct.AllowUserToDeleteRows = false;
            this.dataGridViewAddedProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAddedProduct.Location = new System.Drawing.Point(364, 1);
            this.dataGridViewAddedProduct.Name = "dataGridViewAddedProduct";
            this.dataGridViewAddedProduct.ReadOnly = true;
            this.dataGridViewAddedProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAddedProduct.Size = new System.Drawing.Size(433, 348);
            this.dataGridViewAddedProduct.TabIndex = 11;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 353);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 27);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDisplay);
            this.panel1.Controls.Add(this.lblProductName);
            this.panel1.Controls.Add(this.cbbxProductID);
            this.panel1.Controls.Add(this.lblProductPrice);
            this.panel1.Controls.Add(this.lblProductQuantity);
            this.panel1.Controls.Add(this.lblProductOrigin);
            this.panel1.Controls.Add(this.txtbxProductID);
            this.panel1.Controls.Add(this.txtbxProductPrice);
            this.panel1.Controls.Add(this.lblProductID);
            this.panel1.Controls.Add(this.txtbxProductQuantity);
            this.panel1.Controls.Add(this.txtbxOrigin);
            this.panel1.Location = new System.Drawing.Point(8, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 186);
            this.panel1.TabIndex = 13;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(226, 322);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 27);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(217, 386);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 27);
            this.button3.TabIndex = 16;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(12, 386);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(93, 27);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // lblADDPROD
            // 
            this.lblADDPROD.AutoSize = true;
            this.lblADDPROD.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblADDPROD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblADDPROD.Location = new System.Drawing.Point(36, 16);
            this.lblADDPROD.Name = "lblADDPROD";
            this.lblADDPROD.Size = new System.Drawing.Size(294, 25);
            this.lblADDPROD.TabIndex = 17;
            this.lblADDPROD.Text = "ADD PRODUCT TO IMPORT";
            // 
            // lblDisplay
            // 
            this.lblDisplay.AutoSize = true;
            this.lblDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplay.Location = new System.Drawing.Point(21, -2);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(54, 15);
            this.lblDisplay.TabIndex = 18;
            this.lblDisplay.Text = "Display";
            // 
            // frmAddProductImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 425);
            this.ControlBox = false;
            this.Controls.Add(this.lblADDPROD);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridViewAddedProduct);
            this.Name = "frmAddProductImport";
            this.Text = "frmAddProductImport";
            this.Load += new System.EventHandler(this.frmAddProductImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddedProduct)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbxProductID;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblProductPrice;
        private System.Windows.Forms.Label lblProductOrigin;
        private System.Windows.Forms.Label lblProductQuantity;
        private System.Windows.Forms.TextBox txtbxProductID;
        private System.Windows.Forms.TextBox txtbxProductPrice;
        private System.Windows.Forms.TextBox txtbxOrigin;
        private System.Windows.Forms.TextBox txtbxProductQuantity;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.DataGridView dataGridViewAddedProduct;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.Label lblADDPROD;
    }
}