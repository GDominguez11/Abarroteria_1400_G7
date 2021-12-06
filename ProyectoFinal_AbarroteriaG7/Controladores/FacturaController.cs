using ProyectoFinal_AbarroteriaG7.Modelos.DAO;
using ProyectoFinal_AbarroteriaG7.Modelos.Entidades;
using ProyectoFinal_AbarroteriaG7.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_AbarroteriaG7.Controladores
{
    public class FacturaController
    {
        FacturaView vista;
        FacturaDAO facturaDAO = new FacturaDAO();
        FacturaDAO factura = new FacturaDAO();
        UsuarioDAO usuarioDAO = new UsuarioDAO();
        Cliente cliente = new Cliente();
        ClienteDAO clienteDAO = new ClienteDAO();
        ProductoDAO productoDAO = new ProductoDAO();
        Producto producto = new Producto();
        public string _EmailUsuario;

        List<DetalleFactura> detalleFacturas = new List<DetalleFactura>();
        decimal subtotal = 0;
        decimal isv = 0;
        decimal totalPagar = 0;

        public FacturaController(FacturaView view)
        {
            vista = view;
            vista.Load += new EventHandler(Load);
            vista.IdentidadmaskedTextBox.KeyPress += IdentidadmaskedTextBox_KeyPress;
            vista.BuscarClientebutton.Click += new EventHandler(BuscarCliente);
            vista.CodigotextBox.KeyPress += CodigotextBox_KeyPress;
            vista.CantidadtextBox.KeyPress += CantidadtextBox_KeyPress;
        }

        private void CantidadtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && string.IsNullOrEmpty(vista.CantidadtextBox.Text))
            {
                DetalleFactura detalleFactura = new DetalleFactura();
                detalleFactura.IdProducto = producto.Id;
                detalleFactura.Cantidad = Convert.ToInt32(vista.CantidadtextBox.Text);
                detalleFactura.Precio = producto.Precio;
                detalleFactura.Total = Convert.ToDecimal(Convert.ToInt32(vista.CantidadtextBox.Text) * producto.Precio);

                subtotal += detalleFactura.Total;
                isv = subtotal * 0.15M; //la M es para que no lo detecte el 0.15 como double sino como decimal
                totalPagar = subtotal + isv;

                vista.SubtotaltextBox.Text = subtotal.ToString("N2");
                vista.ImpuestotextBox.Text = isv.ToString("N2");
                vista.TotaltextBox.Text = totalPagar.ToString("N2");

            }
        }

        private void CodigotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                producto = productoDAO.GetProductoPorCodigo(vista.CodigotextBox.Text);

                vista.DetalletextBox.Text = producto.Detalle;
            }
            else
            {
                producto = null;
                vista.DetalletextBox.Clear();
            }
        }

        private void BuscarCliente(object sender, EventArgs e)
        {
            BuscarClienteView form = new BuscarClienteView();
            form.ShowDialog(); //permite mostrar el formulario en forma de cuadro de dialogo
            cliente = form._cliente;
            vista.IdentidadmaskedTextBox.Text = cliente.Identidad;
            vista.NombretextBox.Text = cliente.Nombre;
        }

        private void IdentidadmaskedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cliente = clienteDAO.GetClientePorIdentidad(vista.IdentidadmaskedTextBox.Text);

                vista.NombretextBox.Text = cliente.Nombre;
            }
            else
            {
                cliente = null;
                vista.NombretextBox.Clear();
            }
        }

        private void Load(object sender, EventArgs e)
        {
            vista.UsuariotextBox.Text = usuarioDAO.GetNombreUsuarios(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
    }
}
