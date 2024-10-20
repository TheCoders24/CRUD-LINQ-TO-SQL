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
    }
}
