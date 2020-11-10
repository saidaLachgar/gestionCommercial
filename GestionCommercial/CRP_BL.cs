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
    public partial class CRP_BL : Form
    {
        public CRP_BL()
        {
            InitializeComponent();
        }

        private void CRP_BL_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(@"Data Source =.\SQLEXPRESS ;Initial Catalog = gestcom; Integrated Security = True");
                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                da = new SqlDataAdapter("select * from DETAIL_BL", cn);
                da.Fill(ds, "DETAIL_BL");

                da = new SqlDataAdapter("select * from BL", cn);
                da.Fill(ds, "BL");

                CrystalReportBL crpBL = new CrystalReportBL();
                crystalReportViewer1.ReportSource = crpBL;
                crystalReportViewer1.Refresh();
                crpBL.SetDataSource(ds);//.Tables["nomtable"]

            }
            catch (Exception es)
            {

                MessageBox.Show(es.Message);
            }

        }
    }
}
