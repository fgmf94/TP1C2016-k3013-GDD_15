namespace WindowsFormsApplication1.Listado_Estadistico
{
    partial class Seleccionar
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
            this.buttonListado1 = new System.Windows.Forms.Button();
            this.buttonListado2 = new System.Windows.Forms.Button();
            this.buttonListado3 = new System.Windows.Forms.Button();
            this.buttonListado4 = new System.Windows.Forms.Button();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.comboBoxAño = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxTri = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonListado1
            // 
            this.buttonListado1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonListado1.Location = new System.Drawing.Point(12, 124);
            this.buttonListado1.Name = "buttonListado1";
            this.buttonListado1.Size = new System.Drawing.Size(284, 56);
            this.buttonListado1.TabIndex = 199;
            this.buttonListado1.Text = "Vendedores con mayor cantidad de productos no vendidos";
            this.buttonListado1.UseVisualStyleBackColor = true;
            this.buttonListado1.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonListado2
            // 
            this.buttonListado2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonListado2.Location = new System.Drawing.Point(308, 124);
            this.buttonListado2.Name = "buttonListado2";
            this.buttonListado2.Size = new System.Drawing.Size(284, 56);
            this.buttonListado2.TabIndex = 200;
            this.buttonListado2.Text = "Clientes con mayor cantidad de productos comprados";
            this.buttonListado2.UseVisualStyleBackColor = true;
            // 
            // buttonListado3
            // 
            this.buttonListado3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonListado3.Location = new System.Drawing.Point(12, 186);
            this.buttonListado3.Name = "buttonListado3";
            this.buttonListado3.Size = new System.Drawing.Size(284, 56);
            this.buttonListado3.TabIndex = 201;
            this.buttonListado3.Text = "Vendedores con mayor cantidad de facturas";
            this.buttonListado3.UseVisualStyleBackColor = true;
            // 
            // buttonListado4
            // 
            this.buttonListado4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonListado4.Location = new System.Drawing.Point(308, 186);
            this.buttonListado4.Name = "buttonListado4";
            this.buttonListado4.Size = new System.Drawing.Size(284, 56);
            this.buttonListado4.TabIndex = 202;
            this.buttonListado4.Text = "Vendedores con mayor monto facturado";
            this.buttonListado4.UseVisualStyleBackColor = true;
            this.buttonListado4.Click += new System.EventHandler(this.button3_Click);
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelTitulo.Location = new System.Drawing.Point(223, 18);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(174, 25);
            this.labelTitulo.TabIndex = 203;
            this.labelTitulo.Text = "Listado Estadístico";
            // 
            // comboBoxAño
            // 
            this.comboBoxAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAño.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAño.Location = new System.Drawing.Point(126, 68);
            this.comboBoxAño.Name = "comboBoxAño";
            this.comboBoxAño.Size = new System.Drawing.Size(170, 28);
            this.comboBoxAño.TabIndex = 205;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 20);
            this.label7.TabIndex = 204;
            this.label7.Text = "Año";
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
            this.comboBoxTri.Location = new System.Drawing.Point(422, 68);
            this.comboBoxTri.Name = "comboBoxTri";
            this.comboBoxTri.Size = new System.Drawing.Size(170, 28);
            this.comboBoxTri.TabIndex = 207;
            this.comboBoxTri.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(308, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 206;
            this.label1.Text = "Trimestre";
            // 
            // Seleccionar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(604, 249);
            this.Controls.Add(this.comboBoxTri);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxAño);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.buttonListado4);
            this.Controls.Add(this.buttonListado3);
            this.Controls.Add(this.buttonListado2);
            this.Controls.Add(this.buttonListado1);
            this.Name = "Seleccionar";
            this.Text = "Seleccionar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonListado1;
        private System.Windows.Forms.Button buttonListado2;
        private System.Windows.Forms.Button buttonListado3;
        private System.Windows.Forms.Button buttonListado4;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.ComboBox comboBoxAño;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxTri;
        private System.Windows.Forms.Label label1;
    }
}