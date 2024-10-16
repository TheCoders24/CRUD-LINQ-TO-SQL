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

        private ProductoService productoService;
        public Productos()
        {
            InitializeComponent();
           
            productoService = new ProductoService();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            GetProductos();
        }

        public void GetProductos()
        {
           
        }

        private void dataGridViewProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
