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
    public partial class FormCadena : Form
    {
        cadenas cadena;
        Boolean nou;

        public FormCadena(Boolean _nou)
        {
            InitializeComponent();
            cadena = new cadenas();
            nou = _nou;
            panelNou.Visible = true;
            panelNou.BringToFront();
            buttonCrear.Enabled= true;
            buttonGuardar.Enabled= false;
        }

        public FormCadena(Boolean _nou, cadenas _cadena)
        {
            InitializeComponent();
            cadena = _cadena;
            nou = _nou;
            bindingSourceHotels.DataSource = cadena.hoteles.ToList();
        }

        private void FormCadena_Load(object sender, EventArgs e)
        {
            ActualitzarDataGrid();
            OmplirCamps();
        }

        private void ActualitzarDataGrid()
        {
            bindingSourceHotels.DataSource = Models.HotelsORM.SelectByCadena(cadena.cif);
            cadena.hoteles = Models.HotelsORM.SelectByCadena(cadena.cif);
        }

        private void OmplirCamps()
        {
            if (nou)
            {
                labelNomCadena.Text = "Nova cadena";
            }
            else
            {
                labelNomCadena.Text = cadena.nombre;
                textBoxNom.Text = cadena.nombre;
                textBoxAdreca.Text = cadena.dir_fis;
                textBoxCIF.Text = cadena.cif;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RetornGestio();
        }

        private void buttonEditAct_Click(object sender, EventArgs e)
        {
            HotelsCadena hotcadena = new HotelsCadena(cadena);
            hotcadena.ShowDialog();
            ActualitzarDataGrid();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            String missatge = "";

            if (!ErrorDades())
            {
                cadena.cif = textBoxCIF.Text;
                cadena.nombre = textBoxNom.Text;
                cadena.dir_fis = textBoxAdreca.Text;

                missatge = Models.CadenesORM.Update();

                if (!MissatgeError(missatge))
                {
                    RetornGestio();
                }
            }

            
        }

        private void RetornGestio()
        {
            Panel panel = (Panel)this.Parent;
            GestioCadenes cadenes = new GestioCadenes { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            panel.Controls.Clear();
            panel.Controls.Add(cadenes);
            cadenes.FormBorderStyle = FormBorderStyle.None;
            cadenes.Show();
        }

        private void dataGridViewActivitats_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            hoteles _hotel = (hoteles)dataGridViewActivitats.Rows[e.RowIndex].DataBoundItem;

            if (e.ColumnIndex == 1)
            {
                if (_hotel.categoria == 1)
                {
                    e.Value = "✸";
                }
                else if (_hotel.categoria == 2)
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
            if (e.ColumnIndex == 2)
            {
                e.Value = Models.CiutatsORM.SelectCiutatsByID(_hotel.id_ciudad).nombre;
            }
        }

        private void buttonAbsorvir_Click(object sender, EventArgs e)
        {
            Absorvir abs = new Absorvir(cadena);
            abs.ShowDialog();
            ActualitzarDataGrid();
        }

        private void buttonCrear_Click(object sender, EventArgs e)
        {
            String missatge = "";

            if (!ErrorDades())
            {
                cadena.cif = textBoxCIF.Text;
                cadena.nombre = textBoxNom.Text;
                cadena.dir_fis = textBoxAdreca.Text;
                cadena.hoteles = new List<hoteles>();

                missatge = Models.CadenesORM.Insert(cadena);

                if (!MissatgeError(missatge))
                {
                    panelNou.Visible = false;
                    panelNou.SendToBack();
                    buttonCrear.Enabled = false;
                    buttonGuardar.Enabled = true;
                    ActualitzarDataGrid();
                }

            }
            
        }

        private Boolean ErrorDades()
        {
            Boolean error = false;
            String missatge = "Error en els següents camps:";

            if (textBoxNom.Text == "")
            {
                missatge += "\n - El camp Nom no pot estar buit.";
                error = true;
            }
            if (textBoxCIF.Text == "")
            {
                missatge += "\n - El camp CIF no pot estar buit.";
                error = true;
            }
            if (textBoxAdreca.Text == "")
            {
                missatge += "\n - El camp Adreça no pot estar buit.";
                error = true;
            }

            if (error)
            {
                MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return error;
        }

        private Boolean MissatgeError(String missatge)
        {
            Boolean error = false;

            if (missatge != "" && !nou)
            {
                MessageBox.Show(missatge, "Actualitzar Cadena", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
            }
            else if (missatge != "" && nou)
            {
                MessageBox.Show(missatge, "Crear Cadena", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
            }

            return error;
        }
    }
}
