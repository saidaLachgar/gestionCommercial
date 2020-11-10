using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestionCommercial
{
    public partial class CRP_Devis : Form
    {
        public CRP_Devis()
        {
            InitializeComponent();
        }
        private void CRP_Devis_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(@"Data Source =.\SQLEXPRESS ;Initial Catalog = gestcom; Integrated Security = True");
                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                da = new SqlDataAdapter("select * from DETAIL_DEVIS", cn);
                da.Fill(ds, "DETAIL_DEVIS");

                da = new SqlDataAdapter("select * from DEVIS", cn);
                da.Fill(ds, "DEVIS");

                CrystalReportDevis crp = new CrystalReportDevis();
                crystalReportViewer1.ReportSource = crp;
                crystalReportViewer1.Refresh();
                crp.SetDataSource(ds);//.Tables["nomtable"]

            }
            catch (Exception es)
            {

                MessageBox.Show(es.Message);
            }
        }
    }
}
