namespace WindowsFormsApplication1.Facturas
{
    partial class Facturas
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
            this.labelNumPag = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonFiltrar = new System.Windows.Forms.Button();
            this.buttonSigPag = new System.Windows.Forms.Button();
            this.buttonPriPag = new System.Windows.Forms.Button();
            this.buttonPaginaAnt = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label32 = new System.Windows.Forms.Label();
            this.dateFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.chkFechas = new System.Windows.Forms.CheckBox();
            this.chkImportes = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrecioInicio = new System.Windows.Forms.TextBox();
            this.labelPrecio = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrecioFin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkCVentas = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkCTipo = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkCEnvio = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNumPag
            // 
            this.labelNumPag.AutoSize = true;
            this.labelNumPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumPag.Location = new System.Drawing.Point(1187, 423);
            this.labelNumPag.Name = "labelNumPag";
            this.labelNumPag.Size = new System.Drawing.Size(0, 20);
            this.labelNumPag.TabIndex = 78;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1102, 423);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 77;
            this.label1.Text = "Página Nº";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Location = new System.Drawing.Point(219, 470);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 38);
            this.button1.TabIndex = 76;
            this.button1.Text = "Reestablecer todo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonFiltrar
            // 
            this.buttonFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonFiltrar.Location = new System.Drawing.Point(386, 470);
            this.buttonFiltrar.Name = "buttonFiltrar";
            this.buttonFiltrar.Size = new System.Drawing.Size(172, 38);
            this.buttonFiltrar.TabIndex = 75;
            this.buttonFiltrar.Text = "Filtrar";
            this.buttonFiltrar.UseVisualStyleBackColor = true;
            this.buttonFiltrar.Click += new System.EventHandler(this.buttonFiltrar_Click);
            // 
            // buttonSigPag
            // 
            this.buttonSigPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSigPag.Location = new System.Drawing.Point(672, 423);
            this.buttonSigPag.Name = "buttonSigPag";
            this.buttonSigPag.Size = new System.Drawing.Size(137, 31);
            this.buttonSigPag.TabIndex = 73;
            this.buttonSigPag.Text = "Siguiente página >>";
            this.buttonSigPag.UseVisualStyleBackColor = true;
            this.buttonSigPag.Click += new System.EventHandler(this.buttonSigPag_Click);
            // 
            // buttonPriPag
            // 
            this.buttonPriPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPriPag.Location = new System.Drawing.Point(529, 423);
            this.buttonPriPag.Name = "buttonPriPag";
            this.buttonPriPag.Size = new System.Drawing.Size(137, 31);
            this.buttonPriPag.TabIndex = 72;
            this.buttonPriPag.Text = "Primera página";
            this.buttonPriPag.UseVisualStyleBackColor = true;
            this.buttonPriPag.Click += new System.EventHandler(this.buttonPriPag_Click);
            // 
            // buttonPaginaAnt
            // 
            this.buttonPaginaAnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPaginaAnt.Location = new System.Drawing.Point(386, 423);
            this.buttonPaginaAnt.Name = "buttonPaginaAnt";
            this.buttonPaginaAnt.Size = new System.Drawing.Size(137, 31);
            this.buttonPaginaAnt.TabIndex = 71;
            this.buttonPaginaAnt.Text = "<< Página anterior";
            this.buttonPaginaAnt.UseVisualStyleBackColor = true;
            this.buttonPaginaAnt.Click += new System.EventHandler(this.buttonPaginaAnt_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(385, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(834, 353);
            this.dataGridView1.TabIndex = 69;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelTitulo.Location = new System.Drawing.Point(731, 23);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(88, 25);
            this.labelTitulo.TabIndex = 64;
            this.labelTitulo.Text = "Facturas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 20);
            this.label2.TabIndex = 63;
            this.label2.Text = "Activar intervalo de fechas";
            // 
            // dateFechaInicio
            // 
            this.dateFechaInicio.Location = new System.Drawing.Point(149, 103);
            this.dateFechaInicio.Name = "dateFechaInicio";
            this.dateFechaInicio.Size = new System.Drawing.Size(230, 20);
            this.dateFechaInicio.TabIndex = 150;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(27, 104);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(99, 20);
            this.label32.TabIndex = 149;
            this.label32.Text = "Fecha Inicio:";
            // 
            // dateFechaFin
            // 
            this.dateFechaFin.Location = new System.Drawing.Point(149, 141);
            this.dateFechaFin.Name = "dateFechaFin";
            this.dateFechaFin.Size = new System.Drawing.Size(230, 20);
            this.dateFechaFin.TabIndex = 152;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 151;
            this.label3.Text = "Fecha Fin:";
            // 
            // chkFechas
            // 
            this.chkFechas.AutoSize = true;
            this.chkFechas.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFechas.Location = new System.Drawing.Point(240, 73);
            this.chkFechas.Name = "chkFechas";
            this.chkFechas.Size = new System.Drawing.Size(15, 14);
            this.chkFechas.TabIndex = 153;
            this.chkFechas.UseVisualStyleBackColor = true;
            this.chkFechas.CheckedChanged += new System.EventHandler(this.chkEnvio_CheckedChanged);
            // 
            // chkImportes
            // 
            this.chkImportes.AutoSize = true;
            this.chkImportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkImportes.Location = new System.Drawing.Point(240, 186);
            this.chkImportes.Name = "chkImportes";
            this.chkImportes.Size = new System.Drawing.Size(15, 14);
            this.chkImportes.TabIndex = 155;
            this.chkImportes.UseVisualStyleBackColor = true;
            this.chkImportes.CheckedChanged += new System.EventHandler(this.chkImportes_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 20);
            this.label4.TabIndex = 154;
            this.label4.Text = "Activar intervalo de importes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(157, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 20);
            this.label5.TabIndex = 158;
            this.label5.Text = "$";
            // 
            // txtPrecioInicio
            // 
            this.txtPrecioInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioInicio.Location = new System.Drawing.Point(181, 215);
            this.txtPrecioInicio.Name = "txtPrecioInicio";
            this.txtPrecioInicio.Size = new System.Drawing.Size(198, 26);
            this.txtPrecioInicio.TabIndex = 157;
            // 
            // labelPrecio
            // 
            this.labelPrecio.AutoSize = true;
            this.labelPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecio.Location = new System.Drawing.Point(27, 218);
            this.labelPrecio.Name = "labelPrecio";
            this.labelPrecio.Size = new System.Drawing.Size(94, 20);
            this.labelPrecio.TabIndex = 156;
            this.labelPrecio.Text = "Precio Inicio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(157, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 20);
            this.label6.TabIndex = 161;
            this.label6.Text = "$";
            // 
            // txtPrecioFin
            // 
            this.txtPrecioFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioFin.Location = new System.Drawing.Point(181, 257);
            this.txtPrecioFin.Name = "txtPrecioFin";
            this.txtPrecioFin.Size = new System.Drawing.Size(198, 26);
            this.txtPrecioFin.TabIndex = 160;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 159;
            this.label7.Text = "Precio Fin";
            // 
            // chkCVentas
            // 
            this.chkCVentas.AutoSize = true;
            this.chkCVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCVentas.Location = new System.Drawing.Point(240, 350);
            this.chkCVentas.Name = "chkCVentas";
            this.chkCVentas.Size = new System.Drawing.Size(15, 14);
            this.chkCVentas.TabIndex = 163;
            this.chkCVentas.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 344);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 20);
            this.label8.TabIndex = 162;
            this.label8.Text = "Comisión por venta";
            // 
            // chkCTipo
            // 
            this.chkCTipo.AutoSize = true;
            this.chkCTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCTipo.Location = new System.Drawing.Point(240, 311);
            this.chkCTipo.Name = "chkCTipo";
            this.chkCTipo.Size = new System.Drawing.Size(15, 14);
            this.chkCTipo.TabIndex = 165;
            this.chkCTipo.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(27, 305);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(209, 20);
            this.label9.TabIndex = 164;
            this.label9.Text = "Comisión tipo de publicación";
            // 
            // chkCEnvio
            // 
            this.chkCEnvio.AutoSize = true;
            this.chkCEnvio.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCEnvio.Location = new System.Drawing.Point(240, 386);
            this.chkCEnvio.Name = "chkCEnvio";
            this.chkCEnvio.Size = new System.Drawing.Size(15, 14);
            this.chkCEnvio.TabIndex = 167;
            this.chkCEnvio.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(27, 380);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(142, 20);
            this.label10.TabIndex = 166;
            this.label10.Text = "Comisión por envío";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonCancelar.Location = new System.Drawing.Point(31, 470);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(98, 38);
            this.buttonCancelar.TabIndex = 168;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label11.Location = new System.Drawing.Point(148, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 25);
            this.label11.TabIndex = 169;
            this.label11.Text = "Filtros";
            // 
            // Facturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1246, 520);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.chkCEnvio);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.chkCTipo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkCVentas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPrecioFin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPrecioInicio);
            this.Controls.Add(this.labelPrecio);
            this.Controls.Add(this.chkImportes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkFechas);
            this.Controls.Add(this.dateFechaFin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateFechaInicio);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.labelNumPag);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonFiltrar);
            this.Controls.Add(this.buttonSigPag);
            this.Controls.Add(this.buttonPriPag);
            this.Controls.Add(this.buttonPaginaAnt);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.label2);
            this.Name = "Facturas";
            this.Text = "Facturas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNumPag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonFiltrar;
        private System.Windows.Forms.Button buttonSigPag;
        private System.Windows.Forms.Button buttonPriPag;
        private System.Windows.Forms.Button buttonPaginaAnt;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateFechaInicio;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.DateTimePicker dateFechaFin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkFechas;
        private System.Windows.Forms.CheckBox chkImportes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrecioInicio;
        private System.Windows.Forms.Label labelPrecio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrecioFin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkCVentas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkCTipo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkCEnvio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label label11;
    }
}