﻿namespace ProyectoProgra
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscarNombre = new System.Windows.Forms.TextBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.btnLeerProductos = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCantProducto = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtPrecioU = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.lblIdProducto = new System.Windows.Forms.Label();
            this.txtIdProducto = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.actualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(48, 336);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(124, 16);
            this.lblBuscar.TabIndex = 37;
            this.lblBuscar.Text = "Buscar por nombre:";
            // 
            // txtBuscarNombre
            // 
            this.txtBuscarNombre.Location = new System.Drawing.Point(105, 356);
            this.txtBuscarNombre.Name = "txtBuscarNombre";
            this.txtBuscarNombre.Size = new System.Drawing.Size(116, 22);
            this.txtBuscarNombre.TabIndex = 36;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Location = new System.Drawing.Point(24, 355);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(75, 24);
            this.btnBuscarCliente.TabIndex = 35;
            this.btnBuscarCliente.Text = "Buscar";
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(80, 261);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 24);
            this.btnEliminar.TabIndex = 34;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(80, 289);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 24);
            this.btnEditar.TabIndex = 33;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(251, 101);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.RowTemplate.Height = 24;
            this.dgvProductos.Size = new System.Drawing.Size(526, 427);
            this.dgvProductos.TabIndex = 32;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);
            // 
            // btnLeerProductos
            // 
            this.btnLeerProductos.Location = new System.Drawing.Point(70, 399);
            this.btnLeerProductos.Name = "btnLeerProductos";
            this.btnLeerProductos.Size = new System.Drawing.Size(94, 29);
            this.btnLeerProductos.TabIndex = 31;
            this.btnLeerProductos.Text = "Leer Datos";
            this.btnLeerProductos.UseVisualStyleBackColor = true;
            this.btnLeerProductos.Click += new System.EventHandler(this.btnLeerClientes_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(80, 232);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 24);
            this.btnGuardar.TabIndex = 30;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(43, 201);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(64, 16);
            this.lblCantidad.TabIndex = 29;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // txtCantProducto
            // 
            this.txtCantProducto.Location = new System.Drawing.Point(120, 198);
            this.txtCantProducto.Name = "txtCantProducto";
            this.txtCantProducto.Size = new System.Drawing.Size(116, 22);
            this.txtCantProducto.TabIndex = 28;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(12, 166);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(98, 16);
            this.lblTelefono.TabIndex = 27;
            this.lblTelefono.Text = "Precio Unitario:";
            this.lblTelefono.Click += new System.EventHandler(this.lblTelefono_Click);
            // 
            // txtPrecioU
            // 
            this.txtPrecioU.Location = new System.Drawing.Point(120, 166);
            this.txtPrecioU.Name = "txtPrecioU";
            this.txtPrecioU.Size = new System.Drawing.Size(116, 22);
            this.txtPrecioU.TabIndex = 26;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(48, 133);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(59, 16);
            this.lblNombre.TabIndex = 25;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Location = new System.Drawing.Point(120, 133);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(116, 22);
            this.txtNombreProducto.TabIndex = 24;
            // 
            // lblIdProducto
            // 
            this.lblIdProducto.AutoSize = true;
            this.lblIdProducto.Location = new System.Drawing.Point(84, 101);
            this.lblIdProducto.Name = "lblIdProducto";
            this.lblIdProducto.Size = new System.Drawing.Size(23, 16);
            this.lblIdProducto.TabIndex = 39;
            this.lblIdProducto.Text = "ID:";
            // 
            // txtIdProducto
            // 
            this.txtIdProducto.Location = new System.Drawing.Point(120, 101);
            this.txtIdProducto.Name = "txtIdProducto";
            this.txtIdProducto.ReadOnly = true;
            this.txtIdProducto.Size = new System.Drawing.Size(116, 22);
            this.txtIdProducto.TabIndex = 38;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualizarToolStripMenuItem,
            this.informaciónToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 52);
            // 
            // actualizarToolStripMenuItem
            // 
            this.actualizarToolStripMenuItem.Name = "actualizarToolStripMenuItem";
            this.actualizarToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.actualizarToolStripMenuItem.Text = "Actualizar";
            this.actualizarToolStripMenuItem.Click += new System.EventHandler(this.actualizarToolStripMenuItem_Click);
            // 
            // informaciónToolStripMenuItem
            // 
            this.informaciónToolStripMenuItem.Name = "informaciónToolStripMenuItem";
            this.informaciónToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.informaciónToolStripMenuItem.Text = "Información";
            this.informaciónToolStripMenuItem.Click += new System.EventHandler(this.informaciónToolStripMenuItem_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 547);
            this.Controls.Add(this.lblIdProducto);
            this.Controls.Add(this.txtIdProducto);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscarNombre);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.btnLeerProductos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.txtCantProducto);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtPrecioU);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombreProducto);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscarNombre;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnLeerProductos;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantProducto;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtPrecioU;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.Label lblIdProducto;
        private System.Windows.Forms.TextBox txtIdProducto;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informaciónToolStripMenuItem;
    }
}