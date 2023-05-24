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
    public partial class FormHotel : Form
    {
        Boolean nou;
        hoteles hotel;

        public FormHotel(Boolean _nou)
        {
            InitializeComponent();
            hotel = new hoteles();
            panelNou.BringToFront();
            panelNou.Visible= true;
            buttonCrear.Enabled= true;
            buttonGuardar.Enabled= false;
            nou = _nou;
        }

        public FormHotel(Boolean _nou, hoteles _hotel)
        {
            InitializeComponent();
            //hotel = Models.HotelsORM.SelectByNomCadena(_hotel.nombre, _hotel.cif)[0];
            hotel = _hotel;
            nou= _nou;

            ActialitzarGridActivitats();
        }

        private void ActialitzarGridActivitats()
        {
            bindingSourceActivitatsHotel.DataSource = Models.ActHotelORM.SelectByHotel(hotel);
            hotel.act_hotel = Models.ActHotelORM.SelectByHotel(hotel);
        }

        private void carregadades()
        {
            if (nou)
            {
                labelNomHotel.Text = "Nou hotel";
                comboBoxCiutat.SelectedIndex = -1;
                comboBoxCadena.SelectedIndex = -1;
            }
            else
            {
                labelNomHotel.Text = hotel.nombre;
                textBoxNom.Text = hotel.nombre;
                textBoxAdreca.Text = hotel.direccion;
                textBoxCIF.Text = ((cadenas)comboBoxCadena.SelectedItem).cif;
                textBoxTelefon.Text = hotel.telefono.ToString();
                textBoxTipus.Text = hotel.tipo;


                comboBoxCategoria.SelectedIndex = hotel.categoria - 1;

                seleccionarComboBox();
            }
        }


        private void seleccionarComboBox()
        {
            int indexCombo = -1;
            int i = 0;
            Boolean hecho = false;

            while (i < comboBoxCadena.Items.Count && indexCombo == -1 && !hecho)
            {
                cadenas cadenita = (cadenas)comboBoxCadena.Items[i];
                if (cadenita.cif == hotel.cif)
                {
                    indexCombo = i;
                    hecho = true;
                }
                i++;
            }

            if (indexCombo != -1)
            {
                comboBoxCadena.SelectedIndex = indexCombo;
            }

            indexCombo = -1;
            i = 0;
            hecho = false;

            while (i < comboBoxCiutat.Items.Count && indexCombo == -1 && !hecho)
            {
                ciudades ciutadella = (ciudades)comboBoxCiutat.Items[i];
                if (ciutadella.id_ciudad == hotel.id_ciudad)
                {
                    indexCombo = i;
                    hecho = true;
                }
                i++;
            }

            if (indexCombo != -1)
            {
                comboBoxCiutat.SelectedIndex = indexCombo;
            }
        }


        private void RetornGestio()
        {
            Panel panel = (Panel)this.Parent;
            GestioHotels hotels = new GestioHotels { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            panel.Controls.Clear();
            panel.Controls.Add(hotels);
            hotels.FormBorderStyle = FormBorderStyle.None;
            hotels.Show();
        }

        private void buttonEditAct_Click(object sender, EventArgs e)
        {
            Activitats activitats= new Activitats(hotel);
            activitats.ShowDialog();
            ActialitzarGridActivitats();
        }

        private void FormHotel_Load(object sender, EventArgs e)
        {
            bindingSourceCiutats.DataSource = Models.CiutatsORM.Select();
            
            bindingSourceCadena.DataSource = Models.CadenesORM.Select();

            carregadades();
        }

        private void dataGridViewActivitats_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                act_hotel activitatHotel = (act_hotel)dataGridViewActivitats.Rows[e.RowIndex].DataBoundItem;
                actividades activitat = Models.ActivitatsORM.SelectActivitatByID(activitatHotel.id_act);
                e.Value = activitat.descripcion;
            }
        }

        private void comboBoxCadena_SelectedIndexChanged(object sender, EventArgs e)
        {
            cadenas cad = (cadenas)comboBoxCadena.SelectedItem;

            if (cad != null)
            {
                textBoxCIF.Text = cad.cif;
            }
        }

        private void buttonCrear_Click(object sender, EventArgs e)
        {
            String missatge = "";

            if (!ErrorDades())
            {
                hotel.nombre = textBoxNom.Text;
                hotel.categoria = (int)comboBoxCategoria.SelectedIndex + 1;
                hotel.id_ciudad = (int)comboBoxCiutat.SelectedValue;
                hotel.direccion = textBoxAdreca.Text;
                hotel.telefono = Int32.Parse(textBoxTelefon.Text);
                hotel.tipo = textBoxTipus.Text;
                hotel.cif = textBoxCIF.Text;
                hotel.act_hotel = new List<act_hotel>();
                hotel.ciudades = Models.CiutatsORM.SelectCiutatsByID((int)comboBoxCiutat.SelectedValue);
                hotel.cadenas = Models.CadenesORM.SelectByCIF(textBoxCIF.Text);

                missatge = Models.HotelsORM.Insert(hotel);

                if(!MissatgeError(missatge))
                {
                    panelNou.SendToBack();
                    panelNou.Visible= false;
                    buttonCrear.Enabled= false;
                    buttonGuardar.Enabled= true;
                    ActialitzarGridActivitats();
                }
                             
            }
            
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            String missatge = "";

            if (!ErrorDades())
            {
                hotel.nombre = textBoxNom.Text;
                hotel.categoria = (int)comboBoxCategoria.SelectedIndex + 1;
                hotel.id_ciudad = (int)comboBoxCiutat.SelectedValue;
                hotel.direccion = textBoxAdreca.Text;
                hotel.telefono = Int32.Parse(textBoxTelefon.Text);
                hotel.tipo = textBoxTipus.Text;
                hotel.cif = textBoxCIF.Text;
                hotel.ciudades = Models.CiutatsORM.SelectCiutatsByID((int)comboBoxCiutat.SelectedValue);
                hotel.cadenas = Models.CadenesORM.SelectByCIF(textBoxCIF.Text);

                missatge = Models.HotelsORM.Update();

                if (!MissatgeError(missatge))
                {
                    RetornGestio();
                }
            }
            
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            RetornGestio();
        }

        private Boolean MissatgeError(String missatge)
        {
            Boolean error = false;

            if (missatge != "" && !nou)
            {
                MessageBox.Show(missatge, "Actualitzar Hotel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
            }
            else if(missatge != "" && nou)
            {
                MessageBox.Show(missatge, "Crear Hotel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
            }

            return error;
        }

        private Boolean ErrorDades()
        {
            Boolean error = false;
            String missatge = "Error en els següents camps:";

            if(textBoxNom.Text == "")
            {
                missatge += "\n - El camp Nom no pot estar buit.";
                error = true;
            }
            if (comboBoxCategoria.SelectedIndex == -1)
            {
                missatge += "\n - El camp Categoria ha de tenir un item sel·leccionat.";
                error = true;
            }
            if (comboBoxCadena.SelectedIndex == -1)
            {
                missatge += "\n - El camp Cadena ha de tenir un item sel·leccionat.";
                error = true;
            }
            if (comboBoxCiutat.SelectedIndex == -1)
            {
                missatge += "\n - El camp Ciutat ha de tenir un item sel·leccionat.";
                error = true;
            }
            if (textBoxTelefon.Text == "")
            {
                missatge += "\n - El camp Telèfon no pot estar buit.";
                error = true;
            }
            try
            {
                int result = Int32.Parse(textBoxTelefon.Text);
            }
            catch (Exception e)
            {
                missatge+= "\n - El camp Telèfon ha d'estar format només de números";
            }
            if (textBoxAdreca.Text == "")
            {
                missatge += "\n - El camp Adreça no pot estar buit.";
                error = true;
            }
            if (textBoxTipus.Text == "")
            {
                missatge += "\n - El Tipus nom no pot estar buit.";
                error = true;
            }

            if (error)
            {
                MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return error;
        }

        
    }
}
