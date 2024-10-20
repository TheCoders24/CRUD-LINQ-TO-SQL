using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDatos
{
    public class DataService
    {
        private NorthwindDataContextDataContext contexto;

        public DataService()
        {
            contexto = new NorthwindDataContextDataContext();
        }

        // Métodos para obtener datos
        public List<Customers> ObtenerClientes()
        {
            var customers = contexto.Customers.ToList();
            if (customers.Count == 0)
            {
                throw new Exception("No se encontraron clientes en la base de datos.");
            }
            return customers;
        }

        public List<Employees> ObtenerEmpleados()
        {
            var employees = contexto.Employees.ToList();
            if (employees.Count == 0)
            {
                throw new Exception("No se encontraron empleados en la base de datos.");
            }
            return employees;
        }

        public List<Shippers> ObtenerMetodosDeEnvio()
        {
            var shippers = contexto.Shippers.ToList();
            if (shippers.Count == 0)
            {
                throw new Exception("No se encontraron métodos de envío en la base de datos.");
            }
            return shippers;
        }

        // Método para cargar los ComboBox
        public void CargarComboBoxes(ComboBox comboBoxCustomerid, ComboBox comboBoxEmployeeid, ComboBox comboBoxShipVia)
        {
            try
            {
                // Cargar CustomerID
                var customers = ObtenerClientes();
                comboBoxCustomerid.DataSource = customers;
                comboBoxCustomerid.DisplayMember = "CustomerID";
                comboBoxCustomerid.ValueMember = "CustomerID";

                // Cargar EmployeeID
                var employees = ObtenerEmpleados();
                comboBoxEmployeeid.DataSource = employees;
                comboBoxEmployeeid.DisplayMember = "EmployeeID";
                comboBoxEmployeeid.ValueMember = "EmployeeID";

                // Cargar ShipVia
                var shippers = ObtenerMetodosDeEnvio();
                comboBoxShipVia.DataSource = shippers;
                comboBoxShipVia.DisplayMember = "CompanyName";
                comboBoxShipVia.ValueMember = "ShipperID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los ComboBox: " + ex.Message);
            }
        }
    }
}
