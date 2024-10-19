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
    public partial class Productos : Form
    {

        private NegocioService negocioService;
        public Productos()
        {
            InitializeComponent();

            negocioService = new NegocioService();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            GetProductos();
        }
       

        // Este método es llamado cuando se quiere cargar los productos con sus categorías
        public void GetProductos()
        {
            try
            {
                dataGridViewProductos.DataSource = negocioService.ObtenerProductosConCategorias();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("No se pudo establecer una conexión con el servidor SQL. Por favor, verifique su configuración. Detalle del error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }


        private void dataGridViewProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
