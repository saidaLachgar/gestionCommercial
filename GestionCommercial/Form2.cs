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
    public partial class Form2 : Form
    {
        ADO d = new ADO();
        public Form2()
        {
            InitializeComponent();
        }
        public void initial()
        {
            // Data Grid View 
            d.ds.Clear();
            //dataGridView1.DataSource = d.ds.Tables["FAMILLES"];
            d.da = new SqlDataAdapter("select * from FAMILLES", d.cn);
            d.da.Fill(d.ds, "FAMILLES");
            dataGridView1.DataSource = d.ds.Tables["FAMILLES"];
            bunifuMetroTextbox1.Text = ""; 
            bunifuMetroTextbox2.Text = "";
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (bunifuFlatButton1.Text == "Ajouter")
                {
                    d.Open();
                    d.cmd = new SqlCommand("insert into FAMILLES values(" + bunifuMetroTextbox1.Text + ",'" + bunifuMetroTextbox2.Text + "')", d.cn);
                    d.cmd.ExecuteNonQuery();
                    initial();
                    d.Close();

                }
                else if (bunifuFlatButton1.Text == "Modifier")
                {
                    d.Open();
                    d.cmd = new SqlCommand("update FAMILLES set Famille='" + bunifuMetroTextbox2.Text + "' where idFamille=" + bunifuMetroTextbox1.Text, d.cn);
                    d.cmd.ExecuteNonQuery();                    
                    initial();
                    d.Close();
                    bunifuFlatButton1.Text = "Ajouter";
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            bunifuMetroTextbox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            bunifuMetroTextbox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            bunifuFlatButton1.Text = "Modifier";
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to Delete it!", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    d.Open();
                    d.cmd = new SqlCommand("delete from FAMILLES where idFamille=" + dataGridView1.CurrentRow.Cells[0].Value.ToString(), d.cn);
                    d.cmd.ExecuteNonQuery();
                    d.Close();
                    initial();
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            initial();
        }
    }
}
