using CapaDatos;
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
    public partial class Orders : Form
    {
        private NegocioService repositorio;
        private NorthwindDataContextDataContext NorthwindDataContextDataContext;
        public Orders()
        {
            InitializeComponent();
            repositorio = new NegocioService();
            CargarDatos();
            CargarComboBoxes();
        }

        private void CargarComboBoxes()
        {
            try
            {
                // Crear una instancia del repositorio
                var repositorio = new RepositorioDatos();

                //// Cargar OrderID
                //var orders = repositorio.ObtenerOrders();
                //comboBoxOrdersID.DataSource = orders;
                //comboBoxOrdersID.DisplayMember = "OrderID"; // Asegúrate de que "OrderID" es la propiedad que necesitas
                //comboBoxOrdersID.ValueMember = "OrderID";   // El valor que se enviará al ComboBox

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

        private async void CargarDatos()
        {
            using (SqlConnection connection = new SqlConnection(Conexiones.CN))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT TOP (1000) [OrderID], [CustomerID], [EmployeeID], [OrderDate], [RequiredDate], [ShippedDate], [ShipVia], [Freight], [ShipName], [ShipAddress], [ShipCity], [ShipRegion], [ShipPostalCode], [ShipCountry] FROM [Northwind].[dbo].[Orders]";

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

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                // Validar que los campos de la orden no estén vacíos
                if (string.IsNullOrWhiteSpace(comboBoxCustomerid.Text) ||
                    string.IsNullOrWhiteSpace(comboBoxemployeeid.Text) ||
                    string.IsNullOrWhiteSpace(txtFreight.Text) ||
                    string.IsNullOrWhiteSpace(txtShipName.Text))
                {
                    MessageBox.Show("Todos los campos de la orden son obligatorios.");
                    return;
                }

                // Validar que los campos de los detalles del pedido no estén vacíos
                if (string.IsNullOrWhiteSpace(comboBoxproductid.Text) ||
                    string.IsNullOrWhiteSpace(txtUnitPrice.Text) ||
                    string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                    string.IsNullOrWhiteSpace(txtdiscount.Text))
                {
                    MessageBox.Show("Todos los campos de los detalles del pedido son obligatorios.");
                    return;
                }

                // Intentar convertir los campos a los tipos correspondientes
                if (!int.TryParse(comboBoxOrdersID.Text, out int orderId) ||
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

                // Verificar si el cliente existe
                var customerId = comboBoxCustomerid.Text;
                var customerExists = VerificarClienteExistente(customerId);
                if (!customerExists)
                {
                    MessageBox.Show("El cliente seleccionado no existe.");
                    return;
                }

                // Crear una nueva instancia de Orders
                var nuevaOrden = new CapaDatos.Orders
                {
                    CustomerID = customerId,
                    EmployeeID = string.IsNullOrWhiteSpace(comboBoxemployeeid.Text) ? (int?)null : int.Parse(comboBoxemployeeid.Text),
                    OrderDate = dateTimePickerordersdate.Value,
                    RequiredDate = dateTimePickerRequiredDate.Value,
                    ShippedDate = dateTimePickerShippedDate.Value,
                    ShipVia = comboBoxshipvia.SelectedItem != null && int.TryParse(comboBoxshipvia.SelectedItem.ToString(), out var shipVia) ? shipVia : (int?)null,
                    Freight = decimal.TryParse(txtFreight.Text, out var freightValue) ? freightValue : throw new FormatException("Freight debe ser un número válido."),
                    ShipName = txtShipName.Text,
                    ShipAddress = txtShipAddress.Text,
                    ShipCity = txtShipCity.Text,
                    ShipRegion = txtShipRegion.Text,
                    ShipPostalCode = txtShipPostalCode.Text,
                    ShipCountry = txtShipCountry.Text
                };

                // Crear el objeto Order_Details
                var detallesOrden = new List<Order_Details>
                {
                    new Order_Details
                    {
                        OrderID = orderId,
                        ProductID = productId,
                        UnitPrice = unitPrice,
                        Quantity = quantity,
                        Discount = discount
                    }
                };

                // Verificar si se va a actualizar o agregar una nueva orden
                if (!string.IsNullOrWhiteSpace(comboBoxOrdersID.Text) && int.TryParse(comboBoxOrdersID.Text, out var existingOrderId))
                {
                    // Insertar nueva orden
                    repositorio.AgregarOrden(nuevaOrden, detallesOrden); // Inserción con la lista de detalles de la orden
                    
                    MessageBox.Show("Orden agregada exitosamente.");
                    CargarDatos();
                }
                else
                {
                  

                    //// Actualizar la orden existente
                    //nuevaOrden.OrderID = existingOrderId;
                    //repositorio.ModificarPedido(nuevaOrden); // Actualización con la lista de detalles de la orden
                    //MessageBox.Show("Orden actualizada exitosamente.");

                }

                MessageBox.Show("Detalle del Pedido insertado exitosamente.");
                CargarDatos();
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Error de formato: " + fe.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la solicitud: " + ex.Message);
            }
        }
        public bool VerificarClienteExistente(string customerId)
        {
            using (var connection = new SqlConnection(Conexiones.CN))
            {
                connection.Open();
                var command = new SqlCommand("SELECT COUNT(1) FROM Customers WHERE CustomerID = @CustomerID", connection);
                command.Parameters.AddWithValue("@CustomerID", customerId);
                return (int)command.ExecuteScalar() > 0;
            }
        }
        private  void Orders_Load(object sender, EventArgs e)
        {
            // Llenar ComboBox para CustomerID
            var customerIds = ObtenerCustomerIDs();
            comboBoxCustomerid.DataSource = customerIds;

            // Llenar ComboBox para EmployeeID
            var employeeIds = ObtenerEmployeeIDs();
            comboBoxemployeeid.DataSource = employeeIds;

            // Llenar ComboBox para ShipperID
            var shipperIds = ObtenerShipperIDs();
            comboBoxshipvia.DataSource = shipperIds;

            // Crear una instancia del repositorio
            var repositorio = new RepositorioDatos();

            // Cargar OrderID
            var orders = repositorio.ObtenerOrders();
            comboBoxOrdersID.DataSource = orders;
            comboBoxOrdersID.DisplayMember = "OrderID"; // Asegúrate de que "OrderID" es la propiedad que necesitas
            comboBoxOrdersID.ValueMember = "OrderID";   // El valor que se enviará al ComboBox
        }

        #region obtenerids
        public List<string> ObtenerCustomerIDs()
        {
            var customerIds = new List<string>();
            using (var connection = new SqlConnection(Conexiones.CN))
            {
                connection.Open();
                var command = new SqlCommand("SELECT [CustomerID] FROM [Northwind].[dbo].[Customers]", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customerIds.Add(reader["CustomerID"].ToString());
                    }
                }
            }
            return customerIds;
        }
        // Método para obtener EmployeeIDs
        public List<int> ObtenerEmployeeIDs()
        {
            var employeeIds = new List<int>();
            using (var connection = new SqlConnection(Conexiones.CN))
            {
                connection.Open();
                var command = new SqlCommand("SELECT [EmployeeID] FROM [Northwind].[dbo].[Employees]", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employeeIds.Add(reader.GetInt32(0)); // Asumiendo que EmployeeID es un entero
                    }
                }
            }
            return employeeIds;
        }

        // Método para obtener ShipperIDs
        public List<int> ObtenerShipperIDs()
        {
            var shipperIds = new List<int>();
            using (var connection = new SqlConnection(Conexiones.CN))
            {
                connection.Open();
                var command = new SqlCommand("SELECT [ShipperID] FROM [Northwind].[dbo].[Shippers]", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        shipperIds.Add(reader.GetInt32(0)); // Asumiendo que ShipperID es un entero
                    }
                }
            }
            return shipperIds;
        }
        #endregion

        private void btnModificar_Click(object sender, EventArgs e)
        {

            try
            {
                // Validar que los campos de la orden no estén vacíos
                if (string.IsNullOrWhiteSpace(comboBoxCustomerid.Text) ||
                    string.IsNullOrWhiteSpace(comboBoxemployeeid.Text) ||
                    string.IsNullOrWhiteSpace(txtFreight.Text) ||
                    string.IsNullOrWhiteSpace(txtShipName.Text))
                {
                    MessageBox.Show("Todos los campos de la orden son obligatorios.");
                    return;
                }

                // Validar que los campos de los detalles del pedido no estén vacíos
                if (string.IsNullOrWhiteSpace(comboBoxproductid.Text) ||
                    string.IsNullOrWhiteSpace(txtUnitPrice.Text) ||
                    string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                    string.IsNullOrWhiteSpace(txtdiscount.Text))
                {
                    MessageBox.Show("Todos los campos de los detalles del pedido son obligatorios.");
                    return;
                }

                // Intentar convertir los campos a los tipos correspondientes
                if (!int.TryParse(comboBoxOrdersID.Text, out int orderId) ||
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

                // Verificar si el cliente existe
                var customerId = comboBoxCustomerid.Text;
                var customerExists = VerificarClienteExistente(customerId);
                if (!customerExists)
                {
                    MessageBox.Show("El cliente seleccionado no existe.");
                    return;
                }

                // Crear una nueva instancia de Orders
                var nuevaOrden = new CapaDatos.Orders
                {
                    CustomerID = customerId,
                    EmployeeID = string.IsNullOrWhiteSpace(comboBoxemployeeid.Text) ? (int?)null : int.Parse(comboBoxemployeeid.Text),
                    OrderDate = dateTimePickerordersdate.Value,
                    RequiredDate = dateTimePickerRequiredDate.Value,
                    ShippedDate = dateTimePickerShippedDate.Value,
                    ShipVia = comboBoxshipvia.SelectedItem != null && int.TryParse(comboBoxshipvia.SelectedItem.ToString(), out var shipVia) ? shipVia : (int?)null,
                    Freight = decimal.TryParse(txtFreight.Text, out var freightValue) ? freightValue : throw new FormatException("Freight debe ser un número válido."),
                    ShipName = txtShipName.Text,
                    ShipAddress = txtShipAddress.Text,
                    ShipCity = txtShipCity.Text,
                    ShipRegion = txtShipRegion.Text,
                    ShipPostalCode = txtShipPostalCode.Text,
                    ShipCountry = txtShipCountry.Text
                };

                // Crear el objeto Order_Details
                var detallesOrden = new List<Order_Details>
                {
                    new Order_Details
                    {
                        OrderID = orderId,
                        ProductID = productId,
                        UnitPrice = unitPrice,
                        Quantity = quantity,
                        Discount = discount
                    }
                };

                // Verificar si se va a actualizar o agregar una nueva orden
                if (!string.IsNullOrWhiteSpace(comboBoxOrdersID.Text) && int.TryParse(comboBoxOrdersID.Text, out var existingOrderId))
                {
                    // Actualizar la orden existente
                    nuevaOrden.OrderID = existingOrderId;
                    repositorio.ModificarPedido(nuevaOrden); // Actualización con la lista de detalles de la orden
                    MessageBox.Show("Orden actualizada exitosamente.");
                    CargarDatos();
                }
               
                MessageBox.Show("Detalle del Pedido insertado exitosamente.");
                CargarDatos();
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Error de formato: " + fe.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la solicitud: " + ex.Message);
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
