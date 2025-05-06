using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace ProyectoProgra
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            string ruta = @"C:\Users\Adal\Documents\2025 CUNOR\Introducción a Progra\archivosProyecto\productos.txt";

            int id = File.Exists(ruta) ? File.ReadAllLines(ruta).Length : 0;

            string NombreProducto = txtNombreProducto.Text;
            string cantidad = txtCantProducto.Text;
            string precioU = txtPrecioU.Text;

            if (string.IsNullOrWhiteSpace(NombreProducto) || string.IsNullOrWhiteSpace(cantidad) || string.IsNullOrWhiteSpace(precioU))
            {
                MessageBox.Show("Por favor completa todos los campos");
                return;
            }

            if (!int.TryParse(cantidad, out _) || !decimal.TryParse(precioU, out _))
            {
                MessageBox.Show("Cantidad debe ser número entero y precio un número válido.");
                return;
            }

            string linea = $"{id}|{NombreProducto}|{cantidad}|{precioU}";

            try
            {

                File.AppendAllText(@"C:\Users\Adal\Documents\2025 CUNOR\Introducción a Progra\archivosProyecto\productos.txt", linea + Environment.NewLine);

                MessageBox.Show("Producto guardado correctamente");
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void LimpiarCampos()
        {
            txtIdProducto.Clear();
            txtNombreProducto.Clear();
            txtCantProducto.Clear();
            txtPrecioU.Clear();
            txtIdProducto.Focus();
        }

        private void btnLeerClientes_Click(object sender, EventArgs e)
        {


            string rutaArchivo = @"C:\Users\Adal\Documents\2025 CUNOR\Introducción a Progra\archivosProyecto\productos.txt";

            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("El archivo de productos no existe.");
                return;
            }

            DataTable tabla = new DataTable();
            tabla.Columns.Add("ID");
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Cantidad");
            tabla.Columns.Add("Precio U");

            try
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);
                foreach (string linea in lineas)
                {
                    string[] campos = linea.Split('|');
                    if (campos.Length == 4)
                    {
                        tabla.Rows.Add(campos);
                    }
                }

                dgvProductos.DataSource = tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el archivo: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                dgvProductos.Rows.RemoveAt(dgvProductos.SelectedRows[0].Index);
                GuardarCambiosEnArchivo();
                MessageBox.Show("Producto eliminado correctamente.");
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para eliminar.");
            }
        }
        private void GuardarCambiosEnArchivo()
        {


            string rutaArchivo = @"C:\Users\Adal\Documents\2025 CUNOR\Introducción a Progra\archivosProyecto\productos.txt";

            List<string> lineas = new List<string>();

            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                if (!fila.IsNewRow)
                {
                    string id = fila.Cells["ID"].Value?.ToString() ?? "0";
                    string nombre = fila.Cells["Nombre"].Value?.ToString() ?? "";
                    string cantidad = fila.Cells["Cantidad"].Value?.ToString() ?? "0";
                    string precioU = fila.Cells["Precio U"].Value?.ToString() ?? "0";
                    string linea = $"{id}|{nombre}|{cantidad}|{precioU}";
                    lineas.Add(linea); 
                }
            }

            File.WriteAllLines(rutaArchivo, lineas);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {


            string ruta = @"C:\Users\Adal\2025 CUNOR\Introducción a Progra\archivosProyecto\productos.txt";

            int id = File.Exists(ruta) ? File.ReadAllLines(ruta).Length : 0;

            string NombreProducto = txtNombreProducto.Text;
            string cantidad = txtCantProducto.Text;
            string precioU = txtPrecioU.Text;

            if (string.IsNullOrWhiteSpace(NombreProducto) || string.IsNullOrWhiteSpace(cantidad) || string.IsNullOrWhiteSpace(precioU))
            {
                MessageBox.Show("Por favor completa todos los campos");
                return;
            }

            if (!int.TryParse(cantidad, out _) || !decimal.TryParse(precioU, out _))
            {
                MessageBox.Show("Cantidad debe ser número entero y precio un número válido.");
                return;
            }

            if (dgvProductos.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvProductos.SelectedRows[0];

                fila.Cells["ID"].Value = id;
                fila.Cells["Nombre"].Value = NombreProducto;
                fila.Cells["Cantidad"].Value = cantidad;
                fila.Cells["Precio U"].Value = precioU;

                GuardarCambiosEnArchivo();

                MessageBox.Show("Producto editado correctamente.");
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para editar.");
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtIdProducto.Text = dgvProductos.Rows[e.RowIndex].Cells["ID"].Value?.ToString();
                txtNombreProducto.Text = dgvProductos.Rows[e.RowIndex].Cells["Nombre"].Value?.ToString();
                txtCantProducto.Text = dgvProductos.Rows[e.RowIndex].Cells["Cantidad"].Value?.ToString();
                txtPrecioU.Text = dgvProductos.Rows[e.RowIndex].Cells["Precio U"].Value?.ToString();
            }
        }
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string buscar = txtBuscarNombre.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(buscar))
            {
                MessageBox.Show("Ingresa un nombre para buscar.");
                return;
            }

            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                if (!fila.IsNewRow)
                {
                    string nombre = fila.Cells["Nombre"].Value?.ToString().ToLower();
                    if (nombre.Contains(buscar))
                    {
                        fila.Selected = true;
                        dgvProductos.FirstDisplayedScrollingRowIndex = fila.Index;
                        return;
                    }
                }
            }

            MessageBox.Show("No se encontró ningún producto con ese nombre.");
        }

        private void lblTelefono_Click(object sender, EventArgs e)
        {

        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Actualizando...");
        }

        private void informaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Versión 1.0 - Proyecto de Práctica.");
        }
    }
    
}
