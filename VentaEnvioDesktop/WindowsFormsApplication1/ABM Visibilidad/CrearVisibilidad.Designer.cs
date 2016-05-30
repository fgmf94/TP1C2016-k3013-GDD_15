namespace WindowsFormsApplication1.ABM_Visibilidad
{
    partial class CrearVisibilidad
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreVisibilidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCPrecio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCPorcentaje = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCEnvio = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(163, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "Crear Visibilidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Nombre de Visibilidad";
            // 
            // txtNombreVisibilidad
            // 
            this.txtNombreVisibilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreVisibilidad.Location = new System.Drawing.Point(205, 74);
            this.txtNombreVisibilidad.Name = "txtNombreVisibilidad";
            this.txtNombreVisibilidad.Size = new System.Drawing.Size(230, 26);
            this.txtNombreVisibilidad.TabIndex = 19;
            this.txtNombreVisibilidad.TextChanged += new System.EventHandler(this.txtNombreVisibilidad_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Comisión Precio";
            // 
            // txtCPrecio
            // 
            this.txtCPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPrecio.Location = new System.Drawing.Point(205, 121);
            this.txtCPrecio.Name = "txtCPrecio";
            this.txtCPrecio.Size = new System.Drawing.Size(230, 26);
            this.txtCPrecio.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Comisión Porcentaje";
            // 
            // txtCPorcentaje
            // 
            this.txtCPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPorcentaje.Location = new System.Drawing.Point(205, 172);
            this.txtCPorcentaje.Name = "txtCPorcentaje";
            this.txtCPorcentaje.Size = new System.Drawing.Size(230, 26);
            this.txtCPorcentaje.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "Comisión Envio ";
            // 
            // txtCEnvio
            // 
            this.txtCEnvio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCEnvio.Location = new System.Drawing.Point(205, 226);
            this.txtCEnvio.Name = "txtCEnvio";
            this.txtCEnvio.Size = new System.Drawing.Size(230, 26);
            this.txtCEnvio.TabIndex = 27;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(43, 278);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 58);
            this.button2.TabIndex = 29;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonGuardar.Location = new System.Drawing.Point(318, 278);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(117, 58);
            this.buttonGuardar.TabIndex = 30;
            this.buttonGuardar.Text = "Agregar Visibilidad";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(402, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 20);
            this.label6.TabIndex = 31;
            this.label6.Text = "%";
            // 
            // CrearVisibilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(502, 365);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCEnvio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCPorcentaje);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCPrecio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombreVisibilidad);
            this.Controls.Add(this.label1);
            this.Name = "CrearVisibilidad";
            this.Text = "Crear Visibilidad";
            this.Load += new System.EventHandler(this.CrearVisibilidad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreVisibilidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCPrecio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCPorcentaje;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCEnvio;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Label label6;
    }
}