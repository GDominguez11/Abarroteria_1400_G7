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
        }
    }
}
