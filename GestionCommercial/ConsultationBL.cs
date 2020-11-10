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
    public partial class ConsultationBL : Form
    {
        ADO d = new ADO();
        public ConsultationBL()
        {
            InitializeComponent();
        }
        public void Actualiser()
        {
            d.ds.Clear();
            d.da = new SqlDataAdapter("select * from BL", d.cn);
            d.da.Fill(d.ds, "BL");
            dataGridView1.DataSource = d.ds.Tables["BL"];
        }

        private void ConsultationBL_Load(object sender, EventArgs e)
        {
            Actualiser();
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Changer l'information que vous voulez et clique sur le bouton Modifier à droit", "", MessageBoxButtons.OKCancel);
        }

        private void actualisierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actualiser();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            d.Open();
            d.cmd = new SqlCommand("update BL set IdClient=" + dataGridView1.CurrentRow.Cells[1].Value + ",DateBL='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "',OBSERVATION='" + dataGridView1.CurrentRow.Cells[3].Value.ToString() + "' where NumBL='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", d.cn);
            d.cmd.ExecuteNonQuery();
            Actualiser();
            d.Close();
            MessageBox.Show("Modifier avec succés!");
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                d.Open();
                d.cmd = new SqlCommand("delete from BL where NumBL='" + dataGridView1.CurrentRow.Cells[0].Value + "'", d.cn);
                d.cmd.ExecuteNonQuery();
                d.Close();
                Actualiser();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);

            }

        }
    }
}
