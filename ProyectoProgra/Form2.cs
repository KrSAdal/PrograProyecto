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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string ruta = @"C:\Users\Adal\Documents\2025 CUNOR\Introducción a Progra\archivosProyecto\clientes.txt";

            int id = File.Exists(ruta) ? File.ReadAllLines(ruta).Length : 0;
            string nombre = txtNombreCliente.Text;
            string telefono = txtTelefonoCliente.Text;
            string correo = txtCorreoCliente.Text;


            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(correo))
            {
                MessageBox.Show("Por favor completa todos los campos");
                return;
            }

            if (telefono.Length != 8 || !telefono.All(char.IsDigit))
            {
                MessageBox.Show("El número de teléfono debe tener exactamente 8 dígitos.");
                return;
            }

            if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("El correo electrónico no tiene un formato válido.");
                return;
            }


            string linea = $"{id}|{nombre}|{telefono}|{correo}";

            try
            {
                File.AppendAllText(@"C:\Users\Adal\Documents\2025 CUNOR\Introducción a Progra\archivosProyecto\clientes.txt", linea + Environment.NewLine);
                MessageBox.Show("Cliente guardado correctamente");
                LimpiarCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void btnLeerClientes_Click(object sender, EventArgs e)
        {

            string rutaArchivo = @"C:\Users\Adal\Documents\2025 CUNOR\Introducción a Progra\archivosProyecto\clientes.txt";

            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("El archivo de clientes no existe.");
                return;
            }

            DataTable tabla = new DataTable();
            tabla.Columns.Add("ID");
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Teléfono");
            tabla.Columns.Add("Correo");

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

                dgvClientes.DataSource = tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el archivo: " + ex.Message);
            }
        }
        private void LimpiarCampos()
        {
            txtIdCliente.Clear();
            txtNombreCliente.Clear();
            txtTelefonoCliente.Clear();
            txtCorreoCliente.Clear();
            txtNombreCliente.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            string ruta = @"C:\Users\Adal\Documents\2025 CUNOR\Introducción a Progra\archivosProyecto\clientes.txt";
            int id = File.Exists(ruta) ? File.ReadAllLines(ruta).Length : 0;
            string nombre = txtNombreCliente.Text;
            string telefono = txtTelefonoCliente.Text;
            string correo = txtCorreoCliente.Text;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(correo))
            {
                MessageBox.Show("Por favor completa todos los campos");
                return;
            }

            if (telefono.Length != 8 || !telefono.All(char.IsDigit))
            {
                MessageBox.Show("El número de teléfono debe tener exactamente 8 dígitos.");
                return;
            }

            if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("El correo electrónico no tiene un formato válido.");
                return;
            }


            if (dgvClientes.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvClientes.SelectedRows[0];

                fila.Cells["ID"].Value = nombre;
                fila.Cells["Nombre"].Value = nombre;
                fila.Cells["Teléfono"].Value = telefono;
                fila.Cells["Correo"].Value = correo;

                GuardarCambiosEnArchivo();

                MessageBox.Show("Cliente editado correctamente.");
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para editar.");
            }

        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtIdCliente.Text = dgvClientes.Rows[e.RowIndex].Cells["ID"].Value?.ToString();
                txtNombreCliente.Text = dgvClientes.Rows[e.RowIndex].Cells["Nombre"].Value?.ToString();
                txtTelefonoCliente.Text = dgvClientes.Rows[e.RowIndex].Cells["Teléfono"].Value?.ToString();
                txtCorreoCliente.Text = dgvClientes.Rows[e.RowIndex].Cells["Correo"].Value?.ToString();
            }
        }


        private void GuardarCambiosEnArchivo()
        {

            string rutaArchivo = @"C:\Users\Adal\Documents\2025 CUNOR\Introducción a Progra\archivosProyecto\archivosProyecto\clientes.txt";

            List<string> lineas = new List<string>();

            foreach (DataGridViewRow fila in dgvClientes.Rows)
            {
                if (!fila.IsNewRow)
                {
                    string id = fila.Cells["ID"].Value?.ToString() ?? "0";
                    string nombre = fila.Cells["Nombre"].Value?.ToString();
                    string telefono = fila.Cells["Teléfono"].Value?.ToString();    
                    string correo = fila.Cells["Correo"].Value?.ToString();
                    lineas.Add($"{id}|{nombre}|{telefono}|{correo}");
                }
            }

            File.WriteAllLines(rutaArchivo, lineas);
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                dgvClientes.Rows.RemoveAt(dgvClientes.SelectedRows[0].Index);
                GuardarCambiosEnArchivo();
                MessageBox.Show("Cliente eliminado correctamente.");
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para eliminar.");
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

            foreach (DataGridViewRow fila in dgvClientes.Rows)
            {
                if (!fila.IsNewRow)
                {
                    string nombre = fila.Cells["Nombre"].Value?.ToString().ToLower();
                    if (nombre.Contains(buscar))
                    {
                        fila.Selected = true;
                        dgvClientes.FirstDisplayedScrollingRowIndex = fila.Index;
                        return;
                    }
                }
            }

            MessageBox.Show("No se encontró ningún cliente con ese nombre.");
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
