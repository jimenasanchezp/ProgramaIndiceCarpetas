namespace ProgramaIndiceCarpetas
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.lblRuta = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvEstructura = new System.Windows.Forms.TreeView();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.colArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCarpeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRuta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.btnExportarArchivo = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.pnlBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.pnlTop.Controls.Add(this.btnActualizar);
            this.pnlTop.Controls.Add(this.btnSeleccionar);
            this.pnlTop.Controls.Add(this.txtRuta);
            this.pnlTop.Controls.Add(this.lblRuta);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(984, 65);
            this.pnlTop.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.White;
            this.btnActualizar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Location = new System.Drawing.Point(875, 18);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(95, 30);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.Text = "↻ Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSeleccionar.FlatAppearance.BorderSize = 0;
            this.btnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionar.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionar.Location = new System.Drawing.Point(755, 18);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(110, 30);
            this.btnSeleccionar.TabIndex = 2;
            this.btnSeleccionar.Text = "Examinar...";
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRuta.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuta.Location = new System.Drawing.Point(60, 21);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.ReadOnly = true;
            this.txtRuta.Size = new System.Drawing.Size(685, 29);
            this.txtRuta.TabIndex = 1;
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Location = new System.Drawing.Point(15, 25);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(42, 20);
            this.lblRuta.TabIndex = 0;
            this.lblRuta.Text = "Ruta:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 65);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvEstructura);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(15, 15, 5, 15);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvResultados);
            this.splitContainer1.Panel2.Controls.Add(this.pnlBusqueda);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5, 15, 15, 15);
            this.splitContainer1.Size = new System.Drawing.Size(984, 496);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 1;
            // 
            // tvEstructura
            // 
            this.tvEstructura.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvEstructura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvEstructura.ItemHeight = 24;
            this.tvEstructura.Location = new System.Drawing.Point(15, 15);
            this.tvEstructura.Name = "tvEstructura";
            this.tvEstructura.Size = new System.Drawing.Size(280, 466);
            this.tvEstructura.TabIndex = 0;
            // 
            // dgvResultados
            // 
            this.dgvResultados.AllowUserToAddRows = false;
            this.dgvResultados.AllowUserToDeleteRows = false;
            this.dgvResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResultados.BackgroundColor = System.Drawing.Color.White;
            this.dgvResultados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResultados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvResultados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResultados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResultados.ColumnHeadersHeight = 35;
            this.dgvResultados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colArchivo,
            this.colCarpeta,
            this.colRuta});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResultados.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResultados.EnableHeadersVisualStyles = false;
            this.dgvResultados.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvResultados.Location = new System.Drawing.Point(5, 65);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.ReadOnly = true;
            this.dgvResultados.RowHeadersVisible = false;
            this.dgvResultados.RowHeadersWidth = 51;
            this.dgvResultados.RowTemplate.Height = 28;
            this.dgvResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResultados.Size = new System.Drawing.Size(660, 416);
            this.dgvResultados.TabIndex = 1;
            // 
            // colArchivo
            // 
            this.colArchivo.HeaderText = "Nombre del Archivo";
            this.colArchivo.MinimumWidth = 6;
            this.colArchivo.Name = "colArchivo";
            this.colArchivo.ReadOnly = true;
            // 
            // colCarpeta
            // 
            this.colCarpeta.HeaderText = "Carpeta Contenedora";
            this.colCarpeta.MinimumWidth = 6;
            this.colCarpeta.Name = "colCarpeta";
            this.colCarpeta.ReadOnly = true;
            // 
            // colRuta
            // 
            this.colRuta.HeaderText = "Ruta Completa";
            this.colRuta.MinimumWidth = 6;
            this.colRuta.Name = "colRuta";
            this.colRuta.ReadOnly = true;
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.Controls.Add(this.btnExportarArchivo);
            this.pnlBusqueda.Controls.Add(this.btnBuscar);
            this.pnlBusqueda.Controls.Add(this.txtBuscar);
            this.pnlBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBusqueda.Location = new System.Drawing.Point(5, 15);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Size = new System.Drawing.Size(660, 50);
            this.pnlBusqueda.TabIndex = 0;
            // 
            // btnExportarArchivo
            // 
            this.btnExportarArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarArchivo.BackColor = System.Drawing.Color.White;
            this.btnExportarArchivo.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnExportarArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarArchivo.Location = new System.Drawing.Point(400, 0);
            this.btnExportarArchivo.Name = "btnExportarArchivo";
            this.btnExportarArchivo.Size = new System.Drawing.Size(160, 27);
            this.btnExportarArchivo.TabIndex = 2;
            this.btnExportarArchivo.Text = "📄 Exportar Archivo...";
            this.btnExportarArchivo.UseVisualStyleBackColor = false;
            this.btnExportarArchivo.Click += new System.EventHandler(this.btnExportarArchivo_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(575, 0);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(85, 27);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(0, 1);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(390, 30);
            this.txtBuscar.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Explorador";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Label lblRuta;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvEstructura;
        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCarpeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRuta;
        private System.Windows.Forms.Button btnExportarArchivo; // 🔹 BOTON NUEVO
    }
}