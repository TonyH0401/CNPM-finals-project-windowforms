using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Finals_Project
{
    public partial class frmAddProductImport : Form
    {
        //the quantity after this will be saved into the database
        Dictionary<string, int> initialProductQuantity = new Dictionary<string, int>();
        public frmAddProductImport()
        {
            InitializeComponent();
        }

        private void frmAddProductImport_Load(object sender, EventArgs e)
        {
            txtbxProductID.ReadOnly = true;
            txtbxProductPrice.ReadOnly = true;
            txtbxProductQuantity.ReadOnly = true;
            txtbxOrigin.ReadOnly = true;
            txtbxProductID.BackColor = Color.White;
            txtbxProductPrice.BackColor = Color.White;
            txtbxProductQuantity.BackColor = Color.White;
            txtbxOrigin.BackColor = Color.White;

            txtbxStoreID.ReadOnly = true;
            txtbxStoreLocation.ReadOnly = true;
            txtbxSessionUser.ReadOnly = true;
            txtbxStoreID.BackColor = Color.White;
            txtbxStoreLocation.BackColor = Color.White;
            txtbxSessionUser.BackColor = Color.White;
            txtbxSessionUser.Text = (!Program.sessionAccount.Trim().Equals("")) ? Program.sessionAccount.Trim() : "admin";

            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            this.ActiveControl = txtbxQuantityToImport;

            initiateLoadProductQuantity();
            initiateDataGridView();
            initiateComboBox();
            initiateComboBoxStoreName();

        }

        private void initiateDataGridView()
        {
            dataGridViewAddedProduct.ColumnCount = 6;
            dataGridViewAddedProduct.Columns[0].Name = "ProductID";
            dataGridViewAddedProduct.Columns[1].Name = "Product Name";
            dataGridViewAddedProduct.Columns[2].Name = "Product Price";
            dataGridViewAddedProduct.Columns[3].Name = "Quantity";
            dataGridViewAddedProduct.Columns[4].Name = "Total Price";
            dataGridViewAddedProduct.Columns[5].Name = "Store ID";


        }

        private void initiateComboBox()
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
                cbbxProductID.DataSource = dt;
                cbbxProductID.DisplayMember = "productName";
                cbbxProductID.ValueMember = "productID";
            }
            else
            {
                MessageBox.Show("No data", "Warning");
            }
        }

        private void initiaProductInformation()
        {
            SqlConnection conn = new SqlConnection(Program.strConn);
            conn.Open();

            String sSQL = "select * from Product where productID=@productID";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@productID", cbbxProductID.SelectedValue.ToString().Trim());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtbxProductID.Text = (String)dt.Rows[0][0];
                txtbxProductPrice.Text = ((int)dt.Rows[0][2]).ToString().Trim();
                //txtbxProductQuantity.Text = ((int)dt.Rows[0][3]).ToString().Trim();
                txtbxProductQuantity.Text = initialProductQuantity[cbbxProductID.SelectedValue.ToString().Trim()].ToString();
                txtbxOrigin.Text = (String)dt.Rows[0][4];
                btnAdd.Enabled = (txtbxProductID.Text.Equals("") == true) ? false : true;
            }
            else
            {
                //MessageBox.Show("No data", "Warning");
            }
        }

        private void cbbxProductID_SelectedIndexChanged(object sender, EventArgs e)
        {
            initiaProductInformation();
        }

        private void initiateComboBoxStoreName()
        {
            SqlConnection conn = new SqlConnection(Program.strConn);
            conn.Open();

            String sSQL = "select * from Store";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cbbxStoreName.DataSource = dt;
                cbbxStoreName.DisplayMember = "storeName";
                cbbxStoreName.ValueMember = "storeID";
            }
            else
            {
                MessageBox.Show("No data", "Warning");
            }
        }

        private void initiaStoreInformation()
        {
            SqlConnection conn = new SqlConnection(Program.strConn);
            conn.Open();

            String sSQL = "select * from Store where storeID=@storeID";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@storeID", cbbxStoreName.SelectedValue.ToString().Trim());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtbxStoreID.Text = (String)dt.Rows[0][0];
                txtbxStoreLocation.Text = (String) dt.Rows[0][2].ToString().Trim();
                btnAdd.Enabled = (txtbxStoreID.Text.Equals("") == true) ? false : true;
            }
            else
            {
                //MessageBox.Show("No data", "Warning");
            }
        }

        private void cbbxStoreName_SelectedIndexChanged(object sender, EventArgs e)
        {
            initiaStoreInformation();
        }

        private void initiateLoadProductQuantity()
        {
            SqlConnection conn = new SqlConnection(Program.strConn);
            conn.Open();

            String sSQL = "select productID, productQuantity from Product";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    initialProductQuantity.Add((String)dr[0], (int)dr[1]);
                }
            }
            else
            {
                //MessageBox.Show("No data", "Warning");
            }

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(((int) txtbxStoreID.Text.Length * (int) txtbxStoreID.Text.Length) == 0)
            {
                MessageBox.Show("Incomplete Product or Location selection. Please complete!", "Warning Incompletion");
            }
            else
            {
                if (txtbxQuantityToImport.Text.Length == 0)
                {
                    MessageBox.Show("Incomplete Quantity", "Warning Incompletion");
                }
                else
                {
                    int n;
                    bool isNumeric = int.TryParse(txtbxQuantityToImport.Text.ToString().Trim(), out n);
                    if(isNumeric == false)
                    {
                        MessageBox.Show("Please enter a number", "Warning input type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtbxQuantityToImport.Clear();
                    }
                    else
                    {
                        if((n <= 0) || n >= ((int)initialProductQuantity[txtbxProductID.Text]))
                        {
                            MessageBox.Show("Exceed the limit product", "Warning Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtbxQuantityToImport.Clear();
                        }
                        else
                        {
                            //remember to add a loop to iterate through
                            int rowIndex = -1;
                            String searchValuePROD = cbbxProductID.SelectedValue.ToString().Trim();
                            String searchValueSTORE = cbbxStoreName.SelectedValue.ToString().Trim();
                            bool foundProduct = false;
                            foreach (DataGridViewRow cRow in dataGridViewAddedProduct.Rows)
                            {
                                if (cRow.Cells[0].Value.ToString().Equals(searchValuePROD) && cRow.Cells[5].Value.ToString().Equals(searchValueSTORE))
                                {
                                    cRow.Cells[3].Value = Int32.Parse(cRow.Cells[3].Value.ToString().Trim()) + Int32.Parse(txtbxQuantityToImport.Text.ToString().Trim());
                                    cRow.Cells[4].Value = Int32.Parse(cRow.Cells[2].Value.ToString().Trim()) * Int32.Parse(cRow.Cells[3].Value.ToString().Trim());
                                    //update quantity of SERVER VIA DICTIONARY after import
                                    int temp_value = initialProductQuantity[cbbxProductID.SelectedValue.ToString().Trim()] - Int32.Parse(txtbxQuantityToImport.Text);
                                    initialProductQuantity[cbbxProductID.SelectedValue.ToString().Trim()] = temp_value;
                                    //update quantity of DISPLAYED TEXT after import
                                    txtbxProductQuantity.Text = initialProductQuantity[cbbxProductID.SelectedValue.ToString().Trim()].ToString();
                                    rowIndex = cRow.Index;
                                    foundProduct = true;
                                    break;
                                }
                            }
                            if(foundProduct == false)
                            {
                                string[] row = new string[] { txtbxProductID.Text, cbbxProductID.Text.ToString(), txtbxProductPrice.Text, txtbxQuantityToImport.Text, (Int32.Parse(txtbxProductPrice.Text.ToString().Trim()) * Int32.Parse(txtbxQuantityToImport.Text.ToString().Trim())).ToString().Trim(), cbbxStoreName.SelectedValue.ToString().Trim() };
                                //update quantity of SERVER VIA DICTIONARY after import
                                int temp_value = initialProductQuantity[cbbxProductID.SelectedValue.ToString().Trim()] - Int32.Parse(txtbxQuantityToImport.Text);
                                initialProductQuantity[cbbxProductID.SelectedValue.ToString().Trim()] = temp_value;
                                //update quantity of DISPLAYED TEXT after import
                                txtbxProductQuantity.Text = initialProductQuantity[cbbxProductID.SelectedValue.ToString().Trim()].ToString();
                                dataGridViewAddedProduct.Rows.Add(row);
                                //MessageBox.Show(initialProductQuantity[cbbxProductID.SelectedValue.ToString().Trim()].ToString() + "; " + cbbxProductID.SelectedValue.ToString().Trim());
                            }
                            MessageBox.Show("Successfully Added", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtbxQuantityToImport.Clear();
                        }
                    }

                   
       
                }


                //save current account, storeID, productID, productQuantity, totalprice, created time, total price bill
                //also save current product quantity after 
            }
        }

    }
}
