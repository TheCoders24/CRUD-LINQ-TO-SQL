using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public  class ProductoService
    {

        private NorthwindDAL _dal;

        public ProductoService()
        {
            _dal = new NorthwindDAL();
        }

        public List<NorthwindDAL.Products> ObtenerProductosConCategorias()
        {
            return _dal.ObtenerProductosCategorias();
        }
    }
}
