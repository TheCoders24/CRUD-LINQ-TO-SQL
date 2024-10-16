using CapaDatos;
using System.Collections.Generic;

namespace CapaNegocio
{
    public  class NegocioService
    {
        private RepositorioDatos repositorio;
        public NegocioService() 
        { 
            repositorio = new RepositorioDatos();   
        }
        public List<dynamic> ObtenerProductosConCategorias()
        {
            return repositorio.obtenerproductoscategoria();
        }

        public List<Customers> ObtenerClientesDeLondon()
        {
            return repositorio.obtenerclientesdelondonberlin();
        }

        public List<Orders> ObtenerOrdenesConFreightMayorA100YEnviadas()
        {
            return repositorio.ObtenerOrdenesConFreightMayorA100YEnviadas();
        }

        public List<Products> ObtenerProductosConStockYPrecioMayorA20()
        {
            return repositorio.ObtenerProductosConStockYPrecioMayorA20();
        }

        public List<dynamic> ObtenerOrdenesConClienteYEmpleado()
        {
            return repositorio.ObtenerOrdenesConClienteYEmpleado();
        }

        public List<Products> ObtenerProductosDeProveedoresUSAyCanada()
        {
            return repositorio.ObtenerProductosDeProveedoresUSAyCanada();
        }

        public List<Customers> ObtenerClientesSinOrdenes()
        {
            return repositorio.ObtenerClientesSinOrdenes();
        }

        public void AgregarOrden(Orders order, List<Order_Details> detalles)
        {
            repositorio.AgregarOrden(order, detalles);
        }

        public void ModificarOrden(int orderId, Orders ordenModificada)
        {
            repositorio.ModificarOrden(orderId, ordenModificada);
        }

        public Orders ObtenerOrdenPorId(int orderId)
        {
            return repositorio.ObtenerOrdenPorId(orderId);
        }

        public List<Order_Details> ObtenerDetallesPorIdOrden(int orderId)
        {
            return repositorio.ObtenerDetallesPorIdOrden(orderId);
        }
    }
}
