using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

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
    }
}
