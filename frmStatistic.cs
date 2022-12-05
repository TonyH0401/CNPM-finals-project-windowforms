using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finals_Project
{
    public partial class frmStatistic : Form
    {
        public frmStatistic()
        {
            InitializeComponent();
        }

        private void frmStatistic_Load(object sender, EventArgs e)
        {
            initiateComponents();
        }
        public void initiateComponents()
        {
            dateTimePickerCurrentTime.Value = DateTime.Now;
            dateTimePickerCurrentTime.Enabled = false;

            dateTimePickerImportExportBill.Format = DateTimePickerFormat.Custom;
            dateTimePickerImportExportBill.CustomFormat = "MM/yyyy";

            txtbxImportValue.ReadOnly = true;
            txtbxExportValue.ReadOnly = true;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            String dayMonthYear = dateTimePickerImportExportBill.Value.ToString("yyyy-MM-dd").Trim();
            int month = Int32.Parse(dayMonthYear.Split('-')[1]);
            //MessageBox.Show(month);
            txtbxExportValue.Text = getTotalPriceByMonthExport(month).ToString().Trim();
            txtbxImportValue.Text = getTotalPriceByMonthImport(month).ToString().Trim();
        }
        public double getTotalPriceByMonthExport(int month)
        {
            double sum = 0;
            SqlConnection conn = new SqlConnection(Program.strConn);
            conn.Open();
            String sSQL = "select exportTotalPrice from Export where MONTH(exportCreated) = @month";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@month", month);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    double temp = double.Parse(dr[0].ToString());
                    sum = sum + temp;
                }
            }
            else
            {
                MessageBox.Show("No Export Data for: " +month, "Warning");
            }
            return sum;
        }
        public double getTotalPriceByMonthImport(int month)
        {
            double sum = 0;
            SqlConnection conn = new SqlConnection(Program.strConn);
            conn.Open();
            String sSQL = "select importTotalPrice from Import where MONTH(importCreated) = @month";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.AddWithValue("@month", month);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    double temp = double.Parse(dr[0].ToString());
                    sum = sum + temp;
                }
            }
            else
            {
                MessageBox.Show("No Import Data for: " + month, "Warning");
            }
            return sum;
        }
    }
}
