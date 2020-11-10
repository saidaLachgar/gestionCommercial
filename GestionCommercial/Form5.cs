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
    public partial class Form5 : Form
    {
        ADO d = new ADO();

        public Form5()
        {
            InitializeComponent();
            Actualiser();
            bunifuMetroTextbox1.Text = (A() + 1).ToString();
        }
        public int A()
        {
            int count;
            string Num;
            d.Open();
            d.cmd = new SqlCommand("SELECT MAX(NumBL) FROM BL", d.cn);
            if (d.cmd.ExecuteScalar().Equals(DBNull.Value))
            {
                count = 1;
                d.Close();
                return count;
            }
            Num = (string)d.cmd.ExecuteScalar();

            var SPlitedNUm = Num.Split('/');
            Num = SPlitedNUm[0];
            count = Convert.ToInt32(Num) + 1;
            d.Close();
            return count;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
        }
        public void Actualiser()
        {
            //REMPLISSAGE DataGrid
            d.ds.Clear();
            d.da = new SqlDataAdapter("select * from DETAIL_BL", d.cn);
            d.da.Fill(d.ds, "DETAIL_BL");
            dataGridView1.DataSource = d.ds.Tables["DETAIL_BL"];

            //REMPLISSAGE cmbx1   
            d.Open();
            d.cmd = new SqlCommand("select * from CLIENTS", d.cn);
            d.dr = d.cmd.ExecuteReader();
            while (d.dr.Read())
            {
                comboBox1.Items.Add(d.dr[0].ToString());
            }
            d.dr.Close();
            d.Close();

            //REMPLISSAGE cmbx2 
            d.Open();
            d.cmd = new SqlCommand("select * from ARTICLES", d.cn);
            d.dr = d.cmd.ExecuteReader();
            while (d.dr.Read())
            {
                comboBox2.Items.Add(d.dr[0].ToString());
            }
            d.dr.Close();
            d.Close();

            //REMPLISSAGE cmbx3 
            d.Open();
            d.cmd = new SqlCommand("select * from BL", d.cn);
            d.dr = d.cmd.ExecuteReader();
            while (d.dr.Read())
            {
                comboBox3.Items.Add(d.dr[0].ToString());
            }
            d.dr.Close();
            d.Close();
        }
        public void VIDER(Control f)//Vider TextBox
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            bunifuMetroTextbox3.Text = "";
            bunifuMetroTextbox4.Text = "";
            bunifuMetroTextbox5.Text = "";
            bunifuMetroTextbox2.Text = "";

        }
        decimal PT_TTC_Calc(string Ref)
        {
            // retrive tva from articles
           
            d.Open();
            d.cmd = new SqlCommand("select TxTVA from articles where ref = '" + Ref + "'", d.cn);
            decimal tva = (decimal)d.cmd.ExecuteScalar();
            d.Close();
            // calculate pt_ht
            decimal pt_ht = (Decimal.Parse(bunifuMetroTextbox3.Text) - (Decimal.Parse(bunifuMetroTextbox3.Text) * Decimal.Parse(bunifuMetroTextbox4.Text))) * int.Parse(bunifuMetroTextbox5.Text);
            //calculate pt_ttc
            decimal pt_ttc = (pt_ht + (pt_ht * tva));

            return Convert.ToInt32(pt_ttc);
        }
        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            if (bunifuFlatButton6.Text == "Ajouter")
            {
                decimal pt_ttc = PT_TTC_Calc(comboBox2.Text);

                d.Open();
                d.cmd = new SqlCommand("insert into DETAIL_BL (REF,NumBL,QTE,PRIX_VENTEHT,TxRemise,PT_TTC) values('" + comboBox2.Text + "','" + comboBox3.Text + "'," + bunifuMetroTextbox5.Text + "," + bunifuMetroTextbox3.Text +",@txR," + pt_ttc + ")", d.cn);
                d.cmd.Parameters.AddWithValue("@txR", Convert.ToDecimal(bunifuMetroTextbox4.Text));
                d.cmd.ExecuteNonQuery();
                d.Close();
            }
            else if (bunifuFlatButton6.Text == "Modifier")
            {
                d.Open();
                d.cmd = new SqlCommand("update DETAIL_BL set  NumBL='" + comboBox3.Text + "',REF='" + comboBox2.Text + "',QTE=" + bunifuMetroTextbox5.Text + ",Prix_VenteHT=" + bunifuMetroTextbox3.Text + ",TxRemise=" + bunifuMetroTextbox4.Text + "where NumBL='" + comboBox3.Text + "'", d.cn);
                d.cmd.ExecuteNonQuery();
                MessageBox.Show("Modifier avec succés!");
                d.Close();
                bunifuFlatButton6.Text = "Ajouter";
            }
            d.ds.Clear();
            d.da = new SqlDataAdapter("select * from DETAIL_BL", d.cn);
            d.da.Fill(d.ds, "DETAIL_BL");
            dataGridView1.DataSource = d.ds.Tables["DETAIL_BL"];

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            bunifuFlatButton5.Visible = true;
            bunifuFlatButton6.Text = "Modifier";
            comboBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            bunifuMetroTextbox5.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            bunifuMetroTextbox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            bunifuMetroTextbox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //insert BL
                d.Open();
                d.cmd = new SqlCommand("insert into BL values('" + bunifuMetroTextbox1.Text + "'," + comboBox1.Text + ",'" + bunifuDatepicker1.Text + "','" + bunifuMetroTextbox2.Text + "')", d.cn);
                d.cmd.ExecuteNonQuery();
                d.Close();
                MessageBox.Show("insertion avec succés!");
                Actualiser();
                VIDER(this);
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }

        }

        private void bunifuMetroTextbox6_OnValueChanged(object sender, EventArgs e)
        {
            d.cmd = new SqlCommand("select * from DETAIL_BL where REF like '% " + bunifuMetroTextbox6.Text + "%'", d.cn);
            d.dr = d.cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(d.dr);
            dataGridView1.DataSource = dt;
            d.dr.Close();

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to Delete it!", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    d.Open();
                    d.cmd = new SqlCommand("delete from DETAIL_BL where NumBL='" + dataGridView1.CurrentRow.Cells[1].Value + "'", d.cn);
                    d.cmd.ExecuteNonQuery();
                    d.Close();
                    //datagrid actualiser
                    d.ds.Clear();
                    d.da = new SqlDataAdapter("select * from DETAIL_DEVIS", d.cn);
                    d.da.Fill(d.ds, "DETAIL_DEVIS");
                    dataGridView1.DataSource = d.ds.Tables["DETAIL_DEVIS"];
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);

                }
            }
        }
        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            VIDER(this);
            bunifuFlatButton5.Visible = false;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            CRP_BL BL = new CRP_BL();
            BL.ShowDialog();

        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            ConsultationBL conBL = new ConsultationBL();
            conBL.ShowDialog();

        }
    }
}

