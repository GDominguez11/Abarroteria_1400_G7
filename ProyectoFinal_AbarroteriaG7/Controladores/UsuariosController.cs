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
    public class UsuariosController
    {
        UsuariosView vista;
        string operacion = string.Empty;
        UsuarioDAO userDAO = new UsuarioDAO();
        Usuario user = new Usuario();

        public UsuariosController(UsuariosView view)
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
            user = null;
        }

        private void Eliminar(object serder, EventArgs e)
        {
            if (vista.UsuariosdataGridView.SelectedRows.Count > 0)
            {
                bool elimino = userDAO.EliminarUsuario(Convert.ToInt32(vista.UsuariosdataGridView.CurrentRow.Cells[0].Value.ToString()));

                if (elimino)
                {
                    DesabilitarControles();
                    LimpiarControles();

                    MessageBox.Show("Usuario Eliminado Exitosamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarUsuarios();
                }
            }
        }

        private void Nuevo(object serder, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo";
        }

        private void Modificar(object serder, EventArgs e)
        {
            operacion = "Modificar";
            if (vista.UsuariosdataGridView.SelectedRows.Count > 0)
            {
                vista.IdtextBox.Text = vista.UsuariosdataGridView.CurrentRow.Cells["ID"].Value.ToString();
                vista.NombretextBox.Text = vista.UsuariosdataGridView.CurrentRow.Cells["NOMBRE"].Value.ToString();
                vista.EmailtextBox.Text = vista.UsuariosdataGridView.CurrentRow.Cells["EMAIL"].Value.ToString();
                vista.AdministradorcheckBox.Checked = Convert.ToBoolean(vista.UsuariosdataGridView.CurrentRow.Cells["ESADMINISTRADOR"].Value);

                HabilitarControles();
            }
        }

        private void Load(object serder, EventArgs e)
        {
            ListarUsuarios();
        }

        private void Guardar(object serder, EventArgs e)
        {
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

            if (vista.ClavetextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.ClavetextBox, "Ingrese una clave");
                vista.ClavetextBox.Focus();
                return;
            }

            user.Nombre = vista.NombretextBox.Text;
            user.Email = vista.EmailtextBox.Text;
            user.Clave = vista.ClavetextBox.Text;
            user.EsAdministrador = vista.AdministradorcheckBox.Checked;

            if (operacion == "Nuevo")
            {
                bool inserto = userDAO.InsertarNuevoUsuario(user);

                if (inserto)
                {
                    DesabilitarControles();
                    LimpiarControles();

                    MessageBox.Show("Usuario Agregado Exitosamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarUsuarios();
                }
                else
                {
                    MessageBox.Show("No se pudo insertar el Usuario", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (operacion == "Modificar")
            {
                user.Id = Convert.ToInt32(vista.IdtextBox.Text);
                bool modifico = userDAO.ActualizarUsuario(user);
                if (modifico)
                {
                    DesabilitarControles();
                    LimpiarControles();

                    MessageBox.Show("Usuario Modificado Exitosamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarUsuarios();
                }
                else
                {
                    MessageBox.Show("No se pudo Modificar el Usuario", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }



            }





        }
        private void ListarUsuarios()
        {

            vista.UsuariosdataGridView.DataSource = userDAO.GetUsuarios();

        }

        private void LimpiarControles()
        {
            vista.IdtextBox.Clear();
            vista.NombretextBox.Clear();
            vista.EmailtextBox.Clear();
            vista.ClavetextBox.Clear();
            vista.AdministradorcheckBox.Enabled = false;
        }

        private void HabilitarControles()
        {
            vista.IdtextBox.Enabled = true;
            vista.NombretextBox.Enabled = true;
            vista.EmailtextBox.Enabled = true;
            vista.ClavetextBox.Enabled = true;
            vista.AdministradorcheckBox.Enabled = true;

            vista.Guardarbutton.Enabled = true;
            vista.Cancelarbutton.Enabled = true;
            vista.Modificarbutton.Enabled = false;
            vista.Nuevobutton.Enabled = false;
        }

        private void DesabilitarControles()
        {
            vista.IdtextBox.Enabled = false;
            vista.NombretextBox.Enabled = false;
            vista.EmailtextBox.Enabled = false;
            vista.ClavetextBox.Enabled = false;
            vista.AdministradorcheckBox.Enabled = false;

            vista.Guardarbutton.Enabled = false;
            vista.Cancelarbutton.Enabled = false;
            vista.Modificarbutton.Enabled = true;
            vista.Nuevobutton.Enabled = true;
        }





    }

}
