namespace WindowsFormsApplication1.Elegir_Funcionalidad
{
    partial class EleccionFuncionalidad
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
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxFuncionalidad = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Funcionalidad:";
            // 
            // funcionalidadCombo
            // 
            this.comboBoxFuncionalidad.FormattingEnabled = true;
            this.comboBoxFuncionalidad.Items.AddRange(new object[] {
            "ABM de Rol",
            "ABM de Usuarios",
            "ABM de Rubro",
            "ABM visibilidad de publicación",
            "Generar Publicación",
            "Comprar/Ofertar",
            "Historial del Vendedor",
            "Consulta de facturas",
            "Listado Estadístico"});
            this.comboBoxFuncionalidad.Location = new System.Drawing.Point(159, 77);
            this.comboBoxFuncionalidad.Name = "funcionalidadCombo";
            this.comboBoxFuncionalidad.Size = new System.Drawing.Size(219, 21);
            this.comboBoxFuncionalidad.TabIndex = 3;
            this.comboBoxFuncionalidad.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(159, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(219, 22);
            this.button1.TabIndex = 4;
            this.button1.Text = "Seleccionar Funcionalidad";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EleccionFuncionalidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(450, 233);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxFuncionalidad);
            this.Controls.Add(this.label2);
            this.Name = "EleccionFuncionalidad";
            this.Text = "Elección Funcionalidad";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxFuncionalidad;
        private System.Windows.Forms.Button button1;

    }
}