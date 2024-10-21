using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NegocioService
    {
        private RepositorioDatos repositorio;

        public NegocioService()
        {
            repositorio = new RepositorioDatos();
        }

        // Obtener productos con sus categorías
        public List<ProductoCategoria> ObtenerProductosConCategorias()
        {
            return repositorio.ObtenerProductosCategoria();
        }

        // Obtener clientes de London o Berlin
        public List<Customers> ObtenerClientesDeLondonBerlin()
        {
            return repositorio.ObtenerClientesDeLondonBerlin();
        }

        // Obtener órdenes con Freight mayor a 100 y enviadas
        public List<Orders> ObtenerOrdenesConFreightMayorA100YEnviadas()
        {
            return repositorio.ObtenerOrdenesConFreightMayorA100YEnviadas();
        }

        // Obtener productos con stock y precio mayor a 20
        public List<Products> ObtenerProductosConStockYPrecioMayorA20()
        {
            return repositorio.ObtenerProductosConStockYPrecioMayorA20();
        }

        // Obtener órdenes con cliente y empleado
        public List<OrdenClienteEmpleado> ObtenerOrdenesConClienteYEmpleado()
        {
            return repositorio.ObtenerOrdenesConClienteYEmpleado();
        }

        // Obtener productos suministrados por proveedores de USA y Canadá
        public List<Products> ObtenerProductosDeProveedoresUSAyCanada()
        {
            return repositorio.ObtenerProductosDeProveedoresUSAyCanada();
        }

        // Obtener clientes sin órdenes
        public List<Customers> ObtenerClientesSinOrdenes()
        {
            return repositorio.ObtenerClientesSinOrdenes();
        }

        // Agregar una nueva orden con sus detalles
        public void AgregarOrden(Orders order, List<Order_Details> detalles)
        {
            repositorio.AgregarOrden(order, detalles);
        }
        
        // Modificar una orden existente
        public void ModificarOrden(int orderId, Orders ordenModificada)
        {
            repositorio.ModificarOrden(orderId, ordenModificada);
        }

        // Obtener una orden por su ID
        public Orders ObtenerOrdenPorId(int orderId)
        {
            return repositorio.ObtenerOrdenPorId(orderId);
        }
        // Método para obtener las órdenes
        public List<OrdenClienteEmpleado> ObtenerOrdenes()
        {
            return repositorio.ObtenerOrdenes(); // Llamada al método de repositorio que acabas de crear
        }
        // Obtener detalles de una orden por su ID
        public List<Order_Details> ObtenerDetallesPorIdOrden(int orderId)
        {
            return repositorio.ObtenerDetallesPorIdOrden(orderId);
        }
        public void CrearPedido(Orders newOrder, List<Order_Details> orderDetails)
        {
            repositorio.InsertOrder(newOrder);
            foreach (var detail in orderDetails)
            {
                detail.OrderID = newOrder.OrderID; // Asegurarse de que el OrderID esté configurado
                repositorio.InsertOrderDetail(detail);
            }
        }
        
        public void ModificarPedido(Orders updatedOrder)
        {
            repositorio.UpdateOrder(updatedOrder);
        }

        public void ModificarDetallePedido(Order_Details updatedDetail)
        {
            try
            {
                repositorio.UpdateOrderDetail(updatedDetail);
                MessageBox.Show("Detalle del pedido actualizado exitosamente.");
            }
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message); // Muestra el mensaje de error específico
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el detalle del pedido: " + ex.Message); // Maneja otros errores
            }
        }

        public Orders ConsultarPedido(int orderId)
        {
            return repositorio.GetOrderById(orderId);
        }
        public List<Orders> ConsultarTodosLosPedidos()
        {
            return repositorio.GetAllOrders();
        }
        public List<Order_Details> ConsultarDetallesPedido(int orderId)
        {
            return repositorio.GetOrderDetailsByOrderId(orderId);
        }
        public void InsertarDetallePedido(Order_Details detail)
        {
            
            try
            {
                // Intentar insertar el detalle del pedido a través del repositorio
                repositorio.InsertOrderDetail(detail);
                MessageBox.Show("El detalle del pedido se ha insertado correctamente.");
            }
            catch (InvalidOperationException ioex)
            {
                // Si la excepción indica que el OrderID no existe
                MessageBox.Show($"Error: {ioex.Message}\nPor favor, verifique que el OrderID exista.");
            }
            catch (SqlException sqlEx)
            {
                // Manejar errores específicos de SQL
                MessageBox.Show($"Error en la base de datos: {sqlEx.Message}\nPor favor, intente nuevamente.");
               
            }
            catch (Exception ex)
            {
                // Capturar cualquier otro error que ocurra durante la inserción
                MessageBox.Show("Error al insertar el detalle del pedido: " + ex.Message);
                
            }
        }
        public List<Customers> ObtenerClientes()
        {
            // Llama al método sincrónico
            return repositorio.ObtenerCustomers();
        }

        public List<Employees> ObtenerEmpleados()
        {
            // Llama al método sincrónico
            return repositorio.ObtenerEmployees();
        }

        public List<Shippers> ObtenerMetodosDeEnvio()
        {
            // Llama al método sincrónico
            return repositorio.ObtenerShipMethods();
        }

    }
}
