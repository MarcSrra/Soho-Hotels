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
    public partial class GestioHotels : Form
    {
        public GestioHotels()
        {
            InitializeComponent();
        }

        private void GestioHotels_Load(object sender, EventArgs e)
        {
            Actualitzardatagrid();
            bindingSourceCadenes.DataSource = Models.CadenesORM.Select();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Actualitzardatagrid();
        }

        private void checkBoxCadena_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCadena.Checked)
            {
                comboBoxCadena.Enabled = true;
            }
            else
            {
                comboBoxCadena.Enabled = false;
            }

            Actualitzardatagrid();
        }

        private void comboBoxCadena_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCadena.SelectedItem != null)
            {
                Actualitzardatagrid();
            }
        }

        private void Actualitzardatagrid()
        {
            cadenas cadena = (cadenas)comboBoxCadena.SelectedItem;

            if (textBoxNom.Text == "" && checkBoxCadena.Checked) //Cadena
            {
                bindingSourceHotels.DataSource = Models.HotelsORM.SelectByCadena(cadena.cif);
            }
            else if (textBoxNom.Text != "" && checkBoxCadena.Checked) //Cadena i Nom
            {
                bindingSourceHotels.DataSource = Models.HotelsORM.SelectByNomCadena(textBoxNom.Text, cadena.cif);
            }
            else if (textBoxNom.Text != "" && !checkBoxCadena.Checked) //Nom
            {
                bindingSourceHotels.DataSource = Models.HotelsORM.SelectByNom(textBoxNom.Text);
            }
            else //Res
            {
                bindingSourceHotels.DataSource = Models.HotelsORM.Select();
            }
        }

        private void buttonNou_Click(object sender, EventArgs e)
        {
            Panel panel = (Panel)this.Parent;
            FormHotel hotel = new FormHotel(true) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            panel.Controls.Clear();
            panel.Controls.Add(hotel);
            hotel.FormBorderStyle = FormBorderStyle.None;
            hotel.Show();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            hoteles _hotel = (hoteles)dataGridViewHotels.CurrentRow.DataBoundItem;

            Panel panel = (Panel)this.Parent;
            FormHotel hotel = new FormHotel(false, _hotel) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            panel.Controls.Clear();
            panel.Controls.Add(hotel);
            hotel.FormBorderStyle = FormBorderStyle.None;
            hotel.Show();
            Actualitzardatagrid();
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            String missatge;
            if(dataGridViewHotels.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Segur que vols eliminar l'hotel " +
                           dataGridViewHotels.Rows[this.dataGridViewHotels.CurrentRow.Index].Cells[0].Value + "?",
                           "Eliminar Hotel", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    
                    hoteles _hotel = (hoteles)dataGridViewHotels.CurrentRow.DataBoundItem;

                    foreach (act_hotel activs in _hotel.act_hotel.ToList())
                    {
                        missatge = Models.ActHotelORM.Delete(activs);

                        MissatgeError(missatge);
                    }

                    missatge = Models.HotelsORM.Delete(_hotel);

                    MissatgeError(missatge);

                    Actualitzardatagrid();
                }
            }
        }

        
        private void dataGridViewHotels_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            hoteles _hotel = (hoteles)dataGridViewHotels.Rows[e.RowIndex].DataBoundItem;

            if (e.ColumnIndex == 1)
            {             
                if(_hotel.categoria == 1)
                {
                    e.Value = "✸";
                }
                else if(_hotel.categoria == 2)
                {
                    e.Value = "✸✸";
                }
                else if (_hotel.categoria == 3)
                {
                    e.Value = "✸✸✸";
                }
                else if (_hotel.categoria == 4)
                {
                    e.Value = "✸✸✸✸";
                }
                else
                {
                    e.Value = "✸✸✸✸✸";
                }

            }
            if(e.ColumnIndex == 3)
            {
                e.Value = Models.CiutatsORM.SelectCiutatsByID(_hotel.id_ciudad).nombre;
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
