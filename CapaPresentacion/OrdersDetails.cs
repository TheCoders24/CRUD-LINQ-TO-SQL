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
using System.Xml.Serialization;
using CapaDatos;
using CapaNegocio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CapaPresentacion
{
    public partial class OrdersDetails : Form
    {
        private RepositorioDatos repositorio;
        public OrdersDetails()
        {
            InitializeComponent();
            repositorio = new RepositorioDatos(); // inicializamos el repositorio o la clase de la CapaNegocio
            CargarDatos();
        }

        private async void CargarDatos()
        {
            using (SqlConnection connection = new SqlConnection(Conexiones.CN))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT TOP (1000) [OrderID], [ProductID], [UnitPrice], [Quantity], [Discount] FROM [Northwind].[dbo].[Order Details]";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Asignar el DataTable como origen de datos del DataGridView
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
            }
        }

        // Método para insertar el detalle de pedido
        public void InsertarDetallePedido(Order_Details detail)
        {
            repositorio.InsertOrderDetail(detail); // Llama al método en el repositorio para insertar el detalle
        }

        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
           
        }
        public void ModificarDetallePedido(Order_Details updatedDetail)
        {
            repositorio.UpdateOrderDetail(updatedDetail);
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
           
        }

        private void OrdersDetails_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
