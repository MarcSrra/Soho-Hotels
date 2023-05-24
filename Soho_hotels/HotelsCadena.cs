using Soho_hotels.Models;
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
    public partial class HotelsCadena : Form
    {
        cadenas cadena;
        List<hoteles> hotels;

        public HotelsCadena(cadenas _cadena)
        {
            InitializeComponent();
            cadena = _cadena;
            hotels = _cadena.hoteles.ToList();
            bindingSourceHotCad.DataSource = hotels;
        }

        private void HotelsCadena_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            bindingSourceHotels.DataSource = Models.HotelsORM.Select();

            actualitzaGridHotCad();
        }

        private void actualitzaGridHotCad()
        {
            bindingSourceHotCad.ResetBindings(true);
            bindingSourceHotCad.DataSource = hotels;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            String missatge = "";
            ICollection<hoteles> IChotels = hotels;
            cadena.hoteles = IChotels;

            missatge = Models.CadenesORM.Update();
            MissatgeError(missatge);

            this.Close();
            this.Close();
        }

        private void buttonAfegir_Click(object sender, EventArgs e)
        {
            Boolean afegir = true;
            hoteles _hotel = (hoteles)dataGridViewHotels.CurrentRow.DataBoundItem;


            foreach (hoteles hotelcadena in hotels)
            {
                if (_hotel.id_ciudad == hotelcadena.id_ciudad && _hotel.nombre == hotelcadena.nombre)
                {
                    afegir = false;
                }
            }

            if (afegir)
            {              
                hotels.Add(_hotel);

                actualitzaGridHotCad();
            }
            else
            {
                DialogResult dr = MessageBox.Show("Errr al afegir l'hotel " + _hotel.nombre
                        + ", ja forma part de la cadena " + cadena.nombre + ".", "Afegir Hotel",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonTreure_Click(object sender, EventArgs e)
        {
            hoteles _hotel = (hoteles)dataGridViewHotelsCad.CurrentRow.DataBoundItem;

            DialogResult dr = MessageBox.Show("Segur que vols eliminar l''hotel " + _hotel.nombre + " de la cadena " + cadena.nombre + "?",
                            "Eliminar hotel", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                hotels.Remove(_hotel);
                actualitzaGridHotCad();
            }
        }

        private void MissatgeError(String missatge)
        {
            if (missatge != "")
            {
                MessageBox.Show(missatge, "Eliminar Hotel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
