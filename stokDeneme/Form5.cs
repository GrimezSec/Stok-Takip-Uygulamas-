using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace stokDeneme
{
    public partial class Form5 : Form
    {

        private int targetPanelWidth = 528;
        public Form5()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 16;
            if (panel2.Width >= targetPanelWidth)
            {
                timer1.Stop();

                // Açılış ekranı tamamlandığında ana formu göster ve bu açılış ekranını kapat
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();

            }
        }
    }
}
