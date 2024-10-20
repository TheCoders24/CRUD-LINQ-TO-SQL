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
            CargarComboBoxes();
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

        private void CargarComboBoxes()
        {
            try
            {
                // Crear una instancia del repositorio
                var repositorio = new RepositorioDatos();

                // Cargar OrderID
                var orders = repositorio.ObtenerOrders();
                comboBoxorderid.DataSource = orders;
                comboBoxorderid.DisplayMember = "OrderID"; // Asegúrate de que "OrderID" es la propiedad que necesitas
                comboBoxorderid.ValueMember = "OrderID";   // El valor que se enviará al ComboBox

                // Cargar ProductID
                var products = repositorio.ObtenerProducts();
                comboBoxproductid.DataSource = products;
                comboBoxproductid.DisplayMember = "ProductID"; // Asegúrate de que "ProductID" es la propiedad que necesitas
                comboBoxproductid.ValueMember = "ProductID";   // El valor que se enviará al ComboBox
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los ComboBox: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(comboBoxorderid.Text) ||
                    string.IsNullOrWhiteSpace(comboBoxproductid.Text) ||
                    string.IsNullOrWhiteSpace(txtUnitPrice.Text) ||
                    string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                    string.IsNullOrWhiteSpace(txtdiscount.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios.");
                    return;
                }

                // Intentar convertir los campos a los tipos correspondientes
                if (!int.TryParse(comboBoxorderid.Text, out int orderId) ||
                    !int.TryParse(comboBoxproductid.Text, out int productId) ||
                    !decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice) ||
                    !short.TryParse(txtQuantity.Text, out short quantity) ||
                    !float.TryParse(txtdiscount.Text, out float discount))
                {
                    MessageBox.Show("Uno o más valores tienen un formato incorrecto.");
                    return;
                }

                // Procesar el descuento como porcentaje
                discount /= 100;

                // Crear el objeto Order_Details
                Order_Details details = new Order_Details
                {
                    OrderID = orderId,
                    ProductID = productId,
                    UnitPrice = unitPrice,
                    Quantity = quantity,
                    Discount = discount
                };

                // Insertar el detalle del pedido
                InsertarDetallePedido(details);

                MessageBox.Show("Detalle del Pedido Insertado Exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la solicitud: " + ex.Message);
            }
        }
        public void ModificarDetallePedido(Order_Details updatedDetail)
        {
            repositorio.UpdateOrderDetail(updatedDetail);
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Asegúrate de que los campos de texto contienen valores válidos
                int orderId = int.Parse(comboBoxorderid.Text);   // Obtener OrderID desde el campo de texto
                int productId = int.Parse(comboBoxproductid.Text); // Obtener ProductID desde el campo de texto

                // Crear un objeto Order_Details con los datos a modificar
                Order_Details updatedDetails = new Order_Details
                {
                    OrderID = orderId,
                    ProductID = productId,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text), // Obtener precio unitario
                    Quantity = short.Parse(txtQuantity.Text), // Obtener cantidad
                    Discount = float.Parse(txtdiscount.Text) / 100 // Obtener descuento (convertir a decimal)
                };

                // Llamar al método para modificar el detalle del pedido
                ModificarDetallePedido(updatedDetails);

                // Informar al usuario que la modificación fue exitosa
                MessageBox.Show("Detalle del pedido modificado exitosamente.");
            }
            catch (FormatException fe)
            {
                // Manejar errores de formato (por ejemplo, entradas no numéricas)
                MessageBox.Show("Error de formato: " + fe.Message);
            }
            catch (Exception ex)
            {
                // Manejar cualquier otro error
                MessageBox.Show("Error al modificar el detalle del pedido: " + ex.Message);
            }
        }

        private void OrdersDetails_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
