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
        public Orders()
        {
            InitializeComponent();
            repositorio = new NegocioService();
            
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var customerId = comboBoxCustomerid.Text;

                // Verificar si el cliente existe
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
                    ShipVia = comboBoxshipvia.SelectedItem != null ? (int)comboBoxshipvia.SelectedItem : (int?)null,
                    Freight = decimal.TryParse(txtFreight.Text, out var freightValue) ? freightValue : throw new FormatException("Freight debe ser un número válido."),
                    ShipName = txtShipName.Text,
                    ShipAddress = txtShipAddress.Text,
                    ShipCity = txtShipCity.Text,
                    ShipRegion = txtShipRegion.Text,
                    ShipPostalCode = txtShipPostalCode.Text,
                    ShipCountry = txtShipCountry.Text
                };

                // Llamar al método para agregar la orden
                repositorio.AgregarOrden(nuevaOrden, new List<Order_Details>());

                MessageBox.Show("Orden agregada exitosamente.");
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Error de formato: " + fe.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la orden: " + ex.Message);
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
                // Obtener el OrderID desde un control como TextBox o ComboBox
                var orderId = int.Parse(comboBoxOrdersID.Text); // Asume que el ID es un entero

                // Verificar si la orden existe
                var ordenExistente = repositorio.ObtenerOrdenPorId(orderId); // Asegúrate de tener este método
                if (ordenExistente == null)
                {
                    MessageBox.Show("La orden no existe.");
                    return;
                }

                var customerId = comboBoxCustomerid.Text;

                // Verificar si el cliente existe
                var customerExists = VerificarClienteExistente(customerId);
                if (!customerExists)
                {
                    MessageBox.Show("El cliente seleccionado no existe.");
                    return;
                }

                // Crear una nueva instancia de Orders
                var ordenActualizada = new CapaDatos.Orders
                {
                    OrderID = orderId, // Incluye el OrderID
                    CustomerID = customerId,
                    EmployeeID = string.IsNullOrWhiteSpace(comboBoxemployeeid.Text) ? (int?)null : int.Parse(comboBoxemployeeid.Text),
                    OrderDate = dateTimePickerordersdate.Value,
                    RequiredDate = dateTimePickerRequiredDate.Value,
                    ShippedDate = dateTimePickerShippedDate.Value,
                    ShipVia = comboBoxshipvia.SelectedItem != null ? (int)comboBoxshipvia.SelectedItem : (int?)null,
                    Freight = decimal.TryParse(txtFreight.Text, out var freightValue) ? freightValue : throw new FormatException("Freight debe ser un número válido."),
                    ShipName = txtShipName.Text,
                    ShipAddress = txtShipAddress.Text,
                    ShipCity = txtShipCity.Text,
                    ShipRegion = txtShipRegion.Text,
                    ShipPostalCode = txtShipPostalCode.Text,
                    ShipCountry = txtShipCountry.Text
                };

                // Llamar al método para modificar la orden
                repositorio.ModificarOrden(orderId, ordenActualizada); // Asegúrate de pasar el OrderID y el objeto

                MessageBox.Show("Orden actualizada exitosamente.");
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Error de formato: " + fe.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la orden: " + ex.Message);
            }

        }
    }
}
