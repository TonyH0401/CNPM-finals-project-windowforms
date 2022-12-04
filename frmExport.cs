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
    public partial class frmExport : Form
    {
        private String sessionAccount = "";
        private String sessAccountPhone = "";
        public frmExport()
        {
            InitializeComponent();
        }

        private void frmExport_Load(object sender, EventArgs e)
        {
            initiateComponents();
            getSessionUserData();
            getExportIDList();
        }
        public void initiateComponents()
        {
            txtAccount.ReadOnly = true;
            txtExportID.ReadOnly = true;
            txtbxStoreID.ReadOnly = true;
            txtbxExportStatus.ReadOnly = true;
            dateTimePickerExportCreated.Enabled = false;
            txtbxPaymentMethod.ReadOnly = true;
            txtTotal.ReadOnly = true;
        }
        //done
        public String getSessionUserDataFromProgram()
        {
            String value0 = Program.sessionAccount;
            if (value0.Length == 0)
            {
                return "admin";
            }
            else
            {
                return value0;
            }
        }
        //done
        public void getSessionUserData()
        {
            SqlConnection conn = new SqlConnection(Program.strConn);
            conn.Open();

            String sSQL = "select accountID, accountPhone from Account where accountID=@accountID";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@accountID", getSessionUserDataFromProgram().Trim());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                String sessionID = (String)dt.Rows[0][0];
                String sessionPhone = (String)dt.Rows[0][1];
                sessionAccount = sessionID;
                sessAccountPhone = sessionPhone;
            }
            else
            {
                MessageBox.Show("Invalid Login. Please check Username or Password!", "Warning");
            }
        }
        //done
        public void getExportIDList()
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();

                String sSQL = "select exportID from Export";
                SqlCommand cmd = new SqlCommand(sSQL, conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                List<String> exportIDList = new List<String>();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        String temp = dt.Rows[i][0].ToString().Trim();
                        exportIDList.Add(temp);
                    }
                    listBoxExportID.DataSource = exportIDList;
                }
                else
                {
                    MessageBox.Show("No Data", "Warning");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //done
        public void getDataFromExportID()
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select exportID, exportTotalPrice, exportCreated, exportStatus, accountID, paymentID, storeID from Export where exportID = @exportID";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@exportID", listBoxExportID.SelectedValue.ToString().Trim());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtExportID.Text = dt.Rows[0][0].ToString().Trim();
                    txtTotal.Text = dt.Rows[0][1].ToString().Trim();
                    dateTimePickerExportCreated.Text = dt.Rows[0][2].ToString().Trim();
                    getExportStatus(dt.Rows[0][3].ToString().Trim());
                    txtAccount.Text = dt.Rows[0][4].ToString().Trim();
                    getExportPaymentMethodName(dt.Rows[0][5].ToString().Trim());
                    txtbxStoreID.Text = dt.Rows[0][6].ToString().Trim();
                }
                else
                {
                    MessageBox.Show("No Data", "Warning");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //done
        public void getExportStatus(String exportStatusValue)
        {
            if (exportStatusValue.Equals("0") == true)
            {
                txtbxExportStatus.Text = "Delivering";
                txtbxExportStatus.ForeColor = Color.Red;
            }
            else if (exportStatusValue.Equals("1") == true)
            {
                txtbxExportStatus.Text = "Received";
                txtbxExportStatus.ForeColor = Color.Green;
            } 
            else
            {
                MessageBox.Show("Invalid Export Status Code", "Warning");
            }
            //remember to update database if anything
        }
        //done
        public void getExportPaymentMethodName(String exportPaymentID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select paymentName from PaymentMethod where paymentID = @paymentID";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@paymentID", exportPaymentID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtbxPaymentMethod.Text = dt.Rows[0][0].ToString().Trim();
                }
                else
                {
                    MessageBox.Show("No data in Payment Method", "Warning");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //
        public void getDetailDataFromExportID()
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();

                String sSQL = "select productID, productName, productPrice, productQuantity, productOrigin from ExportDetail where exportID = @exportID";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@exportID", listBoxExportID.SelectedValue.ToString().Trim());

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridViewExportDetail.DataSource = dt;
                    //be used in ReportViewer
                    //dtProduct = dt;
                    //dtProductTotal = dt.Rows.Count.ToString().Trim();
                }
                else
                {
                    MessageBox.Show("No Data", "Warning");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //done
        private void listBoxExportID_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDataFromExportID();
            getDetailDataFromExportID();
        }
        //done
        private void btnNewExport_Click(object sender, EventArgs e)
        {
            frmAddProductExport frmAddProductExport = new frmAddProductExport();
            frmAddProductExport.ShowDialog();
        }
        //done
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.frmExport_Load(null, EventArgs.Empty);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //1.change the status
            //2.update quantity in db
            //3.disable the button forever, this should also be done for loading and index change
        }
    }
}
