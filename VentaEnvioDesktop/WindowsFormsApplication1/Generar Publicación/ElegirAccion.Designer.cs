namespace WindowsFormsApplication1.Generar_Publicación
{
    partial class ElegirAccion
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
            this.buttonCompra = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSubasta = new System.Windows.Forms.Button();
            this.buttonBorradores = new System.Windows.Forms.Button();
            this.buttonPublicaciones = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCompra
            // 
            this.buttonCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonCompra.Location = new System.Drawing.Point(12, 145);
            this.buttonCompra.Name = "buttonCompra";
            this.buttonCompra.Size = new System.Drawing.Size(160, 38);
            this.buttonCompra.TabIndex = 7;
            this.buttonCompra.Text = "Compra Inmediata";
            this.buttonCompra.UseVisualStyleBackColor = true;
            this.buttonCompra.Click += new System.EventHandler(this.crearButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(286, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Generar Publicación";
            // 
            // buttonSubasta
            // 
            this.buttonSubasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonSubasta.Location = new System.Drawing.Point(199, 145);
            this.buttonSubasta.Name = "buttonSubasta";
            this.buttonSubasta.Size = new System.Drawing.Size(160, 38);
            this.buttonSubasta.TabIndex = 8;
            this.buttonSubasta.Text = "Subasta";
            this.buttonSubasta.UseVisualStyleBackColor = true;
            this.buttonSubasta.Click += new System.EventHandler(this.crearSubasta_Click);
            // 
            // buttonBorradores
            // 
            this.buttonBorradores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonBorradores.Location = new System.Drawing.Point(392, 145);
            this.buttonBorradores.Name = "buttonBorradores";
            this.buttonBorradores.Size = new System.Drawing.Size(160, 38);
            this.buttonBorradores.TabIndex = 9;
            this.buttonBorradores.Text = "Mis Borradores";
            this.buttonBorradores.UseVisualStyleBackColor = true;
            this.buttonBorradores.Click += new System.EventHandler(this.buttonBorradores_Click);
            // 
            // buttonPublicaciones
            // 
            this.buttonPublicaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonPublicaciones.Location = new System.Drawing.Point(585, 145);
            this.buttonPublicaciones.Name = "buttonPublicaciones";
            this.buttonPublicaciones.Size = new System.Drawing.Size(160, 38);
            this.buttonPublicaciones.TabIndex = 10;
            this.buttonPublicaciones.Text = "Mis Publicaciones";
            this.buttonPublicaciones.UseVisualStyleBackColor = true;
            this.buttonPublicaciones.Click += new System.EventHandler(this.buttonPublicaciones_Click);
            // 
            // ElegirAccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(757, 216);
            this.Controls.Add(this.buttonPublicaciones);
            this.Controls.Add(this.buttonBorradores);
            this.Controls.Add(this.buttonSubasta);
            this.Controls.Add(this.buttonCompra);
            this.Controls.Add(this.label2);
            this.Name = "ElegirAccion";
            this.Text = "Elegir Accion";
            this.Load += new System.EventHandler(this.ElegirAccion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCompra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSubasta;
        private System.Windows.Forms.Button buttonBorradores;
        private System.Windows.Forms.Button buttonPublicaciones;
    }
}