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
    public partial class Form4 : Form
    {
        ADO d = new ADO();
        public Form4()
        {
            InitializeComponent();
        }
        public void initial()
        {
            // Vider les TextBoxes
            bunifuMetroTextbox1.Text = "";
            bunifuMetroTextbox2.Text = "";
            bunifuMetroTextbox3.Text = "";
            bunifuMetroTextbox4.Text = "";
            bunifuMetroTextbox5.Text = "";
            // Remplasage Data Grid View 
            d.ds.Clear();
            bunifuCustomDataGrid1.DataSource = d.ds.Tables["CLIENTS"];
            d.da = new SqlDataAdapter("select * from CLIENTS", d.cn);
            d.da.Fill(d.ds, "CLIENTS");
            bunifuCustomDataGrid1.DataSource = d.ds.Tables["CLIENTS"];
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (bunifuFlatButton1.Text == "Ajouter")
                {                                       
                    if(bunifuMetroTextbox1.Text == "" || bunifuMetroTextbox2.Text == "" ||bunifuMetroTextbox3.Text == "" ||bunifuMetroTextbox4.Text == "" || bunifuMetroTextbox5.Text == "" )
                    {
                        MessageBox.Show("Fill All Fildes!","Attention",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    else
                    {
                        d.Open();
                        d.cmd = new SqlCommand("insert into CLIENTS values(" + bunifuMetroTextbox1.Text + ",'" + bunifuMetroTextbox2.Text + "','" + bunifuMetroTextbox5.Text + "','" + bunifuMetroTextbox3.Text + "','" + bunifuMetroTextbox4.Text + "')", d.cn);
                        d.cmd.ExecuteNonQuery();
                        initial();
                        d.Close();
                    }
                    
                }
                else if (bunifuFlatButton1.Text == "Modifier")
                {
                    d.Open();
                    d.cmd = new SqlCommand("update CLIENTS set RaisonSocial='" + bunifuMetroTextbox2.Text + "',Adresse='" + bunifuMetroTextbox5.Text + "',Ville='" + bunifuMetroTextbox3.Text + "',TEL='" + bunifuMetroTextbox4.Text + "' where IdClient=" + bunifuMetroTextbox1.Text, d.cn);
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
            bunifuMetroTextbox1.Text = bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString();
            bunifuMetroTextbox2.Text = bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString();
            bunifuMetroTextbox5.Text = bunifuCustomDataGrid1.CurrentRow.Cells[2].Value.ToString();
            bunifuMetroTextbox3.Text = bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString();
            bunifuMetroTextbox4.Text = bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString();
            d.Open();
            bunifuFlatButton1.Text = "Modifier";
            d.Close();

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to delete it!", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                d.Open();
                d.cmd = new SqlCommand("delete from CLIENTS where IdClient='" + bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString() + "'", d.cn);
                d.cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted !");
                d.Close();
                initial();
            }
        }


        private void Form4_Load(object sender, EventArgs e)
        {
            initial();           
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            bunifuMetroTextbox1.Text = "";
            bunifuMetroTextbox2.Text = "";
            bunifuMetroTextbox3.Text = "";
            bunifuMetroTextbox4.Text = "";
            bunifuMetroTextbox5.Text = "";
        }
    }
}
