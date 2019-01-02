namespace GenerateTypeScriptServicesFromWebApi
{
    partial class frmGenerador
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGenerarServicios = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerarServicios
            // 
            this.btnGenerarServicios.Location = new System.Drawing.Point(296, 65);
            this.btnGenerarServicios.Name = "btnGenerarServicios";
            this.btnGenerarServicios.Size = new System.Drawing.Size(235, 60);
            this.btnGenerarServicios.TabIndex = 0;
            this.btnGenerarServicios.Text = "Generar Servicios";
            this.btnGenerarServicios.UseVisualStyleBackColor = true;
            this.btnGenerarServicios.Click += new System.EventHandler(this.btnGenerarServicios_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ruta del Assembly";
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(167, 7);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(567, 22);
            this.txtRuta.TabIndex = 2;
            this.txtRuta.Text = "D:\\WorkSpace\\API-SPP\\WS_SPP\\bin\\WS_SPP.dll";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(740, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(74, 28);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmGenerador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 148);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerarServicios);
            this.Name = "frmGenerador";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerarServicios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Button btnBuscar;
    }
}

