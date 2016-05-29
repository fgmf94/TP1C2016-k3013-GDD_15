namespace WindowsFormsApplication1.Elegir_Rol
{
    partial class EleccionRol
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
            this.comboBoxRoles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.boton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxRoles
            // 
            this.comboBoxRoles.FormattingEnabled = true;
            this.comboBoxRoles.Items.AddRange(new object[] {
            "Cliente",
            "Empresa",
            "Administrador"});
            this.comboBoxRoles.Location = new System.Drawing.Point(142, 69);
            this.comboBoxRoles.Name = "comboBoxRoles";
            this.comboBoxRoles.Size = new System.Drawing.Size(219, 21);
            this.comboBoxRoles.TabIndex = 0;
            this.comboBoxRoles.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione Rol";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // boton
            // 
            this.boton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.boton.Location = new System.Drawing.Point(142, 138);
            this.boton.Name = "boton";
            this.boton.Size = new System.Drawing.Size(219, 31);
            this.boton.TabIndex = 2;
            this.boton.Text = "Ingresar";
            this.boton.UseVisualStyleBackColor = true;
            this.boton.Click += new System.EventHandler(this.boton_Click);
            // 
            // EleccionRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(452, 225);
            this.Controls.Add(this.boton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxRoles);
            this.Name = "EleccionRol";
            this.Text = "Elegir Rol";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxRoles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button boton;
    }
}