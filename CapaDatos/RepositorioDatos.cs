using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos
{
    public class ProductoCategoria
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
    }

    public class OrdenClienteEmpleado
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
    }

    public class RepositorioDatos
    {
        private NorthwindDataContextDataContext db;

        public RepositorioDatos()
        {
            try
            {
                // Obtener la cadena de conexión del archivo App.config
                string connectionString = Conexiones.CN;

                // Verificar si la cadena de conexión es nula
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("La cadena de conexión no está configurada en App.config.");
                }

                // Probar la conexión antes de crear el contexto de datos
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Intentar abrir la conexión
                    Console.WriteLine("Conexión exitosa.");
                }

                // Crear el contexto de datos
                db = new NorthwindDataContextDataContext(connectionString);

                // Verificar si el contexto de datos se creó correctamente
                if (db == null)
                {
                    throw new InvalidOperationException("No se pudo crear el contexto de datos.");
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException($"Sucedió un error con SQL: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Sucedió un error: {ex.Message}", ex);
            }

        }


        // Obtener los productos y sus categorías
        public List<ProductoCategoria> ObtenerProductosCategoria()
        {
            var query = from p in db.Products
                        join c in db.Categories on p.CategoryID equals c.CategoryID
                        select new ProductoCategoria
                        {
                            ProductName = p.ProductName,
                            CategoryName = c.CategoryName
                        };

            return query.ToList();
        }

        // Obtener clientes de London o Berlin
        public List<Customers> ObtenerClientesDeLondonBerlin()
        {
            var query = (from c in db.Customers
                         where c.City == "London"
                         select c)
                        .Union(from c in db.Customers
                               where c.City == "Berlin"
                               select c);

            return query.ToList();
        }

        // Obtener órdenes con Freight superior a 100 y enviadas
        public List<Orders> ObtenerOrdenesConFreightMayorA100YEnviadas()
        {
            var query = from o in db.Orders
                        where o.Freight > 100 && o.ShippedDate != null
                        select o;

            return query.ToList();
        }

        // Obtener productos con stock y precio mayor a 20
        public List<Products> ObtenerProductosConStockYPrecioMayorA20()
        {
            var query = from p in db.Products
                        where p.UnitsInStock > 0 && p.UnitPrice > 20
                        select p;

            return query.ToList();
        }

        // Obtener órdenes con nombre de cliente y empleado
        public List<OrdenClienteEmpleado> ObtenerOrdenesConClienteYEmpleado()
        {
            var query = from o in db.Orders
                        join c in db.Customers on o.CustomerID equals c.CustomerID
                        join e in db.Employees on o.EmployeeID equals e.EmployeeID
                        select new OrdenClienteEmpleado
                        {
                            OrderID = o.OrderID,
                            CustomerName = c.CompanyName,
                            EmployeeName = e.FirstName + " " + e.LastName
                        };

            return query.ToList();
        }

        // Obtener productos suministrados por proveedores de USA y Canadá
        public List<Products> ObtenerProductosDeProveedoresUSAyCanada()
        {
            var query = (from p in db.Products
                         join s in db.Suppliers on p.SupplierID equals s.SupplierID
                         where s.Country == "USA" || s.Country == "Canada"
                         select p).Distinct();

            return query.ToList();
        }

        // Obtener clientes sin órdenes
        public List<Customers> ObtenerClientesSinOrdenes()
        {
            var query = from c in db.Customers
                        where !(from o in db.Orders select o.CustomerID).Contains(c.CustomerID)
                        select c;

            return query.ToList();
        }

        // Métodos CRUD para Orders y Order Details
        public void AgregarOrden(Orders order, List<Order_Details> detalles)
        {
            db.Orders.InsertOnSubmit(order);
            db.Order_Details.InsertAllOnSubmit(detalles);
            db.SubmitChanges();
        }
        public void InsertOrderDetail(Order_Details orderDetail)
        {
            db.Order_Details.InsertOnSubmit(orderDetail);
            db.SubmitChanges();
        }
        public void UpdateOrder(Orders updatedOrder)
        {
            var existingOrder = db.Orders.SingleOrDefault(o => o.OrderID == updatedOrder.OrderID);
            if (existingOrder != null)
            {
                existingOrder.CustomerID = updatedOrder.CustomerID;
                existingOrder.EmployeeID = updatedOrder.EmployeeID;
                existingOrder.OrderDate = updatedOrder.OrderDate;
                existingOrder.RequiredDate = updatedOrder.RequiredDate;
                existingOrder.ShippedDate = updatedOrder.ShippedDate;
                existingOrder.ShipVia = updatedOrder.ShipVia;
                existingOrder.Freight = updatedOrder.Freight;
                existingOrder.ShipName = updatedOrder.ShipName;
                existingOrder.ShipAddress = updatedOrder.ShipAddress;
                existingOrder.ShipCity = updatedOrder.ShipCity;
                existingOrder.ShipPostalCode = updatedOrder.ShipPostalCode;
                existingOrder.ShipCountry = updatedOrder.ShipCountry;

                db.SubmitChanges();
            }
        }
        public void UpdateOrderDetail(Order_Details updatedDetail)
        {
            var existingDetail = db.Order_Details.SingleOrDefault(od => od.OrderID == updatedDetail.OrderID && od.ProductID == updatedDetail.ProductID);
            if (existingDetail != null)
            {
                existingDetail.UnitPrice = updatedDetail.UnitPrice;
                existingDetail.Quantity = updatedDetail.Quantity;
                existingDetail.Discount = updatedDetail.Discount;

                db.SubmitChanges();
            }
        }


        public void ModificarOrden(int orderId, Orders ordenModificada)
        {
            var order = db.Orders.SingleOrDefault(o => o.OrderID == orderId);
            if (order != null)
            {
                order.OrderDate = ordenModificada.OrderDate;
                order.ShippedDate = ordenModificada.ShippedDate;
                order.Freight = ordenModificada.Freight;
                db.SubmitChanges();
            }
        }
        public Orders GetOrderById(int orderId)
        {
            return db.Orders.SingleOrDefault(o => o.OrderID == orderId);
        }

        public List<Orders> GetAllOrders()
        {
            return db.Orders.ToList();
        }
        public List<Order_Details> GetOrderDetailsByOrderId(int orderId)
        {
            return db.Order_Details.Where(od => od.OrderID == orderId).ToList();
        }
        public void InsertOrder(Orders newOrder)
        {
            db.Orders.InsertOnSubmit(newOrder);
            db.SubmitChanges();
        }
        public Orders ObtenerOrdenPorId(int orderId)
        {
            return db.Orders.SingleOrDefault(o => o.OrderID == orderId);
        }

        public List<Order_Details> ObtenerDetallesPorIdOrden(int orderId)
        {
            return db.Order_Details.Where(od => od.OrderID == orderId).ToList();
        }

       
    }

}
