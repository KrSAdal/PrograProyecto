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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public class Cliente
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public override string ToString()
            {
                return Nombre;
            }
        }

        List<CarritoItem> carrito = new List<CarritoItem>();

        class CarritoItem
        {
            public int IdProducto { get; set; } 
            public string Nombre { get; set; }
            public int Cantidad { get; set; }
            public decimal PrecioUnitario { get; set; }
            public decimal Total => Cantidad * PrecioUnitario;
        }



        private void CargarClientes()
        {
            string ruta = @"C:\Users\wander\Documents\2025 CUNOR\Introducción a Progra\archivosProyecto\clientes.txt";
            List<Cliente> clientes = new List<Cliente>();

            if (File.Exists(ruta))
            {
                string[] lineas = File.ReadAllLines(ruta);
                foreach (string linea in lineas)
                {
                    string[] partes = linea.Split('|');
                    if (partes.Length >= 2 && int.TryParse(partes[0].Trim(), out int idCliente))
                    {
                        clientes.Add(new Cliente
                        {
                            Id = idCliente,
                            Nombre = partes[1].Trim()
                        });
                    }
                }
                cmbClientes.DataSource = clientes;
            }
        }

        private void CargarProductos()
        {
            string rutaArchivo = @"C:\Users\wander\Documents\2025 CUNOR\Introducción a Progra\archivosProyecto\productos.txt";
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
        

        private void Form4_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarProductos();
            
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvProductos.SelectedRows[0];
                string nombre = fila.Cells["Nombre"].Value.ToString();
                int cantidadDisponible = int.Parse(fila.Cells["Cantidad"].Value.ToString());
                decimal precio = decimal.Parse(fila.Cells["Precio U"].Value.ToString());

                int cantidadDeseada;
                if (!int.TryParse(txtCantidad.Text, out cantidadDeseada) || cantidadDeseada <= 0)
                {
                    MessageBox.Show("Ingresa una cantidad válida.");
                    return;
                }

                if (cantidadDeseada > cantidadDisponible)
                {
                    MessageBox.Show("No hay suficiente inventario.");
                    return;
                }

                int idProducto = int.Parse(fila.Cells["ID"].Value.ToString());

                carrito.Add(new CarritoItem
                {
                    IdProducto = idProducto,
                    Nombre = nombre,
                    Cantidad = cantidadDeseada,
                    PrecioUnitario = precio
                });

                fila.Cells["Cantidad"].Value = (cantidadDisponible - cantidadDeseada).ToString();

                dgvCarrito.DataSource = null;
                dgvCarrito.DataSource = carrito;
            }
            else
            {
                MessageBox.Show("Selecciona un producto para agregar.");
            }
        }

        private void GuardarInventarioActualizado()
        {
            string ruta = @"C:\Users\wander\Documents\2025 CUNOR\Introducción a Progra\archivosProyecto\productos.txt";
            List<string> nuevasLineas = new List<string>();

            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                if (!fila.IsNewRow)
                {
                    string id = fila.Cells["ID"].Value?.ToString();
                    string nombre = fila.Cells["Nombre"].Value?.ToString();
                    string cantidad = fila.Cells["Cantidad"].Value?.ToString();
                    string precio = fila.Cells["Precio U"].Value?.ToString();

                    nuevasLineas.Add($"{id}|{nombre}|{cantidad}|{precio}");
                }
            }

            File.WriteAllLines(ruta, nuevasLineas);
        }


        int ObtenerNuevoIdVenta()
        {
            string ruta = @"C:\Users\wander\Documents\2025 CUNOR\Introducción a Progra\archivosProyecto\ventas.txt"; 

            if (!File.Exists(ruta))
                return 1;

            var lineas = File.ReadAllLines(ruta);
            if (lineas.Length == 0)
                return 1;

            var ultimoId = int.Parse(lineas.Last().Split('|')[0]);
            return ultimoId + 1;
        }

        private void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            if (carrito.Count == 0)
            {
                MessageBox.Show("El carrito está vacío.");
                return;
            }

            int idVenta = ObtenerNuevoIdVenta();
            string rutaVentas = @"C:\Users\wander\Documents\2025 CUNOR\Introducción a Progra\archivosProyecto\ventas.txt";

            Cliente clienteSeleccionado = cmbClientes.SelectedItem as Cliente;
            if (clienteSeleccionado == null)
            {
                MessageBox.Show("Selecciona un cliente para registrar la venta.");
                return;
            }

            string nombreCliente = clienteSeleccionado.Nombre;

            foreach (var item in carrito)
            {
                string linea = $"{idVenta}|{item.IdProducto}|{item.Nombre}|{item.Cantidad}|{item.PrecioUnitario}|{item.Total}|{nombreCliente}";
                File.AppendAllText(rutaVentas, linea + Environment.NewLine);
            }

            MessageBox.Show($"Venta #{idVenta} registrada correctamente para el cliente {nombreCliente}.");

            GuardarInventarioActualizado();

            carrito.Clear();
            dgvCarrito.DataSource = null;
            dgvCarrito.DataSource = carrito;
        }
    }
}
