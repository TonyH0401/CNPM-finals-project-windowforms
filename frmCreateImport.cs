using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finals_Project
{
    public partial class frmCreateImport : Form
    {
        //Dictionary<string, int> initialProductQuantity = new Dictionary<string, int>();

        public frmCreateImport()
        {
            InitializeComponent();
        }

        private void frmCreateImport_Load(object sender, EventArgs e)
        {
            initiateComponentsOnLoad(); 
            initiateDataGridView();
        }

        private void initiateComponentsOnLoad()
        {
            //pre-exist products
            cbbxProductName.Enabled = false;
            txtbxProductIDOld.Enabled = false;
            txtbxProductIDOld.ReadOnly = true;
            txtbxProductOriginOld.Enabled = false;
            txtbxProductOriginOld.ReadOnly = true;
            txtbxProductPriceOld.Enabled = false;
            txtbxProductPriceOld.ReadOnly = true;
            txtbxProductQuantityOld.Enabled = false;

            //new products
            txtbxProductID.Enabled = false;
            txtbxProductName.Enabled = false;
            txtbxProductQuantityNew.Enabled = false;
            txtbxProductPrice.Enabled = false;
            txtbxProductOrigin.Enabled = false;

            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void initiateDataGridView()
        {
            dataGridViewImportProduct.ColumnCount = 6;
            dataGridViewImportProduct.Columns[0].Name = "ProductID";
            dataGridViewImportProduct.Columns[1].Name = "Product Name";
            dataGridViewImportProduct.Columns[2].Name = "Product Price";
            dataGridViewImportProduct.Columns[3].Name = "Quantity";
            dataGridViewImportProduct.Columns[4].Name = "Origin";
            dataGridViewImportProduct.Columns[5].Name = "Total Price";
        }
        private void btnChooseImportType_Click(object sender, EventArgs e)
        {
            if(rdbtnImportNewProduct.Checked == false && rdbtnImportOldProduct.Checked == false)
            {
                MessageBox.Show("Please choose type of Import", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
            if(rdbtnImportNewProduct.Checked == true)
            {
                this.ActiveControl = txtbxProductName;

                txtbxProductID.Enabled = true;
                txtbxProductName.Enabled = true;
                txtbxProductOrigin.Enabled = true;
                txtbxProductPrice.Enabled = true;
                txtbxProductQuantityNew.Enabled = true;

                cbbxProductName.Enabled = false; ;
                txtbxProductPriceOld.Enabled = false;
                txtbxProductQuantityOld.Enabled = false;

                btnAdd.Enabled = true;
            }
            if(rdbtnImportOldProduct.Checked == true)
            {
                this.ActiveControl = txtbxProductQuantityOld;

                cbbxProductName.Enabled = true;

                txtbxProductID.Enabled = false;
                txtbxProductName.Enabled = false;
                txtbxProductOrigin.Enabled = false;
                txtbxProductPrice.Enabled = false;
                txtbxProductQuantityNew.Enabled = false;

                btnAdd.Enabled = true;

                loadComboBoxOldProduct();
            }
        }
        private void loadComboBoxOldProduct()
        {
            SqlConnection conn = new SqlConnection(Program.strConn);
            conn.Open();

            String sSQL = "select * from Product";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cbbxProductName.DataSource = dt;
                cbbxProductName.DisplayMember = "productName";
                cbbxProductName.ValueMember = "productID";
            }
            else
            {
                MessageBox.Show("No data", "Warning");
            }
        }
        private void loadOtherDataFromComboBoxOldProduct()
        {
            SqlConnection conn = new SqlConnection(Program.strConn);
            conn.Open();

            String sSQL = "select * from Product where productID = @productID";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@productID", cbbxProductName.SelectedValue.ToString().Trim());
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtbxProductIDOld.Text = (String)dt.Rows[0][0];
                txtbxProductPriceOld.Text = ((int)dt.Rows[0][2]).ToString().Trim();
                txtbxProductOriginOld.Text = (String)dt.Rows[0][4];
            }
            else
            {
                //MessageBox.Show("No data", "Warning");
            }
        }
        private void cbbxProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ActiveControl = txtbxProductQuantityOld;
            txtbxProductQuantityOld.Enabled = true;

            loadOtherDataFromComboBoxOldProduct();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            String productID = "";
            String productName = "";
            String productPrice = "";
            String productOrigin = "";
            String productQuantity = "";
            if (rdbtnImportOldProduct.Checked == true)
            {
                if (txtbxProductQuantityOld.Text.ToString().Trim().Equals("") == true)
                {
                    MessageBox.Show("Please fill in the quantity!", "Warning Box");
                }
                else
                {
                    int n;
                    bool isNumeric = int.TryParse(txtbxProductQuantityOld.Text.ToString().Trim(), out n);
                    if (isNumeric == false)
                    {
                        MessageBox.Show("Please enter a number", "Warning input type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtbxProductQuantityOld.Clear();
                    }
                    else
                    {
                        //get data from text box
                        productID = txtbxProductIDOld.Text.ToString().Trim();
                        productName = cbbxProductName.Text.ToString().Trim();
                        productPrice = txtbxProductPriceOld.Text.ToString().Trim();
                        productOrigin = txtbxProductOriginOld.Text.ToString().Trim();
                        productQuantity = txtbxProductQuantityOld.Text.ToString().Trim();

                        int rowIndex = -1;
                        String searchValuePROD = cbbxProductName.SelectedValue.ToString().Trim();
                        bool foundProduct = false;
                        //add to an existing product in the datagrid
                        foreach (DataGridViewRow row in dataGridViewImportProduct.Rows)
                        {
                            if (row.Cells[0].Value.ToString().Equals(searchValuePROD) == true)
                            {
                                row.Cells[3].Value = Int32.Parse(row.Cells[3].Value.ToString().Trim()) + Int32.Parse(txtbxProductQuantityOld.Text.ToString().Trim());
                                row.Cells[5].Value = Int32.Parse(row.Cells[2].Value.ToString().Trim()) * Int32.Parse(row.Cells[3].Value.ToString().Trim());
                                rowIndex = row.Index;
                                foundProduct = true;
                                break;
                            }
                        }
                        //add new data to datagrid
                        if (foundProduct == false)
                        {
                            String totalPrice = (Int32.Parse(productPrice) * Int32.Parse(productQuantity)).ToString().Trim();
                            string[] row = new string[] { productID, productName, productPrice, productQuantity, productOrigin, totalPrice };
                            dataGridViewImportProduct.Rows.Add(row);
                        }
                        MessageBox.Show("Successfully Added", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearDataFromInsert();
                    }
                }
            }
            if(rdbtnImportNewProduct.Checked == true)
            {
                int pNameNew = txtbxProductName.Text.ToString().Trim().Length;
                int pIDNew = txtbxProductID.Text.ToString().Trim().Length;
                int pQuantityNew = txtbxProductQuantityNew.Text.ToString().Trim().Length;
                int pPriceNew = txtbxProductPrice.Text.ToString().Trim().Length;
                int pOriginNew = txtbxProductOrigin.Text.ToString().Trim().Length;

                if((pNameNew * pIDNew * pQuantityNew * pPriceNew * pOriginNew) == 0)
                {
                    MessageBox.Show("Please fill in all the correct information", "Warning");
                }
                else
                {
                    int n, m;
                    bool isNumericQuantity = int.TryParse(txtbxProductQuantityNew.Text.ToString().Trim(), out n);
                    bool isNumberPrice = int.TryParse(txtbxProductPrice.Text.ToString().Trim(), out m);
                    if((isNumericQuantity && isNumberPrice) == false)
                    {
                        MessageBox.Show("Wrong data input type", "Warning");
                    }
                    else
                    {
                        productID = txtbxProductID.Text.ToString().ToUpper().Trim();
                        productName = txtbxProductName.Text.ToString().Trim();
                        productPrice = txtbxProductPrice.Text.ToString().Trim();
                        productOrigin = txtbxProductOrigin.Text.ToString().Trim();
                        productQuantity = txtbxProductQuantityNew.Text.ToString().Trim();

                        int rowIndex = -1;
                        String searchValuePROD = productID;
                        bool foundProduct = false;
                        //add to an existing product in the datagrid
                        foreach (DataGridViewRow row in dataGridViewImportProduct.Rows)
                        {
                            if (row.Cells[0].Value.ToString().Equals(searchValuePROD) == true)
                            {
                                row.Cells[3].Value = Int32.Parse(row.Cells[3].Value.ToString().Trim()) + Int32.Parse(txtbxProductQuantityOld.Text.ToString().Trim());
                                row.Cells[5].Value = Int32.Parse(row.Cells[2].Value.ToString().Trim()) * Int32.Parse(row.Cells[3].Value.ToString().Trim());
                                rowIndex = row.Index;
                                foundProduct = true;
                                break;
                            }
                        }
                        //add new data to datagrid
                        if (foundProduct == false)
                        {
                            String totalPrice = (Int32.Parse(productPrice) * Int32.Parse(productQuantity)).ToString().Trim();
                            string[] row = new string[] { productID, productName, productPrice, productQuantity, productOrigin, totalPrice };
                            dataGridViewImportProduct.Rows.Add(row);
                        }
                        MessageBox.Show("Successfully Added", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearDataFromInsert();
                    }
                }
            }
        }
        public void clearDataFromInsert()
        {
            //old products sections
            //cbbxProductName.SelectedIndex = -1;
            txtbxProductIDOld.Clear();
            txtbxProductPriceOld.Clear();
            txtbxProductOriginOld.Clear();
            txtbxProductQuantityOld.Clear();
            //new products section
            txtbxProductID.Clear();
            txtbxProductName.Clear();
            txtbxProductPrice.Clear();
            txtbxProductOrigin.Clear();
            txtbxProductQuantityNew.Clear();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearDataFromInsert();
        }

    }
}
