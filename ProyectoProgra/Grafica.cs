using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ProyectoProgra
{
    public partial class Grafica : MaterialForm
    {
        public Grafica()
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

        private void Grafica_Load(object sender, EventArgs e)
        {
            // Cargar opciones de gráficos
            comboOpciones.Items.Clear();
            comboOpciones.Items.Add("Productos más vendidos");
            comboOpciones.Items.Add("Ventas por cliente");
            comboOpciones.SelectedIndex = 0; // Selección inicial

            // Mostrar la primera gráfica al cargar
            MostrarGraficaProductosVendidos();
        }

        private void comboOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = comboOpciones.SelectedItem.ToString();

            if (opcion == "Productos más vendidos")
            {
                MostrarGraficaProductosVendidos();
            }
            else if (opcion == "Ventas por cliente")
            {
                MostrarGraficaVentasPorCliente();
            }
        }

        private void MostrarGraficaProductosVendidos()
        {
            string rutaArchivo = @"C:\Users\Adal\Documents\2025 CUNOR\Introducción a Progra\archivosProyecto\ventas.txt";

            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("El archivo de ventas no existe.");
                return;
            }

            Dictionary<string, int> productos = new Dictionary<string, int>();

            foreach (string linea in File.ReadAllLines(rutaArchivo))
            {
                string[] campos = linea.Split('|');
                if (campos.Length == 7)
                {
                    string producto = campos[2];
                    if (int.TryParse(campos[3], out int cantidad))
                    {
                        if (productos.ContainsKey(producto))
                            productos[producto] += cantidad;
                        else
                            productos[producto] = cantidad;
                    }
                }
            }

            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Titles.Add("Productos más vendidos");

            Series serie = new Series("Cantidad Vendida")
            {
                ChartType = SeriesChartType.Column
            };

            foreach (var item in productos)
            {
                serie.Points.AddXY(item.Key, item.Value);
            }

            chart1.Series.Add(serie);
        }

        private void MostrarGraficaVentasPorCliente()
        {
            string rutaArchivo = @"C:\Users\Adal\Documents\2025 CUNOR\Introducción a Progra\archivosProyecto\ventas.txt";

            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("El archivo de ventas no existe.");
                return;
            }

            Dictionary<string, double> clientes = new Dictionary<string, double>();

            foreach (string linea in File.ReadAllLines(rutaArchivo))
            {
                string[] campos = linea.Split('|');
                if (campos.Length == 7)
                {
                    string cliente = campos[6];
                    if (double.TryParse(campos[5], out double total))
                    {
                        if (clientes.ContainsKey(cliente))
                            clientes[cliente] += total;
                        else
                            clientes[cliente] = total;
                    }
                }
            }

            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Titles.Add("Ventas por cliente");

            Series serie = new Series("Total")
            {
                ChartType = SeriesChartType.Pie
            };

            foreach (var item in clientes)
            {
                serie.Points.AddXY(item.Key, item.Value);
            }

            chart1.Series.Add(serie);
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
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
