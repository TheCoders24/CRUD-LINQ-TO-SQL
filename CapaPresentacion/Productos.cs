using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CapaPresentacion
{
    public partial class Productos : Form
    {

        private NegocioService negocioService;
        public Productos()
        {
            InitializeComponent();
            CargarComboBoxConsultas();
            negocioService = new NegocioService();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
          
        }
        private void CargarComboBoxConsultas()
        {
            comboBoxConsultas.Items.Add("Obtener Productos y Categorías");
            comboBoxConsultas.Items.Add("Obtener Clientes de London o Berlin");
            comboBoxConsultas.Items.Add("Obtener Órdenes con Freight > 100 y Enviadas");
            comboBoxConsultas.Items.Add("Obtener Productos con Stock y Precio > 20");
            comboBoxConsultas.Items.Add("Obtener Órdenes con Cliente y Empleado");
            comboBoxConsultas.Items.Add("Obtener Productos de Proveedores USA y Canadá");
            comboBoxConsultas.Items.Add("Obtener Clientes sin Órdenes");
        }


        // Este método es llamado cuando se quiere cargar los productos con sus categorías
        public void GetProductos()
        {
            try
            {
                dataGridViewProductos.DataSource = negocioService.ObtenerProductosConCategorias();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("No se pudo establecer una conexión con el servidor SQL. Por favor, verifique su configuración. Detalle del error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }


        private void dataGridViewProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBoxConsultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = comboBoxConsultas.SelectedItem.ToString();
            CargarDatosEnDataGridView(seleccion);
        }
        private void CargarDatosEnDataGridView(string seleccion)
        {
            switch (seleccion)
            {
                case "Obtener Productos y Categorías":
                    dataGridViewProductos.DataSource = negocioService.ObtenerProductosConCategorias();
                    break;
                case "Obtener Clientes de London o Berlin":
                    dataGridViewProductos.DataSource = negocioService.ObtenerClientesDeLondonBerlin();
                    break;
                case "Obtener Órdenes con Freight > 100 y Enviadas":
                    dataGridViewProductos.DataSource = negocioService.ObtenerOrdenesConFreightMayorA100YEnviadas();
                    break;
                case "Obtener Productos con Stock y Precio > 20":
                    dataGridViewProductos.DataSource = negocioService.ObtenerProductosConStockYPrecioMayorA20();
                    break;
                case "Obtener Órdenes con Cliente y Empleado":
                    dataGridViewProductos.DataSource = negocioService.ObtenerOrdenesConClienteYEmpleado();
                    break;
                case "Obtener Productos de Proveedores USA y Canadá":
                    dataGridViewProductos.DataSource = negocioService.ObtenerProductosDeProveedoresUSAyCanada();
                    break;
                case "Obtener Clientes sin Órdenes":
                    dataGridViewProductos.DataSource = negocioService.ObtenerClientesSinOrdenes();
                    break;
                default:
                    break;
            }
        }
    }
}
