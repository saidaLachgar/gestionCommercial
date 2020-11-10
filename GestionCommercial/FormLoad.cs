using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionCommercial
{
    public partial class FormLoad : Form
    {
        public FormLoad()
        {
            InitializeComponent();
        }

        private void FormLoad_Load(object sender, EventArgs e)
        {
            bunifuCircleProgressbar1.Value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bunifuCircleProgressbar1.Value += 1;
            if (bunifuCircleProgressbar1.Value == 100)
            {

                Form1 fr = new Form1();
                fr.Show();
                this.Hide();
                timer1.Enabled = false;
                
            }
        }
    }
}
