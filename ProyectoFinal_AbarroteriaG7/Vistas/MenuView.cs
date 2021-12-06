using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyectoFinal_AbarroteriaG7.Vistas
{
    public partial class MenuView : Syncfusion.Windows.Forms.Office2010Form
    {
        public MenuView()
        {
            InitializeComponent();
        }
        UsuariosView vistaUsuarios;
        ClientesView vistaClientes;
        ProductosView vistaProductos;
        FacturaView vistaFacturas;

        public string EmailUsuario;
       

        private void RibbonPanel_Click(object sender, EventArgs e)
        {

        }

        private void UsuariostoolStripButton_Click(object sender, EventArgs e)
        {
            if (vistaUsuarios == null)
            {
                vistaUsuarios = new UsuariosView();
                vistaUsuarios.MdiParent = this;
                vistaUsuarios.FormClosed += Vista_FormClosed;
                vistaUsuarios.Show();
            }
            else
            {
                vistaUsuarios.Activate();
            }
        }

        private void Vista_FormClosed(object sender, FormClosedEventArgs e)
        {
            vistaUsuarios = null;
            vistaClientes = null;
            vistaProductos = null;
            vistaFacturas = null;
        }

        private void ClientestoolStripButton_Click(object sender, EventArgs e)
        {
            if (vistaClientes == null)
            {
                vistaClientes = new ClientesView();
                vistaClientes.MdiParent = this;
                vistaClientes.FormClosed += Vista_FormClosed;
                vistaClientes.Show();
            }
            else
            {
                vistaClientes.Activate();
            }
        }

        private void ProductostoolStripButton_Click_1(object sender, EventArgs e)
        {
            if (vistaProductos == null)
            {
                vistaProductos = new ProductosView();
                vistaProductos.MdiParent = this;
                vistaProductos.FormClosed += Vista_FormClosed;
                vistaProductos.Show();
            }
            else
            {
                vistaProductos.Activate();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (vistaFacturas == null)
            {
                vistaFacturas = new FacturaView();
                vistaFacturas.MdiParent = this;
                vistaFacturas.FormClosed += Vista_FormClosed;
                vistaFacturas.Show();
            }
            else
            {
                vistaFacturas.Activate();
            }
        }
    }
}
