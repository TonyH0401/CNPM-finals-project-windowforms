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
    public partial class frmAddProductImport : Form
    {
        //SqlConnection conn = new SqlConnection(Program.strConn);
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

            initiateDataGridView();
            initiateComboBox();
            initiateComboBoxStoreName();
        }

        private void initiateDataGridView()
        {
            dataGridViewAddedProduct.ColumnCount = 5;
            dataGridViewAddedProduct.Columns[0].Name = "ProductID";
            dataGridViewAddedProduct.Columns[1].Name = "Product Name";
            dataGridViewAddedProduct.Columns[2].Name = "Product Price";
            dataGridViewAddedProduct.Columns[3].Name = "Quantity";
            dataGridViewAddedProduct.Columns[4].Name = "Total Price";


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
                txtbxProductQuantity.Text = ((int)dt.Rows[0][3]).ToString().Trim();
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
            }
        }
    }
}
