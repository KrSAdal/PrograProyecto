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
using iTextSharp.text;
using iTextSharp.text.pdf;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ProyectoProgra
{
    public partial class Form5 : MaterialForm
    {
        public Form5()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Indigo500, Primary.Indigo700,
                Primary.Indigo100, Accent.Indigo200,
                TextShade.WHITE
            );
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {

            string rutaArchivo = @"C:\Users\Adal\Documents\2025 CUNOR\Introducción a Progra\archivosProyecto\ventas.txt";

            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (!File.Exists(rutaArchivo))
            

            {
                MessageBox.Show("El archivo de productos no existe.");
                return;
            }

            DataTable tabla = new DataTable();
            tabla.Columns.Add("IdVenta");
            tabla.Columns.Add("IdProducto");
            tabla.Columns.Add("Producto");
            tabla.Columns.Add("Cantidad");
            tabla.Columns.Add("PrecioUnitario");
            tabla.Columns.Add("Total");
            tabla.Columns.Add("Cliente");

            try
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);
                foreach (string linea in lineas)
                {
                    string[] campos = linea.Split('|');
                    if (campos.Length == 7)
                    {
                        tabla.Rows.Add(campos);
                    }
                }

                dgvVentas.DataSource = tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el archivo: " + ex.Message);
            }
        }


        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtIdVenta.Text = dgvVentas.Rows[e.RowIndex].Cells["IdVenta"].Value?.ToString();
                txtIdProducto.Text = dgvVentas.Rows[e.RowIndex].Cells["IdProducto"].Value?.ToString();  
                txtProducto.Text = dgvVentas.Rows[e.RowIndex].Cells["Producto"].Value?.ToString();
                txtCantidad.Text = dgvVentas.Rows[e.RowIndex].Cells["Cantidad"].Value?.ToString();
                txtPrecioU.Text = dgvVentas.Rows[e.RowIndex].Cells["PrecioUnitario"].Value?.ToString();
                txtTotal.Text = dgvVentas.Rows[e.RowIndex].Cells["Total"].Value?.ToString();
                txtCliente.Text = dgvVentas.Rows[e.RowIndex].Cells["Cliente"].Value?.ToString();
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvVentas.SelectedRows.Count > 0)
            {
                dgvVentas.Rows.RemoveAt(dgvVentas.SelectedRows[0].Index);
                GuardarCambiosEnArchivo();
                MessageBox.Show("Producto eliminado correctamente.");
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para eliminar.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvVentas.SelectedRows.Count > 0)
            {
                var fila = dgvVentas.SelectedRows[0];
                fila.Cells["IdVenta"].Value = txtIdVenta.Text;
                fila.Cells["IdProducto"].Value = txtIdProducto.Text;
                fila.Cells["Producto"].Value = txtProducto.Text;
                fila.Cells["Cantidad"].Value = txtCantidad.Text;
                fila.Cells["PrecioUnitario"].Value = txtPrecioU.Text;
                fila.Cells["Total"].Value = txtTotal.Text;
                fila.Cells["Cliente"].Value = txtCliente.Text;

                GuardarCambiosEnArchivo();
                MessageBox.Show("Venta editada correctamente.");
            }
            else
            {
                MessageBox.Show("Selecciona una fila para editar.");
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

            foreach (DataGridViewRow fila in dgvVentas.Rows)
            {
                if (!fila.IsNewRow)
                {
                    string nombre = fila.Cells["Cliente"].Value?.ToString().ToLower();
                    if (nombre.Contains(buscar))
                    {
                        fila.Selected = true;
                        dgvVentas.FirstDisplayedScrollingRowIndex = fila.Index;
                        return;
                    }
                }
            }

            MessageBox.Show("No se encontró ningún cliente con ese nombre.");
        
        }

        private void GuardarCambiosEnArchivo()
        {



            string ruta = @"C:\Users\Adal\Documents\2025 CUNOR\Introducción a Progra\archivosProyecto\ventas.txt";

            List<string> nuevasLineas = new List<string>();

            foreach (DataGridViewRow fila in dgvVentas.Rows)
            {
                if (!fila.IsNewRow)
                {
                    string idVenta = fila.Cells["IdVenta"].Value?.ToString();
                    string idProducto = fila.Cells["IdProducto"].Value?.ToString();
                    string producto = fila.Cells["Producto"].Value?.ToString();
                    string cantidad = fila.Cells["Cantidad"].Value?.ToString();
                    string precio = fila.Cells["PrecioUnitario"].Value?.ToString();
                    string total = fila.Cells["Total"].Value?.ToString();
                    string cliente = fila.Cells["Cliente"].Value?.ToString();

                    nuevasLineas.Add($"{idVenta}|{idProducto}|{producto}|{cantidad}|{precio}|{total}|{cliente}");
                }
            }

            File.WriteAllLines(ruta, nuevasLineas);
        }
        private void LimpiarCampos()
        {
            txtIdVenta.Clear();
            txtIdProducto.Clear();
            txtProducto.Clear();
            txtCantidad.Clear();
            txtPrecioU.Clear();
            txtTotal.Clear();
            txtCliente.Clear();
        }

        private void btnLeerClientes_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void btnGrafica_Click(object sender, EventArgs e)
        {
            Grafica grafica = new Grafica();
            grafica.Show();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // Ruta de salida
            string rutaPDF = @"C:\Users\Adal\Documents\2025 CUNOR\Introducción a Progra\archivosProyecto\ventas_generadas.pdf";

            // Crear el documento y el escritor
            Document documento = new Document(PageSize.A4, 10, 10, 10, 10);
            try
            {
                PdfWriter.GetInstance(documento, new FileStream(rutaPDF, FileMode.Create));
                documento.Open();

                // Título del documento
                Paragraph titulo = new Paragraph("REPORTE DE VENTAS")
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 20f
                };
                documento.Add(titulo);

                // Tabla con tantas columnas como el DataGridView
                PdfPTable tabla = new PdfPTable(dgvVentas.Columns.Count);
                tabla.WidthPercentage = 100;

                // Agregar encabezados
                foreach (DataGridViewColumn columna in dgvVentas.Columns)
                {
                    PdfPCell celdaEncabezado = new PdfPCell(new Phrase(columna.HeaderText))
                    {
                        BackgroundColor = new BaseColor(200, 200, 200),
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };
                    tabla.AddCell(celdaEncabezado);
                }

                // Agregar filas
                foreach (DataGridViewRow fila in dgvVentas.Rows)
                {
                    if (!fila.IsNewRow)
                    {
                        foreach (DataGridViewCell celda in fila.Cells)
                        {
                            tabla.AddCell(celda.Value?.ToString());
                        }
                    }
                }

                documento.Add(tabla);
                MessageBox.Show("PDF generado correctamente en: " + rutaPDF);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message);
            }
            finally
            {
                if (documento.IsOpen()) documento.Close();
            }
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
