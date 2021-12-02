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
            vista.Load += new EventHandler(Load);
            vista.Modificarbutton.Click += new EventHandler(Modificar);
            vista.Eliminarbutton.Click += new EventHandler(Eliminar);
            vista.Cancelarbutton.Click += new EventHandler(Cancelar);
        }

        private void Cancelar(object sender, EventArgs e)
        {
            DesabilitarControles();
            LimpiarControles();
            producto = null;
        }

        private void Eliminar(object sender, EventArgs e)
        {
            if (vista.ProductosdataGridView.SelectedRows.Count > 0)
            {
                bool elimino = productoDAO.EliminarProducto(Convert.ToInt32(vista.ProductosdataGridView.CurrentRow.Cells["ID"].Value));
                if (elimino)
                {

                    MessageBox.Show("Producto Eliminado Exitosamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarProductos();
                }
                else
                {
                    MessageBox.Show("No se Pudo Eliminar el Producto", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Modificar(object sender, EventArgs e)
        {
            if (vista.ProductosdataGridView.SelectedRows.Count > 0)
            {
                operacion = "Modificar";
                HabilitarControles();

                vista.IdtextBox.Text = vista.ProductosdataGridView.CurrentRow.Cells["ID"].Value.ToString();
                vista.CodigotextBox.Text = vista.ProductosdataGridView.CurrentRow.Cells["CODIGO"].Value.ToString();
                vista.DetalletextBox.Text = vista.ProductosdataGridView.CurrentRow.Cells["DETALLE"].Value.ToString();
                vista.StocktextBox.Text = vista.ProductosdataGridView.CurrentRow.Cells["STOCK"].Value.ToString();
                vista.PreciotextBox.Text = vista.ProductosdataGridView.CurrentRow.Cells["PRECIO"].Value.ToString();
                vista.Productolabel.Text = vista.ProductosdataGridView.CurrentRow.Cells["TIPOPRODUCTO"].Value.ToString();
                vista.ProveedortextBox.Text = vista.ProductosdataGridView.CurrentRow.Cells["PROVEEDOR"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Registro");
            }


        }

        private void Load(object sender, EventArgs e)
        {
            ListarProductos();
        }

        private void ListarProductos()
        {
            vista.ProductosdataGridView.DataSource = productoDAO.GetProductos();
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
                        DesabilitarControles();
                        LimpiarControles();
                        MessageBox.Show("Producto Insertado Exitosamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarProductos();

                    }
                    else
                    {
                        MessageBox.Show("No se pudo insertar el Producto", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else if (operacion == "Modificar")
                {
                    producto.Id = Convert.ToInt32(vista.IdtextBox.Text);
                    bool modifico = productoDAO.ActualizarProductos(producto);
                    if (modifico)
                    {
                        DesabilitarControles();
                        LimpiarControles();
                        MessageBox.Show("Producto Modificado Exitosamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarProductos();
                    }
                    else
                    {
                        MessageBox.Show("No se Pudo Modificar el Producto", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void DesabilitarControles()
        {
            vista.IdtextBox.Enabled = false;
            vista.CodigotextBox.Enabled = false;
            vista.DetalletextBox.Enabled = false;
            vista.StocktextBox.Enabled = false;
            vista.PreciotextBox.Enabled = false;
            vista.ProductocomboBox.Enabled = false;
            vista.ProveedortextBox.Enabled = false;

            vista.Guardarbutton.Enabled = false;
            vista.Cancelarbutton.Enabled = false;
            vista.Modificarbutton.Enabled = true;
            vista.Nuevobutton.Enabled = true;
        }

        private void LimpiarControles()
        {
            vista.IdtextBox.Clear();
            vista.CodigotextBox.Clear();
            vista.DetalletextBox.Clear();
            vista.StocktextBox.Clear();
            vista.PreciotextBox.Clear();
            vista.ProductocomboBox.Text = "";
            vista.Productolabel.Text = "";
            vista.ProveedortextBox.Clear();


        }

    }
}
