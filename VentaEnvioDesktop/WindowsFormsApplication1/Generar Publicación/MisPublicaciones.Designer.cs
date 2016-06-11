namespace WindowsFormsApplication1.Generar_Publicación
{
    partial class MisPublicaciones
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
            this.buttonPausar = new System.Windows.Forms.Button();
            this.buttonFinalizar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonActivar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPausar
            // 
            this.buttonPausar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPausar.Location = new System.Drawing.Point(359, 342);
            this.buttonPausar.Name = "buttonPausar";
            this.buttonPausar.Size = new System.Drawing.Size(117, 58);
            this.buttonPausar.TabIndex = 69;
            this.buttonPausar.Text = "Pausar";
            this.buttonPausar.UseVisualStyleBackColor = true;
            // 
            // buttonFinalizar
            // 
            this.buttonFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonFinalizar.Location = new System.Drawing.Point(725, 342);
            this.buttonFinalizar.Name = "buttonFinalizar";
            this.buttonFinalizar.Size = new System.Drawing.Size(117, 58);
            this.buttonFinalizar.TabIndex = 68;
            this.buttonFinalizar.Text = "Finalizar";
            this.buttonFinalizar.UseVisualStyleBackColor = true;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(41, 342);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(117, 58);
            this.buttonCancelar.TabIndex = 67;
            this.buttonCancelar.Text = "Atrás";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(41, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1148, 257);
            this.dataGridView1.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(522, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 25);
            this.label1.TabIndex = 65;
            this.label1.Text = "Mis Publicaciones";
            // 
            // buttonActivar
            // 
            this.buttonActivar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonActivar.Location = new System.Drawing.Point(1072, 342);
            this.buttonActivar.Name = "buttonActivar";
            this.buttonActivar.Size = new System.Drawing.Size(117, 58);
            this.buttonActivar.TabIndex = 70;
            this.buttonActivar.Text = "Activar";
            this.buttonActivar.UseVisualStyleBackColor = true;
            this.buttonActivar.Click += new System.EventHandler(this.buttonActivar_Click);
            // 
            // MisPublicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1235, 424);
            this.Controls.Add(this.buttonActivar);
            this.Controls.Add(this.buttonPausar);
            this.Controls.Add(this.buttonFinalizar);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "MisPublicaciones";
            this.Text = "Mis Publicaciones";
            this.Load += new System.EventHandler(this.MisPublicaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPausar;
        private System.Windows.Forms.Button buttonFinalizar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonActivar;

    }
}