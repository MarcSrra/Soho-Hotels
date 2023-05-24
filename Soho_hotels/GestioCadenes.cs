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
    public partial class GestioCadenes : Form
    {
        public GestioCadenes()
        {
            InitializeComponent();
        }

        private void GestioCadenes_Load(object sender, EventArgs e)
        {
            Actualitzardatagrid();
            bindingSourceCadenes.DataSource = Models.CadenesORM.Select();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Actualitzardatagrid();
        }

        private void Actualitzardatagrid()
        {
            if (textBoxNom.Text == "")
            {
                bindingSourceCadenes.DataSource = Models.CadenesORM.Select();
            }
            else
            {
                bindingSourceCadenes.DataSource = Models.CadenesORM.SelectByNom(textBoxNom.Text);
            }
        }

        private void buttonNou_Click(object sender, EventArgs e)
        {
            Panel panel = (Panel)this.Parent;
            FormCadena cadena = new FormCadena(true) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            panel.Controls.Clear();
            panel.Controls.Add(cadena);
            cadena.FormBorderStyle = FormBorderStyle.None;
            cadena.Show();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            cadenas _cadena = (cadenas)dataGridViewCadenes.CurrentRow.DataBoundItem;
            Panel panel = (Panel)this.Parent;
            FormCadena cadena = new FormCadena(false, _cadena) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            panel.Controls.Clear();
            panel.Controls.Add(cadena);
            cadena.FormBorderStyle = FormBorderStyle.None;
            cadena.Show();
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            String missatge;
            if (dataGridViewCadenes.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Segur que vols eliminar l'a cadena " +
                           dataGridViewCadenes.Rows[this.dataGridViewCadenes.CurrentRow.Index].Cells[0].Value + "?",
                           "Eliminar Hotel", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {

                    cadenas _cadena = (cadenas)dataGridViewCadenes.CurrentRow.DataBoundItem;

                    missatge = Models.CadenesORM.Delete(_cadena);

                    MissatgeError(missatge);

                    Actualitzardatagrid();
                }
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
