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
    public partial class frmImport : Form
    {
        public String sessionAccount = "";
        public String sessAccountPhone = "";
        public frmImport()
        {
            InitializeComponent();
        }

        private void frmImport_Load(object sender, EventArgs e)
        { 
            //this.reportViewer1.RefreshReport();
            initiateComponents();
            getImportID();
        }
        public void initiateComponents()
        {
            txtAccount.Enabled = false;
            txtImportID.Enabled = false;
            dateTimePickerImportCreated.Enabled = false;
        }
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
        public void getImportID()
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();

                String sSQL = "select importID from Import";
                SqlCommand cmd = new SqlCommand(sSQL, conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                List<String> importIDList = new List<String>();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        String temp = dt.Rows[i][0].ToString().Trim();
                        importIDList.Add(temp);
                    }
                    listBoxImportID.DataSource = importIDList;
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
        public void 
        public void getDetailDataFromImportID() { 

        }
    }
}
