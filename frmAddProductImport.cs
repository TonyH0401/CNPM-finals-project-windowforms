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


            initiateDataGridView();
            initiateComboBox();
        }

        private void initiateDataGridView()
        {
            dataGridViewAddedProduct.ColumnCount = 5;
            dataGridViewAddedProduct.Columns[0].Name = "ProductID";
            dataGridViewAddedProduct.Columns[1].Name = "Product Name";
            dataGridViewAddedProduct.Columns[2].Name = "Product Price";
            dataGridViewAddedProduct.Columns[3].Name = "Product Quantity";
            dataGridViewAddedProduct.Columns[4].Name = "Origin";


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
    }
}
