namespace WindowsFormsApplication1.Historial_Cliente
{
    partial class Historial
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
            this.buttonSigPag = new System.Windows.Forms.Button();
            this.buttonPriPag = new System.Windows.Forms.Button();
            this.buttonPaginaAnt = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelEstrellas = new System.Windows.Forms.Label();
            this.labelOperaciones = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNumPag
            // 
            this.labelNumPag.AutoSize = true;
            this.labelNumPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumPag.Location = new System.Drawing.Point(1186, 432);
            this.labelNumPag.Name = "labelNumPag";
            this.labelNumPag.Size = new System.Drawing.Size(0, 20);
            this.labelNumPag.TabIndex = 78;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1107, 432);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 77;
            this.label1.Text = "Página Nº";
            // 
            // buttonSigPag
            // 
            this.buttonSigPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSigPag.Location = new System.Drawing.Point(297, 429);
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
            this.buttonPriPag.Location = new System.Drawing.Point(154, 429);
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
            this.buttonPaginaAnt.Location = new System.Drawing.Point(11, 429);
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1227, 353);
            this.dataGridView1.TabIndex = 69;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelTitulo.Location = new System.Drawing.Point(525, 19);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(178, 25);
            this.labelTitulo.TabIndex = 64;
            this.labelTitulo.Text = "Historial del Cliente";
            this.labelTitulo.Click += new System.EventHandler(this.labelTitulo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(440, 432);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 20);
            this.label2.TabIndex = 79;
            this.label2.Text = "Operaciones por calificar:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(771, 432);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 80;
            this.label3.Text = "Estrellas dadas:";
            // 
            // labelEstrellas
            // 
            this.labelEstrellas.AutoSize = true;
            this.labelEstrellas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstrellas.Location = new System.Drawing.Point(890, 432);
            this.labelEstrellas.Name = "labelEstrellas";
            this.labelEstrellas.Size = new System.Drawing.Size(0, 20);
            this.labelEstrellas.TabIndex = 81;
            // 
            // labelOperaciones
            // 
            this.labelOperaciones.AutoSize = true;
            this.labelOperaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOperaciones.Location = new System.Drawing.Point(620, 432);
            this.labelOperaciones.Name = "labelOperaciones";
            this.labelOperaciones.Size = new System.Drawing.Size(0, 20);
            this.labelOperaciones.TabIndex = 82;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonCancelar.Location = new System.Drawing.Point(12, 466);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(97, 38);
            this.buttonCancelar.TabIndex = 83;
            this.buttonCancelar.Text = "Atrás";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // Historial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1251, 509);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.labelOperaciones);
            this.Controls.Add(this.labelEstrellas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelNumPag);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSigPag);
            this.Controls.Add(this.buttonPriPag);
            this.Controls.Add(this.buttonPaginaAnt);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelTitulo);
            this.Name = "Historial";
            this.Text = "Historial";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNumPag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSigPag;
        private System.Windows.Forms.Button buttonPriPag;
        private System.Windows.Forms.Button buttonPaginaAnt;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelEstrellas;
        private System.Windows.Forms.Label labelOperaciones;
        private System.Windows.Forms.Button buttonCancelar;
    }
}