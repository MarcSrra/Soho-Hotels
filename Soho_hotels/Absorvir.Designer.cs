namespace Soho_hotels
{
    partial class Absorvir
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Absorvir));
            this.label2 = new System.Windows.Forms.Label();
            this.buttonTreure = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxCadena = new System.Windows.Forms.ComboBox();
            this.bindingSourceCadena = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCadena)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Indica la cadena a absorvir";
            // 
            // buttonTreure
            // 
            this.buttonTreure.AutoSize = true;
            this.buttonTreure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(93)))), ((int)(((byte)(108)))));
            this.buttonTreure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonTreure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTreure.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTreure.ForeColor = System.Drawing.Color.White;
            this.buttonTreure.Location = new System.Drawing.Point(40, 95);
            this.buttonTreure.Name = "buttonTreure";
            this.buttonTreure.Size = new System.Drawing.Size(81, 30);
            this.buttonTreure.TabIndex = 20;
            this.buttonTreure.Text = "Acceptar";
            this.buttonTreure.UseVisualStyleBackColor = false;
            this.buttonTreure.Click += new System.EventHandler(this.buttonTreure_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(93)))), ((int)(((byte)(108)))));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(-5, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(305, 3);
            this.flowLayoutPanel1.TabIndex = 22;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(93)))), ((int)(((byte)(108)))));
            this.panel4.Location = new System.Drawing.Point(296, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(3, 150);
            this.panel4.TabIndex = 21;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(93)))), ((int)(((byte)(108)))));
            this.flowLayoutPanel2.Location = new System.Drawing.Point(-5, 147);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(305, 3);
            this.flowLayoutPanel2.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(93)))), ((int)(((byte)(108)))));
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(3, 150);
            this.panel1.TabIndex = 22;
            // 
            // comboBoxCadena
            // 
            this.comboBoxCadena.DataSource = this.bindingSourceCadena;
            this.comboBoxCadena.DisplayMember = "nombre";
            this.comboBoxCadena.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCadena.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCadena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.comboBoxCadena.FormattingEnabled = true;
            this.comboBoxCadena.Location = new System.Drawing.Point(40, 55);
            this.comboBoxCadena.Name = "comboBoxCadena";
            this.comboBoxCadena.Size = new System.Drawing.Size(213, 26);
            this.comboBoxCadena.TabIndex = 24;
            this.comboBoxCadena.ValueMember = "cif";
            // 
            // bindingSourceCadena
            // 
            this.bindingSourceCadena.DataSource = typeof(Soho_hotels.Models.cadenas);
            // 
            // Absorvir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(299, 150);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.buttonTreure);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxCadena);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(93)))), ((int)(((byte)(108)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Absorvir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SOHO - Absorvir cadena";
            this.Load += new System.EventHandler(this.Absorvir_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCadena)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonTreure;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxCadena;
        private System.Windows.Forms.BindingSource bindingSourceCadena;
    }
}