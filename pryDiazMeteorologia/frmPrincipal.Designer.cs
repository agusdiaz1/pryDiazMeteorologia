namespace pryDiazMeteorologia
{
    partial class frmPrincipal
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
            this.lblFecha = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpFecha = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.stpSeleccion = new System.Windows.Forms.StatusStrip();
            this.tvUbicaciones = new System.Windows.Forms.TreeView();
            this.lvTemperaturas = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lblFecha
            // 
            this.lblFecha.BackColor = System.Drawing.Color.Transparent;
            this.lblFecha.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(12, 39);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(52, 18);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Checked = true;
            this.dtpFecha.FillColor = System.Drawing.Color.LavenderBlush;
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpFecha.Location = new System.Drawing.Point(85, 27);
            this.dtpFecha.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFecha.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(221, 42);
            this.dtpFecha.TabIndex = 1;
            this.dtpFecha.Value = new System.DateTime(2025, 10, 24, 2, 43, 42, 480);
            // 
            // stpSeleccion
            // 
            this.stpSeleccion.Location = new System.Drawing.Point(0, 344);
            this.stpSeleccion.Name = "stpSeleccion";
            this.stpSeleccion.Size = new System.Drawing.Size(645, 22);
            this.stpSeleccion.TabIndex = 2;
            this.stpSeleccion.Text = "---";
            // 
            // tvUbicaciones
            // 
            this.tvUbicaciones.Location = new System.Drawing.Point(12, 101);
            this.tvUbicaciones.Name = "tvUbicaciones";
            this.tvUbicaciones.Size = new System.Drawing.Size(225, 211);
            this.tvUbicaciones.TabIndex = 3;
            this.tvUbicaciones.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvUbicaciones_AfterSelect_1);
            // 
            // lvTemperaturas
            // 
            this.lvTemperaturas.HideSelection = false;
            this.lvTemperaturas.Location = new System.Drawing.Point(286, 101);
            this.lvTemperaturas.Name = "lvTemperaturas";
            this.lvTemperaturas.Size = new System.Drawing.Size(220, 211);
            this.lvTemperaturas.TabIndex = 4;
            this.lvTemperaturas.UseCompatibleStateImageBehavior = false;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 366);
            this.Controls.Add(this.lvTemperaturas);
            this.Controls.Add(this.tvUbicaciones);
            this.Controls.Add(this.stpSeleccion);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblFecha);
            this.Name = "frmPrincipal";
            this.Text = "Meteorologia - App";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblFecha;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFecha;
        private System.Windows.Forms.StatusStrip stpSeleccion;
        private System.Windows.Forms.TreeView tvUbicaciones;
        private System.Windows.Forms.ListView lvTemperaturas;
    }
}