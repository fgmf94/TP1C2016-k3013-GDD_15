namespace WindowsFormsApplication1.Generar_Publicación
{
    partial class CrearPublicacion
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
            this.label5 = new System.Windows.Forms.Label();
            this.labelPrecio = new System.Windows.Forms.Label();
            this.labelStock = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodPub = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxVisi = new System.Windows.Forms.ComboBox();
            this.txtDescrip = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.comboBoxRubro = new System.Windows.Forms.ComboBox();
            this.dateFechaVen = new System.Windows.Forms.DateTimePicker();
            this.chkEnvio = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(57, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 39;
            this.label5.Text = "Rubro";
            // 
            // labelPrecio
            // 
            this.labelPrecio.AutoSize = true;
            this.labelPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecio.Location = new System.Drawing.Point(56, 243);
            this.labelPrecio.Name = "labelPrecio";
            this.labelPrecio.Size = new System.Drawing.Size(109, 20);
            this.labelPrecio.TabIndex = 37;
            this.labelPrecio.Text = "Precio unitario";
            // 
            // labelStock
            // 
            this.labelStock.AutoSize = true;
            this.labelStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStock.Location = new System.Drawing.Point(57, 198);
            this.labelStock.Name = "labelStock";
            this.labelStock.Size = new System.Drawing.Size(50, 20);
            this.labelStock.TabIndex = 35;
            this.labelStock.Text = "Stock";
            this.labelStock.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "Descripción";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelTitulo.Location = new System.Drawing.Point(120, 23);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(268, 25);
            this.labelTitulo.TabIndex = 31;
            this.labelTitulo.Text = "Crear Publicación de Compra";
            this.labelTitulo.Click += new System.EventHandler(this.label1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(56, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 20);
            this.label6.TabIndex = 43;
            this.label6.Text = "Código de publicación";
            // 
            // txtCodPub
            // 
            this.txtCodPub.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodPub.Location = new System.Drawing.Point(223, 62);
            this.txtCodPub.Name = "txtCodPub";
            this.txtCodPub.ReadOnly = true;
            this.txtCodPub.Size = new System.Drawing.Size(230, 26);
            this.txtCodPub.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(56, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 136;
            this.label7.Text = "Visibilidad";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(57, 333);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 20);
            this.label13.TabIndex = 140;
            this.label13.Text = "Fecha Vencimiento";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(56, 367);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 20);
            this.label8.TabIndex = 141;
            this.label8.Text = "Permite Envío";
            // 
            // comboBoxVisi
            // 
            this.comboBoxVisi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxVisi.Location = new System.Drawing.Point(223, 105);
            this.comboBoxVisi.Name = "comboBoxVisi";
            this.comboBoxVisi.Size = new System.Drawing.Size(230, 28);
            this.comboBoxVisi.TabIndex = 143;
            this.comboBoxVisi.SelectedIndexChanged += new System.EventHandler(this.comboBoxVisi_SelectedIndexChanged);
            // 
            // txtDescrip
            // 
            this.txtDescrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescrip.Location = new System.Drawing.Point(223, 150);
            this.txtDescrip.Name = "txtDescrip";
            this.txtDescrip.Size = new System.Drawing.Size(230, 26);
            this.txtDescrip.TabIndex = 144;
            // 
            // txtStock
            // 
            this.txtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStock.Location = new System.Drawing.Point(223, 195);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(230, 26);
            this.txtStock.TabIndex = 145;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(223, 240);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(230, 26);
            this.txtPrecio.TabIndex = 146;
            // 
            // comboBoxRubro
            // 
            this.comboBoxRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRubro.Location = new System.Drawing.Point(223, 289);
            this.comboBoxRubro.Name = "comboBoxRubro";
            this.comboBoxRubro.Size = new System.Drawing.Size(230, 28);
            this.comboBoxRubro.TabIndex = 147;
            // 
            // dateFechaVen
            // 
            this.dateFechaVen.Location = new System.Drawing.Point(223, 332);
            this.dateFechaVen.Name = "dateFechaVen";
            this.dateFechaVen.Size = new System.Drawing.Size(230, 20);
            this.dateFechaVen.TabIndex = 148;
            // 
            // chkEnvio
            // 
            this.chkEnvio.AutoSize = true;
            this.chkEnvio.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnvio.Location = new System.Drawing.Point(223, 373);
            this.chkEnvio.Name = "chkEnvio";
            this.chkEnvio.Size = new System.Drawing.Size(15, 14);
            this.chkEnvio.TabIndex = 149;
            this.chkEnvio.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(31, 410);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 58);
            this.button2.TabIndex = 150;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(197, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 58);
            this.button1.TabIndex = 151;
            this.button1.Text = "Guardar Borrador";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonGuardar.Location = new System.Drawing.Point(357, 410);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(117, 58);
            this.buttonGuardar.TabIndex = 152;
            this.buttonGuardar.Text = "Generar Publicación";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(199, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 153;
            this.label1.Text = "$";
            // 
            // CrearPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(508, 480);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.chkEnvio);
            this.Controls.Add(this.dateFechaVen);
            this.Controls.Add(this.comboBoxRubro);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtDescrip);
            this.Controls.Add(this.comboBoxVisi);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCodPub);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelPrecio);
            this.Controls.Add(this.labelStock);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelTitulo);
            this.Name = "CrearPublicacion";
            this.Text = "Crear Compra";
            this.Load += new System.EventHandler(this.CrearCompra_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelPrecio;
        private System.Windows.Forms.Label labelStock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodPub;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxVisi;
        private System.Windows.Forms.TextBox txtDescrip;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.ComboBox comboBoxRubro;
        private System.Windows.Forms.DateTimePicker dateFechaVen;
        private System.Windows.Forms.CheckBox chkEnvio;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Label label1;
    }
}