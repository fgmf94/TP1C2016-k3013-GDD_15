namespace WindowsFormsApplication1.Calificar
{
    partial class CalificarOperacion
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtTextoLibre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxDetalle = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxEstrellas = new System.Windows.Forms.ComboBox();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodOpe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 200;
            this.label4.Text = "Texto Libre";
            // 
            // txtTextoLibre
            // 
            this.txtTextoLibre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTextoLibre.Location = new System.Drawing.Point(200, 244);
            this.txtTextoLibre.Name = "txtTextoLibre";
            this.txtTextoLibre.ReadOnly = true;
            this.txtTextoLibre.Size = new System.Drawing.Size(230, 26);
            this.txtTextoLibre.TabIndex = 199;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 198;
            this.label3.Text = "Detalle";
            // 
            // comboBoxDetalle
            // 
            this.comboBoxDetalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBoxDetalle.FormattingEnabled = true;
            this.comboBoxDetalle.Items.AddRange(new object[] {
            "Texto libre",
            "Malo",
            "Medio",
            "Bueno",
            "Muy bueno",
            "Excelente"});
            this.comboBoxDetalle.Location = new System.Drawing.Point(200, 190);
            this.comboBoxDetalle.Name = "comboBoxDetalle";
            this.comboBoxDetalle.Size = new System.Drawing.Size(230, 28);
            this.comboBoxDetalle.TabIndex = 197;
            this.comboBoxDetalle.SelectedIndexChanged += new System.EventHandler(this.comboBoxDetalle_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(44, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 196;
            this.label5.Text = "Estrellas";
            // 
            // comboBoxEstrellas
            // 
            this.comboBoxEstrellas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstrellas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBoxEstrellas.FormattingEnabled = true;
            this.comboBoxEstrellas.Items.AddRange(new object[] {
            "★",
            "★★",
            "★★★",
            "★★★★",
            "★★★★★"});
            this.comboBoxEstrellas.Location = new System.Drawing.Point(200, 132);
            this.comboBoxEstrellas.Name = "comboBoxEstrellas";
            this.comboBoxEstrellas.Size = new System.Drawing.Size(230, 28);
            this.comboBoxEstrellas.TabIndex = 195;
            this.comboBoxEstrellas.SelectedIndexChanged += new System.EventHandler(this.comboBoxEstrellas_SelectedIndexChanged);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonGuardar.Location = new System.Drawing.Point(313, 294);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(117, 58);
            this.buttonGuardar.TabIndex = 194;
            this.buttonGuardar.Text = "Calificar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(48, 294);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 58);
            this.button2.TabIndex = 193;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 20);
            this.label2.TabIndex = 192;
            this.label2.Text = "Código Operación";
            // 
            // txtCodOpe
            // 
            this.txtCodOpe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodOpe.Location = new System.Drawing.Point(200, 75);
            this.txtCodOpe.Name = "txtCodOpe";
            this.txtCodOpe.ReadOnly = true;
            this.txtCodOpe.Size = new System.Drawing.Size(230, 26);
            this.txtCodOpe.TabIndex = 191;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(158, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 190;
            this.label1.Text = "Calificar Compra";
            // 
            // CalificarOperacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(474, 375);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTextoLibre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxDetalle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxEstrellas);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodOpe);
            this.Controls.Add(this.label1);
            this.Name = "CalificarOperacion";
            this.Text = "Calificar Operacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTextoLibre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxDetalle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxEstrellas;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodOpe;
        private System.Windows.Forms.Label label1;

    }
}