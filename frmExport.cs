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
        public void getDataFromExportID()
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select exportID, exportTotalPrice, exportCreated, exportStatus, accountID , paymentID from Import where importID = @importID";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@importID", listBoxImportID.SelectedValue.ToString().Trim());
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtImportID.Text = dt.Rows[0][0].ToString().Trim();
                    txtTotal.Text = dt.Rows[0][1].ToString().Trim();
                    dateTimePickerImportCreated.Text = dt.Rows[0][2].ToString().Trim();
                    txtAccount.Text = dt.Rows[0][3].ToString().Trim();
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
    }
}
