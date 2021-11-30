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
    public class ProductoController
    {
        ProductosView vista;
        string operacion = string.Empty;
        ProductoDAO productoDAO = new ProductoDAO();
        Producto producto = new Producto();

        public ProductoController(ProductosView view)
        {
            vista = view;
            vista.Nuevobutton.Click += new EventHandler(Nuevo);
            vista.Guardarbutton.Click += new EventHandler(Guardar);

        }

        private void Guardar(object sender, EventArgs e)
        {
            if (vista.CodigotextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.CodigotextBox, "Ingrese Codigo de Producto");
                vista.CodigotextBox.Focus();
                return;
            }
            if (vista.DetalletextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.DetalletextBox, "Ingrese Descripcion del Producto");
                vista.DetalletextBox.Focus();
                return;
            }
            if (vista.StocktextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.StocktextBox, "Ingrese Cantidad en Existencia");
                vista.StocktextBox.Focus();
                return;
            }
            if (vista.PreciotextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.PreciotextBox, "Ingrese Precio del Producto");
                vista.PreciotextBox.Focus();
                return;
            }
            if (vista.ProveedortextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.ProveedortextBox, "Ingrese Nombre del Proveedor");
                vista.ProveedortextBox.Focus();
                return;
            }
            try
            {
                producto.Codigo = vista.CodigotextBox.Text;
                producto.Detalle = vista.DetalletextBox.Text;
                producto.Stock = Convert.ToInt32(vista.StocktextBox.Text);
                producto.Precio = Convert.ToDecimal(vista.PreciotextBox.Text);
                producto.TipoProducto = vista.Productolabel.Text;
                producto.Proveedor = vista.ProveedortextBox.Text;

                if (operacion == "Nuevo")
                {
                    bool inserto = productoDAO.InsertarNuevoProducto(producto);

                    if (inserto)
                    {
                        
                        MessageBox.Show("Producto Insertado Exitosamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        

                    }
                    else
                    {
                        MessageBox.Show("No se pudo insertar el Producto", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }


            }
            catch (Exception)
            {
            }



        }

        private void Nuevo(object sender, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo";
        }


        private void HabilitarControles()
        {
            vista.IdtextBox.Enabled = true;
            vista.CodigotextBox.Enabled = true;
            vista.DetalletextBox.Enabled = true;
            vista.StocktextBox.Enabled = true;
            vista.PreciotextBox.Enabled = true;
            vista.ProductocomboBox.Enabled = true;
            vista.ProveedortextBox.Enabled = true;

            vista.Guardarbutton.Enabled = true;
            vista.Cancelarbutton.Enabled = true;
            vista.Modificarbutton.Enabled = false;
            vista.Nuevobutton.Enabled = false;
        }
    }
}
