using Soho_hotels.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soho_hotels
{
    public partial class Activitats : Form
    {
        List<act_hotel> activs;
        hoteles hotel;

        public Activitats(hoteles _hotel)
        {
            InitializeComponent();
            hotel = _hotel;
        }

        private void Activitats_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            bindingSourceActivitats.DataSource = Models.ActivitatsORM.Select();

            activs = Models.ActHotelORM.SelectByHotel(hotel);

            actualitzarGridActHot();
        }

        private void actualitzarGridActHot()
        {
            bindingSourceActivitatsHotel.ResetBindings(true);
            bindingSourceActivitatsHotel.DataSource = activs;
        }

        private void dataGridViewActivitatsHotel_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                act_hotel activitatHotel = (act_hotel)dataGridViewActivitatsHotel.Rows[e.RowIndex].DataBoundItem;
                actividades activitat = Models.ActivitatsORM.SelectActivitatByID(activitatHotel.id_act);
                e.Value = activitat.descripcion;
            }
        }

        private void buttonAfegir_Click(object sender, EventArgs e)
        {
            Boolean afegir = true;
            actividades activ = (actividades)dataGridViewActivitats.CurrentRow.DataBoundItem;
            

            foreach(act_hotel newactiv in activs)
            {
                if(newactiv.id_act == activ.id_act)
                {
                    afegir = false;
                }
            }

            if((int)numericUpDownDificultat.Value > 0)
            {
                if (afegir)
                {
                    act_hotel novaacthotel = new act_hotel();
                    novaacthotel.id_act = activ.id_act;
                    novaacthotel.id_ciudad = hotel.id_ciudad;
                    novaacthotel.nombre = hotel.nombre;
                    novaacthotel.grado = (int)numericUpDownDificultat.Value;
                    novaacthotel.actividades = activ;
                    novaacthotel.hoteles = hotel;
                    activs.Add(novaacthotel);
                    
                    actualitzarGridActHot();
                    numericUpDownDificultat.Value = 0;
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Error al afegir l'activitat " + activ.descripcion
                           + ", l'hotel " + hotel.nombre + " ja ofereix aquesta activitat.", "Afegir activitat",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Error al afegir l'activitat " + activ.descripcion
                            + ", La dificultat ha de ser igual o superior a 0.", "Afegir activitat", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void buttonTreure_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Segur que vols eliminar l'activitat " +
                            Models.ActivitatsORM.SelectActivitatByID((int)dataGridViewActivitatsHotel.Rows[this.dataGridViewActivitatsHotel.CurrentRow.Index].Cells[0].Value).descripcion + "?",
                            "Eliminar Activitat", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                activs.Remove((act_hotel)dataGridViewActivitatsHotel.CurrentRow.DataBoundItem);
                actualitzarGridActHot();
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            String missatge = "";
            //hoteles hotelupdated = hotel;
            ICollection<act_hotel> ICactivitats = activs;
            //hotelupdated.act_hotel = ICactivitats;
            hotel.act_hotel = ICactivitats;

            missatge = Models.HotelsORM.Update();
            MissatgeError(missatge);

            this.Close();
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
