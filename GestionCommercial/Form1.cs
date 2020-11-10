using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using WMPLib;
using System.Runtime.InteropServices;

namespace GestionCommercial
{


    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        WindowsMediaPlayer pl = new WindowsMediaPlayer();
        int plx = 1;
        int pnx = 1;
        Form2 myForm2 = new Form2();
        Form3 myForm3 = new Form3();
        Form4 myForm4 = new Form4();
        Form5 myForm5 = new Form5();
        Form6 myForm6 = new Form6();
        public Form1()
        {
            InitializeComponent();
            pl.URL = "Beethoven Moonlight Sonata.mp3";         

        }

       

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            myForm2.TopLevel = false;
            myForm2.AutoScroll = true;
            panel2.Controls.Clear();
            panel2.Controls.Add(myForm2);
            if (pnx == 1)
            {
                myForm2.Location = new Point(77, 0);
            }
            if (pnx == 0)
            {
                myForm2.Location = new Point(0, 0);
            }
            myForm2.Show();


            Color Active = Color.FromArgb(37, 37, 38);
            bunifuFlatButton1.Normalcolor = Active;
            bunifuFlatButton2.Normalcolor = Color.Transparent;
            bunifuFlatButton3.Normalcolor = Color.Transparent;
            bunifuFlatButton4.Normalcolor = Color.Transparent;
            bunifuFlatButton5.Normalcolor = Color.Transparent;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            myForm3.TopLevel = false;
            myForm3.AutoScroll = true;
            panel2.Controls.Clear();
            panel2.Controls.Add(myForm3);
            if (pnx == 1)
            {
                myForm3.Location = new Point(77, 0);
            }
            if (pnx == 0)
            {
                myForm3.Location = new Point(0, 0);
            }
            myForm3.Show();


            
            Color Active = Color.FromArgb(37, 37, 38);
            bunifuFlatButton1.Normalcolor = Color.Transparent;
            bunifuFlatButton2.Normalcolor = Active;
            bunifuFlatButton3.Normalcolor = Color.Transparent;
            bunifuFlatButton4.Normalcolor = Color.Transparent;
            bunifuFlatButton5.Normalcolor = Color.Transparent;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            myForm4.TopLevel = false;
            myForm4.AutoScroll = true;
            panel2.Controls.Clear();
            panel2.Controls.Add(myForm4);
            if (pnx == 1)
            {
                myForm4.Location = new Point(77, 0);
            }
            if (pnx == 0)
            {
                myForm4.Location = new Point(0, 0);
            }
            myForm4.Show();


            
            Color Active = Color.FromArgb(37, 37, 38);
            bunifuFlatButton1.Normalcolor = Color.Transparent;
            bunifuFlatButton2.Normalcolor = Color.Transparent;
            bunifuFlatButton3.Normalcolor = Active;
            bunifuFlatButton4.Normalcolor = Color.Transparent;
            bunifuFlatButton5.Normalcolor = Color.Transparent;
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            myForm5.TopLevel = false;
            myForm5.AutoScroll = true;
            panel2.Controls.Clear();
            panel2.Controls.Add(myForm5);
            if (pnx == 1)
            {
                myForm5.Location = new Point(77, 0);
            }
            if (pnx == 0)
            {
                myForm5.Location = new Point(0, 0);
            }
            myForm5.Show();


            
            Color Active = Color.FromArgb(37, 37, 38);
            bunifuFlatButton1.Normalcolor = Color.Transparent;
            bunifuFlatButton2.Normalcolor = Color.Transparent;
            bunifuFlatButton3.Normalcolor = Color.Transparent;
            bunifuFlatButton4.Normalcolor = Active;
            bunifuFlatButton5.Normalcolor = Color.Transparent;
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            myForm6.TopLevel = false;
            myForm6.AutoScroll = true;
            panel2.Controls.Clear();
            panel2.Controls.Add(myForm6);
            if (pnx == 1)
            {
                myForm6.Location = new Point(77, 0);
            }
            if (pnx == 0)
            {
                myForm6.Location = new Point(0, 0);
            }
            myForm6.Show();


            
            Color Active = Color.FromArgb(37, 37, 38);
            bunifuFlatButton1.Normalcolor = Color.Transparent;
            bunifuFlatButton2.Normalcolor = Color.Transparent;
            bunifuFlatButton3.Normalcolor = Color.Transparent;
            bunifuFlatButton4.Normalcolor = Color.Transparent;
            bunifuFlatButton5.Normalcolor = Active;
        }

        private void bunifuImageButton2_MouseEnter(object sender, EventArgs e)
        {
            Color Active = Color.FromArgb(99, 217, 255);

            bunifuCustomLabel2.ForeColor = Active;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            bunifuFlatButton1.BackColor = Color.Transparent;
            bunifuFlatButton2.BackColor = Color.Transparent;
            bunifuFlatButton3.BackColor = Color.Transparent;
            bunifuFlatButton4.BackColor = Color.Transparent;
            bunifuFlatButton5.BackColor = Color.Transparent;
            bunifuFlatButton1.ForeColor = Color.White;
            bunifuFlatButton2.ForeColor = Color.White;
            bunifuFlatButton3.ForeColor = Color.White;
            bunifuFlatButton4.ForeColor = Color.White;
            bunifuFlatButton5.ForeColor = Color.White;
            panel2.Controls.Clear();
            bunifuCustomLabel1.Visible = false;
            panel6.Visible = false;
            panel2.Controls.Add(bunifuCustomLabel1);
            panel2.Controls.Add(panel6);
            bunifuTransition2.ShowSync(panel6);
            bunifuTransition2.ShowSync(bunifuCustomLabel1);
            
        }

        private void bunifuImageButton2_MouseLeave(object sender, EventArgs e)
        {
            bunifuCustomLabel2.ForeColor = Color.LightGray;
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton2_MouseHover(object sender, EventArgs e)
        {
            Color Notactive = Color.FromArgb(83, 83, 85);
            Color Active = Color.FromArgb(99, 217, 255);

            bunifuCustomLabel2.ForeColor = Active;
        }

        private void bunifuiOSSwitch1_OnValueChange(object sender, EventArgs e)
        {
            if (plx == 1) { pl.URL = ""; plx = 0; }
            else if (plx == 0) { pl.URL = "Beethoven Moonlight Sonata.mp3"; plx = 1; }
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Cyan;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.LightGray;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contact us , Xcore@outlook.fr !!!");
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            bunifuFlatButton1.BackColor = Color.Transparent;
            bunifuFlatButton2.BackColor = Color.Transparent;
            bunifuFlatButton3.BackColor = Color.Transparent;
            bunifuFlatButton4.BackColor = Color.Transparent;
            bunifuFlatButton5.BackColor = Color.Transparent;
            bunifuFlatButton1.ForeColor = Color.White;
            bunifuFlatButton2.ForeColor = Color.White;
            bunifuFlatButton3.ForeColor = Color.White;
            bunifuFlatButton4.ForeColor = Color.White;
            bunifuFlatButton5.ForeColor = Color.White;
            panel2.Controls.Clear();
            bunifuCustomLabel1.Visible = false;
            panel6.Visible = false;
            panel2.Controls.Add(bunifuCustomLabel1);
            panel2.Controls.Add(panel6);
            bunifuTransition2.ShowSync(panel6);
            bunifuTransition2.ShowSync(bunifuCustomLabel1);
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {


            if (pnx == 1)
            {
                panel5.Location = new Point(846, 0);
                panel1.Visible = false;
                panel6.Visible = false;
                ///////////////////
                myForm2.Location = new Point(0, 0);
                myForm3.Location = new Point(0, 0);
                myForm4.Location = new Point(0, 0);
                myForm5.Location = new Point(0, 0);
                myForm6.Location = new Point(0, 0);
                ///////////////////
                bunifuImageButton2.Visible = false;
                bunifuCustomLabel1.Visible = false;
                panel1.Size = new Size(204, 660);
                bunifuTransition1.ShowSync(panel1);


                ; pnx = 0;

                bunifuImageButton2.Size = new Size(130, 130);
                bunifuImageButton2.Location = new Point(37, 68);
                bunifuTransition2.ShowSync(bunifuImageButton2);

                
                bunifuCustomLabel1.Location = new Point(340, 189);
                panel6.Location = new Point(62, 308);
                bunifuTransition2.ShowSync(panel6);
                bunifuTransition2.ShowSync(bunifuCustomLabel1);

                
            }
            else if (pnx == 0)
            {
                panel5.Location = new Point(998, 0);
                panel1.Visible = false;
                panel6.Visible = false;
                ///////////////////
                myForm2.Location = new Point(77, 0);
                myForm3.Location = new Point(77, 0);
                myForm4.Location = new Point(77, 0);
                myForm5.Location = new Point(77, 0);
                myForm6.Location = new Point(77, 0);
                ///////////////////
                bunifuImageButton2.Visible = false;
                bunifuCustomLabel1.Visible = false;
                panel1.Size = new Size(52, 660);
                bunifuTransition1.ShowSync(panel1);



                ; pnx = 1;

                bunifuImageButton2.Size = new Size(38, 41);
                bunifuImageButton2.Location = new Point(7, 130);
                bunifuTransition2.ShowSync(bunifuImageButton2);

                
                bunifuCustomLabel1.Location = new Point(416, 189);
                panel6.Location = new Point(141, 308);
                bunifuTransition2.ShowSync(panel6);
                bunifuTransition2.ShowSync(bunifuCustomLabel1);
            }
        }

       


        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            Color myRgbColor = Color.FromArgb(253, 84, 28);
            panel1.BackColor = myRgbColor;
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Teal;
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Gray;
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Olive;
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            myForm2.TopLevel = false;
            myForm2.AutoScroll = true;
            panel2.Controls.Clear();
            panel2.Controls.Add(myForm2);
            if (pnx == 1)
            {
                myForm2.Location = new Point(77, 0);
            }
            if (pnx == 0)
            {
                myForm2.Location = new Point(0, 0);
            }
            myForm2.Show();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            myForm3.TopLevel = false;
            myForm3.AutoScroll = true;
            panel2.Controls.Clear();
            panel2.Controls.Add(myForm3);
            if (pnx == 1)
            {
                myForm3.Location = new Point(77, 0);
            }
            if (pnx == 0)
            {
                myForm3.Location = new Point(0, 0);
            }
            myForm3.Show();

        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            myForm4.TopLevel = false;
            myForm4.AutoScroll = true;
            panel2.Controls.Clear();
            panel2.Controls.Add(myForm4);
            if (pnx == 1)
            {
                myForm4.Location = new Point(77, 0);
            }
            if (pnx == 0)
            {
                myForm4.Location = new Point(0, 0);
            }
            myForm4.Show();

        }

        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            myForm5.TopLevel = false;
            myForm5.AutoScroll = true;
            panel2.Controls.Clear();
            panel2.Controls.Add(myForm5);
            if (pnx == 1)
            {
                myForm5.Location = new Point(77, 0);
            }
            if (pnx == 0)
            {
                myForm5.Location = new Point(0, 0);
            }
            myForm5.Show();

        }

        private void bunifuTileButton5_Click(object sender, EventArgs e)
        {
            myForm6.TopLevel = false;
            myForm6.AutoScroll = true;
            panel2.Controls.Clear();
            panel2.Controls.Add(myForm6);
            if (pnx == 1)
            {
                myForm6.Location = new Point(77, 0);
            }
            if (pnx == 0)
            {
                myForm6.Location = new Point(0, 0);
            }
            myForm6.Show();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
