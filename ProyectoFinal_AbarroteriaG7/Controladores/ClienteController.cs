using ProyectoFinal_AbarroteriaG7.Modelos.DAO;
using ProyectoFinal_AbarroteriaG7.Modelos.Entidades;
using ProyectoFinal_AbarroteriaG7.Vistas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_AbarroteriaG7.Controladores
{
    public class ClienteController
    {
        ClientesView vista;
        ClienteDAO clienteDAO = new ClienteDAO();
        Cliente cliente = new Cliente();
        string operacion = string.Empty;

        public ClienteController(ClientesView view)
        {

            vista = view;
            vista.Nuevobutton.Click += new EventHandler(Nuevo);
            vista.Guardarbutton.Click += new EventHandler(Guardar);
            vista.Imagenbutton.Click += new EventHandler(Imagen);
            vista.Modificarbutton.Click += new EventHandler(Modificar);
            vista.Load += new EventHandler(Load);
            vista.Eliminarbutton.Click += new EventHandler(Eliminar);
            vista.Cancelarbutton.Click += new EventHandler(Cancelar);

        }

        private void Cancelar(object sender, EventArgs e)
        {
            DesabilitarControles();
            LimpiarControles();
            cliente = null;
        }

        private void Eliminar(object sender, EventArgs e)
        {
            if (vista.ClientesdataGridView.SelectedRows.Count > 0)
            {
                bool elimino = clienteDAO.EliminarCliente(Convert.ToInt32(vista.ClientesdataGridView.CurrentRow.Cells["ID"].Value));

                if (elimino)
                {

                    MessageBox.Show("Cliente Eliminado exitosamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ListarClientes();
                }
                else
                {
                    MessageBox.Show("Cliente no se pudo Eliminar", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Load(object sender, EventArgs e)
        {
            ListarClientes();
        }

        private void ListarClientes()
        {
            vista.ClientesdataGridView.DataSource = clienteDAO.GetClientes();
        }

        private void Modificar(object sender, EventArgs e)
        {
            if (vista.ClientesdataGridView.SelectedRows.Count > 0)
            {
                operacion = "Modificar";
                HabilitarControles();

                vista.IdtextBox.Text = vista.ClientesdataGridView.CurrentRow.Cells["ID"].Value.ToString();
                vista.IdentidadMaskedTextBox.Text = vista.ClientesdataGridView.CurrentRow.Cells["IDENTIDAD"].Value.ToString();
                vista.NombretextBox.Text = vista.ClientesdataGridView.CurrentRow.Cells["NOMBRE"].Value.ToString();
                vista.EmailtextBox.Text = vista.ClientesdataGridView.CurrentRow.Cells["EMAIL"].Value.ToString();
                vista.DirecciontextBox.Text = vista.ClientesdataGridView.CurrentRow.Cells["DIRECCION"].Value.ToString();
                vista.TelefonotextBox.Text = vista.ClientesdataGridView.CurrentRow.Cells["TELEFONO"].Value.ToString();

                byte[] img = clienteDAO.SeleccionarImagenCliente(Convert.ToInt32(vista.ClientesdataGridView.CurrentRow.Cells["ID"].Value));

                if (img.Length > 0)
                {
                    MemoryStream ms = new MemoryStream(img);
                    vista.ImagenpictureBox.Image = Bitmap.FromStream(ms);
                }

            }
            else
            {
                MessageBox.Show("Debe Seleccionar un Registro");
            }




        }

        private void Imagen(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog(); //para permitir que el usuario busque la imagen en el pc se hace lo siguiente
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                vista.ImagenpictureBox.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void Nuevo(object sender, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo";
        }

        private void Guardar(object sender, EventArgs e)
        {
            if (vista.IdentidadMaskedTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.IdentidadMaskedTextBox, "Ingrese una Identidad");
                vista.IdentidadMaskedTextBox.Focus();
                return;
            }
            if (vista.NombretextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.NombretextBox, "Ingrese un Nombre");
                vista.NombretextBox.Focus();
                return;
            }
            if (vista.EmailtextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.EmailtextBox, "Ingrese un Email");
                vista.EmailtextBox.Focus();
                return;
            }
            if (vista.DirecciontextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.DirecciontextBox, "Ingrese una Direccion");
                vista.DirecciontextBox.Focus();
                return;
            }
            if (vista.TelefonotextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.TelefonotextBox, "Ingrese un Numero de Telefono");
                vista.TelefonotextBox.Focus();
                return;
            }
            try
            {
                cliente.Identidad = vista.IdentidadMaskedTextBox.Text;
                cliente.Nombre = vista.NombretextBox.Text.ToUpper();
                cliente.Email = vista.EmailtextBox.Text;
                cliente.Direccion = vista.DirecciontextBox.Text;
                cliente.Telefono = vista.TelefonotextBox.Text;

                if (vista.ImagenpictureBox.Image != null)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(); //Permite capturar o almacenar temporalmente la imagen
                    vista.ImagenpictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    cliente.Foto = ms.GetBuffer();
                }



                if (operacion == "Nuevo")
                {

                    bool inserto = clienteDAO.InsertarNuevoCliente(cliente);
                    if (inserto)
                    {
                        DesabilitarControles();
                        LimpiarControles();
                        MessageBox.Show("Cliente creado exitosamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ListarClientes();
                    }
                    else
                    {
                        MessageBox.Show("Cliente no se pudo insertar", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (operacion == "Modificar")
                {
                    cliente.Id = Convert.ToInt32(vista.IdtextBox.Text);
                    bool modifico = clienteDAO.ActualizarCliente(cliente);
                    if (modifico)
                    {
                        DesabilitarControles();
                        LimpiarControles();
                        MessageBox.Show("Cliente Modificado exitosamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ListarClientes();
                    }
                    else
                    {
                        MessageBox.Show("Cliente no se pudo Modificar", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }




                }

            }
            catch (Exception)
            {
            }

        }


        private void HabilitarControles()
        {
            vista.IdentidadMaskedTextBox.Enabled = true;
            vista.NombretextBox.Enabled = true;
            vista.DirecciontextBox.Enabled = true;
            vista.TelefonotextBox.Enabled = true;
            vista.EmailtextBox.Enabled = true;


            vista.Guardarbutton.Enabled = true;
            vista.Cancelarbutton.Enabled = true;
            vista.Imagenbutton.Enabled = true;
            vista.Modificarbutton.Enabled = false;
            vista.Nuevobutton.Enabled = false;




        }

        private void DesabilitarControles()
        {
            vista.IdentidadMaskedTextBox.Enabled = false;
            vista.NombretextBox.Enabled = false;
            vista.DirecciontextBox.Enabled = false;
            vista.TelefonotextBox.Enabled = false;
            vista.EmailtextBox.Enabled = false;


            vista.Guardarbutton.Enabled = false;
            vista.Cancelarbutton.Enabled = false;
            vista.Imagenbutton.Enabled = false;
            vista.Modificarbutton.Enabled = true;
            vista.Nuevobutton.Enabled = true;




        }

        private void LimpiarControles()
        {
            vista.IdtextBox.Clear();
            vista.IdentidadMaskedTextBox.Clear();
            vista.NombretextBox.Clear();
            vista.DirecciontextBox.Clear();
            vista.TelefonotextBox.Clear();
            vista.EmailtextBox.Clear();
            vista.ImagenpictureBox.Image = null;
        }

    }
}
