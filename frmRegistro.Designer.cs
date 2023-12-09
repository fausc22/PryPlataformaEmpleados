namespace PryPlataformaEmpleados
{
    partial class frmRegistro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistro));
            this.bnInit = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.pbHuella = new System.Windows.Forms.PictureBox();
            this.gpForm = new System.Windows.Forms.GroupBox();
            this.optEgreso = new System.Windows.Forms.RadioButton();
            this.optIngreso = new System.Windows.Forms.RadioButton();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbHuella)).BeginInit();
            this.gpForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnInit
            // 
            this.bnInit.BackColor = System.Drawing.Color.NavajoWhite;
            this.bnInit.Enabled = false;
            this.bnInit.Location = new System.Drawing.Point(20, 208);
            this.bnInit.Name = "bnInit";
            this.bnInit.Size = new System.Drawing.Size(116, 44);
            this.bnInit.TabIndex = 0;
            this.bnInit.Text = "SIGUIENTE";
            this.bnInit.UseVisualStyleBackColor = false;
            this.bnInit.Click += new System.EventHandler(this.bnInit_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(137, 20);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(13, 13);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "0";
            this.lblId.Visible = false;
            // 
            // pbHuella
            // 
            this.pbHuella.Location = new System.Drawing.Point(208, 18);
            this.pbHuella.Name = "pbHuella";
            this.pbHuella.Size = new System.Drawing.Size(131, 174);
            this.pbHuella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbHuella.TabIndex = 9;
            this.pbHuella.TabStop = false;
            this.pbHuella.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pbHuella_LoadCompleted);
            this.pbHuella.LocationChanged += new System.EventHandler(this.pbHuella_LocationChanged);
            this.pbHuella.Paint += new System.Windows.Forms.PaintEventHandler(this.pbHuella_Paint);
            // 
            // gpForm
            // 
            this.gpForm.Controls.Add(this.optEgreso);
            this.gpForm.Controls.Add(this.optIngreso);
            this.gpForm.Controls.Add(this.btnRegistrar);
            this.gpForm.Controls.Add(this.label3);
            this.gpForm.Controls.Add(this.lblId);
            this.gpForm.Controls.Add(this.txtNombre);
            this.gpForm.Controls.Add(this.txtMail);
            this.gpForm.Controls.Add(this.label1);
            this.gpForm.Controls.Add(this.bnInit);
            this.gpForm.Controls.Add(this.pbHuella);
            this.gpForm.Location = new System.Drawing.Point(9, 10);
            this.gpForm.Margin = new System.Windows.Forms.Padding(2);
            this.gpForm.Name = "gpForm";
            this.gpForm.Padding = new System.Windows.Forms.Padding(2);
            this.gpForm.Size = new System.Drawing.Size(373, 279);
            this.gpForm.TabIndex = 10;
            this.gpForm.TabStop = false;
            this.gpForm.Text = "INGRESE SUS DATOS";
            this.gpForm.Enter += new System.EventHandler(this.gpForm_Enter);
            // 
            // optEgreso
            // 
            this.optEgreso.AutoSize = true;
            this.optEgreso.Enabled = false;
            this.optEgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optEgreso.Location = new System.Drawing.Point(31, 172);
            this.optEgreso.Margin = new System.Windows.Forms.Padding(2);
            this.optEgreso.Name = "optEgreso";
            this.optEgreso.Size = new System.Drawing.Size(97, 22);
            this.optEgreso.TabIndex = 18;
            this.optEgreso.TabStop = true;
            this.optEgreso.Text = "EGRESO";
            this.optEgreso.UseVisualStyleBackColor = true;
            this.optEgreso.CheckedChanged += new System.EventHandler(this.optEgreso_CheckedChanged);
            // 
            // optIngreso
            // 
            this.optIngreso.AutoSize = true;
            this.optIngreso.Enabled = false;
            this.optIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optIngreso.Location = new System.Drawing.Point(31, 146);
            this.optIngreso.Margin = new System.Windows.Forms.Padding(2);
            this.optIngreso.Name = "optIngreso";
            this.optIngreso.Size = new System.Drawing.Size(102, 22);
            this.optIngreso.TabIndex = 17;
            this.optIngreso.TabStop = true;
            this.optIngreso.Text = "INGRESO";
            this.optIngreso.UseVisualStyleBackColor = true;
            this.optIngreso.CheckedChanged += new System.EventHandler(this.optIngreso_CheckedChanged);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnRegistrar.Location = new System.Drawing.Point(225, 208);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(114, 44);
            this.btnRegistrar.TabIndex = 16;
            this.btnRegistrar.Text = "REGISTRAR";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Visible = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(53, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "EMAIL";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(20, 49);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(128, 20);
            this.txtNombre.TabIndex = 14;
            this.txtNombre.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtMail
            // 
            this.txtMail.Enabled = false;
            this.txtMail.Location = new System.Drawing.Point(19, 106);
            this.txtMail.Margin = new System.Windows.Forms.Padding(2);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(128, 20);
            this.txtMail.TabIndex = 13;
            this.txtMail.TextChanged += new System.EventHandler(this.txtMail_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "NOMBRE";
            // 
            // frmRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(395, 311);
            this.Controls.Add(this.gpForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRegistro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PUNTO SUR MULTIMERCADO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegistro_FormClosing);
            this.Load += new System.EventHandler(this.frmRegistro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbHuella)).EndInit();
            this.gpForm.ResumeLayout(false);
            this.gpForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bnInit;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.PictureBox pbHuella;
        private System.Windows.Forms.GroupBox gpForm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton optEgreso;
        private System.Windows.Forms.RadioButton optIngreso;
        private System.Windows.Forms.Button btnRegistrar;
    }
}

