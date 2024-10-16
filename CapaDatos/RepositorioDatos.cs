using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos
{
    public class RepositorioDatos
    {
        private NorthwindDataContextDataContext db;
        public RepositorioDatos()
        {

            // Cargamos la cadena de conexión desde el App.config
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
            db = new NorthwindDataContextDataContext(connectionString);

        }

        // obtener los productos y sus categorias
        public List<dynamic> obtenerproductoscategoria()
        {
            var query = from p in db.Products
                        join c in db.Categories on p.CategoryID equals c.CategoryID
                        select new
                        {
                            ProductName = p.ProductName,
                            CategoryName = c.CategoryName
                        };

            return query.ToList<dynamic>();
        }

        // obtener clientes de london o berlin
        public List<Customers> obtenerclientesdelondonberlin()
        {
            var query = (from c in db.Customers
                         where c.City == "London"
                         select c)
                      .Union(from c in db.Customers
                             where c.City == "Berlin"
                             select c);

            return query.ToList();
        }
        // 3. Obtener órdenes con Freight superior a 100 y enviadas
        public List<Orders> ObtenerOrdenesConFreightMayorA100YEnviadas()
        {
            var query = from o in db.Orders
                        where o.Freight > 100 && o.ShippedDate != null
                        select o;

            return query.ToList();
        }

        // 4. Obtener productos con stock y precio mayor a 20
        public List<Products> ObtenerProductosConStockYPrecioMayorA20()
        {
            var query = from p in db.Products
                        where p.UnitsInStock > 0 && p.UnitPrice > 20
                        select p;

            return query.ToList();
        }
        // 5. Obtener órdenes con nombre de cliente y empleado
        public List<dynamic> ObtenerOrdenesConClienteYEmpleado()
        {
            var query = from o in db.Orders
                        join c in db.Customers on o.CustomerID equals c.CustomerID
                        join e in db.Employees on o.EmployeeID equals e.EmployeeID
                        select new
                        {
                            OrderID = o.OrderID,
                            CustomerName = c.CompanyName,
                            EmployeeName = e.FirstName + " " + e.LastName
                        };

            return query.ToList<dynamic>();
        }
        // 6. Obtener productos suministrados por proveedores de USA y Canadá
        public List<Products> ObtenerProductosDeProveedoresUSAyCanada()
        {
            var usSuppliers = from p in db.Products
                              join s in db.Suppliers on p.SupplierID equals s.SupplierID
                              where s.Country == "USA"
                              select p;

            var canadaSuppliers = from p in db.Products
                                  join s in db.Suppliers on p.SupplierID equals s.SupplierID
                                  where s.Country == "Canada"
                                  select p;

            return usSuppliers.Intersect(canadaSuppliers).ToList();
        }
        // 7. Obtener clientes sin órdenes
        public List<Customers> ObtenerClientesSinOrdenes()
        {
            var customersWithOrders = from o in db.Orders
                                      select o.CustomerID;

            var customersWithoutOrders = from c in db.Customers
                                         where !customersWithOrders.Contains(c.CustomerID)
                                         select c;

            return customersWithoutOrders.ToList();
        }
        // Métodos CRUD para Orders y Order Details
        public void AgregarOrden(Orders order, List<Order_Details> detalles)
        {
            db.Orders.InsertOnSubmit(order);
            db.Order_Details.InsertAllOnSubmit(detalles);
            db.SubmitChanges();
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
