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
    public partial class Form3 : Form
    {
        ADO d = new ADO();
        string idf;
        public Form3()
        {
            InitializeComponent();
            initial();
            // Remplassage de Combo Box 
            d.Open();
            d.cmd = new SqlCommand("select * from FAMILLES", d.cn);
            d.dr = d.cmd.ExecuteReader();
            while (d.dr.Read())
            {
                comboBox1.Items.Add(d.dr[1].ToString());
            }
            d.dr.Close();
        }
        public void initial()
        {
            d.Open();
            // Remplassage data Grid View 
            d.ds.Clear();
            //dataGridView1.DataSource = ds.Tables["ARTICLES"];
            d.da = new SqlDataAdapter("select * from ARTICLES", d.cn);
            d.da.Fill(d.ds, "ARTICLES");
            dataGridView1.DataSource = d.ds.Tables["ARTICLES"];
            d.Close();
            bunifuMetroTextbox1.Text = "";
            comboBox1.Text = "";
            bunifuMetroTextbox6.Text = "";
            bunifuMetroTextbox3.Text = "";
            bunifuMetroTextbox2.Text = "";
            bunifuMetroTextbox5.Text = "";
            bunifuMetroTextbox4.Text = "";
            
        }
        public void remplire()
        {
            bunifuMetroTextbox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            bunifuMetroTextbox6.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            bunifuMetroTextbox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            bunifuMetroTextbox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            bunifuMetroTextbox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            bunifuMetroTextbox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                d.Open();
                d.cmd = new SqlCommand("select * from FAMILLES where famille='" + comboBox1.Text + "'", d.cn);
                d.dr = d.cmd.ExecuteReader();
                while (d.dr.Read()) { idf = d.dr["idFamille"].ToString(); }
                d.Close();
                d.Open();
                d.cmd = new SqlCommand("insert into ARTICLES values('" + bunifuMetroTextbox1.Text + "'," + int.Parse(idf) + ",'" + bunifuMetroTextbox6.Text + "'," + bunifuMetroTextbox3.Text + "," + bunifuMetroTextbox2.Text + "," + bunifuMetroTextbox5.Text + "," + bunifuMetroTextbox4.Text + ")", d.cn);
                d.cmd.ExecuteNonQuery();
                d.Close();
                initial();
            }
            catch (Exception es )
            {

                MessageBox.Show(es.Message);
            }
            
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to Delete it!", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                d.Open();
                d.cmd = new SqlCommand("delete from ARTICLES where REF='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", d.cn);
                d.cmd.ExecuteNonQuery();
                d.Close();
            }
            initial();
        }
        int p = 0;
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (p == 1)
                {
                    d.Open();
                    d.cmd = new SqlCommand("update ARTICLES set IdFamille=" + comboBox1.Text + ",Description='" + bunifuMetroTextbox6.Text + "',PU_ACHAT=" + bunifuMetroTextbox3.Text + ",PU_VENTE=" + bunifuMetroTextbox2.Text + ",QTE_STOCK=" + bunifuMetroTextbox5.Text + ",TxTVA=" + bunifuMetroTextbox4.Text + " where REF='" + bunifuMetroTextbox1.Text + "'", d.cn);
                    d.cmd.ExecuteNonQuery();
                    d.Close();
                    p = 0;
                }
                else if (p == 0)
                {
                    remplire();
                    p = 1;
                }
                // Remplassage data Grid View 
                d.ds.Clear();
                dataGridView1.DataSource = d.ds.Tables["ARTICLES"];
                d.da = new SqlDataAdapter("select * from ARTICLES", d.cn);
                d.da.Fill(d.ds, "ARTICLES");
                dataGridView1.DataSource = d.ds.Tables["ARTICLES"];
                d.Close();

            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            bunifuMetroTextbox1.Text = "";
            comboBox1.Text = "";
            bunifuMetroTextbox6.Text = "";
            bunifuMetroTextbox3.Text = "";
            bunifuMetroTextbox2.Text = "";
            bunifuMetroTextbox5.Text = "";
            bunifuMetroTextbox4.Text = "";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
           
        }
    }
}

    

    

