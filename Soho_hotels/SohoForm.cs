using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soho_hotels
{
    public partial class SohoForm : Form
    {
        Boolean changecolorhotel = true, changecolorcadena = true;

        public SohoForm()
        {
            InitializeComponent();
        }

        private void SohoForm_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void btnhotels_MouseEnter(object sender, EventArgs e)
        {
            if (changecolorhotel)
            {
                btnhotels.BackColor = Color.FromArgb(54, 93, 108);
                btnhotels.ForeColor = Color.FromArgb(241, 241, 241);
            }
        }

        private void btnhotels_MouseLeave(object sender, EventArgs e)
        {
            if (changecolorhotel)
            {
                btnhotels.BackColor = Color.FromArgb(241, 241, 241);
                btnhotels.ForeColor = Color.FromArgb(54, 93, 108);
            }           
        }

        private void btncadenes_MouseEnter(object sender, EventArgs e)
        {
            if (changecolorcadena)
            {
                btncadenes.BackColor = Color.FromArgb(54, 93, 108);
                btncadenes.ForeColor = Color.FromArgb(241, 241, 241);
            }
        }

        private void btncadenes_MouseLeave(object sender, EventArgs e)
        {
            if (changecolorcadena)
            {
                btncadenes.BackColor = Color.FromArgb(241, 241, 241);
                btncadenes.ForeColor = Color.FromArgb(54, 93, 108);
            }
        }

        private void btnhotels_Click(object sender, EventArgs e)
        {
            changecolorcadena = true;
            btncadenes.BackColor = Color.FromArgb(241, 241, 241);
            btncadenes.ForeColor = Color.FromArgb(54, 93, 108);
            changecolorhotel = false;
            btnhotels.BackColor = Color.FromArgb(54, 93, 108);
            btnhotels.ForeColor = Color.FromArgb(241, 241, 241);

            GestioHotels hotels = new GestioHotels() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panelform.Controls.Clear();
            this.panelform.Controls.Add(hotels);
            hotels.FormBorderStyle = FormBorderStyle.None;
            hotels.Show();

        }


        private void btncadenes_Click(object sender, EventArgs e)
        {
            changecolorhotel = true;
            btnhotels.BackColor = Color.FromArgb(241, 241, 241);
            btnhotels.ForeColor = Color.FromArgb(54, 93, 108);
            changecolorcadena = false;
            btncadenes.BackColor = Color.FromArgb(54, 93, 108);
            btncadenes.ForeColor = Color.FromArgb(241, 241, 241);
            GestioCadenes cadenes = new GestioCadenes() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panelform.Controls.Clear();
            this.panelform.Controls.Add(cadenes);
            cadenes.FormBorderStyle = FormBorderStyle.None;
            cadenes.Show();

        }
    }
}
