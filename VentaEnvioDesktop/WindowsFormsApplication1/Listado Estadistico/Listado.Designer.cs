namespace WindowsFormsApplication1.Listado_Estadistico
{
    partial class Listado
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.buttonFiltrar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.comboBoxTri = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxAño = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxRubro = new System.Windows.Forms.ComboBox();
            this.labelRubro = new System.Windows.Forms.Label();
            this.labelVisi = new System.Windows.Forms.Label();
            this.chkListaVisibilidades = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(376, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(843, 220);
            this.dataGridView1.TabIndex = 53;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelTitulo.Location = new System.Drawing.Point(352, 18);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(69, 25);
            this.labelTitulo.TabIndex = 54;
            this.labelTitulo.Text = "Top 5:";
            this.labelTitulo.Click += new System.EventHandler(this.labelTitulo_Click);
            // 
            // buttonFiltrar
            // 
            this.buttonFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonFiltrar.Location = new System.Drawing.Point(376, 308);
            this.buttonFiltrar.Name = "buttonFiltrar";
            this.buttonFiltrar.Size = new System.Drawing.Size(172, 38);
            this.buttonFiltrar.TabIndex = 61;
            this.buttonFiltrar.Text = "Filtrar";
            this.buttonFiltrar.UseVisualStyleBackColor = true;
            this.buttonFiltrar.Click += new System.EventHandler(this.buttonFiltrar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonCancelar.Location = new System.Drawing.Point(22, 308);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(98, 38);
            this.buttonCancelar.TabIndex = 60;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // comboBoxTri
            // 
            this.comboBoxTri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTri.Items.AddRange(new object[] {
            "1º Trimestre",
            "2º Trimestre",
            "3º Trimestre",
            "4º Trimestre"});
            this.comboBoxTri.Location = new System.Drawing.Point(153, 110);
            this.comboBoxTri.Name = "comboBoxTri";
            this.comboBoxTri.Size = new System.Drawing.Size(209, 28);
            this.comboBoxTri.TabIndex = 211;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 210;
            this.label1.Text = "Trimestre";
            // 
            // comboBoxAño
            // 
            this.comboBoxAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAño.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAño.Location = new System.Drawing.Point(153, 65);
            this.comboBoxAño.Name = "comboBoxAño";
            this.comboBoxAño.Size = new System.Drawing.Size(209, 28);
            this.comboBoxAño.TabIndex = 209;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(39, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 20);
            this.label7.TabIndex = 208;
            this.label7.Text = "Año";
            // 
            // comboBoxRubro
            // 
            this.comboBoxRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRubro.Location = new System.Drawing.Point(153, 154);
            this.comboBoxRubro.Name = "comboBoxRubro";
            this.comboBoxRubro.Size = new System.Drawing.Size(209, 28);
            this.comboBoxRubro.TabIndex = 213;
            // 
            // labelRubro
            // 
            this.labelRubro.AutoSize = true;
            this.labelRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRubro.Location = new System.Drawing.Point(39, 157);
            this.labelRubro.Name = "labelRubro";
            this.labelRubro.Size = new System.Drawing.Size(53, 20);
            this.labelRubro.TabIndex = 212;
            this.labelRubro.Text = "Rubro";
            // 
            // labelVisi
            // 
            this.labelVisi.AutoSize = true;
            this.labelVisi.Location = new System.Drawing.Point(98, 151);
            this.labelVisi.Name = "labelVisi";
            this.labelVisi.Size = new System.Drawing.Size(208, 13);
            this.labelVisi.TabIndex = 215;
            this.labelVisi.Text = "Hacer doble click para marcar visibilidades";
            this.labelVisi.Click += new System.EventHandler(this.label4_Click);
            // 
            // chkListaVisibilidades
            // 
            this.chkListaVisibilidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkListaVisibilidades.FormattingEnabled = true;
            this.chkListaVisibilidades.Location = new System.Drawing.Point(43, 167);
            this.chkListaVisibilidades.Name = "chkListaVisibilidades";
            this.chkListaVisibilidades.Size = new System.Drawing.Size(319, 118);
            this.chkListaVisibilidades.TabIndex = 214;
            this.chkListaVisibilidades.SelectedIndexChanged += new System.EventHandler(this.chkListaRubros_SelectedIndexChanged);
            // 
            // Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1249, 358);
            this.Controls.Add(this.labelVisi);
            this.Controls.Add(this.chkListaVisibilidades);
            this.Controls.Add(this.comboBoxRubro);
            this.Controls.Add(this.labelRubro);
            this.Controls.Add(this.comboBoxTri);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxAño);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonFiltrar);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Listado";
            this.Text = "Listado";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Button buttonFiltrar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.ComboBox comboBoxTri;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxAño;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxRubro;
        private System.Windows.Forms.Label labelRubro;
        private System.Windows.Forms.Label labelVisi;
        private System.Windows.Forms.CheckedListBox chkListaVisibilidades;
    }
}