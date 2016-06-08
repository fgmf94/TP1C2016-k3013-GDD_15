namespace WindowsFormsApplication1.ComprarOfertar
{
    partial class ListadoPublicaciones
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
            this.txtDescrip = new System.Windows.Forms.TextBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.buttonSeleccionarTodos = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.chkListaRubros = new System.Windows.Forms.CheckedListBox();
            this.buttonReestablecer = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonPaginaAnt = new System.Windows.Forms.Button();
            this.buttonPriPag = new System.Windows.Forms.Button();
            this.buttonSigPag = new System.Windows.Forms.Button();
            this.buttonElegirPub = new System.Windows.Forms.Button();
            this.buttonFiltrar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNumPag = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 45;
            this.label2.Text = "Descripción";
            // 
            // txtDescrip
            // 
            this.txtDescrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescrip.Location = new System.Drawing.Point(125, 67);
            this.txtDescrip.Name = "txtDescrip";
            this.txtDescrip.Size = new System.Drawing.Size(230, 26);
            this.txtDescrip.TabIndex = 44;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelTitulo.Location = new System.Drawing.Point(494, 20);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(258, 25);
            this.labelTitulo.TabIndex = 46;
            this.labelTitulo.Text = "Publicaciones para Comprar";
            // 
            // buttonSeleccionarTodos
            // 
            this.buttonSeleccionarTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSeleccionarTodos.Location = new System.Drawing.Point(36, 450);
            this.buttonSeleccionarTodos.Name = "buttonSeleccionarTodos";
            this.buttonSeleccionarTodos.Size = new System.Drawing.Size(126, 31);
            this.buttonSeleccionarTodos.TabIndex = 49;
            this.buttonSeleccionarTodos.Text = "Seleccionar todos";
            this.buttonSeleccionarTodos.UseVisualStyleBackColor = true;
            this.buttonSeleccionarTodos.Click += new System.EventHandler(this.buttonSeleccionarTodos_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Hacer doble click para marcar rubros";
            // 
            // chkListaRubros
            // 
            this.chkListaRubros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkListaRubros.FormattingEnabled = true;
            this.chkListaRubros.Location = new System.Drawing.Point(36, 127);
            this.chkListaRubros.Name = "chkListaRubros";
            this.chkListaRubros.Size = new System.Drawing.Size(319, 308);
            this.chkListaRubros.TabIndex = 47;
            // 
            // buttonReestablecer
            // 
            this.buttonReestablecer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReestablecer.Location = new System.Drawing.Point(226, 450);
            this.buttonReestablecer.Name = "buttonReestablecer";
            this.buttonReestablecer.Size = new System.Drawing.Size(129, 31);
            this.buttonReestablecer.TabIndex = 50;
            this.buttonReestablecer.Text = "Deseleccionar todos";
            this.buttonReestablecer.UseVisualStyleBackColor = true;
            this.buttonReestablecer.Click += new System.EventHandler(this.buttonReestablecer_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(390, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(834, 368);
            this.dataGridView1.TabIndex = 52;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonCancelar.Location = new System.Drawing.Point(36, 502);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(98, 38);
            this.buttonCancelar.TabIndex = 53;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.crearButton_Click);
            // 
            // buttonPaginaAnt
            // 
            this.buttonPaginaAnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPaginaAnt.Location = new System.Drawing.Point(390, 450);
            this.buttonPaginaAnt.Name = "buttonPaginaAnt";
            this.buttonPaginaAnt.Size = new System.Drawing.Size(137, 31);
            this.buttonPaginaAnt.TabIndex = 54;
            this.buttonPaginaAnt.Text = "<< Página anterior";
            this.buttonPaginaAnt.UseVisualStyleBackColor = true;
            // 
            // buttonPriPag
            // 
            this.buttonPriPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPriPag.Location = new System.Drawing.Point(533, 450);
            this.buttonPriPag.Name = "buttonPriPag";
            this.buttonPriPag.Size = new System.Drawing.Size(137, 31);
            this.buttonPriPag.TabIndex = 55;
            this.buttonPriPag.Text = "Primera página";
            this.buttonPriPag.UseVisualStyleBackColor = true;
            // 
            // buttonSigPag
            // 
            this.buttonSigPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSigPag.Location = new System.Drawing.Point(676, 450);
            this.buttonSigPag.Name = "buttonSigPag";
            this.buttonSigPag.Size = new System.Drawing.Size(137, 31);
            this.buttonSigPag.TabIndex = 56;
            this.buttonSigPag.Text = "Siguiente página >>";
            this.buttonSigPag.UseVisualStyleBackColor = true;
            // 
            // buttonElegirPub
            // 
            this.buttonElegirPub.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonElegirPub.Location = new System.Drawing.Point(1052, 502);
            this.buttonElegirPub.Name = "buttonElegirPub";
            this.buttonElegirPub.Size = new System.Drawing.Size(172, 38);
            this.buttonElegirPub.TabIndex = 57;
            this.buttonElegirPub.Text = "Elegir Publicación";
            this.buttonElegirPub.UseVisualStyleBackColor = true;
            this.buttonElegirPub.Click += new System.EventHandler(this.buttonElegirPub_Click);
            // 
            // buttonFiltrar
            // 
            this.buttonFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonFiltrar.Location = new System.Drawing.Point(390, 502);
            this.buttonFiltrar.Name = "buttonFiltrar";
            this.buttonFiltrar.Size = new System.Drawing.Size(172, 38);
            this.buttonFiltrar.TabIndex = 58;
            this.buttonFiltrar.Text = "Filtrar";
            this.buttonFiltrar.UseVisualStyleBackColor = true;
            this.buttonFiltrar.Click += new System.EventHandler(this.buttonFiltrar_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Location = new System.Drawing.Point(195, 502);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 38);
            this.button1.TabIndex = 59;
            this.button1.Text = "Reestablecer todo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1106, 450);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 60;
            this.label1.Text = "Página Nº";
            // 
            // labelNumPag
            // 
            this.labelNumPag.AutoSize = true;
            this.labelNumPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumPag.Location = new System.Drawing.Point(1191, 450);
            this.labelNumPag.Name = "labelNumPag";
            this.labelNumPag.Size = new System.Drawing.Size(0, 20);
            this.labelNumPag.TabIndex = 61;
            // 
            // ListadoPublicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1253, 552);
            this.Controls.Add(this.labelNumPag);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonFiltrar);
            this.Controls.Add(this.buttonElegirPub);
            this.Controls.Add(this.buttonSigPag);
            this.Controls.Add(this.buttonPriPag);
            this.Controls.Add(this.buttonPaginaAnt);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonReestablecer);
            this.Controls.Add(this.buttonSeleccionarTodos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkListaRubros);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescrip);
            this.Name = "ListadoPublicaciones";
            this.Text = "Listado de Publicaciones";
            this.Load += new System.EventHandler(this.ListadoPublicaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescrip;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Button buttonSeleccionarTodos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox chkListaRubros;
        private System.Windows.Forms.Button buttonReestablecer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonPaginaAnt;
        private System.Windows.Forms.Button buttonPriPag;
        private System.Windows.Forms.Button buttonSigPag;
        private System.Windows.Forms.Button buttonElegirPub;
        private System.Windows.Forms.Button buttonFiltrar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNumPag;
    }
}