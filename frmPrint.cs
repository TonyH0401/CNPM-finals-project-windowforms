﻿using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finals_Project
{
    public partial class frmPrint : Form
    {
        //DataTable dt = new DataTable();
        List<Product> _products = new List<Product>();
        String _total, _quantity, _importID, _created, _account;
        public frmPrint(List<Product> dataSource, string total, string quantity, string importID, string created, string account)
        {
            InitializeComponent();
            _products = dataSource;
            _total = total;
            _quantity = quantity;
            _importID = importID;
            _created = created;
            _account = account;
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            //List<Product> _product = new List<Product>();
            //foreach(DataRow row in dt.Rows)
            //{
            //    //Product product = new Product(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
            //    Product product = new Product();
            //    product.id = row[0].ToString();
            //    product.name = row[1].ToString();
            //    product.price = row[2].ToString();
            //    product.quantity = row[3].ToString();
            //    product.origin = row[4].ToString();
            //    _product.Add(product);
            //}
            //this.reportViewer1.LocalReport.DataSources.Clear();
            //ReportDataSource rds = new ReportDataSource("Products", dt);
            //MessageBox.Show(dt.Rows.Count.ToString());
            //this.reportViewer1.LocalReport.DataSources.Add(rds);
            //this.reportViewer1.LocalReport.Refresh();

            //remember to name the dataset the same as the dataset model, and the rds should have the same string name
            ReportDataSource rds = new ReportDataSource("Product", _products);
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Finals_Project.Report1.rdlc";
            reportViewer1.Dock = DockStyle.Fill;
            this.Controls.Add(reportViewer1);
            reportViewer1.RefreshReport();

            Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("pImportID", _importID),
                new Microsoft.Reporting.WinForms.ReportParameter("pImportAccountID", _account),
                new Microsoft.Reporting.WinForms.ReportParameter("pImportCreated", _created),
                new Microsoft.Reporting.WinForms.ReportParameter("pImportTotalProduct", _quantity),
                new Microsoft.Reporting.WinForms.ReportParameter("pImportTotalPrice", _total)
            };
            this.reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.RefreshReport();
        }
    }
}
