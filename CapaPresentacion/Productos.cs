using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public void GetProductos()
        {
            dataGridViewProductos.DataSource = negocioService.ObtenerProductosConCategorias();
            //dataGridView1.DataSource = servicio.ObtenerClientesDeLondonBerlin();
            //  dataGridView1.DataSource = servicio.ObtenerOrdenesConFreightMayorA100YEnviadas();
            //  dataGridView1.DataSource = servicio.ObtenerProductosConStockYPrecioMayorA20();
            // dataGridView1.DataSource = servicio.ObtenerOrdenesConClienteYEmpleado();
            //dataGridView1.DataSource = servicio.ObtenerProductosDeProveedoresUSAyCanada();
            //dataGridView1.DataSource = servicio.ObtenerClientesSinOrdenes();
        }


        private void dataGridViewProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
