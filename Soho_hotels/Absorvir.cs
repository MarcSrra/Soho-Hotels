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
    public partial class Absorvir : Form
    {
        cadenas cadena;
        List<hoteles> hotels;
        List<cadenas> totescadenes, cadenes = new List<cadenas>();

        public Absorvir(cadenas _cadena)
        {
            InitializeComponent();
            cadena = _cadena;
        }

        private void Absorvir_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            totescadenes = Models.CadenesORM.Select();

            foreach(cadenas cad in totescadenes)
            {
                if(cad.cif != cadena.cif)
                {
                    cadenes.Add(cad);
                }
            }

            bindingSourceCadena.DataSource = cadenes;

        }

        private void buttonTreure_Click(object sender, EventArgs e)
        {
            String missatge = "";
            DialogResult dr = MessageBox.Show("Segur que vols que la cadena " + cadena.nombre + " absorveixi els hotels de la cadena" + 
                            ((cadenas)comboBoxCadena.SelectedItem).nombre + "?", "Absorvir cadena", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                cadenas cad = Models.CadenesORM.SelectByCIF(((cadenas)comboBoxCadena.SelectedItem).cif);
                foreach (hoteles hot in Models.HotelsORM.SelectByCadena(cad.cif))
                {
                    hot.cif = cadena.cif;
                    missatge = Models.HotelsORM.Update();

                    if (missatge != "")
                    {
                        MessageBox.Show(missatge, "Eliminar Hotel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
        }
    }
}
