using ProyectoFinal_AbarroteriaG7.Modelos.DAO;
using ProyectoFinal_AbarroteriaG7.Modelos.Entidades;
using ProyectoFinal_AbarroteriaG7.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_AbarroteriaG7.Controladores
{
    public class LoginController
    {
        LoginView vista;

        public LoginController(LoginView view)
        {
            vista = view;

            vista.Aceptarbutton.Click += new EventHandler(ValidarUsuario);
            
        }

        private void ValidarUsuario(object serder, EventArgs e)
        {
            bool esValido = false;

            UsuarioDAO userDao = new UsuarioDAO();

            Usuario user = new Usuario();

            user.Email = vista.EmailtextBox.Text; //para Acceder a controles como textbox o botones de otro sitio, se tiene que activar la propiedad modifiers en los controles y ponerla publico
            user.Clave = EncriptarClave(vista.ClavetextBox.Text);

            esValido = userDao.ValidarUsuario(user);

            if (esValido)
            {
                // MessageBox.Show("Usuario Correcto");
                MenuView menu = new MenuView();

                vista.Hide();
                System.Security.Principal.GenericIdentity identidad = new System.Security.Principal.GenericIdentity(vista.EmailtextBox.Text);
                System.Security.Principal.GenericPrincipal principal = new System.Security.Principal.GenericPrincipal(identidad, null);
                System.Threading.Thread.CurrentPrincipal = principal;

                menu.Show();
            }
            else
            {
                MessageBox.Show("Usuario Incorrecto");
            }




        }
        public static string EncriptarClave(string str) //Funcion para encriptar contraseña en la BD
        {
            string cadena = str + "MiClavePersonal";
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(cadena));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
