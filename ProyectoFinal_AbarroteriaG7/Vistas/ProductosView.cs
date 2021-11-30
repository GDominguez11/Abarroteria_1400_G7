using ProyectoFinal_AbarroteriaG7.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_AbarroteriaG7.Vistas
{
    public partial class ProductosView : Form
    {
        public ProductosView()
        {
            InitializeComponent();
            ProductoController controlador = new ProductoController(this);
        }


        private void ProductocomboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string item = ProductocomboBox.Text;
            Productolabel.Text = item;
        }
    }
}
