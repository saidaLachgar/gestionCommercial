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
    public partial class consultationDevis : Form
    {
        ADO d = new ADO();

        public consultationDevis()
        {
            InitializeComponent();
        }
        public void Actualiser()
        {
            d.ds.Clear();
            d.da = new SqlDataAdapter("select * from DEVIS", d.cn);
            d.da.Fill(d.ds, "DEVIS");
            dataGridView1.DataSource = d.ds.Tables["DEVIS"];

        }
        private void consultationDevis_Load(object sender, EventArgs e)
        {
            Actualiser();
        }

        public void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Changer l'information que vous voulez et clique sur le bouton Modifier à droit","", MessageBoxButtons.OKCancel);
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }
        private void actualiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actualiser();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            d.Open();
            d.cmd = new SqlCommand("update DEVIS set IdClient=" + dataGridView1.CurrentRow.Cells[1].Value + ",DateDevis='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "',OBSERVATION='" + dataGridView1.CurrentRow.Cells[3].Value.ToString() + "' where NumDevis='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", d.cn);
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
                d.cmd = new SqlCommand("delete from DEVIS where NumDevis='" + dataGridView1.CurrentRow.Cells[0].Value + "'", d.cn);
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
