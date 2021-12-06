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
    public partial class FacturaView : Form
    {
        public FacturaView()
        {
            InitializeComponent();
            string usuario = EmailUsuario;
            FacturaController controlador = new FacturaController(this);
        }
        public string EmailUsuario;

        private void FacturaView_Load(object sender, EventArgs e)
        {

        }

        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
           
        }
    }
}
